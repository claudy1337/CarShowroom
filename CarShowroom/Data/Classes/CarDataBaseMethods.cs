using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CarShowroom.Data.Classes;
using CarShowroom.Data.Model;
using CarShowroom.Pages;
using Microsoft.Win32;

namespace CarShowroom.Data.Classes
{
    internal class CarDataBaseMethods
    {
        public static ObservableCollection<Cars> GetCar()
        {
            return new ObservableCollection<Cars>(DBConnection.connection.Cars);
        }
        public static Cars GetCars(Cars cars)
        {
            return GetCar().FirstOrDefault(c=>c.id == cars.id);
        }
        public static IEnumerable<Cars> GetAllCars()
        {
            return GetCar().Where(c => c.isBuy == false).ToList();
        }
        public static ObservableCollection<BrandCar> GetCarBrand()
        {
            return new ObservableCollection<BrandCar>(DBConnection.connection.BrandCar);
        }
        public static ObservableCollection<CarModel> GetCarModel()
        {
            return new ObservableCollection<CarModel>(DBConnection.connection.CarModel);
        }
        public static IEnumerable<Cars> GetCarsBodyDilerBrand(BodyCar body, Diler diler, BrandCar brandCar)
        {
            return GetAllCars().Where(c => c.IdBody == body.id && c.idDiler == diler.id && c.CarModel.BrandCar.id == brandCar.id).ToList();
        }



        public static IEnumerable<Cars> GetCarsBrands(BrandCar brand)
        {
            return GetAllCars().Where(c=>c.CarModel.BrandCar.id == brand.id).ToList();
        }
        public static IEnumerable<Cars> GetCarsBrandsDiler(BrandCar brand, Diler diler)
        {
            return GetAllCars().Where(c => c.CarModel.BrandCar.id == brand.id && c.idDiler == diler.id).ToList();
        }
        public static IEnumerable<Cars> GetCarsBrandsBody(BrandCar brand, BodyCar body)
        {
            return GetAllCars().Where(c => c.CarModel.BrandCar.id == brand.id && c.IdBody == body.id).ToList();
        }


        public static IEnumerable<Cars> GetCarsBody(BodyCar body)
        {
            return GetAllCars().Where(c => c.IdBody == body.id).ToList();
        }
        public static IEnumerable<Cars> GetCarsBodyBrand(BodyCar body, BrandCar brandCar)
        {
            return GetAllCars().Where(c => c.IdBody == body.id && c.CarModel.BrandCar.id == brandCar.id).ToList();
        }
        public static IEnumerable<Cars> GetCarsBodyDiler(BodyCar body, Diler diler)
        {
            return GetAllCars().Where(c => c.IdBody == body.id && c.idDiler == diler.id).ToList();
        }
        


        public static IEnumerable<Cars> GetCarsDiler(Diler diler)
        {
            return GetAllCars().Where(c => c.Diler.id == diler.id).ToList();
        }
        public static IEnumerable<Cars> GetCarsDilerBrand(Diler diler, BrandCar brandCar)
        {
            return GetAllCars().Where(c => c.Diler.id == diler.id && c.CarModel.BrandCar.id == brandCar.id).ToList();
        }
        public static IEnumerable<Cars> GetCarsDilerBody(Diler diler, BodyCar bodyCar)
        {
            return GetAllCars().Where(c => c.Diler.id == diler.id && c.IdBody == bodyCar.id).ToList();
        }

        public static void AddImageCar(byte[] image1, byte[] image2, byte[] image3, byte[] image4 ,string description)
        {
            ImageCar imageCar = new ImageCar()
            {
                Image1 = image1,
                Image2 = image2,
                Image3 = image3,
                Image4 = image4,
                Description = description
            };
            DBConnection.connection.ImageCar.Add(imageCar);
            DBConnection.connection.SaveChanges();
        }
        public static void EditCar(Cars cars)
        {
            var getCar = GetCars(cars);
            if (cars != null)
            {
                getCar.isBuy = true;
                DBConnection.connection.SaveChanges();
            }
        }

        
    }
}
