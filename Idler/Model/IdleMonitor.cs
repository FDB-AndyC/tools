namespace Idler.Model
{
    using System;
    using System.Timers;

    public interface IIdleMonitor
    {
        ulong Total { get; }

        void Start();

        void Stop();

        void Reset();
    }

    public class IdleMonitor : IIdleMonitor
    {
        private const int TimerInterval = 251;

        private readonly IIdlingReporter reporter;

        private readonly Timer timer;

        private uint cachedIdleTime;

        private ulong totalIdleTime = 0;

        public IdleMonitor(IIdlingReporter reporter)
        {
            this.reporter = reporter;
            this.timer = new Timer(TimerInterval);
            this.timer.Elapsed += this.OnTimerElapsed;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var newIdleTime = this.reporter.GetIdleTime();
            if (newIdleTime < this.cachedIdleTime)
            {
                this.totalIdleTime += this.cachedIdleTime;
            }

            this.cachedIdleTime = newIdleTime;
        }

        public ulong Total => this.totalIdleTime;

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        public void Reset()
        {
            if (this.timer.Enabled)
            {
                throw new InvalidOperationException();
            }

            this.cachedIdleTime = 0;
            this.totalIdleTime = 0;
        }
    }
}
