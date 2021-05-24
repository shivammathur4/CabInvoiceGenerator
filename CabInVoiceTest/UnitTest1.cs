using CabInvoiceGenerator;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace CabInVoiceTest
{
    public class Tests
    {

        
        InVoiceGenerator invoiceGenerator;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }


        public void GivenUserId_ShouldReturnInvoiceSummary()
        {
            
            invoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            RideRepository repository = new RideRepository();
            string userID = "Shivam";
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            repository.AddRide(userID, rides);
            Ride[] rideData = repository.GetRides(userID);
            InVoiceSummary invoiceSummary = invoiceGenerator.CalculateAvgFare(rideData);
            InVoiceSummary expectedInvoiceSummary = new InVoiceSummary(30.0, 2, 15.0);
            Assert.AreEqual(expectedInvoiceSummary, invoiceSummary);
        }
    }
}
