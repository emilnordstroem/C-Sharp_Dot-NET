using System;
using System.Collections.Generic;
using System.Text;

using CardDeck;

namespace Participant
{

    internal abstract class Person
    {
		private List<Card> hand = new List<Card>();

		public void AddCardToHand(Card card) { hand.Add(card); }
		public List<Card> SeeHand() { return hand; }
		public void ClearHand() { hand.Clear(); }
	}

	internal class Player : Person
	{
        public Player(string name, int balance) 
        {
            Name = name;
            Balance = balance;
        }

        public string Name { get; set; }
        public int Balance { get; set; }

        public override string ToString()
        {
            return $"Player: {Name}";
        }
	}

    internal class House : Person
	{
		public override string ToString()
		{
			return $"House";
		}
	}

}
