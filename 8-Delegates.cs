using System;

namespace CSharp {

  // A Delegate is a stored reference to some function
  // It is how to do callbacks in C#
  // Here I use anonymous functions with lambda expressions
  // These can also be defined and referenced by name.
  public class Delegates {

    // Func Delegate: Used for delegates returning a value
    // Func "add" receives two ints, returns a string

    public static void FuncExample() {
      Func<int, int, string> add = (int x, int y) => {
        var result = x + y;
        return $"Func del output: {result}";
      };
      string report = add(2, 3);
      Console.WriteLine(report);
    }

    // Action Delegate: Used when delegate won't return a value
    public static void ActionExample() {
      Action<string> log = (string message) => Console.WriteLine(message);
      log("Action del output: void");
    }

    // Custom Delegates (an older way of doing delegates)
    // Most situations can use func/action delegates instead of this
    delegate int Custom(int i, int j);
    public static void CustomDelExample() {
      Custom add = (int x, int y) => x + y;
      int result = add(2, 2);
      Console.WriteLine($"Custom del output: {result}");
    }
  }
}