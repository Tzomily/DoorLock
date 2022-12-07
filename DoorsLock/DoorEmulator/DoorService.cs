using MassTransit;
using MassTransit.Util;
using Topshelf;

namespace DoorEmulator;

public class DoorService : ServiceControl
{
    IBusControl _busControl;
    public bool Start(HostControl hostControl)
    {
        _busControl = Bus.Factory.CreateUsingRabbitMq(cnf =>
        {
            cnf.Host(new Uri("rabbitmq://localhost/"), h =>
            {
                h.Username("user");
                h.Password("password");
            });

            cnf.ReceiveEndpoint("DoorService",
                e =>
                {
                    e.Handler<OpenDoorCommand>(
                    context =>
                    {
                        // to do add door id to context
                        Console.WriteLine("Open Door {0}", context.Message.DoorId);
                        return context.RespondAsync<DoorOpened>(new
                        {
                            context.Message.DoorId
                        });
                    });
                });
        });
        Console.WriteLine("Door is ready");

        TaskUtil.Await(() => _busControl.StartAsync());

        return true;
    }

    public bool Stop(HostControl hostControl)
    {
        _busControl?.Stop();

        return true;
    }
}

