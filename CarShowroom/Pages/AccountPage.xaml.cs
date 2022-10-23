using CarShowroom.Data.Classes;
using CarShowroom.Data.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CarShowroom.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public static Client CurrentClient;
        BitmapImage bitmapImage;
        public AccountPage(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            ClientBindingData();
        }

        private void btnEditAccount_Click(object sender, RoutedEventArgs e)
        {
            UserDataBaseMethods.EditClient(CurrentClient, txtName.Text, txtPassword.Text, imgAccount);
            MessageBox.Show("данные успешно поменялись");
        }

        private void imgAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserDataBaseMethods.EditImageClient(CurrentClient);
            NavigationService.Navigate(new AccountPage(CurrentClient));
        }
        public void ClientBindingData()
        {
            txtLogin.Text = CurrentClient.Login;
            txtName.Text = CurrentClient.Name;
            txtPassword.Text = CurrentClient.Password;
            if (CurrentClient.Image == null)
                imgAccount.Source = new BitmapImage(new Uri("/Resources/default_user.png", UriKind.RelativeOrAbsolute));
            else
                this.DataContext = CurrentClient;
        }
    }
}
