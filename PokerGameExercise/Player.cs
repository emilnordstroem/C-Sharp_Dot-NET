using System;
using System.Collections.Generic;
using System.Text;

using CardDeck;

namespace PokerParticipant
{
    internal class Player
    {
        private List<Card> hand = new List<Card>();

        public Player (string name, double balance) 
        {
            Name = name;
            Balance = balance;
        }

        public string Name { get; set; }
        public double Balance { get; set; }

        public void AddCardToHand (Card card) 
        {
			hand.Add(card);
		}
		public List<Card> SeeHand() { return hand; }
		public void ClearHand() { hand.Clear(); }

        public override string ToString()
        {
            return $"Player: {Name} [${Balance}] | Hand: {string.Join(", ", hand.Select(card => card.ToString()))}";
        }
	}

}
