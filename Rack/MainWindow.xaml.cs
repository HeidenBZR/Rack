using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rack
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Icon = null;
        }

        

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(TextBoxMultuplayer.Text.Trim(), out double multiplayer))
            {
                MessageBox.Show($"{TextBoxMultuplayer.Text} must be a number");
                return;
            }
            bool change_tempo = false; //CheckBoxChangeTempo.IsChecked.Value;

            try
            {
                Core.Rack(multiplayer, change_tempo);
                MessageBox.Show("Success!");
                Ust.Current.Save();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Got some error:\n\n" +
                    $"{ex.Message}\n\n" +
                    $"{ex.StackTrace}");
            }
        }
    }
}
