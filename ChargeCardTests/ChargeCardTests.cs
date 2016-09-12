using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ChargeCards;
namespace ChargeCardTests
{
	[TestFixture]
	public class ChargeCardTests
	{
		[SetUp]
		public void SetUpTests()
		{
			//Setup items go here.
		}

		[Test]
		public void TestZeroBalance()
		{
			ChargeCard cardOne = new ChargeCard(0.0);
			Assert.AreEqual(0.0, cardOne.CardBalance, 0.0);
		}

		[Test]
		[TestCase(10)]
		[TestCase(-10.1)]
		public void TestChangeBalance(double balanceChange)
		{
			ChargeCard cardOne = new ChargeCard(0.0);
			cardOne.UpdateBalance(balanceChange);
			Assert.AreEqual(balanceChange, cardOne.CardBalance, 0.0);
		}

		//For the following tests, the rightAnswer variable is a 'hand-calculated' 
		//version of the interest calculation to check against the behavior 
		//of the object without needing to write seperate tests.
		[Test]
		[TestCase(100)]
		[TestCase(250)]
		[TestCase(243.52)]
		public void TestMasterCardInterest(double initialBalance)
		{
			MasterCard masterCard = new MasterCard(initialBalance);
			var rightAnswer = initialBalance * .05;
			Assert.AreEqual(rightAnswer, masterCard.CalculateThisMonthsInterest(), 0.0);
		}

		[Test]
		[TestCase(100)]
		[TestCase(250)]
		[TestCase(243.52)]
		public void TestDiscoverCardInterest(double initialBalance)
		{
			DiscoverCard discoverCard = new DiscoverCard(initialBalance);
			var rightAnswer = initialBalance * .01;
			Assert.AreEqual(rightAnswer, discoverCard.CalculateThisMonthsInterest(), 0.0);
		}

		[Test]
		[TestCase(100)]
		[TestCase(250)]
		[TestCase(243.52)]
		public void TestVisaCardInterest(double initialBalance)
		{
			VisaCard visaCard = new VisaCard(initialBalance);
			var rightAnswer = initialBalance * .10;
			Assert.AreEqual(rightAnswer, visaCard.CalculateThisMonthsInterest(), 0.0);
		}

		[TearDown]
		public void TearDownTests()
		{
			//TearDown items go here.
		}
    }
}
