﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InVoiceGenerator
    {
        
        RideType rideType;
        private RideRepository rideRepository;

        
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        
        public InVoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch (CabInVoiceException)
            {
                throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
            }
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
    }
}
