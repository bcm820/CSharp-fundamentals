using System;

namespace CSharp {

  // Static classes can't be instantiated and only contain static fields/methods.
  // A static class can be a good place to store utility functions.
  public static class Calculator {
    // usage: Calculator.Add(1, 1);
    // Methods are called directly on the class, not an instance
    public static int Add(int a, int b) {
      return a + b;
    }
  }

  // Static classes can also be used to add new methods to an existing class.
  // Both classes must belong to the same namespace.
  // Notice the usage of "this".
  static class AdditionalCircleMethods {
    public static void Resize(this Circle circle, int newSize) {
      circle.size = newSize;
    }
  }

  // Static classes can add new methods to interfaces as well!
  // Every class that implements the interface will have these methods!
  static class AdditionalShapeMethods {
    public static void LogShape(this Shape shape) {
      Console.WriteLine($"{shape} is a shape!");
    }
  }

  public interface Shape {
    void ChangeColor(string newColor);
  }

  public class Circle : Shape {
    public int size { get; set; }
    public string color { get; set; }
    public Circle() {
      size = 10;
      color = "red";
    }
    public void ChangeColor(string newColor) {
      color = newColor;
    }
  }

}