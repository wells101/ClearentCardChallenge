using ChargeCards;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeCardTests
{
	public class ChallengeTestCases
	{
		[Test]
		public void TestCaseOne()
		{
			//Test case. One person, one wallet, three cards (MC, DISCOVER< VISA)
			var testPerson = new Person();
			var testMC = new MasterCard(100.00);
			var testVisa = new VisaCard(100.00);
			var testDiscover = new DiscoverCard(100.00);
			var myWallet = new Wallet();
			myWallet.AddCard(testMC);
			myWallet.AddCard(testVisa);
			myWallet.AddCard(testDiscover);
			testPerson.AddWallet(myWallet);

			var results = testPerson.CalculateMyInterest();
			Assert.AreEqual(16.0, results.Sum(x => x.TotalInterest), 0.0);
			Assert.AreEqual(5.0, results[0].CardResults[0].InterestAmount, 0.0);
		}

		[Test]
		public void TestCaseTwo()
		{
			var testPerson = new Person();
			var testWallet1 = new Wallet();
			var testWallet2 = new Wallet();

			var testMC = new MasterCard(100.00);
			testWallet2.AddCard(testMC);

			var testVisa = new VisaCard(100.00);
			testWallet1.AddCard(testVisa);

			var testDiscover = new DiscoverCard(100.00);
			testWallet1.AddCard(testDiscover);

			testPerson.AddWallet(testWallet1);
			testPerson.AddWallet(testWallet2);

			var results = testPerson.CalculateMyInterest();
			Assert.AreEqual(16.0, results.Sum(x => x.TotalInterest), 0.0);
			Assert.AreEqual(11.0, results[0].TotalInterest, 0.0);
			Assert.AreEqual(5.0, results[1].TotalInterest, 0.0);
		}

		[Test]
		public void TestCaseThree()
		{
			var testPerson1 = new Person();

			testPerson1.AddWallet(new Wallet());
			testPerson1.AddCard(new MasterCard(100.0));
			testPerson1.AddCard(new MasterCard(100.0));
						
			var testPerson2 = new Person();
			testPerson2.AddWallet(new Wallet());
			testPerson2.AddCard(new MasterCard(100.0));
			testPerson2.AddCard(new VisaCard(100.0));

			var person1Results = testPerson1.CalculateMyInterest();
			var person2Results = testPerson2.CalculateMyInterest();

			Assert.AreEqual(10.0, person1Results.Sum(x => x.TotalInterest), 0.0);
			Assert.AreEqual(10.0, person1Results[0].TotalInterest, 0.0);

			Assert.AreEqual(15.0, person2Results.Sum(x => x.TotalInterest), 0.0);
			Assert.AreEqual(15.0, person2Results[0].TotalInterest, 0.0);

		}
	}
}
