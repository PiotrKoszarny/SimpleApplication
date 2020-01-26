using Microsoft.EntityFrameworkCore;
using SimpleApp.DataAccess.Entity;
using System;
using System.Linq;

namespace SimpleApp.DataAccess
{
    public static class SeedDataExtension
    {
        private static Random _random = new Random();

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(GetCars());
        }

        private static Car[] GetCars()
        {

            var cars = new Car[]
            {
                new Car
                {
                    Brand = "Volkswagen",
                    Mileage =GetRandomMileage(),
                    Model = "Golf",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Volkswagen",
                    Mileage =GetRandomMileage(),
                    Model = "Passat",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Volkswagen",
                    Mileage =GetRandomMileage(),
                    Model = "Polo",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Volkswagen",
                    Mileage =GetRandomMileage(),
                    Model = "Bora",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Opel",
                    Mileage =GetRandomMileage(),
                    Model = "Astra",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Opel",
                    Mileage =GetRandomMileage(),
                    Model = "Vectra",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Opel",
                    Mileage =GetRandomMileage(),
                    Model = "Corsa",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Audi",
                    Mileage =GetRandomMileage(),
                    Model = "A3",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Audi",
                    Mileage =GetRandomMileage(),
                    Model = "A5",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Audi",
                    Mileage =GetRandomMileage(),
                    Model = "A7",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Audi",
                    Mileage =GetRandomMileage(),
                    Model = "Q3",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Audi",
                    Mileage =GetRandomMileage(),
                    Model = "Q5",
                    ProductionDate =GetDateTime()

        },new Car
                {
                    Brand = "Audi",
                    Mileage =GetRandomMileage(),
                    Model = "Q7",
                    ProductionDate =GetDateTime()

        },

            };

            var id = 1;
            foreach (var item in cars)
            {
                item.Id = id;
                id++;
            }
            return cars;
        }

        private static int GetRandomMileage()
        {
            return _random.Next(100, 200000);
        }

        private static DateTime GetDateTime()
        {
            var months = _random.Next(0, 120);
            return DateTime.UtcNow.AddMonths(-months).Date;
        }
    }
}
