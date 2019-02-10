using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopshelfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(hostConfig =>
            {
                hostConfig.Service<MyWindowsService>(serviceConfig =>
                {
                    serviceConfig.ConstructUsing(() => new MyWindowsService());
                    serviceConfig.WhenStarted(s => s.Start());
                    serviceConfig.WhenStopped(s => s.Stop());
                   
                });
                hostConfig.SetDisplayName("Demo");
                hostConfig.SetServiceName("Demo");
                hostConfig.SetDescription("Demo service using topshelf.");
                hostConfig.RunAsLocalService();
                
            });
        }
    }
}
