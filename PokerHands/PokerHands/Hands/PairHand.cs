namespace PokerHands
{
    public class PairHand : HandValue
    {
        public Card[] PairSet { get; }

        public PairHand(Card[] cards, Card []  pair) : base(cards)
        {
            PairSet = pair;
        }
    }


}