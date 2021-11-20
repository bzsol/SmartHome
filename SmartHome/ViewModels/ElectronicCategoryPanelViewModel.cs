using Common.Model;
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
        }

        private void DataUpload(string eventName,DateTime dateTime,bool cont,bool isTV) {

            var external = ((List<ExternalFactors>)ExtFactDataProvider.Get()).FirstOrDefault(x => x.ID == 1);
            if (isTV)
            {
                var objTV = new Electronics();
                objTV.Continous = true;
                objTV.EventName = eventName;
                objTV.EventTime = dateTime;
                objTV.Continous = cont;
                external.TV.Add(objTV);
            }
            else {
                var objRadio = new Electronics();
                objRadio.Continous = true;
                objRadio.EventName = eventName;
                objRadio.EventTime = dateTime;
                objRadio.Continous = cont;
                external.Radio.Add(objRadio);
            }
            ExtFactDataProvider.Update(external);
        }


        public void OnAddEventClicked(Button btn)
        {
            
            if (_EE)
            {
                if (_Radio)
                {
                    MessageBox.Show("Radio" + " " + _dateTimePicker.ToString() + " EE");
                    DataUpload(_nameTextBoxText, _dateTimePicker,false,false);
                }
                else if (_TV)
                {
                    MessageBox.Show("TV" + " " + _dateTimePicker.ToString() + " EE");
                    DataUpload(_nameTextBoxText, _dateTimePicker, false,true);
                }
                else
                {
                    MessageBox.Show("Nincs eszköz!");
                }
            }
            else if (_VE)
            {
                if (_Radio)
                {
                    MessageBox.Show("Radio" + " " + _dateTimePicker.ToString() + " VE");
                    DataUpload(_nameTextBoxText, _dateTimePicker, true,false);
                }
                else if (_TV)
                {
                    MessageBox.Show("TV" + " " + _dateTimePicker.ToString() + " VE");
                    DataUpload(_nameTextBoxText, _dateTimePicker, true,true);
                }
                else
                {
                    MessageBox.Show("Nincs eszköz");
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott esemény");
            }

        }

        public void OnChangeToEventList(Button btn)
        {
            _configurePanelViewModel.ExecuteChangeToElectronicPanel(true);
        }
    }
}
