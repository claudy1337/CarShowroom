using CarShowroom.Data.Classes;
using CarShowroom.Data.Model;
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
    /// Логика взаимодействия для AddDilerPage.xaml
    /// </summary>
    public partial class AddDilerPage : Page
    {
        public static Client CurrentClient;
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
                DilerDataBaseMethods.AddDiler(txtName.Text, txtAddress.Text);
                MessageBox.Show("Дилер успешно добавлен");
            }
            
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new DilerPage(CurrentClient));
        }

        private void imgDiler_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Diler diler = new Diler
            {
                Address = txtAddress.Text,
                Name = txtName.Text
            };
            DilerDataBaseMethods.AddImageDiler(diler);
        }
    }
}
