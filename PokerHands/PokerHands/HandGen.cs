using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class HandGen
    {
        // Given a Deck, I want to return 2 hands

        public IList<Card[]> Generate(Deck deck)
        {
            var rand = new Random();

            var knownCards = deck.Cards.ToList();
            var cardsInPlay = new List<Card[]>();

            for (int x = 0; x < 2; x++)
            {
                Card[] hand = new Card[5];

                for (int i = 0; i < 5; i++)
                {
                    var cardIndex = rand.Next(0, knownCards.Count);
                    var randomCard = knownCards[cardIndex];
                    hand[i] = randomCard;
                    knownCards.RemoveAt(cardIndex);
                }

                cardsInPlay.Add(hand);
            }


            return cardsInPlay;
        }

    }
}