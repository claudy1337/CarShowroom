using CarShowroom.Data.Classes;
using CarShowroom.Data.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace CarShowroom.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddDilerPage.xaml
    /// </summary>
    public partial class AddDilerPage : Page
    {
        public static Client CurrentClient;
        byte[] image;
        public AddDilerPage(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("заполните все поля");
                return;
            }
            else
            {
                if (image == null)
                {
                    MessageBox.Show("выберите изображение");
                }
                else
                    DilerDataBaseMethods.AddDiler(txtName.Text, txtAddress.Text, image);

            }
            NavigationService.Navigate(new DilerPage(CurrentClient));
            
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new DilerPage(CurrentClient));
        }

        private void imgDiler_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                imgDiler.Source = bitmapImage;
                image = File.ReadAllBytes(ofd.FileName);
            }
            
        }
    }
}
