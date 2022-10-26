using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для TransactionPage.xaml
    /// </summary>
    public partial class TransactionPage : Page
    {
        public static Client CurrentClient;
        public TransactionPage(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            BindingData();
        }
        public void BindingData()
        {
            DGTransaction.ItemsSource = DBConnection.connection.HistoryTransaction.ToList();
            cbCar.ItemsSource = DBConnection.connection.OrderCar.ToList();
            cbClient.ItemsSource = DBConnection.connection.Client.ToList();
        }
        private void cbClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbCar.SelectedIndex = -1;
                var selectClient = cbClient.SelectedItem as Client; 
                DGTransaction.ItemsSource = DBConnection.connection.HistoryTransaction.Where(t=>t.OrderCar.Client.id == selectClient.id).ToList();
               
            }
            catch(Exception)
            {
                return;
            }  
        }

        private void cbCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbClient.SelectedIndex = -1;
                var selectCar = cbCar.SelectedItem as OrderCar;
                DGTransaction.ItemsSource = DBConnection.connection.HistoryTransaction.Where(t=>t.OrderCar.Cars.id == selectCar.Cars.id).ToList();
            }
            catch(Exception)
            {
                return;
            }
        }

        private void DGTransaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectTransaction = DGTransaction.SelectedItem as HistoryTransaction;
            NavigationService.Navigate(new OrderCarInformationPage(selectTransaction.OrderCar));
        }
    }
}
