using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeCards;
using NUnit.Framework;

namespace ChargeCardTests
{
	public class PersonTests
	{
		[SetUp]
		public void SetUp()
		{
			//Setup items go here.
		}

		[Test]
		public void TestOnePersonOneWalletOneCard()
		{
			var testPerson = new Person();
			var testCard = new MasterCard(100.0);
			var myWallet = new Wallet();
			myWallet.AddCard(testCard);
			testPerson.AddWallet(myWallet);

			var results = testPerson.CalculateMyInterest();
			Assert.AreEqual(5.0, results.Sum(x => x.TotalInterest), 0.0);
		}
	}
}
