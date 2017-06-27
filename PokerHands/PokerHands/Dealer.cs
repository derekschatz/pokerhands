using System;

namespace PokerHands
{
    public class Dealer
    {
        public static WinningHand DetermineWinner(HandValue hand1, HandValue hand2)
        {
            if(hand1.HandType == HandType.HighCard && hand2.HandType == HandType.HighCard)
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
            throw new NotImplementedException();
        }

    }

}