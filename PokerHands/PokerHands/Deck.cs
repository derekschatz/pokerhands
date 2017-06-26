namespace PokerHands
{
    public class Deck
    {
        Card[] cards = new Card[52];
        string[] numbers = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public Deck()
        {
            int x = 0;
            foreach (string s in numbers)
            {
                cards[x] = new Card(Suit.C, s);
                x++;
            }
            foreach (string s in numbers)
            {
                cards[x] = new Card(Suit.D, s);
                x++;
            }
            foreach (string s in numbers)
            {
                cards[x] = new Card(Suit.H, s);
                x++;
            }
            foreach (string s in numbers)
            {
                cards[x] = new Card(Suit.S, s);
                x++;
            }
        }

        public Card[] Cards
        {
            get
            {
                return cards;
            }
        }
    }
}