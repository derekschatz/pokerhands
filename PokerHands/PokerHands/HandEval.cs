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
                return allSuitAreSame ? new HandValue(9, cards) : new HandValue(5, cards);
            }

            if (allSuitAreSame)
            {
                return new HandValue(6, cards);
            }

            var numbersAreSame = cards.GroupBy(e => e.Value);

            var numberOfPairs = numbersAreSame.Count(pairs => pairs.Count() == 2);

            var isThreeOfAKind = numbersAreSame.Count(pairs => pairs.Count() == 3) == 1;

            if (isThreeOfAKind && numberOfPairs == 1)
            {
                return new HandValue(7, cards);
            }

            if (numberOfPairs == 1)
            {
                return new HandValue(2, cards);
            }

            if (numberOfPairs == 2)
            {
                return new HandValue(3, cards);
            }

            if (numbersAreSame.Count(pairs => pairs.Count() == 4) == 1)
            {
                return new HandValue(8, cards);
            }

            if (isThreeOfAKind)
            {
                return new HandValue(4, cards);
            }

            return new HandValue(1, cards);
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