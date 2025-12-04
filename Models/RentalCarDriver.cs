using System;
using System.Collections.Generic;
using System.Text;
using oop_assignment_1_2025_77263.Models;

namespace oop_assignment_1_2025_77263.Models
{
    public static class RentalCarDriver
    {
        public static void Run()
        {
            CarType.RentalCar carType = new CarType.RentalCar("Toyota", "Civic", "HatchBack", "45348", 110);
            CarType.RentalCar carType2 = new CarType.RentalCar("Honda", "Accord", "Sedan", "98765", 130);

            carType.Display();
            carType.Borrow();
            carType.Display();
            carType.Borrow();
            carType.returnRentalCar();
            carType.Display();

            Console.WriteLine($"Car is borrowed: {carType.checkBorrowed()}");
            Console.WriteLine($"Car is not borrowed: {!carType.checkBorrowed()}");

            if (!carType.checkBorrowed())
            {
                carType.Borrow();
            }

            if (carType2.checkBorrowed() == false)
            {
                carType2.Borrow();
            }
        }
    }
}
