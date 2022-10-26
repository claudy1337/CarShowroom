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
    /// Логика взаимодействия для OrderCarInformationPage.xaml
    /// </summary>
    public partial class OrderCarInformationPage : Page
    {
        public static OrderCar Cars;
        public OrderCarInformationPage(OrderCar cars)
        {
            Cars = cars;
            InitializeComponent();
            BindingData();
        }
        public void BindingData()
        {
            txtPrice.Text = "Price: " + Cars.Cars.Price;
            txtYear.Text = "Year: " + Cars.Cars.Date;
            txtBrand.Text = "Brand: " + Cars.Cars.CarModel.BrandCar.Name;
            txtModel.Text = "Model: " + Cars.Cars.CarModel.Name;
            txtEngine.Text = "Engine: " + Cars.Cars.Engine.Name;
            txtIsNew.Text = "Is New: " + Cars.Cars.isNew;
            txtTransmission.Text = "Transmission: " + Cars.Cars.Transmission.Name;
            txtColor.Text = "Color: " + Cars.Cars.Color;
            txtBody.Text = "Body: " + Cars.Cars.BodyCar.Name;
            txtDiler.Text = "Diler: " + Cars.Cars.Diler.Name;
            txtClient.Text = "Client Name: " + Cars.Client.Name;
            txtClientLogin.Text = "Client Login: " + Cars.Client.Login;
            itemsControl.ItemsSource = DBConnection.connection.ImageCar.Where(c=>c.Description == Cars.Cars.ImageCar.Description).ToList();
        }


    }
}
