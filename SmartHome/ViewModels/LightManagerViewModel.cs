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
    public class LightManagerViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Button> SaveSettingsCommand { get; set; }
        public DelegateCommand<Button> UpMinuteCounterCommand { get; set; }
        public DelegateCommand<Button> DownMinuteCounterCommand { get; set; }
        public DelegateCommand<RadioButton> LocationChanged { get; set; }
        public DelegateCommand<ToggleButton> MotionStateChanged { get; set; }

        public List<string> InsidePlaces { get; set; }
        public List<string> OutsidePlaces { get; set; }

        private List<string> _places;
        public List<string> Places
        {
            get => _places;
            set
            {
                _places = value;
                NotifyChange(nameof(Places));
            }
        }

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

        private bool _insideCheckState;
        public bool InsideCheckState
        {
            get => _insideCheckState;
            set
            {
                _insideCheckState = value;
                NotifyChange(nameof(InsideCheckState));
            }
        }

        private bool _outsideCheckState;
        public bool OutsideCheckState
        {
            get => _outsideCheckState;
            set
            {
                _outsideCheckState = value;
                NotifyChange(nameof(OutsideCheckState));
            }
        }

        private Visibility _motionEnabledVisibility;
        public Visibility MotionEnabledVisibility
        {
            get => _motionEnabledVisibility;
            set
            {
                _motionEnabledVisibility = value;
                NotifyChange(nameof(MotionEnabledVisibility));
            }
        }

        private bool _isMotionDetectionEnabled;
        public bool IsMotionDetectionEnabled
        {
            get => _isMotionDetectionEnabled;
            set
            {
                _isMotionDetectionEnabled = value;
                NotifyChange(nameof(IsMotionDetectionEnabled));
            }
        }

        private string _motionTimeTextBox;
        public string MotionTimeTextBox
        {
            get => _motionTimeTextBox;
            set
            {
                _motionTimeTextBox = value;
                NotifyChange(nameof(MotionTimeTextBox));
            }
        }
        bool first = true;
        private int _lightStrenght;
        public int SliderValue {

            get {
                if (first)
                {
                    first = false;
                    return _lightStrenght = 50;
                   
                }
                else {
                   return _lightStrenght;
                }
            }
            set {
                _lightStrenght = value;
                NotifyChange(nameof(SliderValue));
            }
        
        }
        private bool _isColorcold;
        public bool isColorCold {
            get => _isColorcold;
            set {
                _isColorcold = value;
                NotifyChange(nameof(isColorCold));
            }
        }
        private bool _isColorwarm;
        public bool isColorWarm {
            get => _isColorwarm;
            set {
                _isColorwarm = value;
                NotifyChange(nameof(isColorWarm));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public LightManagerViewModel()
        {
            SaveSettingsCommand = new DelegateCommand<Button>(OnSaveSettings);
            UpMinuteCounterCommand = new DelegateCommand<Button>(OnUpMinuteClicked);
            DownMinuteCounterCommand = new DelegateCommand<Button>(OnDownMinuteClicked);
            LocationChanged = new DelegateCommand<RadioButton>(OnLocationChanged);
            MotionStateChanged = new DelegateCommand<ToggleButton>(OnMotionStateChanged);

            InsidePlaces = new()
            {
                "Előszoba",
                "Nappali",
                "Konyha",
                "Fürdőszoba",
                "Iroda",
                "Étkező",
                "Szoba #1",
                "Szoba #2",
                "Szoba #3"
            };

            OutsidePlaces = new()
            {
                "Bejárat",
                "Kapubejáró",
                "Garázs",
                "Kert"
            };
            // debug
            MotionEnabledVisibility = Visibility.Hidden;
            IsMotionDetectionEnabled = false;
            // debug
            InsideCheckState = true;
            Places = InsidePlaces;
            SelectedPlace = Places[0];
        }
        

        private void ChangeTextValue(string text, bool increase)
        {
            bool value =  int.TryParse(text, out int number);

            if (value && increase && number < 10)
            {
                MotionTimeTextBox = "" + (number + 1);
            }
            else if (value && !increase && number > 1)
            {
                MotionTimeTextBox = "" + (number - 1);
            }
            else if (!value && increase)
            {
                MotionTimeTextBox = "10";
            }
            else if (!value && !increase)
            {
                MotionTimeTextBox = "1";
            }
        }

        private void DataUpload()
        {
            ExternalFactors external = ((List<ExternalFactors>)ExtFactDataProvider.Get()).FirstOrDefault(x => x.ID == 1);
            Lights lights = new Lights();
            lights.motionDetection = _isMotionDetectionEnabled;
            lights.strenght = _lightStrenght;
            lights.color = isColorCold ? ExternalFactors.LightColor.cold : ExternalFactors.LightColor.warm;
            if (IsMotionDetectionEnabled)
            {
                lights.activeSpan = int.Parse(_motionTimeTextBox);
            }
            else
            {
                lights.activeSpan = 0;
            }
            external.entryLights.Add(lights);

            ExtFactDataProvider.Update(external);

        }


        private void OnDownMinuteClicked(Button btn)
        {
            ChangeTextValue(MotionTimeTextBox, false);
        }

        private void OnUpMinuteClicked(Button btn)
        {
            ChangeTextValue(MotionTimeTextBox, true);
        }

        private void OnSaveSettings(Button btn)
        {
            MessageBox.Show(_lightStrenght.ToString());
            DataUpload();
        }

        private void OnLocationChanged(RadioButton rbtn)
        {
            if (rbtn.Name.Equals("InsideRadioButton"))
            {
                Places = InsidePlaces;
                SelectedPlace = Places[0];
            }
            else
            {
                Places = OutsidePlaces;
                SelectedPlace = Places[0];
            }
        }

        private void OnMotionStateChanged(ToggleButton tbtn)
        {
            if (IsMotionDetectionEnabled)
            {
                MotionEnabledVisibility = Visibility.Visible;
            }
            else
            {

                MotionEnabledVisibility = Visibility.Hidden;
            }
        }
    }
}
