using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeCards
{
	//Dumb Note: Don't actually use this class on its own.  You'll forget later.
	/// <summary>
	/// Abstract class representing a StoredValueCard, responsible for managing its balance.
	/// Prefers to make balance changes on its own.
	/// </summary>
	public abstract class StoredValueCard
	{
		//Nobody can modify a card balance unless you're a card.
		//Others can see it.
		public double CardBalance { get; protected set; }

		//Nobody that's not a card can modify their interest rate.
		protected double InterestRate { get; set; }

		public StoredValueCard(double initialBalance)
		{
			CardBalance = initialBalance;
			InterestRate = 0;
		}

		public StoredValueCard(double initialBalance, double initialInterest)
		{
			CardBalance = initialBalance;
			InterestRate = initialInterest;
		}

		/// <summary>
		/// Calculate this month's interest.
		/// </summary>
		/// <returns>The amount of this month's interest.</returns>
		public abstract double CalculateThisMonthsInterest();

		public virtual void UpdateBalance(double balanceAdjustment)
		{
			CardBalance += balanceAdjustment;
		}	
	}

	/// <summary>
	/// Represents a Gift Card, likely without interest. Providing a negative interest
	/// will cause the card's value to depricate every month.
	/// </summary>
	public class GiftCard : StoredValueCard
	{
		public GiftCard(double initialBalance) : base (initialBalance, 0.0)
		{
		}

		public override double CalculateThisMonthsInterest()
		{
			return CardBalance * InterestRate;
		}
	}

	/// <summary>
	/// Represents a charge card, potentially with the need to calculate interest.
	/// </summary>
	public class ChargeCard : StoredValueCard
	{
		public ChargeCard(double initialBalance) : base(initialBalance)
		{
		}

		public override double CalculateThisMonthsInterest()
		{
			return CardBalance * InterestRate;
		}

		public override void UpdateBalance(double balanceAdjustment)
		{
			CardBalance += balanceAdjustment;
		}
	}

	//Each TYPE of ChargeCard gets its own class, as in the future they may receive rules
	//that necessitate the overriding of certain rules, like calculating monthly balance
	//or changing interest based on balance.  For example, MasterCard will adjust your
	//interest mid-month if your balance goes under $250.
	
	#region Concrete ChargeCard Classes
	public class MasterCard : ChargeCard
	{
		public MasterCard(double initialBalance) : base (initialBalance)
		{
			InterestRate = .05;
		}

		public override string ToString()
		{
			return "MasterCard";
		}
	}

	public class DiscoverCard : ChargeCard
	{
		public DiscoverCard(double initialBalance) : base(initialBalance)
		{
			InterestRate = .01;
		}

		public override string ToString()
		{
			return "Discover Card";
		}
	}

	public class VisaCard : ChargeCard
	{
		public VisaCard(double initialBalance) : base(initialBalance)
		{
			InterestRate = .10;
		}

		public override string ToString()
		{
			return "Visa Card";
		}
	}
	#endregion
}
