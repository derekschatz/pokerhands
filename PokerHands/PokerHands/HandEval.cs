using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    
    public class HandEval
    {
        private List<string> numbers = Deck.OrderedNumbers.ToList();


        public HandValue Evaluate(Card[] cards)
        {
            int matchCount = GetMatchCount(cards);

            var allSuitAreSame = cards.All(c => c.Suit == cards[0].Suit);

            if (matchCount == 4)
            {
                return allSuitAreSame ?
                    new HandValue(HandType.StraightFlush, cards) 
                    : new HandValue(HandType.Straight, cards);
            }

            if (allSuitAreSame)
            {
                return new HandValue(HandType.Flush, cards);
            }

            var numbersAreSame = cards.GroupBy(e => e.Value);

            var numberOfPairs = numbersAreSame.Count(pairs => pairs.Count() == 2);

            var isThreeOfAKind = numbersAreSame.Count(pairs => pairs.Count() == 3) == 1;

            if (isThreeOfAKind && numberOfPairs == 1)
            {
                return new HandValue(HandType.FullHouse, cards);
            }

            if (numberOfPairs == 1)
            {
                return new HandValue(HandType.Pair, cards);
            }

            if (numberOfPairs == 2)
            {
                return new HandValue(HandType.TwoPair, cards);
            }

            if (numbersAreSame.Count(pairs => pairs.Count() == 4) == 1)
            {
                return new HandValue(HandType.FourOfAKind, cards);
            }

            if (isThreeOfAKind)
            {
                return new HandValue(HandType.ThreeOfAKind, cards);
            }

            return new HandValue(HandType.HighCard, cards);
        }

        private int GetMatchCount(Card[] cards)
        {
            var matchCount = 0;

            for (int a = 0; a < 4; a++)
            {
                var index = numbers.IndexOf(cards[a].Value);
                var index2 = numbers.IndexOf(cards[a + 1].Value);

                if (index == index2 - 1)
                {
                    matchCount++;
                }
            }

            return matchCount;
        }
    }

}