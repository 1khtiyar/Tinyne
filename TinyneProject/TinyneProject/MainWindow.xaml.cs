using System.Windows;
using TinyneProject.ViewModels;

namespace TinyneProject
{
    /// <summary>
    /// MainWindow.xaml 's code behind
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel(this);
        }
    }
}
