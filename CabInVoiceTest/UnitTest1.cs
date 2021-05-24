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
        public void GivenNormal_RideType_ShouldReturnInvoice()
        {
            
            double distance = 2.0;
            int time = 5;
            invoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            double totalActualFare = invoiceGenerator.CalculateFare(distance, time);
            double totalExpectedFare = 25.0;
            Assert.AreEqual(totalExpectedFare, totalActualFare);
        }

        
        [Test]
        public void GivenPremium_RideType_ShouldReturnInvoice()
        {
            double distance = 2.0;
            int time = 5;
            invoiceGenerator = new InVoiceGenerator(RideType.PREMIUM);
            double totalActualFare = invoiceGenerator.CalculateFare(distance, time);
            double totalExpectedFare = 40.0;
            Assert.AreEqual(totalExpectedFare, totalActualFare);
        }
    }
}
