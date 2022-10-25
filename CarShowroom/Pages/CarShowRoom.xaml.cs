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
    /// Логика взаимодействия для CarShowRoom.xaml
    /// </summary>
    public partial class CarShowRoom : Page
    {
        public static Client CurrentClient;

        public CarShowRoom(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            if (UserDataBaseMethods.GetAdminRole(CurrentClient.Login) == false)
            {
                btnAddCar.Visibility = Visibility.Hidden;
            }
            BindingData();
        }

        private void lstvCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectCar = lstvCar.SelectedItem as Cars;
            NavigationService.Navigate(new InformationCarPage(CurrentClient, selectCar));
        }
        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CarAddPage(CurrentClient));
        }
        public void BindingData()
        {
            cbBody.ItemsSource = DBConnection.connection.BodyCar.ToList();
            cbDiler.ItemsSource = DilerDataBaseMethods.GetDiler();
            lstvCar.ItemsSource = CarDataBaseMethods.GetAllCars();
            cbdBrand.ItemsSource = CarDataBaseMethods.GetCarBrand();
        }

        private void cbdBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectDiler = cbDiler.SelectedItem as Diler;
            var selectBody = cbBody.SelectedItem as BodyCar;
            var selectBrand = cbdBrand.SelectedItem as BrandCar;
            if (cbBody.SelectedIndex == -1 && cbDiler.SelectedIndex == -1)
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsBrands(selectBrand);
            }
            else if (cbBody.SelectedIndex == -1)
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsBrandsDiler(selectBrand, selectDiler);
            }
            else if (cbDiler.SelectedIndex == -1)
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsBrandsBody(selectBrand, selectBody);
            }
            else
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsBodyDilerBrand(selectBody, selectDiler, selectBrand);
            }
        }

        private void cbBody_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectDiler = cbDiler.SelectedItem as Diler;
            var selectBody = cbBody.SelectedItem as BodyCar;
            var selectBrand = cbdBrand.SelectedItem as BrandCar;
            if (cbDiler.SelectedIndex == -1 && cbdBrand.SelectedIndex ==-1)
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsBody(selectBody);
            }
            else if (cbDiler.SelectedIndex == -1)
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsBodyBrand(selectBody, selectBrand);
            }
            else if (cbdBrand.SelectedIndex == -1)
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsBodyDiler(selectBody, selectDiler);
            }
            else
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsBodyDilerBrand(selectBody, selectDiler, selectBrand);
            }
        }

        private void cbDiler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectDiler = cbDiler.SelectedItem as Diler;
            var selectBody = cbBody.SelectedItem as BodyCar;
            var selectBrand = cbdBrand.SelectedItem as BrandCar;
            if (cbBody.SelectedIndex == -1 && cbdBrand.SelectedIndex == -1)
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsDiler(selectDiler);
            }
            else if (cbdBrand.SelectedIndex == -1)
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsDilerBody(selectDiler, selectBody);
            }
            else if (cbBody.SelectedIndex == -1)
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsDilerBrand(selectDiler, selectBrand);
            }
            else
            {
                lstvCar.ItemsSource = CarDataBaseMethods.GetCarsBodyDilerBrand(selectBody, selectDiler, selectBrand);
            }
        }

        private void txtClear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CarShowRoom(CurrentClient));
        }
    }
}
