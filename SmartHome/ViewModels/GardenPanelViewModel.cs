using Common.Model;
using SmartHome.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SmartHome.ViewModels
{
    public class GardenPanelViewModel : INotifyPropertyChanged
    {
        private ExternalFactors _actualExternalFactors;

        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public GardenPanelViewModel()
        {
            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
