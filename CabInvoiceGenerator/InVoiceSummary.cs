using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InVoiceSummary
    {
        
        private int numberOfRides;
        public double totalFare;
        private double averageFare;

        
        public InVoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / numberOfRides;
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
