using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarShowroom.Data.Classes;
using CarShowroom.Data.Model;
using MaterialDesignThemes.Wpf;

namespace CarShowroom.Data.Classes
{
    internal class OrderCarDataBaseMethods
    {
        public static ObservableCollection<OrderCar> GetOrderCar()
        {
            return new ObservableCollection<OrderCar>(DBConnection.connection.OrderCar);
        }
        public static OrderCar GetOrderCars(Cars cars)
        {
            return GetOrderCar().FirstOrDefault(o=>o.idCar == cars.id);
        }
        public static OrderCar GetOrderCars(Cars cars, Client client)
        {
            return GetOrderCar().FirstOrDefault(o => o.idCar == cars.id && o.idClient == client.id);
        }
        public static IEnumerable<OrderCar> GetOrderCarsList()
        {
            return GetOrderCar().ToList();
        }
        public static void AddOrderCar(Client client, Cars cars)
        {
            OrderCar orderCar = new OrderCar
            {
                idCar = cars.id,
                idClient = client.id
            };
            DBConnection.connection.OrderCar.Add(orderCar);
            DBConnection.connection.SaveChanges();
            CarDataBaseMethods.EditCar(cars);
            HistoryDataBaseHistory.AddHistoryTransactions(orderCar);
            MessageBox.Show($"куплена машина {cars.CarModel.Name} {cars.CarModel.BrandCar.Name} за {cars.Price}");
        }


    }
}
