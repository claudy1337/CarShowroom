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
        public CarAddPage(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
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

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            CarDataBaseMethods.AddImageCar(image1, image2, image3, image4, tbDescription.Text);
        }
    }
}
