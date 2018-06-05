## Variables

```
string name = "Brian";
int age = 30;
double height = 5.8;
bool male = true;
```

## Type Inference

Rather than explicitly declaring a type, we can also use "var" if the type is easily inferred. It does not reduce type safety. Rather, it will increase type safety in your code. It simply lets the compiler chose the type for you.

```
var name = "Brian";
var age = 30;
var height = 5.8;
var male = true;
```

## Constant

```
const string name = "Brian";
```

## Data Types

* char, string
* int, long, short
* float, double
* bool
* object

## Type Casting

Implicit:

```
int IntegerValue = 60;
double DoubleValue = IntegerValue;
```

Explicit:

```
double DoubleValue = 3.14159265358;
int IntegerValue = (int) DoubleValue;
```

## String interpolation

```
var person = "Brian";
$"Hello {person}";
```

## Conditionals

```
if (true)
{
  doSomething();
}
else
{
  doSomethingElse();
}
```

## Operators

```
<   less than
>   greater than
<=  less than or equal to
>=  greater than or equal to
==  equal to
!=  not equal to
&&  both are true
||  either are true
!   bang
```

## Equality vs. Identity

```
A == B        equality
A.Equals(B)   identity (same loc in mem)
```

## Loops

For loop:

```
for (int i = 1; i <= 5; i++)
{
  Console.WriteLine(i);
}
```

While loop:

```
int i = 1;
while (i <= 5)
{
  Console.WriteLine(i);
  i = i + 1;
}
```

## Random Values

* Create custom Random object based on system clock
* Use the object as a generator for random values
* Repeatedly invoke .Next() method for new random values
* Random.Next() can be given a range to choose from

```
Random rand = new Random();
Console.WriteLine(rand.Next(2, 8));
```

## Arrays

* Must specify exact length when created
* Can be initialized with zero values
* Can also be declared with data (preferred)

```
int[] numArray = new int[5];
int[] numArray2 = {1,2,3,4,5};
```

To acess array values:

```
int[] intArray = {2,4,6,8};
Console.WriteLine(intArray[0] + intArray[1]);
```

To loop through an array's values:

* Use a normal for loop to iterate via index
* Use a foreach loop!

```
foreach (int n in intArray)
  Console.WriteLine(n);
```

## Multimensional Array

Requires perfectly rectangular inner arrays.

```
int[,] array2D = {
  { 45, 1, 16, 17 },
  { 4, 47, 21, 68 }
};

int[,,] array3D = {
  {
    { 45, 1, 16, 17 },
    { 4, 47, 21, 68 }
  },
  {
    { 11, 0, 85, 42 },
    { 9, 10, 14, 96 }
  }
};
```

## Jagged Array

Allows for inner arrays to have varying lengths.

```
int[][] jaggedArray3 = {
    new int[] {1,3,5,7,9},
    new int[] {0,2},
    new int[] {11,22,33,44}
};
```

## Generic Lists

Properties & Methods: [MSDN](<https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx>)

Much more like the arrays of Javascript, a linked list implementation that allows for dynamic sizing. Under the hood they are objects with indexed values.

Note: Must be imported.

```
using System.Collections.Generic;

List<string> bikes = new List<string>();

bikes.Add("Kawasaki");
bikes.Add("Triumph");
bikes.Add("Harley Davidson");

bikes.Insert(2, "Yamaha"); // Insert at index
bikes.Remove("Triumph");
bikes.RemoveAt(0); // Remove at index

Console.WriteLine(bikes[2]); // "Harley Davidson"
Console.WriteLine($"There are {bikes.Count} bikes.");

foreach (string bike in bikes)
  Console.WriteLine(bike);
```

## Dictionary

Properties & Methods: [MSDN](<https://msdn.microsoft.com/en-us/library/xfhwa508(v=vs.110).aspx>)

Also a generic collection type. Has almost all methods used with Lists.

```
using System.Collections.Generic;

Dictionary<string,string> user = new Dictionary<string,string>();

user.Add("Name", "Brian");
user.Add("Location", "DC");
user.Add("Language", "C#");
Console.WriteLine(user["Name"]);
Console.WriteLine(user["Location"]);
Console.WriteLine(user["Language"]);

foreach (var entry in user)
  Console.WriteLine($"{entry.Key}: {entry.Value}");
```
