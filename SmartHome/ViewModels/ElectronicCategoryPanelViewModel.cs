using Common.Model;
using Common.Tool;
using Prism.Commands;
using SmartHome.DataProvider;
using SmartHome.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SmartHome.ViewModels
{
    public class ElectronicCategoryPanelViewModel
    {
        public DelegateCommand<Button> AddEventCommand { get; set; }

        public DelegateCommand<Button> ChangeToEventListCommand { get; set; }

        private ConfigurePanelViewModel _configurePanelViewModel;

        private ExternalFactors _actualExternalFactors;

        private string _nameTextBoxText;

        private DateTime _dateTimePicker = DateTime.Now;

        private bool _EE;

        private bool _VE;

        private bool _TV;

        private bool _Radio;

        public bool EventOnce
        {
            get => _EE;
            set
            {
                _EE = value;
                NotifyChange(nameof(EventOnce));
            }
        }

        public bool EventCont
        {
            get => _VE;
            set
            {
                _VE = value;
                NotifyChange(nameof(EventCont));
            }
        }

        public string EventNameTextBoxText
        {
            get => _nameTextBoxText;
            set
            {
                _nameTextBoxText = value;
                NotifyChange(nameof(EventNameTextBoxText));
            }

        }

        public DateTime EventDatePickerDate
        {
            get => _dateTimePicker;
            set
            {
                _dateTimePicker = value;
                NotifyChange(nameof(EventDatePickerDate));
            }

        }

        public bool TV
        {
            get => _TV;
            set
            {
                _TV = value;
                NotifyChange(nameof(TV));
            }
        }

        public bool Radio
        {
            get => _Radio;
            set
            {
                _Radio = value;
                NotifyChange(nameof(Radio));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ElectronicCategoryPanelViewModel()
        {
            AddEventCommand = new DelegateCommand<Button>(OnAddEventClicked);
            ChangeToEventListCommand = new DelegateCommand<Button>(OnChangeToEventList);
            _configurePanelViewModel = ConfigurePanelViewModel.ActuallyShownConfigurePanel;
            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
        }

        private void DataUpload(string eventName, DateTime dateTime, bool cont, bool isTV)
        {
            var Event = new Electronics
            {
                EventName = eventName,
                EventTime = dateTime,
                Continous = cont,
                Type = isTV == true ? "TV" : "Rádió"
            };
            _actualExternalFactors.ElectronicEvents.Add(Event);

            ExtFactDataProvider.Update(_actualExternalFactors);
        }

        public void OnAddEventClicked(Button btn)
        {
            if (_nameTextBoxText?.Length > 2)
            {
                if (_actualExternalFactors.ElectronicEvents.FirstOrDefault(x => x.EventName == _nameTextBoxText) == null)
                {
                    if (_EE)
                    {
                        if (_Radio)
                        {
                            MessageBox.Show($"Egyszeri rádió esemény sikeresen hozzáadva {_dateTimePicker.ToLongTimeString()} időpontra.");
                            DataUpload(_nameTextBoxText, _dateTimePicker, false, false);
                        }
                        else if (_TV)
                        {
                            MessageBox.Show($"Egyszeri rádió esemény sikeresen hozzáadva {_dateTimePicker.ToLongTimeString()} időpontra.");
                            DataUpload(_nameTextBoxText, _dateTimePicker, false, true);
                        }
                        else
                        {
                            MessageBox.Show("Nincs eszköz kiválasztva!");
                        }
                    }
                    else if (_VE)
                    {
                        if (_Radio)
                        {
                            MessageBox.Show($"Végtelenített rádió esemény sikeresen hozzáadva {_dateTimePicker.ToLongTimeString()} időpontra.");
                            DataUpload(_nameTextBoxText, _dateTimePicker, true, false);
                        }
                        else if (_TV)
                        {
                            MessageBox.Show($"Végtelenített TV esemény sikeresen hozzáadva {_dateTimePicker.ToLongTimeString()} időpontra.");
                            DataUpload(_nameTextBoxText, _dateTimePicker, true, true);
                        }
                        else
                        {
                            MessageBox.Show("Nincs eszköz kiválasztva");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nincs kiválasztott esemény!");
                    }
                }
                else
                {
                    MessageBox.Show("Már létezik esemény ezen a néven!");
                }
            }
            else
            {
                MessageBox.Show("Kötelező az eseménynek nevet választani, mely legalább 3 karakter hosszú!");
            }
        }

        public void OnChangeToEventList(Button btn)
        {
            _configurePanelViewModel.ExecuteChangeToElectronicPanel(true);
        }
    }
}
