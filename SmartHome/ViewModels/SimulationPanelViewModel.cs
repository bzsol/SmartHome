﻿using Common.Model;
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
    public class SimulationPanelViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Rectangle> ElectronicClickedCommand { get; set; }
        public DelegateCommand<Rectangle> CheckMotionCommand { get; set; }

        private ExternalFactors _actualExternalFactors;

        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private List<Lights> _lightsInside;

        private List<Shading> _shadings;

        public int LightValue { get; set; }

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

        private Brush _radioColor;
        public Brush RadioColor
        {
            get => _radioColor;
            set
            {
                _radioColor = value;
                NotifyChange(nameof(RadioColor));
            }
        }

        private Brush _entryLightColor;
        public Brush EntryLightColor
        {
            get => _entryLightColor;
            set
            {
                _entryLightColor = value;
                NotifyChange(nameof(EntryLightColor));
            }
        }

        private Brush _LivingroomLightColor;
        public Brush LivingroomLightColor
        {
            get => _LivingroomLightColor;
            set
            {
                _LivingroomLightColor = value;
                NotifyChange(nameof(LivingroomLightColor));
            }
        }

        private Brush _kitchenLightColor;
        public Brush KitchenLightColor
        {
            get => _kitchenLightColor;
            set
            {
                _kitchenLightColor = value;
                NotifyChange(nameof(KitchenLightColor));
            }
        }

        private Brush _bathLightColor;
        public Brush BathLightColor
        {
            get => _bathLightColor;
            set
            {
                _bathLightColor = value;
                NotifyChange(nameof(BathLightColor));
            }
        }

        private Brush _diningLightColor;
        public Brush DiningLightColor
        {
            get => _diningLightColor;
            set
            {
                _diningLightColor = value;
                NotifyChange(nameof(DiningLightColor));
            }
        }

        private Brush _officeLightColor;
        public Brush OfficeLightColor
        {
            get => _officeLightColor;
            set
            {
                _officeLightColor = value;
                NotifyChange(nameof(OfficeLightColor));
            }
        }

        private Brush _room1LightColor;
        public Brush Room1LightColor
        {
            get => _room1LightColor;
            set
            {
                _room1LightColor = value;
                NotifyChange(nameof(Room1LightColor));
            }
        }

        private Brush _room2LightColor;
        public Brush Room2LightColor
        {
            get => _room2LightColor;
            set
            {
                _room2LightColor = value;
                NotifyChange(nameof(Room2LightColor));
            }
        }

        private Brush _room3LightColor;
        public Brush Room3LightColor
        {
            get => _room3LightColor;
            set
            {
                _room3LightColor = value;
                NotifyChange(nameof(Room3LightColor));
            }
        }

        private Brush _panoramaWindowColor;
        public Brush PanoramaWindowColor
        {
            get => _panoramaWindowColor;
            set
            {
                _panoramaWindowColor = value;
                NotifyChange(nameof(PanoramaWindowColor));
            }
        }

        private Brush _bigWindowColor;
        public Brush BigWindowColor
        {
            get => _bigWindowColor;
            set
            {
                _bigWindowColor = value;
                NotifyChange(nameof(BigWindowColor));
            }
        }

        private Brush _kitchenWindowColor;
        public Brush KitchenWindowColor
        {
            get => _kitchenWindowColor;
            set
            {
                _kitchenWindowColor = value;
                NotifyChange(nameof(KitchenWindowColor));
            }
        }

        private Brush _diningWindowColor;
        public Brush DiningWindowColor
        {
            get => _diningWindowColor;
            set
            {
                _diningWindowColor = value;
                NotifyChange(nameof(DiningWindowColor));
            }
        }

        private Brush _officeWindowColor;
        public Brush OfficeWindowColor
        {
            get => _officeWindowColor;
            set
            {
                _officeWindowColor = value;
                NotifyChange(nameof(OfficeWindowColor));
            }
        }

        private Brush _room1WindowColor;
        public Brush Room1WindowColor
        {
            get => _room1WindowColor;
            set
            {
                _room1WindowColor = value;
                NotifyChange(nameof(Room1WindowColor));
            }
        }

        private Brush _room2WindowColor;
        public Brush Room2WindowColor
        {
            get => _room2WindowColor;
            set
            {
                _room2WindowColor = value;
                NotifyChange(nameof(Room2WindowColor));
            }
        }

        private Brush _room3WindowColor;
        public Brush Room3WindowColor
        {
            get => _room3WindowColor;
            set
            {
                _room3WindowColor = value;
                NotifyChange(nameof(Room3WindowColor));
            }
        }

        private Brush _bathLeftWindowColor;
        public Brush BathLeftWindowColor
        {
            get => _bathLeftWindowColor;
            set
            {
                _bathLeftWindowColor = value;
                NotifyChange(nameof(BathLeftWindowColor));
            }
        }

        private Brush _bathRightWindowColor;
        public Brush BathRightWindowColor
        {
            get => _bathRightWindowColor;
            set
            {
                _bathRightWindowColor = value;
                NotifyChange(nameof(BathRightWindowColor));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public SimulationPanelViewModel()
        {
            ElectronicClickedCommand = new DelegateCommand<Rectangle>(OnElectronicClicked);
            CheckMotionCommand = new DelegateCommand<Rectangle>(OnCheckMotion);

            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
            _lightsInside = new()
            {
                _actualExternalFactors.bathLights,
                _actualExternalFactors.diningLights,
                _actualExternalFactors.entryLights,
                _actualExternalFactors.kitchenLights,
                _actualExternalFactors.livingroomLights,
                _actualExternalFactors.officeLights,
                _actualExternalFactors.roomno1Lights,
                _actualExternalFactors.roomno2Lights,
                _actualExternalFactors.roomno3Lights
            };

            _shadings = new()
            {
                _actualExternalFactors.bathLeftWindowShading,
                _actualExternalFactors.bathRightWindowShading,
                _actualExternalFactors.livingroomPanoramaShading,
                _actualExternalFactors.livingroomShading,
                _actualExternalFactors.officeShading,
                _actualExternalFactors.kitchenShading,
                _actualExternalFactors.diningShading,
                _actualExternalFactors.roomno1Shading,
                _actualExternalFactors.roomno2Shading,
                _actualExternalFactors.roomno3Shading
            };

            foreach (var shading in _shadings)
            {
                ShadeWindow(shading, true);
            }

            TVColor = Brushes.Black;
            RadioColor = Brushes.Black;
            EntryLightColor = Brushes.Black;
            LivingroomLightColor = Brushes.Black;
            KitchenLightColor = Brushes.Black;
            DiningLightColor = Brushes.Black;
            OfficeLightColor = Brushes.Black;
            BathLightColor = Brushes.Black;
            Room1LightColor = Brushes.Black;
            Room2LightColor = Brushes.Black;
            Room3LightColor = Brushes.Black;

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            CheckElectronics();
            CheckLights();
            CheckWindows();
            ExtFactDataProvider.Update(_actualExternalFactors);
        }

        public void CheckElectronics()
        {
            foreach (var ev in _actualExternalFactors.ElectronicEvents)
            {
                if (ev.EventTime.ToLongTimeString().Equals(ToolKit.SecToMilitaryTime(DashboardViewModel.time)))
                {
                    if (ev.Type.Equals("TV"))
                    {
                        TVColor = Brushes.LightGreen;
                    }
                    else
                    {
                        RadioColor = Brushes.LightGreen;
                    }
                }
            }
        }

        public void CheckLights()
        {
            foreach (var light in _lightsInside)
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

        public void CheckWindows()
        {
            LightValue = TemperatureDataProvider.GenerateLight(DashboardViewModel.time / 60);
            foreach (var shading in _shadings)
            {
                if (shading.ShadePreference == ShadePreference.PHOTOSENSITIVTY)
                {
                    if (shading.State != 5 && shading.Photosensitivity < LightValue + (shading.Level - 1) * 50)
                    {
                        ShadeWindow(shading, false);
                    }
                }
            }
        }

        public void TurnOffLamp(Lights light)
        {
            switch (light.Place)
            {
                case "Entry":
                    EntryLightColor = Brushes.Black;
                    break;
                case "Livingroom":
                    LivingroomLightColor = Brushes.Black;
                    break;
                case "Kitchen":
                    KitchenLightColor = Brushes.Black;
                    break;
                case "Office":
                    OfficeLightColor = Brushes.Black;
                    break;
                case "Bath":
                    BathLightColor = Brushes.Black;
                    break;
                case "Dining":
                    DiningLightColor = Brushes.Black;
                    break;
                case "Room1":
                    Room1LightColor = Brushes.Black;
                    break;
                case "Room2":
                    Room2LightColor = Brushes.Black;
                    break;
                default:
                    Room3LightColor = Brushes.Black;
                    break;
            }
        }

        public void OnElectronicClicked(Rectangle r)
        {
            if (r.Name.Equals("TV"))
            {
                TVColor = Brushes.Black;
            }
            else
            {
                RadioColor = Brushes.Black;
            }
        }

        public void OnCheckMotion(Rectangle r)
        {
            if (dispatcherTimer.IsEnabled)
            {
                switch (r.Tag.ToString())
                {
                    case "Entry":
                        if (_actualExternalFactors.entryLights.motionDetection)
                        {
                            EntryLightColor = _actualExternalFactors.entryLights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.entryLights.TimeLeft = _actualExternalFactors.entryLights.activeSpan;
                        }
                        break;
                    case "Livingroom":
                        if (_actualExternalFactors.livingroomLights.motionDetection)
                        {
                            LivingroomLightColor = _actualExternalFactors.livingroomLights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.livingroomLights.TimeLeft = _actualExternalFactors.livingroomLights.activeSpan;
                        }
                        break;
                    case "Kitchen":
                        if (_actualExternalFactors.kitchenLights.motionDetection)
                        {
                            KitchenLightColor = _actualExternalFactors.kitchenLights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.kitchenLights.TimeLeft = _actualExternalFactors.kitchenLights.activeSpan;
                        }
                        break;
                    case "Office":
                        if (_actualExternalFactors.officeLights.motionDetection)
                        {
                            OfficeLightColor = _actualExternalFactors.officeLights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.officeLights.TimeLeft = _actualExternalFactors.officeLights.activeSpan;
                        }
                        break;
                    case "Bath":
                        if (_actualExternalFactors.bathLights.motionDetection)
                        {
                            BathLightColor = _actualExternalFactors.bathLights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.bathLights.TimeLeft = _actualExternalFactors.bathLights.activeSpan;
                        }
                        break;
                    case "Dining":
                        if (_actualExternalFactors.diningLights.motionDetection)
                        {
                            DiningLightColor = _actualExternalFactors.diningLights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.diningLights.TimeLeft = _actualExternalFactors.diningLights.activeSpan;
                        }
                        break;
                    case "Room1":
                        if (_actualExternalFactors.roomno1Lights.motionDetection)
                        {
                            Room1LightColor = _actualExternalFactors.roomno1Lights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.roomno1Lights.TimeLeft = _actualExternalFactors.roomno1Lights.activeSpan;
                        }
                        break;
                    case "Room2":
                        if (_actualExternalFactors.roomno2Lights.motionDetection)
                        {
                            Room2LightColor = _actualExternalFactors.roomno2Lights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.roomno2Lights.TimeLeft = _actualExternalFactors.roomno2Lights.activeSpan;
                        }
                        break;
                    default:
                        if (_actualExternalFactors.roomno3Lights.motionDetection)
                        {
                            Room3LightColor = _actualExternalFactors.roomno3Lights.color == LightColor.warm ? Brushes.LightYellow : Brushes.LightSteelBlue;
                            _actualExternalFactors.roomno3Lights.TimeLeft = _actualExternalFactors.roomno3Lights.activeSpan;
                        }
                        break;
                }
            }
        }

        public void ShadeWindow(Shading shading, bool init)
        {
            if (!init)
            {
                shading.State = CalculateState(shading);
            }
            
            Brush color = GetColorBasedOnShadingState(shading.State);
            switch (shading.Place)
            {
                case "LivingBig":
                    BigWindowColor = color;
                    break;
                case "Kitchen":
                    KitchenWindowColor = color;
                    break;
                case "Office":
                    OfficeWindowColor = color;
                    break;
                case "BathRight":
                    BathRightWindowColor = color;
                    break;
                case "BathLeft":
                    BathLeftWindowColor = color;
                    break;
                case "Dining":
                    DiningWindowColor = color;
                    break;
                case "LivingPanorama":
                    PanoramaWindowColor = color;
                    break;
                case "Room1":
                    Room1WindowColor = color;
                    break;
                case "Room2":
                    Room2WindowColor = color;
                    break;
                default:
                    Room3WindowColor = color;
                    break;
            }
        }

        public Brush GetColorBasedOnShadingState(int shadingState)
        {
            switch (shadingState)
            {
                case 5:
                    return Brushes.DarkBlue;
                case 4:
                    return Brushes.DimGray;
                case 3:
                    return Brushes.Gray;
                case 2:
                    return Brushes.DarkGray;
                case 1:
                    return Brushes.LightGray;
                default:
                    return Brushes.SkyBlue;
            }
        }

        public int CalculateState(Shading shading)
        {
            int state = 5;

            for (int i = 1; i < shading.Level; i++)
            {
                if (shading.Photosensitivity + i * 50 > LightValue)
                {
                    state = i;
                    break;
                }
            }

            return state < shading.State ? shading.State : state;
        }
    }
}