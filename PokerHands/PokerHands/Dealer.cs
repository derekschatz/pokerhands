using System;

namespace PokerHands
{
    public class Dealer
    {
        public static WinningHand DetermineWinner(HandValue hand1, HandValue hand2)
        {
            var handOfPlayer1 = hand1.HandType;
            var handOfPlayer2 = hand2.HandType;
            if (handOfPlayer1 == HandType.HighCard && handOfPlayer2 == HandType.HighCard)
            if (handOfPlayer1 == HandType.HighCard && handOfPlayer2 == HandType.HighCard)
            {
                for(int i = 4; i >= 0; i--)
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
            }
            if(hand1.HandType == HandType.Pair && hand2.HandType == HandType.HighCard)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if(hand2.HandType == HandType.Pair && hand1.HandType == HandType.HighCard)
            {
                return new WinningHand(hand2, Winner.Player2);
            }

            if(hand1.HandType == HandType.Pair && hand2.HandType == HandType.Pair)
            {
                
            }
            return WinningHand.Draw;
        }

    }

}