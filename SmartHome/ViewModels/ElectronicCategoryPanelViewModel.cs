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
        }

        private void DataUpload(ExternalFactors.ElectronicsType electronicsType,string eventName,DateTime dateTime,bool cont) {

            var external = ((List<ExternalFactors>)ExtFactDataProvider.Get()).FirstOrDefault(x => x.ID == 1);
            external.ElectronicType = electronicsType;
            external.EventName = eventName;
            external.EventTime = dateTime;
            external.Continous = cont;
            ExtFactDataProvider.Update(external);
        }


        public void OnAddEventClicked(Button btn)
        {
            
            if (_EE)
            {
                if (_Radio)
                {
                    MessageBox.Show("Radio" + " " + _dateTimePicker.ToString() + " EE");
                    DataUpload(ExternalFactors.ElectronicsType.Radio, _nameTextBoxText, _dateTimePicker,false);
                }
                else if (_TV)
                {
                    MessageBox.Show("TV" + " " + _dateTimePicker.ToString() + " EE");
                    DataUpload(ExternalFactors.ElectronicsType.TV, _nameTextBoxText, _dateTimePicker, false);
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
                    DataUpload(ExternalFactors.ElectronicsType.Radio, _nameTextBoxText, _dateTimePicker, true);
                }
                else if (_TV)
                {
                    MessageBox.Show("TV" + " " + _dateTimePicker.ToString() + " VE");
                    DataUpload(ExternalFactors.ElectronicsType.TV, _nameTextBoxText, _dateTimePicker, true);
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
    }
}
