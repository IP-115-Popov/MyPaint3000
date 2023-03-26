using Avalonia.Controls;
using MyPaint3000.ViewModels;

namespace MyPaint3000.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
