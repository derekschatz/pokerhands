namespace PokerHands
{
    public class Card
    {
        public string value;
        public Suit suit;

        public Card(Suit suit2, string value2)
        {
            suit = suit2;
            value = value2;
        }
        public override string ToString()
        {
            return string.Format("{0}{1}", value, suit);
        }


    }
}