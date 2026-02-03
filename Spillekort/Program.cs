

using Spillekort;

public class Program
{

    static void Main(string[] args)
    {
        DeckOfCards deck = new DeckOfCards();
		deck.AddCard(Suit.Heart, Number.Eight);
		deck.AddCard(Suit.Club, Number.Jack);
		deck.AddCard(Suit.Diamond, Number.Queen);
		deck.AddCard(Suit.Spade, Number.Ace);

		Console.Out.WriteLine(string.Join(",", deck.FilterDeck(FilterByClubs)));
		Console.Out.WriteLine(string.Join(",", deck.FilterDeck(FilterByCourt)));
		Console.Out.WriteLine(string.Join(",", deck.FilterDeck(FilterByNonCourt)));
	}

	static public bool FilterByClubs(Card card)
    {
        return card.Suit == Suit.Club;
    }

	static public bool FilterByCourt(Card card)
	{
		return card.Number == Number.Jack
			|| card.Number == Number.Queen
			|| card.Number == Number.King;
	}

	static public bool FilterByNonCourt(Card card)
	{
		return card.Number != Number.Jack 
            && card.Number != Number.Queen 
            && card.Number != Number.King;
	}

}