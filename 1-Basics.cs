using System;

namespace CSharp {

  class Basics {

    public static void Run() {
      BasicLoop();
      PrintDivisibles();
      PrintFizzBuzz();
      RandomizeFizzBuzz();
    }

    // Create a Loop that prints all values from 1-255.
    static void BasicLoop() {
      for (var i = 1; i <= 255; i++)
        Console.WriteLine(i);
    }

    // Create a new loop that prints all values from 1-100
    // that are divisible by 3 or 5, but not both.
    static void PrintDivisibles() {
      for (var i = 1; i <= 100; i++) {
        if (i % 3 == 0 || i % 5 == 0) {
          if (!(i % 3 == 0 && i % 5 == 0))
            Console.WriteLine(i);
        }
      }
    }

    // FizzBuzz.
    static void PrintFizzBuzz() {
      for (var i = 1; i <= 100; i++)
        Console.WriteLine(FizzBuzz(i));
    }

    static string FizzBuzz(int n) {
      if (n % 3 == 0 && n % 5 == 0)
        return "FizzBuzz";
      else if (n % 3 == 0)
        return "Fizz";
      else if (n % 5 == 0)
        return "Buzz";
      else return n.ToString();
    }

    // Generate 10 random values.
    // Use the FizzBuzz conditions.
    static void RandomizeFizzBuzz() {
      var generator = new Random();
      for (var i = 1; i <= 10; i++)
        Console.WriteLine(
          $"{i}. {FizzBuzz(generator.Next(1, 10))}"
        );
    }



  }
}
