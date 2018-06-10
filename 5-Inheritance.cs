using System;

namespace CSharp {

  public class Inheritance {

    public static void DriveCar() {
      Car usedCar = new Car(40000);
      Console.WriteLine($"Wheels: {usedCar.wheels}");
      Console.WriteLine($"Condition: {usedCar.condition}");
      Console.WriteLine($"Mileage: {usedCar.mileage}");
      usedCar.Drive();
      usedCar.Drive(15);
    }

  }

  class Car : Vehicle {

    public string condition { set; get; }

    // "base" can pass variables into parent constructor
    // parent constructor will execute, then child
    public Car() : base(5) => condition = "New"; // 5 wheels

    // variables can be passed from child into parent
    public Car(double mileage) : base(5, mileage) => condition = "Used";

    // override method -- replaces parent method
    public string Drive() {
      var sound = "Vrooom!";
      Console.WriteLine(sound);
      Console.WriteLine($"The parent method was overridden!");
      Console.WriteLine($"So car mileage is still {mileage} miles!");
      return sound;
    }

    // extend method
    // call parent method via base, then child
    public new string Drive(double distance) {
      base.Drive(distance);
      Console.WriteLine($"The parent method was extended!");
      Console.WriteLine($"The car drove {distance} miles!");
      Console.WriteLine($"Now car mileage is {mileage} miles!");
      var sound = "Vrooom!";
      Console.WriteLine(sound);
      return sound;
    }

  }

}