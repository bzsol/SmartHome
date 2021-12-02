using Common.Model;
using Common.Tool;
using Prism.Commands;
using SmartHome.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace SmartHome.ViewModels
{
    public class SimulationPanelViewModel : INotifyPropertyChanged
    {
        private ExternalFactors _actualExternalFactors;

        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private Brush _TVColor;
        public Brush TVColor
        {
            get => _TVColor;
            set
            {
                _TVColor = value;
                NotifyChange(nameof(TVColor));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public SimulationPanelViewModel()
        {
            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
            TVColor = Brushes.Black;

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            CheckElectronics();
        }

        public void CheckElectronics()
        {
            foreach (var ev in _actualExternalFactors.ElectronicEvents)
            {
                if (ev.EventTime.ToLongTimeString().Equals(ToolKit.SecToMilitaryTime(DashboardViewModel.time)))
                {
                    if (ev.Type.Equals("TV"))
                    {
                        TVColor = Brushes.White;
                    }
                }
            }
        }
    }
}
