using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp {

  class Product {
    public string name;
    public string category;
    public double price;
    public Product(string pName, string pCategory, double pPrice) {
      name = pName;
      category = pCategory;
      price = pPrice;
    }
  }

  class ProductPair {
    public string product1;
    public string product2;
    public double price;
    public ProductPair(string p1, string p2, double ppPrice) {
      product1 = p1;
      product2 = p2;
      price = ppPrice;
    }
  }

  public class LINQIntro {

    static Product[] products = {
      new Product("jeans", "clothing", 24.99),
      new Product("scooter", "vehicle", 99.99),
      new Product("skateboard", "vehicle", 29.99),
      new Product("socks", "clothing", 8.99),
      new Product("shirt", "clothing", 29.99),
      new Product("shorts", "clothing", 21.99),
      new Product("bicycle", "vehicle", 399.99),
      new Product("surfboard", "vehicle", 299.99),
      new Product("jacket", "clothing", 399.99)
    };

    public static void UseQueries(string type) {

      Console.WriteLine($"* {type.ToUpper()} QUERIES *");
      ShowSorted(Sort(products, type));
      var categories = ShowCategorized(Categorize(products, type));
      var productPairs = FindEquals(
        categories["clothing"],
        categories["vehicle"],
        type
        );
      ShowEquallyPriced(productPairs);
    }

    static IEnumerable<Product> Sort(Product[] products, string type) {
      if (type == "method") {
        return products
          .Where(product => product.price > 10)
          .OrderByDescending(product => product.price);
      } else return from product in products
                    where product.price > 10
                    orderby product.price descending
                    select new Product(product.name, product.category, product.price);
    }

    static IEnumerable<IGrouping<string, Product>>
      Categorize(Product[] products, string type) {
      if (type == "method") {
        return products.GroupBy(product => product.category);
      } else return from product in products
                    group product by product.category into category
                    select category;
    }

    static IEnumerable<ProductPair>
      FindEquals(List<Product> list1, List<Product> list2, string type) {
      if (type == "method") {
        return list1.Join(list2,
            product1 => product1.price,
            product2 => product2.price,
            (p1, p2) => new ProductPair(p1.name, p2.name, p1.price)
          );
      } else return from product1 in list1
                    join product2 in list2
                    on product1.price equals product2.price
                    select new ProductPair(product1.name, product2.name, product1.price);
    }

    static void ShowSorted(IEnumerable<Product> sortedProducts) {
      Console.Write(Environment.NewLine);
      Console.WriteLine("SORTED PRODUCTS > $10");
      foreach (var product in sortedProducts)
        Console.WriteLine($"- {product.name}: {product.price}");
      Console.Write(Environment.NewLine);
    }

    static Dictionary<string, List<Product>>
      ShowCategorized(IEnumerable<IGrouping<string, Product>> categories) {
      Console.WriteLine("PRODUCTS BY CATEGORY");
      var categoryDict = new Dictionary<string, List<Product>>();
      foreach (var category in categories) {
        Console.WriteLine($"- Products in the {category.Key} category:");
        categoryDict[category.Key] = new List<Product>();
        foreach (var product in category) {
          Console.WriteLine($"  - {product.name}: {product.price}");
          categoryDict[category.Key].Add(product);
        }
      }
      return categoryDict;
    }

    static void ShowEquallyPriced(IEnumerable<ProductPair> pairs) {
      Console.Write(Environment.NewLine);
      Console.WriteLine("MATCHING PRICES");
      foreach (var pair in pairs)
        Console.WriteLine($"- {pair.product1} & {pair.product2}: {pair.price}");
      Console.Write(Environment.NewLine);
    }

  }

}