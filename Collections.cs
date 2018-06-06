using System;
using System.Collections.Generic;

namespace CSharp {
  class Collections {

    public static void LoadExercises() {
      LogThreeArrays();
      GenerateMultTable();
      ListFlavors();
      StoreUserInfo();
    }

    // Three Basic Arrays
    // Create an array of integer values 0 through 9
    // Create an array of names.
    // Create an array of length 10 that alternates bool values
    static object[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    static object[] names = { "Brian", "Seth", "Sam", "Ray" };
    static object[] bools = new object[10];
    static void LogThreeArrays() {
      var flag = true;
      for (var i = 0; i <= 9; i++) {
        bools[i] = flag;
        flag = !flag;
      }
      Console.WriteLine(string.Join(", ", numbers));
      Console.WriteLine(string.Join(", ", names));
      Console.WriteLine(string.Join(", ", bools));
    }

    // Multiplication Table
    // Use a 2d array to generate a multiplication table.
    static void GenerateMultTable() {
      int[,] MultTable = new int[10, 10];
      for (var x = 0; x < 10; x++) {
        for (var y = 0; y < 10; y++) {
          MultTable[x, y] = (x + 1) * (y + 1);
          Console.Write($"{MultTable[x, y]} ");
        }
        Console.Write(Environment.NewLine);
      };
    }

    // List of Flavors
    // Create a list that holds ice cream flavors.
    // Output the length of this list.
    // Output the third flavor, then remove this value.
    // Output the new length of the list.
    static List<string> flavors = new List<string>();
    static void ListFlavors() {
      flavors.Add("vanilla");
      flavors.Add("chocolate");
      flavors.Add("strawberry");
      flavors.Add("coffee");
      flavors.Add("rocky road");
      Console.WriteLine(string.Join(", ", flavors.ToArray()));
      Console.WriteLine(flavors.Count);
      Console.WriteLine(flavors[2]);
      flavors.RemoveAt(2);
      Console.WriteLine(flavors.Count);
    }

    // User Info Dictionary
    // Create a dictionary with the names array as keys.
    // For each key, store a random ice cream flavor as its value.
    // Loop through the dictionary and print the data.
    static void StoreUserInfo() {
      var random = new Random();
      var users = new Dictionary<string, string>();
      foreach (var name in names)
        users[(string)name] = flavors[random.Next(0, flavors.Count)];
      foreach (var user in users)
        Console.WriteLine($"{user.Key}: {user.Value}");
    }
  }
}