
using CardDeck;
using Participant;

public class Program
{
	private static Deck cardDeck = new Deck();

	private static Dictionary<Player, int> players = new Dictionary<Player, int>();
	private static List<Player> activePlayersInCurrentRound = new List<Player>();

	static void Main(string[] args)
	{
		Console.Out.WriteLine("====================");
		Console.Out.WriteLine("Blackjack 2026");
		Console.Out.WriteLine("____________________");

		RegisterPlayers();

		while (true)
		{
			PlaceBets();
			while (activePlayersInCurrentRound.Count > 0)
			{
				DistributeCards();
				SelectOptions();
			}

			Console.Out.WriteLine("____________________");
			Console.Out.WriteLine("Do you want to quit? - yes/no");
			string responds = Console.ReadLine();
			if (responds.ToLower() == "yes")
			{
				break;
			}
			ResetGame();
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
			while (balance <= 0)
			{
				Console.Out.WriteLine($"!! Illegal amount was entered !!");
				Console.Out.WriteLine("How much money do you bring to the table?");
				balance = int.Parse(Console.ReadLine());
			}
			Player player = new Player(name, balance);
			players.Add(player, 0);
			activePlayersInCurrentRound.Add(player);
			numberOfPlayers--;
		}
	}

	static void ResetGame()
	{
		activePlayersInCurrentRound.AddRange(players.Keys);
        foreach (Player player in players.Keys)
        {
			player.ClearHand();
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

			while (placedBet > player.Balance && placedBet <= 0)
			{
				Console.Out.WriteLine("____________________");
				Console.Out.WriteLine($"!! Illegal amount was entered !!");
				Console.Out.WriteLine($"{player.Name} enter your bet");
				Console.Out.WriteLine($"Maximum bet amount: ${player.Balance}");
				placedBet = int.Parse(Console.ReadLine());
			}

			Console.Out.WriteLine($"Bet of ${placedBet} has been placed");
			player.Balance -= placedBet;
			players[player] = placedBet;
		}
	}

	static void DistributeCards()
	{
		foreach (Player player in activePlayersInCurrentRound)
		{
			player.AddCardToHand(cardDeck.getCard());
		}
	}

	static void SelectOptions()
	{
		List<Player> playersThatStand = new List<Player>();
		foreach (Player player in activePlayersInCurrentRound)
        {
			ShowHand(player);
			int valueOfHand = player.CalculateValueOfHand();

			if (valueOfHand < 21)
			{
				Console.Out.WriteLine("Choose one of the following options:");
				Console.Out.WriteLine("Hit (1), Stand (2)");
				int responds = int.Parse(Console.ReadLine());
				if (responds == 2)
				{
					Console.Out.WriteLine("You choose to stand");
					playersThatStand.Add(player);
				}
			}
			else
			{
				Console.Out.WriteLine("You went over 21");
				playersThatStand.Add(player);
			}
			Console.Out.WriteLine("____________________");
		}
		foreach (Player player in playersThatStand)
		{
			activePlayersInCurrentRound.Remove(player);
		}
	}

	static void ShowHand(Player player)
	{
		Console.Out.WriteLine("____________________");
		Console.Out.WriteLine($"{player.ToString()} | Bet: ${players[player]}");
		Console.Out.WriteLine($"This is your hand: {string.Join("|", player.Hand)}");
		Console.Out.WriteLine($"Value of your hand: {player.CalculateValueOfHand()}");

	}

}

