using NLog;

namespace GameSrv.World.Threads
{
    public class UserProcessor : TimerScheduledService
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public UserProcessor() : base(TimeSpan.FromMilliseconds(50), "UserProcessor")
        {

        }

        protected override Task ExecuteInternal(CancellationToken stoppingToken)
        {
            try
            {
                M2Share.WorldEngine.ProcessHumans();
            }
            catch (Exception ex)
            {
                M2Share.Logger.Error("[�쳣] UserProcessor::OnElapseAsync error");
                M2Share.Logger.Error(ex);
            }
            return Task.CompletedTask;
        }

        protected override void Startup(CancellationToken stoppingToken)
        {
            _logger.Info("玩家管理线程初始化完成...");
        }

        protected override void Stopping(CancellationToken stoppingToken)
        {
            _logger.Info("玩家管理线程停止ֹ...");
        }
    }
}