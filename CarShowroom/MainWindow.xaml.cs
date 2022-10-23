using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
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
using CarShowroom.Data.Classes;
using CarShowroom.Pages;
using CarShowroom.Data.Model;
using CarShowroom.Windws;

namespace CarShowroom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Client CurrentClient;
        public MainWindow(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            if (UserDataBaseMethods.GetAdminRole(CurrentClient.Login) == false)
            {
                clTransaction.Visibility = Visibility.Hidden;
                clHistory.Visibility = Visibility.Hidden;
            }
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

        private void clTransaction_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clColorSet();

            clTransaction.Foreground = Brushes.White; 
        }

        private void clCarShowRoom_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clColorSet();

            clCarShowRoom.Foreground = Brushes.White;
        }

        private void clAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clColorSet();
            fContainer.Navigate(new AccountPage(CurrentClient));
            clAccount.Foreground = Brushes.White;
        }

        private void clOrderCars_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clColorSet();

            clOrderCars.Foreground = Brushes.White;
        }

        private void clDiler_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clColorSet();
            fContainer.Navigate(new DilerPage());
            clDiler.Foreground = Brushes.White;
        }

        private void clHistory_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clColorSet();

            clHistory.Foreground = Brushes.White;
        }
        public void clColorSet()
        {
            clDiler.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            clAccount.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            clHistory.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            clOrderCars.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            clTransaction.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            clCarShowRoom.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
        }

        private void btnClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void btnMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void clExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
    }
}
