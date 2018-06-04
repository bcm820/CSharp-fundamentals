using System;

namespace CSharp {
  class Program {

    static void Main(string[] args) {
      const string myName = "Brian";
      Console.WriteLine($"Hello {myName}!");
      Console.WriteLine("Loading exercises...");
      Basics.LoadExercises();
    }

  }
}
