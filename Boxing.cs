using System;
using System.Collections.Generic;

namespace CSharp {

  class Boxing {

    public static void LoadExercises() {
      UnboxData();
      CastSafely();
    }

    // To store data in a collection with different types,
    // cast it to the generic "object" type. But "boxed"
    // data must be "unboxed" properly when accessed.
    // Otherwise, an exception can be thrown.
    static object BoxedObject = "BoxedObject is string";

    static void UnboxData() {
      if (BoxedObject is int) {
        // var NotAnInt = BoxedObject + 5;
        // This will throw an exception!
      } else if (BoxedObject is string)
        Console.WriteLine(BoxedObject);
    }

    // You can cast safely by using the "as" keyword.
    // If a safe cast fails, it will return a null value.
    // But this only work with non-nullable values.
    // Most simple types are non-nullable!
    static void CastSafely() {

      var MultiTypeList = new List<object>();
      MultiTypeList.Add(7);
      MultiTypeList.Add(2.8);
      MultiTypeList.Add(-1);
      MultiTypeList.Add("100");
      MultiTypeList.Add(true);

      var sum = 0;
      foreach (var item in MultiTypeList) {
        var type = item.GetType().Name;
        Console.WriteLine($"({type}) {item}");
        if (item is int) sum = sum + (int)item;
      }

      Console.WriteLine($"Sum: {sum}");

      // Only string is logged
      // but no exception is thrown
      foreach (var item in MultiTypeList)
        Console.Write($"{item as string}, ");
      Console.Write(Environment.NewLine);
    }

  }

}