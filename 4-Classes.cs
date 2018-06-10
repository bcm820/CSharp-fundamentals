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

    public static void TestDeck() {
      var deck = new Deck();
      Console.WriteLine("// Show 7 at 20, shuffle and show again");
      deck.ShowAt(20, 7).Shuffle().ShowAt(20, 7);
      Console.WriteLine("// Show default (5) from top, draw and show again");
      deck.ShowAt("top");
      for (var i = 0; i < 5; i++) deck.Draw(deck.cards.Count - 1);
      deck.ShowAt("top");
      Console.WriteLine("// Show count, draw 5 random and show again");
      deck.ShowCount();
      var generator = new Random();
      for (var i = 0; i < 5; i++) deck.Draw(generator.Next(0, deck.cards.Count - 1));
      deck.ShowCount();
    }

  }

  class Card {
    public string value { get; } // i.e. King
    public string suit { get; } // i.e. Hearts
    public int rank { get; } // 1st to 14th

    public Card(string cardValue, string cardSuit, int cardRank) {
      value = cardValue;
      suit = cardSuit;
      rank = cardRank;
    }
  }

  class Deck {

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

    public static List<Card> SetDefaultCards() {
      var defaults = new List<Card>();
      foreach (var suit in suits) {
        for (var i = 0; i < 14; i++)
          defaults.Add(new Card(values[i], suit, i));
      }
      return defaults;
    }

    public Deck() => cards = SetDefaultCards();

    public Deck Reset() {
      cards = SetDefaultCards();
      return this;
    }

    public Deck ShowAt(int start, int amount) {
      var stop = start + amount;
      for (var i = start; i < stop; i++) {
        Console.Write($"{cards[i].value} of {cards[i].suit}");
        if (i != stop - 1) Console.Write(", ");
      }
      Console.Write(Environment.NewLine);
      return this;
    }

    public Deck ShowAt(string start, int amount) {
      switch (start) {
        case "bottom": return ShowAt(0, amount);
        case "top":
        default:
          return ShowAt(cards.Count - amount, amount);
      }
    }

    public Deck ShowAt(string start) => ShowAt(start, 5);

    public Deck ShowCount() {
      Console.WriteLine($"Count: {cards.Count}");
      return this;
    }

    public Card Draw(int position) {
      var card = cards[position];
      cards.RemoveAt(position);
      return card;
    }

    public Deck Shuffle() {
      var generator = new Random();
      for (var i = 0; i < 157; i++) {
        var random1 = generator.Next(0, cards.Count - 1);
        var random2 = generator.Next(0, cards.Count - 1);
        var temp = cards[random1];
        cards[random1] = cards[random2];
        cards[random2] = temp;
      }
      return this;
    }

  }

  // Example with notes
  public class Vehicle {

    // without getter/setter
    // note default value given
    // can be overridden by constructor
    public double mileage = 0.0;

    // with getter/setter
    // note use of standardized short form
    public int wheels { get; set; }

    // long form for getter/setter
    // used if computing/parsing a value
    // private int _wheels;
    // public int wheels {
    //   get { return _wheels; }
    //   set { _wheels = value; }
    // }

    // Constructor function
    // Implied static and returns new instance
    // methods can access private attributes
    public Vehicle(int wheelAmt) => wheels = wheelAmt;

    // Constructor method overload
    // Same method name, diff parameter amounts
    public Vehicle(int wheelAmt, double distance) {
      wheels = wheelAmt;
      mileage = distance;
    }

    // Class method
    public int Drive(double distance) {
      mileage += distance;
      return (int)mileage;
    }

    // Class method overload
    // Handles metric conversion and calls original
    public int Drive(double distance, string metric) {
      if (metric == "km") distance *= 0.62;
      return Drive(distance);
    }

  }

}