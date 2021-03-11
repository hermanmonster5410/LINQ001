using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ImmutableCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            


        }


        public static IReadOnlyDictionary<string, int> GetReports(DateTime? from, DateTime? to)
        {
            Dictionary<string, int> dct = new Dictionary<string, int>();

            return new ReadOnlyDictionary<string, int>(dct);
        }
    }

    public class Invoice
    {
        public int Id;
        public string Description;
        public DateTime CreateDate;
        public DateTime? PayDate;
        public IList<InvoiceItem> InvoiceItems;
    }

    public class InvoiceItem
    {
        public int Count;
        public decimal Price;
        public string ProductId;
    }
}
