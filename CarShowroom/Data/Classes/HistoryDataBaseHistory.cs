using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarShowroom.Data.Model;

namespace CarShowroom.Data.Classes
{
    internal class HistoryDataBaseHistory
    {
        public static ObservableCollection<HistoryTransaction> GetHistoryTransaction()
        {
            return new ObservableCollection<HistoryTransaction>(DBConnection.connection.HistoryTransaction);
        }
        public static IEnumerable<HistoryTransaction> GetHistoryTransactions()
        {
            return GetHistoryTransaction().ToList();
        }
        public static HistoryTransaction GetTransaction(OrderCar orderCar)
        {
            return GetHistoryTransaction().FirstOrDefault(t=>t.OrderCar.Cars.id == orderCar.id);
        }
        public static void AddHistoryTransactions(OrderCar orderCar)
        {
            HistoryTransaction history = new HistoryTransaction
            {
                DataBuy = DateTime.Now,
                idOrderCar = orderCar.id
            };
            DBConnection.connection.HistoryTransaction.Add(history);
            DBConnection.connection.SaveChanges();
        }
    }
}
