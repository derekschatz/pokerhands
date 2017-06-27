using System.Collections.Generic;
using System.Linq;
using System;

namespace PokerHands
{
    public class HandEval
    {
        public HandValue Evaluate(Card[] cards)
        {
            var allSuitAreSame = cards.All(c => c.Suit == cards[0].Suit);

            var numbers = Deck.OrderedNumbers.ToList();

            var matchCount = 0;
            for (int a = 0; a < 4; a++)
            {
                var index = numbers.IndexOf(cards[a].Value);
                var index2 = numbers.IndexOf(cards[a + 1].Value);

                if(index == index2 - 1)
                { 
                    matchCount++;
                }

            }
            if(matchCount == 4)
            {
                return new HandValue(9, cards[4].Value);
            }


            throw new NotImplementedException();
        }

    }

}