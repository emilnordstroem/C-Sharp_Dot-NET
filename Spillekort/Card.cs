using System;
using System.Collections.Generic;
using System.Text;
using static Spillekort.Card;

namespace Spillekort
{
    public class Card
    {
        public Card(Suit suit, Number number)
        {
            Suit = suit;
            Number = number;
        }
        public Suit Suit { get; set; }
        public Number Number { get; set; }

        public override string ToString()
        {
            return $"[{Suit} : {Number}]";
        }

		public delegate bool FilterCardDelegate(Card card);
	}

	public enum Suit
    {
        Club = 1,
        Diamond = 2,
        Heart = 3,
        Spade = 4
    }

	public enum Number
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

	public class DeckOfCards
    {
        public DeckOfCards()
        {
            Deck = new Stack<Card>();
        }
        
        public Stack<Card> Deck { get; set; }
        public void AddCard(Suit suit, Number number)
        {
            Deck.Push(new Card(suit, number));
        }
        public Stack<Card> FilterDeck(FilterCardDelegate filter)
        {
            return new Stack<Card>(Deck.Where(card => filter(card)));
        }
    }

}
