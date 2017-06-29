using System.Linq;

namespace PokerHands
{
    public abstract class HandValue
    {
        public Card[] Cards { get; }

        public Card HighCard { get; }

        public HandValue(Card[] cards)
        {
            Cards = cards;
            HighCard = cards.Last();
        }
    }
}