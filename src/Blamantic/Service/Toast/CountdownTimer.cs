using System;
using System.Timers;

namespace BlamanticUI
{
    /// <summary>
    /// 表示倒计时计数器。
    /// </summary>
    internal class CountdownTimer
    {
        private Timer _timer;
        private int _timeout;
        private int _countdownTotal;
        private int _percentComplete;

        internal Action<int> OnTick;
        internal Action OnElapsed;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountdownTimer"/> class.
        /// </summary>
        /// <param name="timeout">持续时间。</param>
        public CountdownTimer(int timeout)
        {
            _countdownTotal = timeout;
            _timeout = (_countdownTotal * 1000) / 100;
            _percentComplete = 0;
            SetupTimer();
        }

        /// <summary>
        /// 启动计时器。
        /// </summary>
        internal void Start()
        {
            _timer.Start();
        }

        /// <summary>
        /// 设置计时器的配置。
        /// </summary>
        private void SetupTimer()
        {
            _timer = new Timer(_timeout);
            _timer.Elapsed += HandleTick;
            _timer.AutoReset = false;
        }

        /// <summary>
        /// 处理计时器每秒的工作。
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void HandleTick(object sender, ElapsedEventArgs args)
        {
            _percentComplete++;
            OnTick?.Invoke(_percentComplete);

            if (_percentComplete == 100)
            {
                OnElapsed?.Invoke();
            }
            else
            {
                SetupTimer();
                Start();
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            _timer.Dispose();
            _timer = null;
        }
    }
}
