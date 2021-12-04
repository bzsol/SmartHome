using Common.Class;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using static Common.Model.ExternalFactors;

namespace SmartHome.ViewModels
{
    public class GardenPanelViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Ellipse> CheckMotionCommand { get; set; }

        private ExternalFactors _actualExternalFactors;

        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private List<Lights> _lightsOutside;

        private List<Irrigative> _irrigatives;

        private Brush _leftGardenLightColor;
        public Brush LeftGardenLightColor
        {
            get => _leftGardenLightColor;
            set
            {
                _leftGardenLightColor = value;
                NotifyChange(nameof(LeftGardenLightColor));
            }
        }

        private Brush _rightGardenLightColor;
        public Brush RightGardenLightColor
        {
            get => _rightGardenLightColor;
            set
            {
                _rightGardenLightColor = value;
                NotifyChange(nameof(RightGardenLightColor));
            }
        }

        private Brush _leftEntranceLightColor;
        public Brush LeftEntranceLightColor
        {
            get => _leftEntranceLightColor;
            set
            {
                _leftEntranceLightColor = value;
                NotifyChange(nameof(LeftEntranceLightColor));
            }
        }

        private Brush _rightEntranceLightColor;
        public Brush RightEntranceLightColor
        {
            get => _rightEntranceLightColor;
            set
            {
                _rightEntranceLightColor = value;
                NotifyChange(nameof(RightEntranceLightColor));
            }
        }

        private Brush _upperGarageLightColor;
        public Brush UpperGarageLightColor
        {
            get => _upperGarageLightColor;
            set
            {
                _upperGarageLightColor = value;
                NotifyChange(nameof(UpperGarageLightColor));
            }
        }

        private Brush _lowerGarageLightColor;
        public Brush LowerGarageLightColor
        {
            get => _lowerGarageLightColor;
            set
            {
                _lowerGarageLightColor = value;
                NotifyChange(nameof(LowerGarageLightColor));
            }
        }

        private Brush _frontIrrigationColor;
        public Brush FrontIrrigationColor
        {
            get => _frontIrrigationColor;
            set
            {
                _frontIrrigationColor = value;
                NotifyChange(nameof(FrontIrrigationColor));
            }
        }

        private Brush _backIrrigationColor;
        public Brush BackIrrigationColor
        {
            get => _backIrrigationColor;
            set
            {
                _backIrrigationColor = value;
                NotifyChange(nameof(BackIrrigationColor));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public GardenPanelViewModel()
        {
            CheckMotionCommand = new DelegateCommand<Ellipse>(OnCheckMotion);
            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
            _lightsOutside = new()
            {
                _actualExternalFactors.garageLights,
                _actualExternalFactors.garageLights2,
                _actualExternalFactors.gardenLights,
                _actualExternalFactors.gardenLights2,
                _actualExternalFactors.gateEntranceLights,
                _actualExternalFactors.gateEntranceLights2
            };

            _irrigatives = new()
            {
                _actualExternalFactors.frontGarden,
                _actualExternalFactors.garden
            };

            LeftGardenLightColor = Brushes.Black;
            RightGardenLightColor = Brushes.Black;
            UpperGarageLightColor = Brushes.Black;
            LowerGarageLightColor = Brushes.Black;
            LeftEntranceLightColor = Brushes.Black;
            RightEntranceLightColor = Brushes.Black;

            FrontIrrigationColor = Brushes.Black;
            BackIrrigationColor = Brushes.Black;

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            CheckLights();
            CheckIrrigation();
            ExtFactDataProvider.Update(_actualExternalFactors);
        }

        public void CheckLights()
        {
            foreach (var light in _lightsOutside)
            {
                if (light.motionDetection && light.TimeLeft > 0)
                {
                    light.TimeLeft -= 1;
                    if (light.TimeLeft == 0)
                    {
                        TurnOffLamp(light);
                    }
                }
            }
        }

        public void CheckIrrigation()
        {
            foreach (var irrigative in _irrigatives)
            {
                if (irrigative.IsTimeSetting && irrigative.Time.ToLongTimeString().Equals(ToolKit.SecToMilitaryTime(DashboardViewModel.time)))
                {
                    SetIrrigationColor(irrigative, Brushes.Blue);
                    irrigative.TimeLeft = irrigative.timespan;
                }

                if (irrigative.TimeLeft > 0)
                {
                    irrigative.TimeLeft -= 1;
                    if (irrigative.TimeLeft == 0)
                    {
                        SetIrrigationColor(irrigative, Brushes.Black);
                    }
                }
            }
        }

        public void SetIrrigationColor(Irrigative irrigative, Brush brush)
        {
            if (irrigative.Place.Equals("Garden"))
            {
                BackIrrigationColor = brush;
            }
            else
            {
                FrontIrrigationColor = brush;
            }
        }

        public void TurnOffLamp(Lights light)
        {
            switch (light.Place)
            {
                case "Garden":
                    LeftGardenLightColor = Brushes.Black;
                    break;
                case "Garden2":
                    RightGardenLightColor = Brushes.Black;
                    break;
                case "Garage":
                    LowerGarageLightColor = Brushes.Black;
                    break;
                case "Garage2":
                    UpperGarageLightColor = Brushes.Black;
                    break;
                case "Gate":
                    LeftEntranceLightColor = Brushes.Black;
                    break;
                default:
                    RightEntranceLightColor = Brushes.Black;
                    break;
            }
        }

        public void OnCheckMotion(Ellipse e)
        {
            if (dispatcherTimer.IsEnabled)
            {
                switch (e.Tag.ToString())
                {
                    case "Garden":
                        if (_actualExternalFactors.gardenLights.motionDetection)
                        {
                            LeftGardenLightColor = _actualExternalFactors.gardenLights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.gardenLights.TimeLeft = _actualExternalFactors.gardenLights.activeSpan;
                        }
                        break;
                    case "Garden2":
                        if (_actualExternalFactors.gardenLights2.motionDetection)
                        {
                            RightGardenLightColor = _actualExternalFactors.gardenLights2.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.gardenLights2.TimeLeft = _actualExternalFactors.gardenLights2.activeSpan;
                        }
                        break;
                    case "Garage":
                        if (_actualExternalFactors.garageLights.motionDetection)
                        {
                            LowerGarageLightColor = _actualExternalFactors.garageLights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.garageLights.TimeLeft = _actualExternalFactors.garageLights.activeSpan;
                        }
                        break;
                    case "Garage2":
                        if (_actualExternalFactors.garageLights2.motionDetection)
                        {
                            UpperGarageLightColor = _actualExternalFactors.garageLights2.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.garageLights2.TimeLeft = _actualExternalFactors.garageLights2.activeSpan;
                        }
                        break;
                    case "Gate":
                        if (_actualExternalFactors.gateEntranceLights.motionDetection)
                        {
                            LeftEntranceLightColor = _actualExternalFactors.gateEntranceLights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.gateEntranceLights.TimeLeft = _actualExternalFactors.gateEntranceLights.activeSpan;
                        }
                        break;
                    default:
                        if (_actualExternalFactors.gateEntranceLights2.motionDetection)
                        {
                            RightEntranceLightColor = _actualExternalFactors.gateEntranceLights2.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.gateEntranceLights2.TimeLeft = _actualExternalFactors.gateEntranceLights2.activeSpan;
                        }
                        break;
                }
            }
        }
    }
}
