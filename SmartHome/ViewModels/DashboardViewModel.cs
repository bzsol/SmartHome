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
        public string insideTemp = "20";
        public static int time = -60;
        public static string forecast = string.Empty;
        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public string temp;
        public static double tempValue;
        public DelegateCommand<Button> ChangeToSimulation { get; set; }
        public DelegateCommand<Button> ChangeToConfiguration { get; set; }

        public DelegateCommand<Button> ResetTime { get; set; }

        public DelegateCommand<Button> StopTime { get; set; }

        private ExternalFactors _actualExternalFactors;

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

        private bool _viewIsOnSimulation;
        public bool ViewIsOnSimulation
        {
            get => _viewIsOnSimulation;
            set
            {
                _viewIsOnSimulation = value;
                NotifyChange(nameof(ViewIsOnSimulation));
            }
        }
        private string _forecast;
        public string Forecast
        {
            get => _forecast;
            set
            {
                _forecast = value;
                NotifyChange(nameof(Forecast));
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
                    new Lights(), new Lights(), new Lights(), new Lights(), new Lights(), new Lights(), new Lights(), new Lights(), new Lights(),
                    new Lights(), new Lights(), new Lights(), new Irrigative(), new Irrigative(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading(), new Shading()));
            }
            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            TimeChange = "Start/Stop";
        }


        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (time < 86400)
            {
                time = time + 60;
            }
            else
            {
                time = 0;
            }

            if (time % (3600 * 3) == 0 || time == 60) {
                forecast = TemperatureDataProvider.GenerateForecast(forecast);
            }
            tempValue = TemperatureDataProvider.GenerateTemp(time / 60);
            temp = tempValue.ToString("N2");
            insideTemp = TemperatureDataProvider.CalculateInsideTemp(double.Parse(insideTemp), double.Parse(temp), ExtFactDataProvider.Get().ToList()[0]).ToString("N2");
            TempChange = $"{temp}°C";
            InsideTemp = $"{insideTemp}°C";
            TimeChange = ToolKit.SecToMilitaryTime(time);
            Forecast = forecast;
        }

        private void Reset(Button btn) 
        {
            time = -60;
            insideTemp = "20";
            TimeChange = "0:00:00";
        }

        private void Stop(Button btn) {
            if (dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Stop();
                if (SimulationCategoryPanelViewModel.IsSimulation)
                {
                    SimulationPanelViewModel.dispatcherTimer.Stop();
                }
                else
                {
                    GardenPanelViewModel.dispatcherTimer.Stop();
                }
            }
            else 
            {
                dispatcherTimer.Start();
                if (SimulationCategoryPanelViewModel.IsSimulation)
                {
                    SimulationPanelViewModel.dispatcherTimer.Start();
                }
                else
                {
                    GardenPanelViewModel.dispatcherTimer.Start();
                }
            }
        }

        public void OnChangeToSimulation(Button btn)
        {
            UserControlViewModel = new SimulationCategoryPanelViewModel();
            ViewIsOnSimulation = true;
        }

        public void OnChangeToConfiguration(Button btn)
        {
            UserControlViewModel = new ConfigurePanelViewModel();
            if (dispatcherTimer.IsEnabled)
            {
                Stop(null);
            }
            ViewIsOnSimulation = false;
        }
    }
}
