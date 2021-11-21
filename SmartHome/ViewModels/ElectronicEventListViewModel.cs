using Common.Model;
using Prism.Commands;
using SmartHome.DataProvider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SmartHome.ViewModels
{
    public class ElectronicEventListViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Button> ChangeToAddElectronicCommand { get; set; }
        public DelegateCommand<Button> DeleteEventCommand { get; set; }

        private ConfigurePanelViewModel _configurePanelViewModel;

        private ExternalFactors _actualExternalFactors;

        private ObservableCollection<Electronics> _electronicEvents;
        public ObservableCollection<Electronics> ElectronicEvents
        {
            get => _electronicEvents;
            set
            {
                _electronicEvents = value;
                NotifyChange(nameof(ElectronicEvents));
            }
        }

        private Electronics _selectedElectronicEvent;
        public Electronics SelectedElectronicEvent
        {
            get => _selectedElectronicEvent;
            set
            {
                _selectedElectronicEvent = value;
                NotifyChange(nameof(SelectedElectronicEvent));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ElectronicEventListViewModel()
        {
            ChangeToAddElectronicCommand = new DelegateCommand<Button>(OnChangeToAddElectronic);
            DeleteEventCommand = new DelegateCommand<Button>(OnDeleteEvent);
            _configurePanelViewModel = ConfigurePanelViewModel.ActuallyShownConfigurePanel;

            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
            ElectronicEvents = new ObservableCollection<Electronics>();

            foreach (var ElectronicEvent in _actualExternalFactors.ElectronicEvents)
            {
                ElectronicEvents.Add(new Electronics
                {
                    EventName = ElectronicEvent.EventName,
                    EventTime = ElectronicEvent.EventTime,
                    Continous = ElectronicEvent.Continous,
                    Type = ElectronicEvent.Type
                });
            }
        }

        public void OnChangeToAddElectronic(Button btn)
        {
            _configurePanelViewModel.ExecuteChangeToElectronicPanel(false);
        }

        public void OnDeleteEvent(Button btn)
        {
            if (SelectedElectronicEvent != null)
            {
                Electronics itemToDelete;
                if (SelectedElectronicEvent.Type.Equals("Rádió"))
                {
                    itemToDelete = ElectronicEvents.FirstOrDefault(x => x.EventName == SelectedElectronicEvent.EventName);
                }
                else
                {
                    itemToDelete = ElectronicEvents.FirstOrDefault(x => x.EventName == SelectedElectronicEvent.EventName);
                }

                ElectronicEvents.Remove(itemToDelete);
                _actualExternalFactors.ElectronicEvents = ElectronicEvents.ToList();
                ExtFactDataProvider.Update(_actualExternalFactors);
            }
        } 
    }
}