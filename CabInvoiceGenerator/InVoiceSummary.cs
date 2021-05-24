using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InVoiceSummary
    {
       
        public int numberOfRides;
        public double totalFare;
        public double averageFare;
        public int length;

        
        public InVoiceSummary(double totalFare, int length)
        {
            this.totalFare = totalFare;
            this.length = length;
        }

        
        public InVoiceSummary(double totalFare, int length, double averageFare)
        {
            this.totalFare = totalFare;
            this.length = length;
            this.averageFare = averageFare;
        }

        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is InVoiceSummary)) return false;
            InVoiceSummary inputedObject = (InVoiceSummary)obj;
            return this.numberOfRides == inputedObject.numberOfRides && this.totalFare == inputedObject.totalFare && this.averageFare == inputedObject.averageFare;
        }

       
        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }
    }
}
