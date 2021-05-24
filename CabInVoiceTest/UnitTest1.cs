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
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            
            invoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenDistanceAndTime_ReturnTotalFare()
        {
            
            invoiceGenerator = new InVoiceGenerator(RideType.PREMIUM);
            double distance = 4.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 70;
            Assert.AreEqual(expected, fare);
        }
    }
}
