
namespace InteractionWithControls.Models
{
    public class UserTextBox : UserControl
    {
        private string _text;

        public UserTextBox(double height, double width, string text) : base(height, width)
        {

        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
    }
}
