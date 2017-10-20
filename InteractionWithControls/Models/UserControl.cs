using System.ComponentModel;
using System.Runtime.CompilerServices;
using InteractionWithControls.Annotations;

namespace InteractionWithControls.Models
{
    public class UserControl : INotifyPropertyChanged
    {
        private double _height;
        private double _width;
        private double _x;
        private double _y;

        public UserControl()
        {
        }

        public UserControl(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged();
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
