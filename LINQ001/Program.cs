using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Net.Http;

public class MyClassA
{
    public MyClassA()
    {
        Console.WriteLine("Constructor A");
    }

    public void abc()
    {
        Console.WriteLine("A");
    }
}

public class MyClassB   : MyClassA
{
    public MyClassB()
    {
        Console.WriteLine("Constructor B");
    }

    public void abc()
    {
        Console.WriteLine("B");
    }
}



public class Program
{
    public static async Task Main()
    {
        MyClassB vrb = new MyClassB();
        MyClassB vra = vrb;
        vra.abc();



        Task tskHttp = TestHttpClientAsync();
        await Task.Delay(10000);


        Func<int, int, string> trend = (a1, a2) => (a1 + a2).ToString();

        string ttt201 = trend(5, 9);

        //      Reverse string

        string ss101 = "Morocco";

        char[] rev;
        Array.Reverse(rev = ss101.ToCharArray());
        string ss102 = new string(rev);

        string gggg = new string (ss101.Reverse().ToArray());


        // Items removal using LINQ:

        List<string> str201 = new List<string> { "Yuriy", "Lena", "Corine", "John",   "Millie", "Kelly",  "Kellie" };
        List<string> str202 = new List<string> { "Stella", "Emily", "table", "Kelly", "chair", "random", "Lena" };

        str202.RemoveAll(a => str201.Exists(b => b == a)); //  a => !b1.Exists(b => a.number == b.number));

        List<string> lst321 = new List<string> { "Delta", "Mango", "Decimal", "Prego", "Sturgeon", "Band", "Mango", "Delta", "Flag", "Roster", "Decimal", "Skip", "Delta", "Band" };

        HashSet<string> set321 = new HashSet<string>(lst321);

        Console.WriteLine("Counter=" + set321.Count);
        foreach (var item in set321)
            Console.WriteLine(item);
        /*
                IList<Student> studentList = new List<Student>() {
                                    new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
        };

                IList<Standard> standardList = new List<Standard>() {
                                    new Standard(){ StandardID = 1, StandardName="Standard 1"},
                                    new Standard(){ StandardID = 2, StandardName="Standard 2"},
                                    new Standard(){ StandardID = 3, StandardName="Standard 3"}
                                 };

        */

        List<string> str203 = str201.Where(x => !x.ToUpper().StartsWith("K")).Select( x => x + "   " + x).ToList();

        Type ttt = typeof(List<string>);
        Type ttt2 = str203.GetType();

        if ( ttt == ttt2 )
        {
            Console.WriteLine("List<string>");
        }

        Dictionary<long, string> www101 = new Dictionary<long, string>()
        {
            {202, "Valley"},
            {210, "Money"},
            {30, "Penny" },
            {21, "Sally" },
            {501, "Derek" }
        };

        string tmp901;
        www101.TryGetValue(202, out tmp901);
        www101.TryGetValue(11, out tmp901);

        www101.Remove(21);
        www101.Remove(22);

        foreach (var item in www101.Keys.OrderBy(x => x))
        {
            Console.WriteLine("Key=" + item + "   Value=" + www101[item]);
        }



        int[] arTest1 = { 23, -8, 68, 12, 901, -86, 45, 78, 1, 3, -9, 0, 34 };
        int[] arTest2 = { 224, 401 };
        int[] arTest3 = { 549 };
        int[] arTest4 = { };

        int ret;
        /*
                ret = maxArray(arTest1);
                ret = maxArray(arTest2);
                ret = maxArray(arTest3);
                ret = maxArray(arTest4);
                ret = maxArray(null);
        */

/*
        Task<int> task = Task.Run(() => { int smx = 0; for (int i = 1; i <= 100000; i++) smx += i; return smx; });
        Console.WriteLine("Task Running...");
        Console.WriteLine("The answer is " + task.Result);

        Console.WriteLine("Running consequently...");
        Stopwatch sw1 = new Stopwatch();
        sw1.Start();

        int cntPrm = Enumerable.Range(2, 3_000_000).Count((n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(x => n % x > 0)));
        Console.WriteLine("Cnt1 = " + cntPrm);

        cntPrm = Enumerable.Range(3_000_001, 6_000_000).Count((n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(x => n % x > 0)));
        Console.WriteLine("Cnt2 = " + cntPrm);

        cntPrm = Enumerable.Range(6_000_001, 9_000_000).Count((n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(x => n % x > 0)));
        Console.WriteLine("Cnt3 = " + cntPrm);
        sw1.Stop();
        Console.WriteLine("Elapsed A = " + sw1.ElapsedMilliseconds);

        sw1 = new Stopwatch();
        Console.WriteLine("Running in parallel...");
        sw1.Start();

        var pnum1 = CountPrimes1Async(2, 3_000_000);
        var pnum2 = CountPrimes2Async(3_000_001, 6_000_000);
        var pnum3 = CountPrimes3Async(6_000_001, 9_000_000);

        var lstTasks = new List<Task<int>> { pnum1, pnum2, pnum3 };

        while (lstTasks.Count > 0)
        {
            Task<int> finishedTask = await Task.WhenAny(lstTasks);
            if (finishedTask == pnum1)
            {
                Console.WriteLine("CountPrimes1 = " + pnum1.Result);
            }
            else if (finishedTask == pnum2)
            {
                Console.WriteLine("CountPrimes2 = " + finishedTask.Result);
            }
            else if (finishedTask == pnum3)
            {
                Console.WriteLine("CountPrimes3 = " + finishedTask.Result);
            }
            lstTasks.Remove(finishedTask);
        }

        sw1.Stop();

        Console.WriteLine("Async operations done.\nElapsed B = " + sw1.ElapsedMilliseconds);
        Console.ReadLine();

*/
        //  Problem #1: Hiders vs Overriders

        Stock st1 = new Stock("General Electric", 135.00m);
        Asset as1 = st1;
        Stock st2 = (Stock)as1;

        bool testIs;

        testIs = (st1 is Asset);
        testIs = (st1 is Stock);

        testIs = (as1 is Asset);
        testIs = (as1 is Stock);

        testIs = (st2 is Asset);
        testIs = (st2 is Stock);


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

        var lstInt = new List<int> { 23, 7, 4, 5, 90, 27, 5, 7, 5, 1, 5, 8, 10, 8, 6, 8, 11, 8 };

        var grpInt = lstInt.GroupBy(x => x);

        var grpInt2 = grpInt.Select(x => new { value = x.Key, count = x.Count() }).OrderByDescending(x => x.count).ThenByDescending(x => x.value);

        foreach (var m in grpInt2)
            Console.WriteLine(m.value + "   " + m.count);

        foreach (var item in grpInt)
        {
            var mm = item;
            Console.WriteLine("Key=" + item.Key + "   " + item.Count());
            foreach (var n in mm)
                Console.WriteLine("  item=" + n);
        }

        //   Problem #3:
        List<string> lstStr101 = new List<string>() { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };

        List<string> lstStr102 = new List<string>();
        lstStr102.AddRange(lstStr101.Skip(1).Take(4));

        lstStr101.AddRange(lstStr102);
            
        List<string> lstStr103 = lstStr101.Distinct().ToList();

        lstStr102.ForEach(x => x.ToUpper());


        int[] socks = { 1, 1, 3, 1, 2, 1, 3, 3, 3, 3 };

        int sq = socks.GroupBy(x => x).Select(x => new { key = x.Key, value = x.Count() }).Sum(x => x.value / 2);

        Dictionary<int, int> dict01 = new Dictionary<int, int>();
        int curVal;
        for (int n = 0; n < socks.Length; n++)
        {
            if (!dict01.ContainsKey(socks[n]))
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

        foreach (var item in dict01)
        {
            Console.WriteLine("Key=" + item.Key + "   Value=" + item.Value);
        }

//      int ggg = dict01[5];

        foreach (var item in dict01.Keys)
            Console.WriteLine("k=" + item + "   v=" + dict01[item]);


        string str02 = "hsgdfjgkh";
        char[] route = str02.ToCharArray();
        //      char prev = 'X';

        foreach (char cval in route)
        {

        }

        // Problem # 4. 

        List<string> lstStr1 = new List<string> { "Henry", "debate", "night", "nonstuff", "trident", "moon", "mySTUFF", "StUfF" };

        RemoveStuff(lstStr1);

        string[] s1;
        int[] i1;

        Console.WriteLine("Hello World");
        Print(UniqueInOrder(s1 = new string[] { "A", "A", "A", "A", "B", "B", "B", "C", "C", "D", "A", "A", "B", "B", "B" }));
        Print(UniqueInOrder(i1 = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 4, 5, 6, 6, 6, 6, 7, 8, 9, 10, 10, 10, 11 }));

        var v1 = s1.ToLookup(p => p);

        foreach (var grp in v1)
        {
            Console.WriteLine("Key: " + grp.Key + "   # of entries: " + grp.Count());

            foreach (var elem in grp)
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
        Print(r);

        string[] names = { "Tom", "Dick", "Bon", "Harry", "Toy", "Gay", "Mary", "Jay" };

        IEnumerable<string> outerQuery = names.Where(n => n.Length == names.OrderBy(n2 => n2.Length).Select(n2 => n2.Length).First());
        Print(outerQuery.ToArray());
        IEnumerable<string> outerQuery1 = names.Where(n => n.Length == names.OrderBy(n2 => n2.Length).First().Length);
        Print(outerQuery1.ToArray());

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
        var grp3 = lstPrd.ToLookup(p => p.Category, p => new { p.Name, p.Price });

        var grp4 = lstPrd.Where(p => p.Category != "Kitcheware").Select(p => new { p.Name, p.Price, p.Category }).GroupBy(p => p.Category);

        foreach (var g in grp4)
        {
            Console.WriteLine("Key: " + g.Key + "  Count: " + g.Count());
            foreach (var t in g)
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



    public static async Task<int> CountPrimes1Async(int n1, int n2)
    {
        int retVal;

        //      retVal = await Enumerable.Range(n1, n2).Count((n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(x => n % x > 0)));
        retVal = await GetPcAsync(n1, n2);

        return retVal;
    }

    public static async Task<int> CountPrimes2Async(int n1, int n2)
    {
        int retVal;

        //      retVal = await Enumerable.Range(n1, n2).Count((n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(x => n % x > 0)));
        retVal = await GetPcAsync(n1, n2);

        return retVal;
    }

    public static async Task<int> CountPrimes3Async(int n1, int n2)
    {
        int retVal;

        //      retVal = await Enumerable.Range(n1, n2).Count((n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(x => n % x > 0)));
        retVal = await GetPcAsync(n1, n2);

        return retVal;
    }

    public static Task<int> GetPcAsync(int n1, int n2)
    {
        Task<int> xx = Task<int>.Run(() => Enumerable.Range(n1, n2).Count((n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(x => n % x > 0))));
        return xx;
    }



    public static int maxArray(int[] pArr)
    {
        if (pArr == null)
            throw new ArgumentNullException();

        if (pArr.Length == 0)
            throw new Exception("Parameter array has no elements");

        if (pArr.Length == 1)
            return pArr[0];

        int retMax = pArr[0];
        for (int i = 1; i < pArr.Length; i++)
            if (pArr[i] > retMax)
                retMax = pArr[i];

        return retMax;
    }

    public static T[] UniqueInOrder<T>(T[] a)
    {
        return a.Where((x, y) => !x.Equals(y)).ToArray<T>();
    }

    public static void Print<T>(T[] p)
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

    public static async Task TestHttpClientAsync()
    {
        var httpClient = new HttpClient();
        var task1 = httpClient.GetStringAsync("http://www.linqpad.net");
        var task2 = httpClient.GetStringAsync("http://www.oracle.com");

        await task1;
        await task2;

        Console.WriteLine("Returned page lenth: " + task1.Result.Length + "\r\n\r\n" + task1.Result);

        Console.WriteLine("\r\n\r\n\r\n==================================================================================");
        Console.WriteLine("\r\n\r\n\r\n==================================================================================");

//        await task2;
        Console.WriteLine("Returned page lenth: " + task2.Result.Length + "\r\n\r\n" + task2.Result);

        Console.WriteLine("\r\n\r\n\r\n==================================================================================");
        Console.WriteLine("\r\n\r\n\r\n==================================================================================");
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

        public Asset() { }

        public Asset(string name)
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

    public class Stock : Asset
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

        public string this[int wn]
        {
            get { return words[wn]; }
            set { words[wn] = value; }
        }

        public int Length
        { get { return words.Length; } }
    }

    public class MyGeneric1<T> where T : class
    {
        IList ww1 = new ArrayList();
        ArrayList ww2 = new ArrayList();
    }

    public class MyGeneric2<T> where T : Hashtable
    {

    }

}
