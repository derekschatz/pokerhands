namespace PokerHands
{
    public class TwoPairHand : HandValue
    {
        
        public Card[] HighestPair { get; }
        public Card[] LowestPair { get; }

        public TwoPairHand(Card[] cards, Card[] highPair, Card[] lowPair) : base(cards)
        {
            HighestPair = highPair;
            LowestPair = lowPair;
        }
    }


}