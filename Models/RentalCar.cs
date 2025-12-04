using System;
using System.Collections.Generic;
using System.Text;

namespace oop_assignment_1_2025_77263.Models
{
    public interface IRentable
    {
        void Display();
        void Borrow();
        void returnRentalCar();
        bool checkBorrowed();
        double CheckPrice();
        void ChangePrice(double newRate);
    }

    public abstract class CarType
    {
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string BodyType { get; set; } = string.Empty;
        public string registrationNumber { get; set; } = string.Empty;
        public double Price { get; set; } = 0.0;
        public bool Borrowed { get; protected set; } = false;

        protected CarType(string manufacturer, string model, string bodytype, string registrationnumber, double price, bool borrowed)
        {
            if (string.IsNullOrEmpty(manufacturer))
                throw new ArgumentNullException("Brand cannot be null or empty.");

            if (string.IsNullOrEmpty(model))
                throw new ArgumentNullException("model cannot be null or empty");

            if (string.IsNullOrEmpty(bodytype))
                throw new ArgumentNullException("bodytype cannot be null or empty");

            if (string.IsNullOrEmpty(registrationnumber))
                throw new ArgumentNullException("registrationnumber cannot be null or empty");

            Manufacturer = manufacturer;
            Model = model;
            BodyType = bodytype;
            registrationNumber = registrationnumber;
            Price = price;
            Borrowed = borrowed;
        }     

        public class RentalCar : CarType, IRentable
        {
            public RentalCar(string manufacturer, string model, string bodytype, string registrationnumber, double price)
                : base(manufacturer, model, bodytype, registrationnumber, price, false)
            {
            }

            public void Display()
            {
                Console.WriteLine($"Car Details:\nBrand: {Manufacturer}\nModel: {Model}\nPrice: {Price:C}\nBody Type: {BodyType}\nRegistration Number: {registrationNumber}\nBorrowed: {Borrowed}");
            }

            public void Borrow()
            {
                if (Borrowed)
                {
                    Console.WriteLine("This car is already borrowed.");
                }
                else
                {
                    Borrowed = true;
                    Console.WriteLine("Car borrowed successfully.");
                }
            }
            public void returnRentalCar()
            {
                if (!Borrowed)
                {
                    Console.WriteLine("This car is not currently borrowed.");
                }
                else
                {
                    Borrowed = false;
                    Console.WriteLine("Car returned successfully.");
                }
            }
            public bool checkBorrowed()
            {
                return Borrowed;
            }
            public double CheckPrice()
            {
                return Price;
            }

            public void ChangePrice(double newRate)
            {
                if (newRate < 0)
                {
                    throw new ArgumentException("Daily rate cannot be negative.");
                }
                Price = newRate;
                Console.WriteLine($"Daily rate updated to {Price:C}");
            }
        }     

    }
}
