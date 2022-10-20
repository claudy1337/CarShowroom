using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace CarShowroom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetCarAsync();

        }
        public async Task GetCarAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://car-data.p.rapidapi.com/cars/makes"),
                Headers =
                {
                    { "X-RapidAPI-Key", "0ee35761d0msh1689f7cf1d8d6c1p16b67fjsnc8c1c0389dc8" },
                    { "X-RapidAPI-Host", "car-data.p.rapidapi.com" },
                 },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                txtResult.Text = body.ToString();
            }
        }
    }
}
