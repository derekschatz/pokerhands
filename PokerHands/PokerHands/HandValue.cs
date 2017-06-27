namespace PokerHands
{
    public class HandValue
    {
       public int HandType { get; }
       public string HighCard { get; }

        public HandValue(int handType, string highCard)
        {
            HandType = handType;
            HighCard = highCard;
        }


    }

}