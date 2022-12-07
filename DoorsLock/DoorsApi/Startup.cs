using DoorsApi.Abstractions.Repositories;
using DoorsApi.Abstractions.Services;
using DoorsApi.Contexts;
using DoorsApi.Repositories;
using DoorsApi.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace DoorsApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("DefaultConnection");

        services.AddSwaggerGen();


        services.AddDbContext<DoorsDbContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


        // add rabbitmq
        services.AddMvc();
        services.AddMassTransit(cnf => cnf.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("rabbitmq://localhost/", h =>
            {
                h.Username("user");
                h.Password("password");
            });

            cfg.ConfigureEndpoints(context);
        }));

        // Repositories
        services.AddScoped<IBuildingsRepository, BuildingsRepository>();
        services.AddScoped<IDoorsRepository, DoorsRepository>();
        services.AddScoped<IHistoryRepository, HistoryRepository>();
        services.AddScoped<IRolesRepository, RolesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        //Services
        services.AddScoped<IBuildingsService, BuildingsService>();
        services.AddScoped<IDoorsService, DoorsService>();
        services.AddScoped<IHistoryService, HistoryService>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<IUsersService, UsersService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swager/v1/swagger.json", "Door Api Service V1"));

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
