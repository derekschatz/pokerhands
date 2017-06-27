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
}