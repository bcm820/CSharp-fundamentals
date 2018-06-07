using System;
using System.Collections.Generic;

namespace CSharp {

  public class ClassPractice {

    public static void RunVehicle() {
      Vehicle car = new Vehicle(4, 100.8);
      car.wheels = 5; // spare in trunk!
      car.Drive(30.5);
      Console.WriteLine($"wheels: {car.wheels}");
      Console.WriteLine($"mileage: {car.mileage} m");
    }

    // basic for now
    public static void PlayCards() {
      var deck = new Deck();
      Console.WriteLine(deck.cards); // returns void. why?
    }

  }

  class Card {
    private string _value { get; } // i.e. King
    private string _suit { get; } // i.e. Hearts
    private int _rank { get; } // 1st to 14th

    public Card(string value, string suit, int rank) {
      _value = value;
      _suit = suit;
      _rank = rank;
    }
  }

  class Deck {

    private List<Card> _cards;
    public List<Card> cards { get; set; }

    static string[] suits = { "Diamonds", "Clubs", "Hearts", "Spades" };
    static string[] values = getValues();

    static string[] getValues() {
      string[] cardValues = new string[14];
      cardValues[0] = "A";
      cardValues[1] = "K";
      cardValues[2] = "Q";
      cardValues[3] = "J";
      for (var i = 4; i <= 13; i++) cardValues[i] = (i - 3).ToString();
      return cardValues;
    }

    public Deck() {
      _cards = SetDefaultCards();
    }

    public static List<Card> SetDefaultCards() {
      var defaults = new List<Card>();
      foreach (var suit in suits) {
        for (var i = 0; i < 5; i++) // test
          defaults.Add(new Card(values[i], suit, i));
      }
      return defaults;
    }

    public List<Card> Reset() {
      _cards = SetDefaultCards();
      return _cards;
    }

    // todo: create shuffle method
    public List<Card> Shuffle() {
      return _cards;
    }

  }



  // Example with notes
  class Vehicle {

    // without getter/setter
    // note default value given
    // can be overridden by constructor
    public double mileage = 0.0;

    // with getter/setter
    // note use of standardized short form
    private int _wheels;
    public int wheels { get; set; }

    // long form for getter/setter
    // public int wheels {
    //   get { return _wheels; }
    //   set { _wheels = value; }
    // }

    // Constructor function
    // Implied static and returns new instance
    // methods can access private attributes
    public Vehicle(int wheels) {
      _wheels = wheels;
    }

    // Constructor method overload
    // Same method name, diff parameter amounts
    public Vehicle(int wheels, double miles) {
      _wheels = wheels;
      mileage = miles;
    }

    // Class method
    public int Drive(double miles) {
      mileage += miles;
      return (int)mileage;
    }

    // Class method overload
    // Handles metric conversion and calls original
    public int Drive(double miles, string metric) {
      if (metric == "km") miles *= 0.62;
      return Drive(miles);
    }

  }

}