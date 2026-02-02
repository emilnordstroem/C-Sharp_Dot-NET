
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using CardDeck;
using Participant;

public class Program
{
	static void Main(string[] args)
	{
		Console.Out.WriteLine("=========================================");
		Console.Out.WriteLine($"Blackjack 2026");
		Console.Out.WriteLine("_________________________________________");

		Console.Out.WriteLine($"What is your name?");
		string name = Console.ReadLine();
		Console.Out.WriteLine($"How much money ($) are you bringing to the table?");
		int balance = int.Parse(Console.ReadLine());
		Player player = new Player(name, balance);

		Console.Out.WriteLine("_________________________________________");
		Console.Out.WriteLine("Let's get started...");
		Console.Out.WriteLine("_________________________________________");

		House house = new House();
		Deck deck = new Deck();

		List<Person> participant = [house, player];

		while (true)
		{
			try
			{
				int placedBet = PlaceBet(ref player);
			}
			catch (InvalidDataException error)
			{
				Console.Out.WriteLine(error.Message);
				PlaceBet(ref player);
			}

			while (true)
			{
				DistributeCards(ref participant, ref deck);
				CheckValue(ref participant);
				bool selectOption = SelectOption(player);
				if (!selectOption)
				{
					break;
				}
			}

			Console.Out.WriteLine("Do you want to continue playing? - yes/no");
			string responds = Console.ReadLine();
			if (responds.ToLower() == "no")
			{
				break;
			}
		}
		Console.Out.WriteLine("_________________________________________");
		Console.Out.WriteLine($"You started ${balance}...");
		Console.Out.WriteLine($"and you are exiting with ${player.Balance}");
		Console.Out.WriteLine("=========================================");
	}

	static int PlaceBet (ref Player player)
	{
		Console.Out.WriteLine($"Place a bet");
		Console.Out.WriteLine($"Limit: ${player.Balance}");
		int placedBet = int.Parse(Console.ReadLine());

		if (placedBet > player.Balance)
		{
			throw new InvalidDataException($"Placed bet must be below ${player.Balance}");
		}
		player.Balance -= placedBet;
		return placedBet;
	}

	static void DistributeCards (ref List<Person> participants, ref Deck deck)
	{
		foreach (Person participant in participants)
		{
			participant.AddCardToHand(deck.getCard());
			List<Card> hand = participant.SeeHand();
			Console.Out.WriteLine("_________________________________________");
			Console.Out.WriteLine(participant.ToString());
			Console.Out.WriteLine($"Hand: {string.Join("|", hand.Select(card => card.ToString()))}");
			Console.Out.WriteLine("_________________________________________");
		}
	}

	static void CheckValue (ref List<Person> participants)
	{
		foreach (Person participant in participants)
		{
			int valueOfHand = participant.ValueOfHand();
			Console.Out.WriteLine("_________________________________________");
			Console.Out.WriteLine(participant.ToString());
			Console.Out.WriteLine($"Value: {valueOfHand}");
			Console.Out.WriteLine("_________________________________________");
		}
	}

	static bool SelectOption(Player player)
	{
		int valueOfHand = player.ValueOfHand();
		if (valueOfHand < 21)
		{
			Console.Out.WriteLine("_________________________________________");
			Console.Out.WriteLine(player.ToString());
			Console.Out.WriteLine("Choose an option: Hit (1), Stand(2)");
			string responds = Console.ReadLine();
			if (responds == "1") 
			{ 
				return true; 
			}
			else 
			{ 
				return false; 
			}
		}
		else if (valueOfHand == 21)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

}

