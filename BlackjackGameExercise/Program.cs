
using CardDeck;
using Participant;

public class Program
{
	private static Deck cardDeck = new Deck();

	private static Dictionary<Player, int> players = new Dictionary<Player, int>();

	static void Main(string[] args)
	{
		Console.Out.WriteLine("====================");
		Console.Out.WriteLine("Blackjack 2026");
		Console.Out.WriteLine("____________________");

		RegisterPlayers();

		while (true)
		{
			PlaceBets();

		}


	}

	static void RegisterPlayers()
	{
		Console.Out.WriteLine("How many players will participate?");
		int numberOfPlayers = int.Parse(Console.ReadLine());

		while (numberOfPlayers > 0)
		{
			Console.Out.WriteLine("____________________");
			Console.Out.WriteLine("Enter your name?");
			string name = Console.ReadLine();
			Console.Out.WriteLine("How much money do you bring to the table?");
			int balance = int.Parse(Console.ReadLine());
			
			players.Add(new Player(name, balance), 0);
			numberOfPlayers--;
		}
	}

	static void PlaceBets()
	{
		foreach (Player player in players.Keys)
		{
			Console.Out.WriteLine("____________________");
			Console.Out.WriteLine($"{player.Name} enter your bet");
			Console.Out.WriteLine($"Maximum bet amount: ${player.Balance}");
			int placedBet = int.Parse(Console.ReadLine());

			while (placedBet > player.Balance)
			{
				Console.Out.WriteLine("____________________");
				Console.Out.WriteLine($"!! Illegal amount was entered !!");
				Console.Out.WriteLine($"{player.Name} enter your bet");
				Console.Out.WriteLine($"Maximum bet amount: ${player.Balance}");
				placedBet = int.Parse(Console.ReadLine());
			}

			Console.Out.WriteLine($"Bet of ${placedBet} has been placed");
			players[player] = placedBet;
		}
	}


}

