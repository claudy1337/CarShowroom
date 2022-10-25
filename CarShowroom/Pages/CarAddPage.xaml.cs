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
using CarShowroom.Data.Model;
using CarShowroom.Data.Classes;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace CarShowroom.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarAddPage.xaml
    /// </summary>
    public partial class CarAddPage : Page
    {
        public static Client CurrentClient;
        byte[] image1;
        byte[] image2;
        byte[] image3;
        byte[] image4;
        bool IsNew;
        public CarAddPage(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            BindingData();
        }

        private void imgUpload1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                imgUpload1.Source = bitmapImage;
                image1 = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void imgUpload2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                imgUpload2.Source = bitmapImage;
                image2 = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void imgUpload3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                imgUpload3.Source = bitmapImage;
                image3 = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void imgUpload4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                imgUpload4.Source = bitmapImage;
                image4 = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void PriceValue(object sender, TextCompositionEventArgs e)
        {

        }

        private void cbIsNew_Checked(object sender, RoutedEventArgs e)
        {
            if (cbIsNew.IsChecked == true)
            {
                IsNew = true;
            }
            else
                IsNew = false;
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
                Regex regex = new Regex("[^1-9]+");
                e.Handled = regex.IsMatch(e.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("0 is not count");
                return;
            }
        }

        private void txtDate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
                Regex regex = new Regex("[^1-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("0 is not count");
                return;
            }
        }

        private void brnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColor.Text) || string.IsNullOrWhiteSpace(txtDate.Text) || string.IsNullOrWhiteSpace(txtDescription.Text) || string.IsNullOrEmpty(txtPrice.Text)||
                cbBodyCar.SelectedIndex == -1 || cbModelCar.SelectedIndex == -1 && cbTransmissionCar.SelectedIndex == -1 || cbEngineCar.SelectedIndex == -1 || cbDiler.SelectedIndex == -1)
            {
                MessageBox.Show("заполните все поля");
            }
            else
            {
                var selectModel = cbModelCar.SelectedItem as CarModel;
                var selectBody = cbBodyCar.SelectedItem as BodyCar;
                var selectTransmis = cbTransmissionCar.SelectedItem as Transmission;
                var selectEngine = cbEngineCar.SelectedItem as Engine;
                var selectDiler = cbDiler.SelectedItem as Diler;
                CarDataBaseMethods.AddImageCar(image1, image2, image3, image4, txtDescription.Text);
                var getImage = CarDataBaseMethods.GetImages(txtDescription.Text);
                CarDataBaseMethods.AddCar(selectModel, selectBody ,selectTransmis , IsNew, selectEngine,Convert.ToInt32(txtPrice.Text),selectDiler, getImage.id, txtColor.Text, Convert.ToInt32(txtDate.Text), getImage);
            }
            
        }
        public void BindingData()
        {
            cbBodyCar.ItemsSource = DBConnection.connection.BodyCar.ToList();
            cbTransmissionCar.ItemsSource = DBConnection.connection.Transmission.ToList();
            cbEngineCar.ItemsSource = DBConnection.connection.Engine.ToList();
            cbDiler.ItemsSource = DBConnection.connection.Diler.ToList();
            cbBrandCar.ItemsSource = DBConnection.connection.BrandCar.ToList();
        }

        private void cbBrandCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectBrand = cbBrandCar.SelectedItem as BrandCar;
            cbModelCar.ItemsSource = CarDataBaseMethods.GetCarsModels(selectBrand);
        }
    }
}
