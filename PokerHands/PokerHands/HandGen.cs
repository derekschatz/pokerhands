using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class HandGen
    {
        Random rand = new Random();
        Dictionary<string, int> numberMapping = new Dictionary<string, int>
            {
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "T", 10 },
                { "J", 11 },
                { "Q", 12 },
                { "K", 13 },
                { "A", 14 }
            };

        public IList<Card[]> Generate(Deck deck)
        {
            Card[] Sort(Card[] cards)
            {
                return cards.OrderBy(card => numberMapping[card.Value]).ToArray();
            }
            
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

                cardsInPlay.Add(Sort(hand));
            }

            return cardsInPlay;
        }
    }
}