using NUnit.Framework;
using ChargeCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeCardTests
{
	[TestFixture]
	public class WalletTests
	{

		[SetUp]
		public void SetUpTests()
		{
			//Setup items go here.
		}

		[Test]
		public void TestAddCard()
		{
			//Test included to make sure list initializes properly.
			var myWallet = new Wallet();
			myWallet.AddCard(new MasterCard(100.0));
			Assert.AreEqual(1, myWallet.GetCardCount());
		}
	}
}
