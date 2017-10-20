using System;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using InteractionWithControls.Helpers;
using InteractionWithControls.Models;

namespace InteractionWithControls.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Constructors

        public MainViewModel()
        {
            Controls = new BindableCollection<UserControl>();
            ButtonCommand = new RelayCommand(() =>
            {
                MessageBox.Show("Click on form");
                ChooseElement();
            });
            CanvasCommand = new RelayCommand(() =>
            {
                if (_element != null)
                {
                    _element.X = Mouse.GetPosition(this as IInputElement).X;
                    _element.Y = Mouse.GetPosition(this as IInputElement).Y;
                }
                Draw();
            });
        }

        #endregion

        #region Fields

        private UserControl _element;

        #endregion

        #region Properties

        public RelayCommand ButtonCommand { get; }
        public BindableCollection<UserControl> Controls { get; }
        public RadioOptions EnumProperty { get; set; }
        public RelayCommand CanvasCommand { get; set; }

        #endregion

        #region Methods

        private void ChooseElement()
        {
            switch (EnumProperty)
            {
                case RadioOptions.ButtonOption:
                    _element = new UserButton(100, 100);
                    break;
                case RadioOptions.TextBoxOption:
                    _element = new UserTextBox(100, 100, "TextBox");
                    break;
                case RadioOptions.LabelOption:
                    _element = new UserLabel(100, 100, "Label");
                    break;
                case RadioOptions.CalendarOption:
                    _element = new UserCalendar();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Draw()
        {
            if (_element != null)
                Controls.Add(_element);
            _element = null;
        }

        #endregion
    }
}
