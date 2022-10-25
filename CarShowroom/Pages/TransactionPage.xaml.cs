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
            cbCar.ItemsSource = DBConnection.connection.Cars.Where(c=>c.isBuy==true).ToList();
            cbClient.ItemsSource = DBConnection.connection.Client.ToList();
        }
        private void cbClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectClient = cbClient.SelectedItem as Client;
            var selectCar = cbCar.SelectedItem as Cars;
            if (cbCar.SelectedIndex == -1)
            {
                DGTransaction.ItemsSource = DBConnection.connection.HistoryTransaction.Where(t => t.OrderCar.Client.id == selectClient.id).ToList();
                
            }
            else
            {
                DGTransaction.ItemsSource = DBConnection.connection.HistoryTransaction.Where(t => t.OrderCar.Client.id == selectClient.id && t.OrderCar.Cars.id == selectCar.id).ToList();
            }
            
        }

        private void cbCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DGTransaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
