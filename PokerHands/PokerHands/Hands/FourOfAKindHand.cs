namespace PokerHands
{
    public class FourOfAKindHand : HandValue
    {

        public Card[] QuadSet { get; }
        public FourOfAKindHand(Card[] cards, Card[] quadPair ) : base(cards)
        {
            QuadSet = quadPair;
        }
    }


}