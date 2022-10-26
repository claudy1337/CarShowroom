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
using CarShowroom.Data.Classes;
using CarShowroom.Data.Model;

namespace CarShowroom.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderCarPage.xaml
    /// </summary>
    public partial class OrderCarPage : Page
    {
        public static Client CurrentClient;
        public OrderCarPage(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            if (UserDataBaseMethods.GetAdminRole(CurrentClient.Login) == false)
            {
                cbClient.Visibility = Visibility.Hidden;
                cardSort.Visibility = Visibility.Hidden;
            }
            BindingData();
        }
        private void ldtvOrderCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectOrderCar = ldtvOrderCar.SelectedItem as OrderCar;
            NavigationService.Navigate(new OrderCarInformationPage(selectOrderCar));
        }
        public void BindingData()
        {
            ldtvOrderCar.ItemsSource = OrderCarDataBaseMethods.GetOrderCarsList(CurrentClient);
            cbClient.ItemsSource = DBConnection.connection.Client.ToList();
        }

        private void cbClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedClient = cbClient.SelectedItem as Client;
            ldtvOrderCar.ItemsSource = DBConnection.connection.OrderCar.Where(c=>c.Client.id == selectedClient.id).ToList();
        }

        private void txtClear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new OrderCarPage(CurrentClient));
        }
    }
}
