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
using CarShowroom.Data.Classes;
using CarShowroom.Windws;
using CarShowroom.Data.Model;

namespace CarShowroom.Windws
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public static Client CurrentClient;
        public Registration()
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
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)
                    || string.IsNullOrWhiteSpace(txtName.Text) || UserDataBaseMethods.GetAdminRole(txtLogin.Text))
                {
                    MessageBox.Show("заполните все поля или пользователь уже существует");
                    return;
                }
                else
                {
                    UserDataBaseMethods.AddClient(txtName.Text, txtLogin.Text, txtPassword.Text);
                    CurrentClient = UserDataBaseMethods.CurrentUser;
                    MessageBox.Show($"welcome {CurrentClient.Name}");
                    MainWindow main = new MainWindow(CurrentClient);
                    main.Show();
                    this.Close();
                }
            }
            catch(Exception)
            {
                return;
            }
            
        }
    }
}
