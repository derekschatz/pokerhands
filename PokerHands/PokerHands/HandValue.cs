using System.Linq;

namespace PokerHands
{
    public class HandValue
    {
        public HandType HandType { get; }
        public string HighCard { get; }

        public Card[] Cards { get; }

        public HandValue(HandType handType, Card[] cards)
        {
            HandType = handType;
            HighCard = cards.Last().Value;
            Cards = cards;
        }
    }
}