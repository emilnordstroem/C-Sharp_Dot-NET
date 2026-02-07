using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
	internal class Deck
	{
		private Stack<Card> deckOfCards = new Stack<Card>();
		public Deck()
		{
			deckOfCards = CreateDeckOfCards();
		}

		public Stack<Card> DeckOfCards
		{
			get { return deckOfCards; }
		}

		private Stack<Card> CreateDeckOfCards()
		{
			Stack<Card> deckOfCards = new Stack<Card>();

			int currentCardSymbol = 1;
			while (currentCardSymbol <= 4)
			{
				int currentCardRank = 1;
				int cardRankLimit = 13;
				while (currentCardRank <= cardRankLimit)
				{
					Ranks rank = (Ranks)currentCardRank;
					Symbols symbol = (Symbols)currentCardSymbol;

					deckOfCards.Push(new Card(rank, symbol));

					currentCardRank++;
				}
				currentCardSymbol++;
			}

			return deckOfCards;
		}

		public void Shuffle()
		{
			deckOfCards = (Stack<Card>)deckOfCards.Shuffle();
		}

		public Card getCard()
		{
			return deckOfCards.Pop();
		}

		public override string ToString()
		{
			return string.Join(", ", deckOfCards.Select(card => card.ToString()));
		}

	}

	internal enum Ranks
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

	internal enum Symbols
	{
		Spades = 1,
		Hearts = 2,
		Diamonds = 3,
		Clubs = 4
	}

	internal class Card
	{

		public Card(Ranks rank, Symbols symbol)
		{
			Rank = rank;
			Symbol = symbol;
		}

		public Ranks Rank { get; set; }
		public Symbols Symbol { get; set; }

		public override string ToString()
		{
			return $"[{Symbol}:{Rank}]";
		}

	}

}
