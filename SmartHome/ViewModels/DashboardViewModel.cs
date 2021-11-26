using Common.Class;
using Common.Model;
using Common.Tool;
using Prism.Commands;
using SmartHome.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SmartHome.ViewModels
{

    public class DashboardViewModel : INotifyPropertyChanged
    {
        public int time = 0;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        string temp;
        string insidetemp = "20";
        string light;
        public DelegateCommand<Button> ChangeToSimulation { get; set; }
        public DelegateCommand<Button> ChangeToConfiguration { get; set; }

        public DelegateCommand<Button> ResetTime { get; set; }

        public DelegateCommand<Button> StopTime { get; set; }

        private object _userControlViewModel;
        public object UserControlViewModel
        {
            get => _userControlViewModel;
            set
            {
                _userControlViewModel = value;
                NotifyChange(nameof(UserControlViewModel));
            }
        }

        private string _timechange;
        public string TimeChange {
            get => _timechange;
            set {
                _timechange = value;
                NotifyChange(nameof(TimeChange));
            }
        }
        private string _tempchange;
        public string TempChange {
            get => _tempchange;
            set {
                _tempchange = value;
                NotifyChange(nameof(TempChange));
            }
            
        }
        private string _insidetemp;
        public string InsideTemp
        {
            get => _insidetemp;
            set
            {
                _insidetemp = value;
                NotifyChange(nameof(InsideTemp));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public DashboardViewModel()
        {
            ChangeToSimulation = new DelegateCommand<Button>(OnChangeToSimulation);
            ChangeToConfiguration = new DelegateCommand<Button>(OnChangeToConfiguration);
            ResetTime = new DelegateCommand<Button>(Reset);
            StopTime = new DelegateCommand<Button>(Stop); 
            Thread.CurrentThread.CurrentCulture = new CultureInfo("hu-HU");
            if (((List<ExternalFactors>)ExtFactDataProvider.Get()).Count < 1)
            {
                // Generate new list without null
                ExtFactDataProvider.Create(new ExternalFactors(new List<Electronics>(), new Climate(), new Climate(), new Climate(), new Climate(), new Climate(), new Climate(), new Climate(), new Climate(), new Climate(), new Lights(), new Lights(), new Lights(),
                    new Lights(), new Lights(), new Lights(), new Lights(), new Lights(), new Lights(),
                    new Lights(), new Lights(), new Lights(), new Irrigative(), new Irrigative(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading()));
            }
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            TimeChange = "Start/Stop";
            insidetemp = "20";
        }


        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (time < 86400)
            {
                time = time + 60;
            }
            else {
                time = 0;
            }
            if (time % 3600 == 0 || time == 60) {
                temp = TemperatureDataProvider.GenerateTemp(time / 3600).ToString("N2");
                insidetemp = TemperatureDataProvider.CalculateInsideTemp(double.Parse(insidetemp), double.Parse(temp),23).ToString("N2");
            }
            TempChange = $"{temp}°C";
            InsideTemp = $"{insidetemp}°C";
            TimeChange = SecToMilitaryTime(time);
        }

        private string SecToMilitaryTime(int seconds) {
            return TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss");
        }

        private void Reset(Button btn) {
            time = 0;
            TimeChange = SecToMilitaryTime(time);
        }

        private void Stop(Button btn) {
            if (dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Stop();
            }
            else {
                dispatcherTimer.Start();
            }
        }

        public void OnChangeToSimulation(Button btn)
        {
            UserControlViewModel = new SimulationCategoryPanelViewModel();
        }

        public void OnChangeToConfiguration(Button btn)
        {
            UserControlViewModel = new ConfigurePanelViewModel();
        }
    }
}
