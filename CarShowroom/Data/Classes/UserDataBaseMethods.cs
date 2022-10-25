using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CarShowroom.Data.Model;
using Microsoft.Win32;

namespace CarShowroom.Data.Classes
{
    internal class UserDataBaseMethods
    {
        public static Client CurrentUser;
        public static ObservableCollection<Client> GetClients()
        {
            return new ObservableCollection<Client>(DBConnection.connection.Client);
        }
        public static Client GetClient(string login, string password)
        {
            return GetClients().FirstOrDefault(c=>c.Login == login && c.Password == password);
        }
        public static void AddClient(string name, string login, string password)
        {
            var getuser = GetClient(login, password);
            if (getuser == null)
            {
                Client client = new Client
                {
                    Login = login,
                    Password = password,
                    Name = name,
                    idRole = 2
                };
                CurrentUser = client;
                DBConnection.connection.Client.Add(client);
                DBConnection.connection.SaveChanges();
            }
            else
            {
                MessageBox.Show("такой пользователь уже существует");
                return;
            }
        }
        public static void EditImageClient(Client oldClient)
        {
            var getuser = GetClient(oldClient.Login, oldClient.Password);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                getuser.Image = File.ReadAllBytes(openFileDialog.FileName);
            }
            DBConnection.connection.SaveChanges();
        }
        public static void EditClient(Client oldClient, string name, string password, Image image)
        {
            var getuser = GetClient(oldClient.Login, oldClient.Password);
            getuser.Name= name;
            getuser.Password = password;
            DBConnection.connection.SaveChanges();
        }
        public static bool GetAdminRole(string login)
        {
            ObservableCollection<Client> admin = new ObservableCollection<Client>(DBConnection.connection.Client);
            var currentAdmin = admin.Where(a => a.Login == login && a.idRole == 1).FirstOrDefault();
            return currentAdmin != null;
        }
    }
}
