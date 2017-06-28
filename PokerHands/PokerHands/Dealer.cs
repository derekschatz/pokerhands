using System;

namespace PokerHands
{
    public class Dealer
    {
        public static WinningHand DetermineWinner(HandValue hand1, HandValue hand2)
        {
            if (hand1.HandType == HandType.HighCard && hand2.HandType == HandType.HighCard)
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

            string[] unPairedCards = new string[3];
            
            if(hand1.HandType == HandType.Pair && hand2.HandType == HandType.Pair)
            {
                for(int i = 4; i >= 0; i--)
                {
                    //if numbers are equal return the value of the number 
                    if(hand1.Cards[i].Value == hand1.Cards[i - 1].Value)
                    {
                        var pairVal1 = NumberMapper.NumberMapping[hand1.Cards[i].Value];
                    }
                    if(hand1.Cards[i].Value != hand1.Cards[i - 1].Value)
                    {
                        for(int x = 0; x < 3; x++)
                        {
                            //add the unpaired cards into a new array
                            unPairedCards[x] = hand1.Cards[i].Value;
                            
                            

                        }
                     
                    }
                }

               
            }
            return WinningHand.Draw;
        }

    }

}