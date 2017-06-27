using System.Linq;

namespace PokerHands
{
    
    public class HandValue
    {
       public int HandType { get; }
       public string HighCard { get; }

        public Card[] Cards { get; }

        public HandValue(int handType,Card[] cards)
        {
            HandType = handType;
            HighCard = cards.Last().Value;
            Cards = cards;
        }


    }

}