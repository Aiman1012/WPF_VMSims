using System;
using System.Text;
using System.Windows;
using Microsoft.VisualBasic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_VMSims
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TimeSpan? timerDuration = null;
        public MainWindow()
        {
            InitializeComponent();

            if (MachineState.LastRunDuration.TotalSeconds > 0)
            {
                lastSessionText.Text = $"Last Session Duration: {MachineState.LastRunDuration:hh\\:mm\\:ss}";
            }
        }
        private void StartManual_Click(object sender, RoutedEventArgs e)
        {
            MachinePage machinePage = new MachinePage(null);
            machinePage.Show();
            this.Close();
        }

        private void SetTimer_Click(object sender, RoutedEventArgs e)
        {
            string input = Interaction.InputBox("Enter run time in seconds:", "Set Timer", "60");
            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                timerDuration = TimeSpan.FromSeconds(seconds);
                MessageBox.Show($"Timer set: {timerDuration.Value:hh\\:mm\\:ss}");

                MachinePage machinePage = new MachinePage(timerDuration);
                machinePage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid time entered.");
            }
        }

    }
}