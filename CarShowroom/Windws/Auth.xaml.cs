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
using System.Windows.Shapes;
using CarShowroom.Windws;
using CarShowroom.Data.Classes;
using CarShowroom.Data.Model;

namespace CarShowroom.Windws
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public static Client Client;
        public Auth()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (System.InvalidOperationException)
            {
                return;
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var getUser = UserDataBaseMethods.GetClient(txtLogin.Text, txtPassword.Text);
            if (getUser!=null)
            {
                MainWindow mainWindow = new MainWindow(getUser);
                MessageBox.Show($"welcome {getUser.Name}");
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("не верные данные");
                return;
            }

        }
    }
}
