using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Cab Invoice Generator!");
            InVoiceGenerator invoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare : {fare}");
        }
    }
}
