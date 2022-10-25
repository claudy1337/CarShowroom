using CarShowroom.Data.Classes;
using CarShowroom.Data.Model;
using MaterialDesignThemes.Wpf;
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

namespace CarShowroom.Pages
{
    /// <summary>
    /// Логика взаимодействия для DilerPage.xaml
    /// </summary>
    public partial class DilerPage : Page
    {
        public static Client CurrentClient;
        public DilerPage(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            if (UserDataBaseMethods.GetAdminRole(CurrentClient.Login) == false)
            {
                btnAddDiler.Visibility = Visibility.Hidden;
            }
            lstDiler.ItemsSource = DilerDataBaseMethods.GetDilers();
            
        }

        private void btnAddDiler_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDilerPage(CurrentClient));
        }

        private void lstDiler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectDiler = lstDiler.SelectedItem as Diler;
            txtName.Text = selectDiler.Name;
            txtAddress.Text = selectDiler.Address;
            txtCountCarAvailable.Text = "Count Сars Available: ";
            txtCountOfSolid.Text = "Count of Sold: ";
            txtAverageCarPrice.Text = "Average Car Price: ";
            this.DataContext = selectDiler;

        }
    }
}
