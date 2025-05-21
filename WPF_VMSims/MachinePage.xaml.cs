using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_VMSims
{
    /// <summary>
    /// Interaction logic for MachinePage.xaml
    /// </summary>
    public partial class MachinePage : Window
    {
        private DispatcherTimer timer;
        private DateTime startTime;
        private TimeSpan? countdownTime;
        private TimeSpan originalCountdown;

        public MachinePage(TimeSpan? runTime)
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            if (runTime.HasValue)
            {
                countdownTime = runTime.Value;
                originalCountdown = runTime.Value;
                timerText.Text = $"Remaining Time: {countdownTime:hh\\:mm\\:ss}";
                statusText.Text = "Machine is RUNNING (Countdown)";
                Logger.Log("Machine started in TIMER mode");
            }
            else
            {
                startTime = DateTime.Now;
                statusText.Text = "Machine is RUNNING (Manual)";
                Logger.Log("Machine started in MANUAL mode");
            }

            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (countdownTime.HasValue)
            {
                if (countdownTime.Value.TotalSeconds <= 0)
                {
                    timer.Stop();
                    MachineState.LastRunDuration = countdownTime.HasValue ? originalCountdown - countdownTime.Value : TimeSpan.Zero;
                    MessageBox.Show("Timer finished. Machine stopped.");
                    Logger.Log("Machine stopped after timer finished");
                    new MainWindow().Show();
                    this.Close();
                }
                else
                {
                    timerText.Text = $"Remaining Time: {countdownTime:hh\\:mm\\:ss}";
                    countdownTime = countdownTime.Value.Subtract(TimeSpan.FromSeconds(1));
                }
            }
            else
            {
                TimeSpan elapsed = DateTime.Now - startTime;
                timerText.Text = $"Elapsed Time: {elapsed:hh\\:mm\\:ss}";

            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            if (countdownTime.HasValue)
            {
                TimeSpan duration = originalCountdown - countdownTime.Value;
                MachineState.LastRunDuration = duration;
                Logger.Log($"Machine forcefully stopped after {duration:hh\\:mm\\:ss}");
            }
            else
            {
                TimeSpan elapsed = DateTime.Now - startTime;
                MachineState.LastRunDuration = DateTime.Now - startTime;
                Logger.Log($"Machine manually stopped after {elapsed:hh\\:mm\\:ss}");
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
