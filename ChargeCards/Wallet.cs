using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeCards
{
	//Wallet could belong to a class of "MoneyContainers" which belongs to "Containers"
	//I'm skipping it to keep the solution smaller in size.

	/// <summary>
	///	Represents a Wallet carried by a person, conceptually a discrete collection of StoredValueCards
	/// </summary>
	public class Wallet
	{
		protected string walletName { get; set; }
		protected List<StoredValueCard> myCards { get; set; }

		public Wallet()
		{
			myCards = new List<StoredValueCard>();
		}

		public void AddCard(StoredValueCard card)
		{
			myCards.Add(card);
		}

		//Should have a way to remove cards as well, based on some criteria related to StoredValueCards

		public double GetCardCount()
		{
			return myCards.Count;
		}
		public StoredValueCard GetCard(int index)
		{
			return myCards[index];
		}
	}

	public class WalletInterestResults
	{
		public List<CardInterestResults> CardResults = new List<CardInterestResults>();
		public double TotalInterest { get; set; }
	}
	public class CardInterestResults
	{
		public string CardName { get; set; }
		public double InterestAmount { get; set; }
		public double CurrentBalance { get; set; }
	}
}
