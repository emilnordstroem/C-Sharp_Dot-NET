
using CardDeck;
using PokerParticipant;

public class Program
{
	static void Main(string[] args)
	{
		Console.Out.WriteLine("=============================");
		Console.Out.WriteLine("Poker2026");
		Console.Out.WriteLine("_____________________________");

		Console.Out.WriteLine("What is your name?");
		string name = Console.ReadLine();
		Console.Out.WriteLine("How much money do you bring to the table?");
		double balance = double.Parse(Console.ReadLine());
		Player player = new Player(name, balance);
		Console.Out.WriteLine("_____________________________");

		while (true)
		{
			Deck deck = new Deck();
			deck.Shuffle();

			Console.Out.WriteLine("=============================");
			Console.Out.WriteLine($"Turn: {player.ToString()}");
			Console.Out.WriteLine("_____________________________");
			
			player.AddCardToHand(deck.getCard());
			player.AddCardToHand(deck.getCard());
			Console.Out.WriteLine("=============================");
			Console.Out.WriteLine($"Turn: {player.ToString()}");
			Console.Out.WriteLine("_____________________________");

			player.ClearHand();

			Console.Out.WriteLine("Are you still interested in playing? - yes, no");
			string responds = Console.ReadLine();
			if (responds.ToLower() == "no")
			{
				break;
			}
		}

		



	}
}

