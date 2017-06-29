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
                  (HandValue)  new StraightFlushHand(cards) 
                    : new StraightHand(cards);
            }

            if (allSuitAreSame)
            {
                return new FlushHand(cards);
            }

            var numbersAreSame = cards.GroupBy(e => e.Value);

            var doubles = numbersAreSame.Where(pairs => pairs.Count() == 2).ToArray();

            var triples = numbersAreSame.Where(pairs => pairs.Count() == 3).ToArray();

            var quadruples = numbersAreSame.Where(pairs => pairs.Count() == 4).ToArray();

            if (triples.Length ==1 && doubles.Length == 1)
            {
                Card[] foundTriple = triples.First().ToArray();
                Card[] foundDouble = doubles.First().ToArray();
                return new FullHouseHand(cards, foundTriple,foundDouble);
            }

            if (doubles.Length == 1)
            {
                Card[] foundDouble = doubles.First().ToArray();
                return new PairHand(cards, foundDouble);
            }

            if (doubles.Length == 2)
            {
                Card[] foundLowestPair = doubles.First().ToArray();
                Card[] foundHighestPair = doubles.Last().ToArray();
                return new TwoPairHand(cards, foundHighestPair, foundLowestPair);
            }

            if (quadruples.Length == 1)
            {
                Card[] foundQuad = quadruples.First().ToArray();
                return new FourOfAKindHand(cards, foundQuad);
            }

            if (triples.Length ==1)
            {
                Card[] foundTriple = triples.First().ToArray();
                return new ThreeOfAKindHand(cards, foundTriple);
            }
            
            return new HighCardHand(cards);
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