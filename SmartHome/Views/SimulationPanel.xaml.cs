using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartHome.Views
{
    /// <summary>
    /// Interaction logic for SimulationPanel.xaml
    /// </summary>
    /// 

    


    public partial class SimulationPanel : UserControl
    {
        private int asd = 0;
        public SimulationPanel()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            

        }
        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            asd++;
        }
    }
            
}

