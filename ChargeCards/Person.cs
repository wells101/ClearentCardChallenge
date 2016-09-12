using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeCards
{
	/// <summary>
	/// A person holds a collection of Wallets.  They can also attempt to figure out the amount of interest they owe.
	/// </summary>
	public class Person
	{
		protected List<Wallet> myWallets = new List<Wallet>();

		/// <summary>
		/// Add a wallet to this person's collection.
		/// </summary>
		/// <param name="addedWallet">The wallet to add.</param>
		public void AddWallet(Wallet addedWallet)
		{
			myWallets.Add(addedWallet);
		}

		/// <summary>
		/// If we don't specify a wallet, add it to the default wallet.
		/// </summary>
		/// <param name="addedCard">a StoredValueCard to add to the wallet.</param>
		public void AddCard(StoredValueCard addedCard)
		{
			myWallets[0].AddCard(addedCard);
		}

		/// <summary>
		/// Try to add a card to a wallet.  If its not found, add it to the wallet in position 0.
		/// </summary>
		/// <param name="walletId">Which wallet to add the card to</param>
		/// <param name="addedCard">The card to add to the wallet.</param>
		public void AddCard(int walletId, StoredValueCard addedCard)
		{
			try
			{
				myWallets[walletId].AddCard(addedCard);
			}
			catch (IndexOutOfRangeException)
			{
				myWallets[0].AddCard(addedCard);
			}
		}

		public List<WalletInterestResults> CalculateMyInterest()
		{

			var allResults = new List<WalletInterestResults>();

			foreach(var wallet in myWallets)
			{
				var currentResults = new WalletInterestResults();

				for (int i = 0; i < wallet.GetCardCount(); i++)
				{
					//double cardInterest = wallet.GetCard(i).CalculateThisMonthsInterest();
					var currentCard = wallet.GetCard(i);
					var cardResults = new CardInterestResults();
					cardResults.CardName = currentCard.ToString();
					cardResults.CurrentBalance = currentCard.CardBalance;
					cardResults.InterestAmount = currentCard.CalculateThisMonthsInterest();
					currentResults.CardResults.Add(cardResults);
				}
				currentResults.TotalInterest = currentResults.CardResults.Sum(x => x.InterestAmount);
				allResults.Add(currentResults);

			}

			return allResults;
		}

	}
}