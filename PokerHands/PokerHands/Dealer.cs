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
            if(handOfPlayer1 == HandType.Pair && handOfPlayer2 == HandType.HighCard)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if(handOfPlayer2 == HandType.Pair && handOfPlayer1 == HandType.HighCard)
            {
                return new WinningHand(hand2, Winner.Player2);
            }

            if(handOfPlayer1 == HandType.Pair && handOfPlayer2 == HandType.Pair)
            {
                
            }
            return WinningHand.Draw;
        }

    }

}