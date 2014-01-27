using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using XeroxTest.ViewModel;

namespace XeroxTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mw = new MainWindowView()
            {
                DataContext = new SpaceObjectViewModel()
            };

            mw.Show();
        }
    }
}
