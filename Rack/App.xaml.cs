using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Rack
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var args = e.Args;
            if (args != null && args.Count() > 0)
            {
                new Ust(args[0]);
                new MainWindow().Show();
            }
            else
            {
                MessageBox.Show("Rack is a ust notes stretcher. Please run it as an UTAU plugin.");
                Shutdown();
            }
        }
    }
}
