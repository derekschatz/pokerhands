namespace PokerHands
{
    public class Card
    {
        public string Value { get;  }
        public Suit Suit { get;  }

        public Card(Suit suit2, string value2)
        {
            Suit = suit2;
            Value = value2;
        }
        public override string ToString()
        {
            return string.Format("{0}{1}", Value, Suit);
        }
    }
}