using System;

namespace CSharp {

  public class Abstraction {

    public static void Practice() {
      var goat = new Goat();
      foreach (var feat in goat.features) {
        Console.WriteLine($"Goat feature: {feat}");
      }
      goat.Run();
    }

  }

  // An abstract class is built only to inherit from
  // and never to instantiate objects of.
  abstract class Animal {

    public string[] features { get; set; }

    // No need to make the constructor public
    // It should only be invoked from its child class
    protected Animal() {
      features = new string[5];
      features[0] = "Multicellular";
      features[1] = "Eukaryotic cell structure";
      features[2] = "Specialized tissues";
      features[3] = "Heterotrophs";
      features[4] = "Nervous System";
    }

  }

  // An interface enforces a class struture
  // i.e. the CanRun interface requires a Run method
  // Goat inherits from Animal, and implements CanRun
  interface CanRun {
    void Run();
  }
  class Goat : Animal, CanRun {
    public Goat() { }
    public void Run() {
      Console.WriteLine("The goat is running...");
    }
  }

}