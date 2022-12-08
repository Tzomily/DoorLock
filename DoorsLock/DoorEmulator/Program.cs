using DoorEmulator;
using Topshelf;
using Topshelf.Logging;

namespace RequestService;

class Program
{
    static int Main(string[] args)
    {
        // Topshelf to use Log4Net
        Log4NetLogWriterFactory.Use();


        return (int)HostFactory.Run(x => x.Service<DoorService>());
    }
}
