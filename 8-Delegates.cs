using System;

namespace CSharp {

  // A Delegate is a stored reference to some function
  // It is how to do callbacks in C#

  // Here I use anonymous functions with lambdas,
  // similar to JS ES6 function declaration with arrows.
  // Those functions can also be defined and referenced by name.

  // Func Delegate: Used for delegates returning a value
  // Func "add" receives two ints, returns a string
  public class FuncDelegate {
    public static void Example() {
      Func<int, int, string> add = (int x, int y) => {
        var result = x + y;
        return $"Func del output: {result}";
      };
      string report = add(2, 3);
      Console.WriteLine(report);
    }
  }

  // Action Delegate: Used when delegate won't return a value
  public class ActionDelegate {
    public static void Example() {
      Action<string> log = (string message) => {
        Console.WriteLine(message);
      };
      log("Action del output: void");
    }
  }

  // Custom Delegates (an older way of doing delegates)
  // Most situations can use func/action delegates instead of this
  public class CustomDelegate {
    public delegate int Custom(int i, int j);
    public static void Example() {
      Custom add = (int x, int y) => {
        return x + y;
      };
      int result = add(2, 2);
      Console.WriteLine($"Custom del output: {result}");
    }
  }

}