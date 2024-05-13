using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProducerConsumerMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel = new ();
        public MainWindow()
        {
            InitializeComponent();
            _viewModel.UpdateScene += Update;
        }

        private void Update()
        {
            Application.Current?.Dispatcher?.Invoke(() =>
            {
                TheCanvas.Children.Clear();
                foreach (var shape in _viewModel.Shapes)
                {
                    var e = new Ellipse
                    {
                        Fill = new SolidColorBrush(shape.Color),
                        Stroke = new SolidColorBrush(Colors.Black),
                        StrokeThickness = 2,
                        Margin = new Thickness(shape.X, shape.Y, 0, 0),
                        Width = 50,
                        Height = 50,
                    };
                    TheCanvas.Children.Add(e);
                }
            });
        }
    }
}