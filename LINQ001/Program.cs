using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //  Problem #1: Hiders vs Overriders

        Stock st1 = new Stock("General Electric", 135.00m);
        Asset as1 = st1;
        Stock st2 = (Stock) as1;

        as1.Display();
        as1.NameLen();

        st2.Display();
        st2.NameLen();

        //  Problem # 1-1: indexers

        Sentence snt = new Sentence("To be    or not to be, this is the question");
        for (int i = 0; i < snt.Length; i++)
            Console.WriteLine(snt[i]);

        snt[2] = "index2";
        snt[5] = "index5";

        for (int i = 0; i < snt.Length; i++)
            Console.WriteLine(snt[i]);

        // Problem #2.

        var lstInt = new List<int> { 23, 7, 4, 5, 90, 27, 5, 7, 5, 1, 5, 8, 10, 8, 6, 8, 11, 8};


        var grpInt = lstInt.GroupBy(x => x);

        var grpInt2 = grpInt.Select(x => new { value = x.Key, count = x.Count() }).OrderByDescending(x => x.count).ThenByDescending(x => x.value);

        foreach (var m in grpInt2)
            Console.WriteLine(m.value + "   " + m.count);

        int[] socks = { 1, 1, 3, 1, 2, 1, 3, 3, 3, 3 };

        int sq = socks.GroupBy(x => x).Select(x => new { key = x.Key, value = x.Count() }).Sum(x => x.value / 2);

        Dictionary<int, int> dict01 = new Dictionary<int, int>();
        int curVal;
        for (int n=0; n<socks.Length; n++ )
        {
            if ( !dict01.ContainsKey(socks[n]) )
            {
                dict01.Add(socks[n], 1);
            }
            else
            {
                curVal = dict01[socks[n]];
                dict01[socks[n]] = ++curVal;
            }
        }

        int sum = 0;
        foreach (int k in dict01.Values)
            sum += k / 2;

        Console.WriteLine("Good pair of socks: " + sum);

        string str02 = "hsgdfjgkh";
        char[] route = str02.ToCharArray();
//      char prev = 'X';
        
        foreach (char cval in route)
        {

        }

// Problem # 3. 

        List<string> lstStr1 = new List<string> { "Henry", "debate", "night", "nonstuff", "trident", "moon", "mySTUFF", "StUfF" };

        RemoveStuff(lstStr1);


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

        var grp4 = lstPrd.Where(p => p.Category != "Kitcheware").Select(p => new { p.Name, p.Price, p.Category }).GroupBy(p => p.Category);

        foreach ( var g in grp4 )
        {
            Console.WriteLine("Key: " + g.Key + "  Count: " + g.Count());
            foreach ( var t in g )
            {
//              Console.WriteLine("Name: " + t.Name + "    Price: " + t.Price);
                Console.WriteLine($"Name:  {t.Name,-30}   Price:  {t.Price,8:N4}");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n\nDone.");

        string name = "Mark";
        var date = DateTime.Now;

        // Composite formatting:
        Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
        // String interpolation:
        Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");


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

    public static void RemoveStuff(List<string> lst)
    {
//        string[] s = lst.ToArray();
        lst.RemoveAll(x => x.ToUpper().Contains("STUFF"));

    }


    public class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public decimal Price;
    }

    public class Asset
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Asset()  { }

        public Asset (string name)
        {
            this.name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine("Method Display; Asset: name=" + name);
        }

        public virtual void NameLen()
        {
            Console.WriteLine("Method NameLen; Asset: name length=" + this.name.Length);
        }

    }

    public class Stock  : Asset
    {
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Stock(string name) : base(name)
        {

        }

        public Stock(string name, decimal price) : this(name)
        {
            this.price = price;
        }

        public Stock(decimal price) => this.price = price;

        public override void Display()
        {
            Console.WriteLine("Method Display; Stock (ovr): name=" + Name + "   price=" + price);
        }

        public new void NameLen()
        {
            Console.WriteLine("Method NameLen; Stock (new): name=" + Name + "   length= " + Name.Length);
        }
    }

    public class Sentence   // indexer
    {
        string text;
        string[] words;

        public Sentence() { }

        public Sentence(string s)
        {
            words = s.Split();
            text = s;
        }

        public string this [int wn]
        {
            get {return words[wn]; }
            set { words[wn] = value; }
        }

        public int Length
        {  get { return words.Length; } }
    }

}