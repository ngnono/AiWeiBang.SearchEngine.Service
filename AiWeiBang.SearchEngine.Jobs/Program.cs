using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AiWeiBang.SearchEngine.Jobs
{
    class Program
    {
        static void Main(string[] args)
        {
            //log4net configs
            log4net.Config.XmlConfigurator.Configure();
            AiWeiBang.SearchEngine.Jobs.Cores.Bootstart.Boot.Init();

#if DEBUG
            new MainJobService().Start();
#else
            if (args.Length > 0)
            {
                new MainJobService().Start();
            }
            else
            {

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new MainJobService()
                };
                ServiceBase.Run(ServicesToRun);
            }
#endif




        }
    }
}
