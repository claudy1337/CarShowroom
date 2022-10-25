using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.Data.Model;
using Microsoft.Win32;

namespace CarShowroom.Data.Classes
{
    internal class DilerDataBaseMethods
    {
        public static ObservableCollection<Diler> GetDiler()
        {
            return new ObservableCollection<Diler>(DBConnection.connection.Diler);
        }
        public static Diler GetDilers(string name, string address)
        {
            return GetDiler().FirstOrDefault(d=>d.Address == address && d.Name == name);
        }
        public static IEnumerable<Diler> GetDilers()
        {
            return GetDiler().ToList();
        }
        public static void AddDiler(string name, string address, Byte[] image)
        {
            var getDiler = GetDilers(name, address);
            if (getDiler == null)
            {
                Diler diler = new Diler
                {
                    Name = name,
                    Address = address,
                    Image = image
                     
                };
                DBConnection.connection.Diler.Add(diler);
                DBConnection.connection.SaveChanges();
                MessageBox.Show("дилер успешно добавлен");
            }
            else
                MessageBox.Show("данный дилер уже существует");
        }
        public static void EditDiler(Diler oldDiler, string name, string address)
        {
            var getDiler = GetDilers(oldDiler.Name, oldDiler.Address);
            if (getDiler != null)
            {
                getDiler.Address = address;
                getDiler.Name = name;
                DBConnection.connection.SaveChanges();
            }
        }
        
    }
}
