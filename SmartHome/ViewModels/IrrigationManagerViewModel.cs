﻿using Common.Class;
using Common.Model;
using Prism.Commands;
using SmartHome.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SmartHome.ViewModels
{
    public class IrrigationManagerViewModel : INotifyPropertyChanged
    {
        

        public DelegateCommand<Button> SaveSettingsCommand { get; set; }
        public DelegateCommand<ToggleButton> IrrigationSettingChangeCommand { get; set; }
        public DelegateCommand<ToggleButton> RepeatSettingChangeCommand { get; set; }

        public List<string> Places { get; set; }

        public List<int> Minutes { get; set; } = new List<int>();

        private string _selectedPlace;
        public string SelectedPlace
        {
            get => _selectedPlace;
            set
            {
                _selectedPlace = value;
                NotifyChange(nameof(SelectedPlace));
            }
        }

        private bool _timeSettingCheckState;
        public bool TimeSettingCheckState
        {
            get
            {
                var external = ((List<ExternalFactors>)ExtFactDataProvider.Get()).FirstOrDefault(x => x.ID == 1);
                _temperatureSettingCheckState = false;
                if ((external.garden.Repeat > 0 || !external.garden.dateTime.Equals(null)) && SelectedPlace.Equals("Kert"))
                {
                    _temperatureSettingCheckState = true;
                }
                if ((external.frontGarden.Repeat > 0 || !external.frontGarden.dateTime.Equals(null)) && SelectedPlace.Equals("Elülső Kert")) {
                    _temperatureSettingCheckState = true;
                }
                return _temperatureSettingCheckState;
            }
            set
            {
                _timeSettingCheckState = value;
                NotifyChange(nameof(TimeSettingCheckState));
            }
        }

        private bool _temperatureSettingCheckState;
        public bool TemperatureSettingCheckState
        {
            get {
                var external = ((List<ExternalFactors>)ExtFactDataProvider.Get()).FirstOrDefault(x => x.ID == 1);
                _temperatureSettingCheckState = false;
                if (external.garden.Temp > 8 && SelectedPlace.Equals("Kert"))
                {
                    
                    _temperatureSettingCheckState = true;

                }
                if (external.frontGarden.Temp > 8 && SelectedPlace.Equals("Elülső Kert"))
                {
                    
                    _temperatureSettingCheckState =  true;
                }
                return _temperatureSettingCheckState;
            }
            set
            {
                _temperatureSettingCheckState = value;
                NotifyChange(nameof(TemperatureSettingCheckState));
            }
        }

        private Visibility _timeSettingOffVisibility;
        public Visibility TimeSettingOffVisibility
        {
            get => _timeSettingOffVisibility;
            set
            {
                _timeSettingOffVisibility = value;
                NotifyChange(nameof(TimeSettingOffVisibility));
            }
        }

        private Visibility _timeSettingOnVisibility;
        public Visibility TimeSettingOnVisibility
        {
            get => _timeSettingOnVisibility;
            set
            {
                _timeSettingOnVisibility = value;
                NotifyChange(nameof(TimeSettingOnVisibility));
            }
        }

        private Visibility _tempSettingOffVisibility;
        public Visibility TempSettingOffVisibility
        {
            get => _tempSettingOffVisibility;
            set
            {
                _tempSettingOffVisibility = value;
                NotifyChange(nameof(TempSettingOffVisibility));
            }
        }

        private Visibility _tempSettingOnVisibility;
        public Visibility TempSettingOnVisibility
        {
            get => _tempSettingOnVisibility;
            set
            {
                _tempSettingOnVisibility = value;
                NotifyChange(nameof(TempSettingOnVisibility));
            }
        }

        private bool _repeatSettingCheckState;
        public bool RepeatSettingCheckState
        {
            get => _repeatSettingCheckState;
            set
            {
                _repeatSettingCheckState = value;
                NotifyChange(nameof(RepeatSettingCheckState));
            }
        }

        private Visibility _repeatTimeSettingVisibility;
        public Visibility RepeatTimeSettingVisiblity
        {
            get => _repeatTimeSettingVisibility;
            set
            {
                _repeatTimeSettingVisibility = value;
                NotifyChange(nameof(RepeatTimeSettingVisiblity));
            }
        }

        private int _selectedRepeatTime;
        public int SelectedRepeatTime
        {
            get => _selectedRepeatTime;
            set
            {
                _selectedRepeatTime = value;
                NotifyChange(nameof(SelectedRepeatTime));
            }
        }
        private int _IrrigationMinute;
        public int IrrigatiionMinute {
            get => _IrrigationMinute;
            set {
                _IrrigationMinute = value;
                NotifyChange(nameof(IrrigatiionMinute));
            }

        }
        private int _IrrigationLevel;
        public int IrrigationLevel {
            get => _IrrigationLevel;
            set {
                _IrrigationLevel = value;
                NotifyChange(nameof(IrrigationLevel));
            }
        }
        private int _TempSlider;
        public int TempSlider {
            get => _TempSlider;
            set {
                _TempSlider = value;
                NotifyChange(nameof(TempSlider));
            }
        }
        private bool _isSunny;
        public bool isSunny {
            get => _isSunny;
            set {
                _isSunny = value;
                NotifyChange(nameof(isSunny));
            }
        }
        private bool _isCloudy;
        public bool isCloudy
        {
            get => _isCloudy;
            set
            {
                _isCloudy = value;
                NotifyChange(nameof(isCloudy));
            }
        }
        private bool _isRain;
        public bool isRain
        {
            get => _isRain;
            set
            {
                _isRain = value;
                NotifyChange(nameof(isRain));
            }
        }
        private bool _isStorm;
        public bool isStorm
        {
            get => _isStorm;
            set
            {
                _isStorm = value;
                NotifyChange(nameof(isStorm));
            }
        }
        private bool _isSnow;
        public bool isSnow
        {
            get => _isSnow;
            set
            {
                _isSnow = value;
                NotifyChange(nameof(isSnow));
            }
        }
        private bool _isthunderstorm;
        public bool isthunderstorm
        {
            get => _isthunderstorm;
            set
            {
                _isthunderstorm = value;
                NotifyChange(nameof(isthunderstorm));
            }
        }
        private DateTime _SelectedTime;
        public DateTime SelectedTime {
            get => _SelectedTime;
            set {
                _SelectedTime = value;
                NotifyChange(nameof(SelectedTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public IrrigationManagerViewModel()
        {
           

            SaveSettingsCommand = new DelegateCommand<Button>(OnSaveSettings);
            IrrigationSettingChangeCommand = new DelegateCommand<ToggleButton>(OnIrrigationSettingChanged);
            RepeatSettingChangeCommand = new DelegateCommand<ToggleButton>(OnRepeatSettingChanged);

            Places = new()
            {
                "Elülső udvar",
                "Kert"
            };

            for (int i = 1; i <= 60; i++)
            {
                Minutes.Add(i);
            }

       
            SelectedPlace = Places[0];
        }

        private void UploadData() {
            var external = ((List<ExternalFactors>)ExtFactDataProvider.Get()).FirstOrDefault(x => x.ID == 1);
            Irrigative irrigative = new Irrigative();
            
            irrigative.isCloudy = _isCloudy;
            irrigative.isRain = _isRain;
            irrigative.isSnow = _isSnow;
            irrigative.isSunny = _isSunny;
            irrigative.isthunderstorm = _isthunderstorm;
            irrigative.isStorm = _isStorm;

            irrigative.strenght = _IrrigationLevel;
            irrigative.timespan = _IrrigationMinute;

            if (_timeSettingCheckState)
            {
                irrigative.dateTime = _SelectedTime;
                if(_repeatSettingCheckState) irrigative.Repeat = _selectedRepeatTime;
            }
            if (_temperatureSettingCheckState) {
                irrigative.Temp = _TempSlider;
            }

            if (SelectedPlace.Equals("Elülső udvar")) {
                external.garden = irrigative;
            }
            else if (SelectedPlace.Equals("Kert")) {
                external.frontGarden = irrigative;
            }
            ExtFactDataProvider.Update(external);
        }

        private void OnSaveSettings(Button btn)
        {
            MessageBox.Show($"{SelectedPlace}");
            UploadData();
        }

        private void OnIrrigationSettingChanged(ToggleButton tbtn)
        {
            if (tbtn.Name.Equals("timeToggleButton"))
            {
                if (TimeSettingCheckState)
                {
                    TimeSettingOffVisibility = Visibility.Hidden;
                    TimeSettingOnVisibility = Visibility.Visible;
                }
                else
                {
                    TimeSettingOffVisibility = Visibility.Visible;
                    TimeSettingOnVisibility = Visibility.Hidden;
                }
            }
            else
            {
                if (TemperatureSettingCheckState)
                {
                    TempSettingOffVisibility = Visibility.Hidden;
                    TempSettingOnVisibility = Visibility.Visible;
                }
                else
                {
                    TempSettingOffVisibility = Visibility.Visible;
                    TempSettingOnVisibility = Visibility.Hidden;
                }
            }
        }

        private void OnRepeatSettingChanged(ToggleButton tbtn)
        {
            RepeatTimeSettingVisiblity = RepeatSettingCheckState ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
