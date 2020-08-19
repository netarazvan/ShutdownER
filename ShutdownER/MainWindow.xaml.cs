using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Management;

namespace ShutdownER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isStarted = false;
        string setTime;
        readonly Shutdown sd = new Shutdown();
        readonly Validator valid = new Validator();
        public MainWindow()
        {
            InitializeComponent();
            TimerSetup();
        }
        private void TimerSetup()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            TimeNow.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeNow.Text = DateTime.Now.ToString("HH:mm:ss");
            if (TimeNow.Text == setTime)
            {
                sd.Shut();
                //MessageBox.Show("Stingerea");
            }

        }
        
        private void StartDog(bool started)
        {
            if (started)
            {
                hour.IsEnabled = false;
                min.IsEnabled = false;
                sec.IsEnabled = false;
                toggle.Content = "Stop";
                setTime = hour.Text + ":" + min.Text + ":" + sec.Text;
            }
            if (!started)
            {
                hour.IsEnabled = true;
                min.IsEnabled = true;
                sec.IsEnabled = true;
                toggle.Content = "Start";
            }

        }

        private void toggle_Click(object sender, RoutedEventArgs e)
        {
            if (valid.Check(hour.Text,min.Text,sec.Text))
            {
                isStarted = !isStarted;
            }
            else { MessageBox.Show("Time not valid"); }
            StartDog(isStarted);
        }

    }
}
