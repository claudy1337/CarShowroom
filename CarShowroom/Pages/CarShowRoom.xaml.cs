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
        }

        private void lstvCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
