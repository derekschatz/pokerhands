namespace PokerHands
{
    public class ThreeOfAKindHand : HandValue
    {
        public Card[] TripleSet { get; }
        public ThreeOfAKindHand(Card[] cards,Card[] triple) : base(cards)
        {
            TripleSet = triple;
        }
    }


}