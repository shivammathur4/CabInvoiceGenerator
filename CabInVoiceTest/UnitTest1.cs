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
        public void GivenMultipleRides_ShouldReturnInvoiceSummary_WithAverage()
        {
            invoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InVoiceSummary invoiceSummary = invoiceGenerator.CalculateAvgFare(rides);
            var resultHashCode = invoiceSummary.GetHashCode();
            InVoiceSummary expectedInvoiceSummary = new InVoiceSummary(30.0, 2, 15.0);
            var resulExpectedHashCode = expectedInvoiceSummary.GetHashCode();
            Assert.AreEqual(expectedInvoiceSummary, invoiceSummary);
        }
    }
}
