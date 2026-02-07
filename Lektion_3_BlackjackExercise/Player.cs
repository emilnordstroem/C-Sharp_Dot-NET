
using CardDeck;

namespace Participant
{

	internal class Player
    {
        private List<Card> hand = new List<Card>();
        public Player (string name, int balance)
        {
            Name = name;
            Balance = balance;
        }

        public string Name { get; set; }
        public int Balance { get; set; }
        public List<Card> Hand { get { return new List<Card>(hand); } set; }
        public void AddCardToHand(Card card) { hand.Add(card); }
        public int CalculateValueOfHand() 
        {
            int value = 0;
            foreach (Card card in hand)
            {
                int rank = (int)card.Rank;

				if (rank > 10)
                {
                    if (IsAceCardPresent())
                    {
                        value += 20;
                    }
                    else
                    {
						value += 10;
					}
				}
                else if (rank == 1 && IsCourtCardPresent())
                {
                    value += 11;
                }
                else
                {
                    value += rank;
                }
            }
            return value;
        }
        public bool IsCourtCardPresent()
        {
            foreach (Card card in hand)
            {
                if ((int)card.Rank > 10)
                {
                    return true;
                }
            }
            return false;
		}
        public bool IsAceCardPresent()
        {
			foreach (Card card in hand)
			{
				if ((int)card.Rank == 1)
				{
					return true;
				}
			}
            return false;
		}
        public void ClearHand () { hand.Clear(); }
        public override string ToString()
        {
            return $"Player: {Name} [${Balance}]";
        }
    }

    internal class Dealer
	{

    }

}
