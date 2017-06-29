namespace PokerHands
{
    public class FullHouseHand : HandValue
    {
        public Card[] ThreeOfAKindCards { get; }
        public Card[] PairSet { get; }

        public FullHouseHand(Card[] cards, Card[] triple, Card[] pair) : base(cards)
        {
            ThreeOfAKindCards = triple;
            PairSet = pair;

        }
    }
}