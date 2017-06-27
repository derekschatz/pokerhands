using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class HandGen
    {
        Random rand = new Random();
        

        public IList<Card[]> Generate(Deck deck)
        {
            Card[] Sort(Card[] cards)
            {
                return cards.OrderBy(card => NumberMapper.NumberMapping[card.Value]).ToArray();
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