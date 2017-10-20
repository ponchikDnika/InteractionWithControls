
namespace InteractionWithControls.Models
{
    public class UserLabel : UserControl
    {
        private string _content;

        public UserLabel(double height, double width, string content) : base(height, width)
        {
            Content = content;
        }

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
    }
}
