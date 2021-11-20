using Common.Model;
using Prism.Commands;
using SmartHome.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace SmartHome.ViewModels
{
    public class ElectronicEventListViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Button> ChangeToAddElectronicCommand { get; set; }
        public DelegateCommand<Button> DeleteEventCommand { get; set; }

        public ConfigurePanelViewModel _configurePanelViewModel;

        private List<Electronics> _electronicEvents;
        public List<Electronics> ElectronicEvents
        {
            get => _electronicEvents;
            set
            {
                _electronicEvents = value;
                NotifyChange(nameof(ElectronicEvents));
            }
        } 

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ElectronicEventListViewModel()
        {
            ChangeToAddElectronicCommand = new DelegateCommand<Button>(OnChangeToAddElectronic);
            DeleteEventCommand = new DelegateCommand<Button>(OnDeleteEvent);
            _configurePanelViewModel = ConfigurePanelViewModel.ActuallyShownConfigurePanel;

            var _extFacts = ExtFactDataProvider.Get().ToList()[0];
            ElectronicEvents = new List<Electronics>();

            foreach (var RadioEvent in _extFacts.Radio)
            {
                ElectronicEvents.Add(new Electronics
                {
                    EventName = RadioEvent.EventName,
                    EventTime = RadioEvent.EventTime,
                    Continous = RadioEvent.Continous,
                    Type = "Rádió"
                });
            }

            foreach (var TVEvent in _extFacts.TV)
            {
                ElectronicEvents.Add(new Electronics
                {
                    EventName = TVEvent.EventName,
                    EventTime = TVEvent.EventTime,
                    Continous = TVEvent.Continous,
                    Type = "TV"
                });
            }
        }

        public void OnChangeToAddElectronic(Button btn)
        {
            _configurePanelViewModel.ExecuteChangeToElectronicPanel(false);
        }

        public void OnDeleteEvent(Button btn)
        {

        } 
    }
}