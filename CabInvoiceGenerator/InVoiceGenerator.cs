using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InVoiceGenerator
    {
        
        public RideType rideType;
        private RideRepository rideRepository;

        
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;
        private readonly int COST_PER_KM;

        
        public InVoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.MINIMUM_COST_PER_KM = 10;
            this.COST_PER_KM = 1;
            this.MINIMUM_FARE = 5;
            this.rideRepository = new RideRepository();
        }

        
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            
            try
            {
                
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInVoiceException)
            {
                if (rideType.Equals(null))
                {
                    
                    throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
                }
                if (distance <= 0)
                {
                    
                    throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if (time < 0)
                {
                    
                    throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_TIME, "Invalid time");
                }
            }
            
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        
        public InVoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            
            try
            {
                
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInVoiceException)
            {
                if (rides == null)
                {
                    throw new CabInVoiceException(CabInVoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
                }
            }
            
            return new InVoiceSummary(rides.Length, (int)totalFare);
        }

        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                
                rideRepository.AddRide(userId, rides);
            }
            catch (CabInVoiceException)
            {
                if (rides == null)
                {
                    throw new CabInVoiceException(CabInVoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
                }
            }
        }

        
        public InVoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch (CabInVoiceException)
            {
                throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserID");
            }
        }

        public InVoiceSummary CalculateAvgFare(Ride[] rides)
        {
            double totalFare = 0;
            double averageFare = 0;
            
            try
            {
                
                foreach (Ride ride in rides)
                {
                    
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
                
                averageFare = (totalFare / rides.Length);
            }
            catch (CabInVoiceException)
            {
                if (rides == null)
                {
                    throw new CabInVoiceException(CabInVoiceException.ExceptionType.NULL_RIDES, "Rides passed are null..");
                }
            }
           
            return new InVoiceSummary(totalFare, rides.Length, averageFare);
        }
    }
}
