using System;

namespace PokerHands
{
    public class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            foreach(Card c in newDeck.Cards)
            {
                Console.WriteLine(c); 
            }

        }
    }

    public enum Suit
    {
        S,
        H,
        D,
        C
    }
    public class CardIdentifier
    {
        public Card cardReader(string input)
        {
            throw new NotImplementedException();
        }
    }
   

    public class HandEval
    {

    }
}