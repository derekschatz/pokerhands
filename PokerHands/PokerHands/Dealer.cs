using System;

namespace PokerHands
{
    public class Dealer
    {
        private static WinningHand EvaluateHighCard(HandValue hand1, HandValue hand2)
        {
            for (int i = 4; i >= 0; i--)
            {
                var val1 = NumberMapper.NumberMapping[hand1.Cards[i].Value];
                var val2 = NumberMapper.NumberMapping[hand2.Cards[i].Value];

                if (val1 > val2)
                {
                    return new WinningHand(hand1, Winner.Player1);
                }
                if (val1 < val2)
                {
                    return new WinningHand(hand2, Winner.Player2);
                }
            }
            return WinningHand.Draw;
        }

        private static WinningHand EvaluatePair(PairHand hand1, PairHand hand2)
        {
            var pairVal1 = NumberMapper.NumberMapping[hand1.PairSet[0].Value];
            var pairVal2 = NumberMapper.NumberMapping[hand2.PairSet[0].Value];


            if (pairVal1 > pairVal2)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (pairVal1 < pairVal2)
            {
                return new WinningHand(hand2, Winner.Player2);
            }

            return WinningHand.Draw;
        }

        private static WinningHand EvaluateTwoPair(TwoPairHand hand1, TwoPairHand hand2)
        {
            var hand1HP = NumberMapper.NumberMapping[hand1.HighestPair[0].Value];
            var hand2HP = NumberMapper.NumberMapping[hand2.HighestPair[0].Value];
            var hand1LP = NumberMapper.NumberMapping[hand1.LowestPair[0].Value];
            var hand2LP = NumberMapper.NumberMapping[hand1.LowestPair[0].Value];

            if (hand1HP > hand2HP)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand1HP < hand2HP)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1HP == hand2HP)
            {
                if (hand1LP > hand2LP)
                {
                    return new WinningHand(hand1, Winner.Player1);
                }
                if (hand1LP < hand2LP)
                {
                    return new WinningHand(hand2, Winner.Player2);
                }
                return WinningHand.Draw;

            }
            return WinningHand.Draw;
        }


        private static WinningHand EvaluateThreeOfAKind(ThreeOfAKindHand hand1, ThreeOfAKindHand hand2)
        {
            var tripVal1 = NumberMapper.NumberMapping[hand1.TripleSet[0].Value];
            var tripVal2 = NumberMapper.NumberMapping[hand2.TripleSet[0].Value];

            if (tripVal1 > tripVal2)
            {
                return new WinningHand(hand1, Winner.Player1);
            }

            return WinningHand.Draw;
        }

        private static WinningHand EvaluateStraight(StraightHand hand1, StraightHand hand2)
        {
            return EvaluateHighCard(hand1, hand2);
        }

        private static WinningHand EvaluateFlush(FlushHand hand1, FlushHand hand2)
        {
            return EvaluateHighCard(hand1, hand2);
        }

        private static WinningHand EvaluateFullHouse(FullHouseHand hand1, FullHouseHand hand2)
        {
            var fullHouseEval = EvaluateThreeOfAKind(new ThreeOfAKindHand(hand1.Cards, hand1.ThreeOfAKindCards), new ThreeOfAKindHand(hand2.Cards, hand2.ThreeOfAKindCards));

            if(fullHouseEval == WinningHand.Draw)
            {
                return EvaluatePair(new PairHand(hand1.Cards, hand1.PairSet), new PairHand(hand2.Cards, hand2.PairSet));
            }

            return fullHouseEval;
        }

        private static WinningHand EvaluateFourOfAKind(FourOfAKindHand hand1, FourOfAKindHand hand2)
        {
            var fourVal1 = NumberMapper.NumberMapping[hand1.QuadSet[0].Value];
            var fourVal2 = NumberMapper.NumberMapping[hand2.QuadSet[0].Value];

            if(fourVal1 > fourVal2)
            {
                return new WinningHand(hand1, Winner.Player1);
            }

            if (fourVal2 > fourVal1)
            {
                return new WinningHand(hand2, Winner.Player2);
            }

            return WinningHand.Draw;
        }

        private static WinningHand EvaluateStraightFlush(StraightFlushHand hand1, StraightFlushHand hand2)
        {
            return WinningHand.Draw;
        }

        private static WinningHand CompareByRank(HandValue hand1, HandValue hand2)
        {
            if (hand1 is PairHand && hand2 is HighCardHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is PairHand && hand1 is HighCardHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is TwoPairHand && hand2 is HighCardHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is TwoPairHand && hand1 is HighCardHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is TwoPairHand && hand2 is PairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is TwoPairHand && hand1 is PairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is ThreeOfAKindHand && hand2 is TwoPairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is ThreeOfAKindHand && hand1 is TwoPairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is ThreeOfAKindHand && hand2 is PairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is ThreeOfAKindHand && hand1 is PairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is ThreeOfAKindHand && hand2 is HighCardHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is ThreeOfAKindHand && hand1 is HighCardHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightHand && hand2 is ThreeOfAKindHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightHand && hand1 is ThreeOfAKindHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightHand && hand2 is TwoPairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightHand && hand1 is TwoPairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightHand && hand2 is HighCardHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightHand && hand1 is HighCardHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FlushHand && hand2 is StraightHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FlushHand && hand1 is StraightHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FlushHand && hand2 is ThreeOfAKindHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FlushHand && hand1 is ThreeOfAKindHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FlushHand && hand2 is TwoPairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FlushHand && hand1 is TwoPairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FlushHand && hand2 is PairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FlushHand && hand1 is PairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FlushHand && hand2 is HighCardHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FlushHand && hand1 is HighCardHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FullHouseHand && hand2 is FlushHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FullHouseHand && hand1 is FlushHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FullHouseHand && hand2 is StraightHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FullHouseHand && hand1 is StraightHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FullHouseHand && hand2 is ThreeOfAKindHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FullHouseHand && hand1 is ThreeOfAKindHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FullHouseHand && hand2 is TwoPairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FullHouseHand && hand1 is TwoPairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FullHouseHand && hand2 is PairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FullHouseHand && hand1 is PairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FullHouseHand && hand2 is HighCardHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FullHouseHand && hand1 is HighCardHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FourOfAKindHand && hand2 is FullHouseHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FourOfAKindHand && hand1 is FullHouseHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FourOfAKindHand && hand2 is FlushHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FourOfAKindHand && hand1 is FlushHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FourOfAKindHand && hand2 is StraightHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FourOfAKindHand && hand1 is StraightHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FourOfAKindHand && hand2 is ThreeOfAKindHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FourOfAKindHand && hand1 is ThreeOfAKindHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FourOfAKindHand && hand2 is TwoPairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FourOfAKindHand && hand1 is TwoPairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FourOfAKindHand && hand2 is PairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FourOfAKindHand && hand1 is PairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is FourOfAKindHand && hand2 is HighCardHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is FourOfAKindHand && hand1 is HighCardHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightFlushHand && hand2 is FourOfAKindHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightFlushHand && hand1 is FourOfAKindHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightFlushHand && hand2 is FullHouseHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightFlushHand && hand1 is FullHouseHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightFlushHand && hand2 is FlushHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightFlushHand && hand1 is FlushHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightFlushHand && hand2 is StraightHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightFlushHand && hand1 is StraightHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightFlushHand && hand2 is ThreeOfAKindHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightFlushHand && hand1 is ThreeOfAKindHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightFlushHand && hand2 is TwoPairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightFlushHand && hand1 is TwoPairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightFlushHand && hand2 is PairHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightFlushHand && hand1 is PairHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            if (hand1 is StraightFlushHand && hand2 is HighCardHand)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2 is StraightFlushHand && hand1 is HighCardHand)
            {
                return new WinningHand(hand2, Winner.Player2);
            }
            return WinningHand.Draw;
        }

        public static WinningHand DetermineWinner(HandValue hand1, HandValue hand2)
        {
            WinningHand wonByRank = CompareByRank(hand1,hand2);

            if(wonByRank.Winner != Winner.Draw)
            {
                return wonByRank;
            }

            var wonByHandComparison = WinningHand.Draw;
            if(hand1 is PairHand && hand2 is PairHand)
            {
                wonByHandComparison = EvaluatePair(hand1 as PairHand, hand2 as PairHand);
            }
            if (hand1 is TwoPairHand && hand2 is TwoPairHand)
            {
                wonByHandComparison = EvaluateTwoPair(hand1 as TwoPairHand, hand2 as TwoPairHand);
            }
            if (hand1 is ThreeOfAKindHand && hand2 is ThreeOfAKindHand)
            {
                wonByHandComparison = EvaluateThreeOfAKind(hand1 as ThreeOfAKindHand, hand2 as ThreeOfAKindHand);
            }
            if (hand1 is StraightHand && hand2 is StraightHand)
            {
                wonByHandComparison = EvaluateStraight(hand1 as StraightHand, hand2 as StraightHand);
            }
            if (hand1 is FlushHand && hand2 is FlushHand)
            {
                wonByHandComparison = EvaluateFlush(hand1 as FlushHand, hand2 as FlushHand);
            }
            if (hand1 is FullHouseHand && hand2 is FullHouseHand)
            {
                wonByHandComparison = EvaluateFullHouse(hand1 as FullHouseHand, hand2 as FullHouseHand);
            }
            if (hand1 is FourOfAKindHand && hand2 is FourOfAKindHand)
            {
                wonByHandComparison = EvaluateFourOfAKind(hand1 as FourOfAKindHand, hand2 as FourOfAKindHand);
            }
            if (hand1 is StraightFlushHand && hand2 is StraightFlushHand)
            {
                wonByHandComparison = EvaluateStraightFlush(hand1 as StraightFlushHand, hand2 as StraightFlushHand);
            }
            if (wonByHandComparison.Winner != Winner.Draw)
                return wonByHandComparison;
                
            return EvaluateHighCard(hand1,hand2);
        }

    }

}