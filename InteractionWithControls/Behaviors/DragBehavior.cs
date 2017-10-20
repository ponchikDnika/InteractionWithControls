using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace InteractionWithControls.Behaviors
{
    public class DragBehavior
    {
        public static readonly DependencyProperty IsDragProperty =
            DependencyProperty.RegisterAttached("Drag",
                typeof(bool), typeof(DragBehavior),
                new PropertyMetadata(false, OnDragChanged));

        public readonly TranslateTransform Transform = new TranslateTransform();
        private Point _elementStartPosition2;
        private Point _mouseStartPosition2;

        public static DragBehavior Instance { get; set; } = new DragBehavior();

        public static bool GetDrag(DependencyObject obj) => (bool)obj.GetValue(IsDragProperty);

        public static void SetDrag(DependencyObject obj, bool value) => obj.SetValue(IsDragProperty, value);

        private static void OnDragChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var element = (UIElement)sender;
            var isDrag = (bool)e.NewValue;

            Instance = new DragBehavior();
            ((UIElement)sender).RenderTransform = Instance.Transform;

            if (isDrag)
            {
                element.PreviewMouseLeftButtonDown += Instance.ElementOnMouseLeftButtonDown;
                element.PreviewMouseLeftButtonUp += Instance.ElementOnMouseLeftButtonUp;
                element.PreviewMouseMove += Instance.ElementOnMouseMove;
            }
            else
            {
                element.PreviewMouseLeftButtonDown -= Instance.ElementOnMouseLeftButtonDown;
                element.PreviewMouseLeftButtonUp -= Instance.ElementOnMouseLeftButtonUp;
                element.PreviewMouseMove -= Instance.ElementOnMouseMove;
            }
        }

        private void ElementOnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var parent = Application.Current.MainWindow;
            _mouseStartPosition2 = mouseButtonEventArgs.GetPosition(parent);
            ((UIElement)sender).CaptureMouse();
        }

        private void ElementOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            ((UIElement)sender).ReleaseMouseCapture();
            _elementStartPosition2.X = Transform.X;
            _elementStartPosition2.Y = Transform.Y;
        }

        private void ElementOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            var parent = Application.Current.MainWindow;
            var mousePos = mouseEventArgs.GetPosition(parent);
            var diff = mousePos - _mouseStartPosition2;
            if (!((UIElement)sender).IsMouseCaptured) return;
            Transform.X = _elementStartPosition2.X + diff.X;
            Transform.Y = _elementStartPosition2.Y + diff.Y;
        }
    }
}
