using System;
using TestRentalCar;
using Xunit;
using static oop_assignment_1_2025_77263.Models.CarType;

namespace TestRentalCar
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

public class UnitTest1
{
    [Fact]
    public void BorrowAndReturnTest()
    {
        var car = new RentalCar("Toyota", "Civic", "HatchBack", "45348", 110);

        Assert.False(car.checkBorrowed());

        car.Borrow();
        Assert.True(car.checkBorrowed());

        car.Borrow();
        Assert.True(car.checkBorrowed());

        car.returnRentalCar();
        Assert.False(car.checkBorrowed());
    }

    [Fact]
    public void ChangePriceTest()
    {
        var car = new RentalCar("Honda", "Accord", "Sedan", "98765", 130);

        Assert.Equal(130, car.CheckPrice());

        car.ChangePrice(150);
        Assert.Equal(150, car.CheckPrice());

        Assert.Throws<ArgumentException>(() => car.ChangePrice(-1));
    }

    [Fact]
    public void DisplayTest()
    {
        var car = new RentalCar("Toyota", "Civic", "HatchBack", "45348", 110);

        using var sw = new StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(sw);
        try
        {
            car.Display();
        }
        finally
        {
            Console.SetOut(originalOut);
        }

        var output = sw.ToString();
        Assert.Contains("Brand: Toyota", output);
        Assert.Contains("Registration Number: 45348", output);
        Assert.Contains("Price:", output);
        }
    }    
}