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
using static System.Net.Mime.MediaTypeNames;

namespace CarShowroom.Pages
{
    /// <summary>
    /// Логика взаимодействия для InformationCarPage.xaml
    /// </summary>
    public partial class InformationCarPage : Page
    {
        public static Client CurrentClient;
        public static Cars Cars;
        public InformationCarPage(Client currentClient, Cars cars)
        {
            CurrentClient = currentClient;
            Cars = cars;
            InitializeComponent();
            BindingDataCars();
            
        }
       
        public void BindingDataCars()
        {
            txtPrice.Text = "Price: " + Cars.Price;
            txtYear.Text = "Year: " + Cars.Date;
            txtBrand.Text = "Brand: " + Cars.CarModel.BrandCar.Name;
            txtModel.Text = "Model: " + Cars.CarModel.Name;
            txtEngine.Text = "Engine: " + Cars.Engine.Name;
            txtIsNew.Text = "Is New: " + Cars.isNew;
            txtTransmission.Text = "Transmission: " + Cars.Transmission.Name;
            txtColor.Text = "Color: " + Cars.Color;
            txtBody.Text = "Body: " + Cars.BodyCar.Name;
            txtDiler.Text = "Diler: " + Cars.Diler.Name;
            itemsControl.ItemsSource = DBConnection.connection.ImageCar.Where(c => c.Description == Cars.ImageCar.Description).ToList();
        }

        private void txtDiler_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new DilerPage(CurrentClient));
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            OrderCarDataBaseMethods.AddOrderCar(CurrentClient, Cars);
            NavigationService.Navigate(new CarShowRoom(CurrentClient));
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CarShowRoom(CurrentClient));
        }

    }
}
