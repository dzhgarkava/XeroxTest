using System.Windows;
using System.Windows.Data;

namespace XeroxTest.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void SolarSystemTreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            AdditionInfoContentControl.Visibility = Visibility.Visible;
        }
    }
}
