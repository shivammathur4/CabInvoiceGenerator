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

       
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            
            invoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(2.0, 2),
                new Ride(4.0, 4),
                new Ride(3.0, 3)
            };
            double expected = 132;
            InVoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(expected, summary.totalFare);
        }

        
        [Test]
        public void GivenMultipleRides_ReturnInvoiceSummary()
        {
            
            invoiceGenerator = new InVoiceGenerator(RideType.PREMIUM);
            Ride[] rides =
            {
                new Ride(7.0, 1),
                new Ride(2.0, 3),
                new Ride(1.0, 2),
                new Ride(5.0, 4),
                new Ride(3.0, 3)
            };
            double expected = 297;
            
            InVoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(expected, summary.totalFare);
        }
    }
}
