using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string[] s1;
        int[]    i1;

        Console.WriteLine("Hello World");
        print(uniqueInOrder(s1 = new string[] { "A", "A", "A", "A", "B", "B", "B", "C", "C", "D", "A", "A", "B", "B", "B" }));
        print(uniqueInOrder(i1 = new int[]    { 1, 1, 1, 2, 2, 2, 3, 3, 4, 5, 6, 6, 6, 6, 7, 8, 9, 10, 10, 10, 11 }));

        var v1 = s1.ToLookup(p => p);

        foreach ( var grp in v1 )
        {
            Console.WriteLine("Key: " + grp.Key + "   # of entries: " + grp.Count());

            foreach ( var elem in grp )
            {
                Console.WriteLine(elem);
            }

            Console.WriteLine();
        }

        var v2 = i1.ToLookup(p => p);

        Console.WriteLine("Experiment.");
        IEnumerable<char> query = "Not what you might expect";
        string vowels = "aeiou";

        for (int i = 0; i < vowels.Length; i++)
        {
            query = query.Where(c => c != vowels[i]).ToArray();
            Console.WriteLine(string.Join("", query));
        }

        foreach (char c in query) Console.Write(c);
        Console.WriteLine();

        int[] s = new int[] { 10, 21, 2, 45, 29, 65, 19, 27, 63, 78, 24 };
        int[] r = s.Where(x => (x >= 20 && x <= 29)).OrderBy(t => t).ToArray();
        print(r);

        string[] names = { "Tom", "Dick", "Bon", "Harry", "Toy", "Gay", "Mary", "Jay" };

        IEnumerable<string> outerQuery = names.Where(n => n.Length == names.OrderBy(n2 => n2.Length).Select(n2 => n2.Length).First());
        print(outerQuery.ToArray());
        IEnumerable<string> outerQuery1 = names.Where(n => n.Length == names.OrderBy(n2 => n2.Length).First().Length);
        print(outerQuery1.ToArray());

        List<Product> lstPrd = new List<Product>
        {
            new Product { Id=1,  Name="Norelco Razor",          Category="Shaving",         Price=  59.00m},
            new Product { Id=2,  Name="Phillips Screwdriver",   Category="Hand Tools",      Price=   4.50m},
            new Product { Id=3,  Name="Liquid Soap",            Category="Cleaning",        Price=   1.79m},
            new Product { Id=4,  Name="Paper Towels",           Category="Paper Product",   Price=   6.99m},
            new Product { Id=5,  Name="Bathroom Tissue",        Category="Paper Product",   Price=   4.99m},
            new Product { Id=6,  Name="Honey Mustard",          Category="Seasoning",       Price=   2.60m},
            new Product { Id=7,  Name="Electric Drill",         Category="Power Tool",      Price= 129.00m},
            new Product { Id=8,  Name="Hand Saw",               Category="Hand Tools",      Price=  11.50m},
            new Product { Id=9,  Name="Fork",                   Category="Kitcheware",      Price=   3.95m},
            new Product { Id=10, Name="Knife",                  Category="Kitchenware",     Price=   4.25m},
            new Product { Id=11, Name="Spoon",                  Category="Kitchenware",     Price=   3.50m},
            new Product { Id=12, Name="Cosmetic Tissue",        Category="Paper Product",   Price=   2.99m},
            new Product { Id=13, Name="Dishwashing Detergent",  Category="Cleaning",        Price=   2.79m},
            new Product { Id=14, Name="Salt",                   Category="Seasoning",       Price=   1.17m},
            new Product { Id=15, Name="Instant Coffee",         Category="Food",            Price=   6.99m},
            new Product { Id=16, Name="Black Pepper",           Category="Seasoning",       Price=   3.49m},
            new Product { Id=17, Name="Ballpoint Pen",          Category="Stationary",      Price=   1.89m},
            new Product { Id=18, Name="Lead HB Pacck",          Category="Stationary",      Price=   1.99m},
        };

        var grp1 = lstPrd.ToLookup(p => p.Category);
        var grp2 = lstPrd.ToLookup(p => p.Category, p => p.Name);
        var grp3 = lstPrd.ToLookup(p => p.Category, p => new { p.Name, p.Price});
    }


    public static T[] uniqueInOrder<T>(T[] a)
    {
        return a.Where((x, y) => !x.Equals(y)).ToArray<T>();
    }

    public static void print<T>(T[] p)
    {
        foreach (T z in p)
            Console.Write(z.ToString() + ", ");

        Console.WriteLine("\n");
    }


    public class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public decimal Price;
    }

}