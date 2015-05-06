using Quartz;
using Quartz.Impl;
using System.ServiceProcess;
using log4net;

namespace AiWeiBang.SearchEngine.Jobs
{
    partial class MainJobService : ServiceBase
    {
        private readonly static ILog Log = LogManager.GetLogger(typeof(MainJobService));

        private IScheduler _scheduler;
        public MainJobService()
        {
            Log.Info(".ctor");
            InitializeComponent();
        }

        public void Start()
        {
            Log.Info("start");
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            Log.Info("OnStart");
            ISchedulerFactory factory = new StdSchedulerFactory();
            _scheduler = factory.GetScheduler();
            _scheduler.Start();
        }

        protected override void OnStop()
        {
            Log.Info("OnStop");
            if (_scheduler != null && !_scheduler.IsShutdown)
            {
                _scheduler.Shutdown();
            }
        }
    }
}
