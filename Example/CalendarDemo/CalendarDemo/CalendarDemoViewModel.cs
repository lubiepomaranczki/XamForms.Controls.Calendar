using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CalendarDemo.Base;
using Xamarin.Forms;
using XamForms.Controls;

namespace CalendarDemo
{
    public class CalendarDemoViewModel : BaseViewModel
    {
        private DateTime? _date;
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                NotifyPropertyChanged(nameof(Date));
            }
        }

        private List<DateTime> _selectedDates;
        public List<DateTime> SelectedDates
        {
            get
            {
                return _selectedDates;
            }
            set
            {
                _selectedDates = value;
                NotifyPropertyChanged(nameof(SelectedDates));
            }
        }

        private ObservableCollection<SpecialDate> attendances;

        public ObservableCollection<SpecialDate> Attendances
        {
            get { return attendances; }
            set { attendances = value; NotifyPropertyChanged(nameof(Attendances)); }
        }

        public ICommand DateChosen => new Command((obj) =>
        {
            System.Diagnostics.Debug.WriteLine(obj as DateTime?);
        });

        public ICommand TestCmd => new Command((obj) =>
        {
            var test = SelectedDates;
        });

        public CalendarDemoViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            var dates = new List<SpecialDate>();

            Attendances = new ObservableCollection<SpecialDate>(dates) {
                new SpecialDate(DateTime.Now.AddDays(2))
                {
                     BackgroundColor = Color.Green,
                     TextColor = Color.Accent,
                     BorderColor = Color.Lime,
                     BorderWidth = 8,
                     Selectable = true },
                new SpecialDate(DateTime.Now.AddDays(3))
                {
                    BackgroundColor = Color.Green,
                    TextColor = Color.Blue,
                    Selectable = true,
                    BackgroundPattern = new BackgroundPattern(1)
                    {
                        Pattern = new List<Pattern>
                        {
                            new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Red},
                            new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Purple},
                            new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Green},
                            new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Yellow,Text = "Test", TextColor=Color.DarkBlue, TextSize=11, TextAlign=TextAlign.Middle}
                        }
                    }
                },
                new SpecialDate(DateTime.Now.AddDays(4))
                {
                    Selectable = true,
                    BackgroundPattern = new BackgroundPattern(1)
                    {
                        Pattern = new List<Pattern>
                        {
                            new Pattern{ WidthPercent = 1f, HightPercent = 0.5f, Color = Color.Red},
                            new Pattern{ WidthPercent = 1f, HightPercent = 0.5f, Color = Color.Purple},
                        }
                    },
                    BackgroundImage = ImageSource.FromFile("ic_calendarCircle.png") as FileImageSource
                }
            };
            SelectedDates = new List<DateTime>();
        }
    }
}

