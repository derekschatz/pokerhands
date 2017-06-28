using System;

namespace PokerHands
{
    public class Dealer
    {
        public static WinningHand DetermineWinner(HandValue hand1, HandValue hand2)
        {
            if (hand1.HandType == HandType.HighCard && hand2.HandType == HandType.HighCard)
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
            }
            if (hand1.HandType == HandType.Pair && hand2.HandType == HandType.HighCard)
            {
                return new WinningHand(hand1, Winner.Player1);
            }
            if (hand2.HandType == HandType.Pair && hand1.HandType == HandType.HighCard)
            {
                return new WinningHand(hand2, Winner.Player2);
            }



            //if both hand 1 and hand 2 have a pair 
            if (hand1.HandType == HandType.Pair && hand2.HandType == HandType.Pair)
            {
                for (int i = 4; i >= 1; i--)
                {

                    int highestUnpaired1 = NumberMapper.NumberMapping[hand1.Cards[i].Value]; ;
                    int highestUnpaired2= NumberMapper.NumberMapping[hand2.Cards[i].Value]; 
                    int pairVal1 = NumberMapper.NumberMapping[hand1.Cards[i].Value];
                    int pairVal2 = NumberMapper.NumberMapping[hand2.Cards[i].Value];


                    //Hand 1 scenario: Chacking for pair value and high card value
                    //if numbers are equal return the value of the number 
                    if (hand1.Cards[i].Value == hand1.Cards[i - 1].Value)
                    {
                        pairVal1 = NumberMapper.NumberMapping[hand1.Cards[i].Value];
                        
                    }

                    if (hand1.Cards[i].Value != hand1.Cards[i - 1].Value)
                    {
                        //add the unpaired cards into a new array
                        highestUnpaired1 = NumberMapper.NumberMapping[hand1.Cards[i].Value];
                    }
                    
                    //Hand 2 Scenarios
                    //if numbers are equal return the value of the number 
                    if (hand2.Cards[i].Value == hand2.Cards[i - 1].Value)
                    {
                        pairVal2 = NumberMapper.NumberMapping[hand2.Cards[i].Value];
                     
                    }

                    if (hand2.Cards[i].Value != hand2.Cards[i - 1].Value)
                    {
                        highestUnpaired2 = NumberMapper.NumberMapping[hand2.Cards[i].Value];
                    }

                    if (pairVal1 > pairVal2)
                    {
                        return new WinningHand(hand1, Winner.Player1);
                    }
                    if (pairVal1 < pairVal2)
                    {
                        return new WinningHand(hand2, Winner.Player2);
                    }
                    if(pairVal1 == pairVal2)
                    {
                        if(highestUnpaired1 > highestUnpaired2)
                        {
                            return new WinningHand(hand1, Winner.Player1);
                        }
                        if(highestUnpaired2 > highestUnpaired1)
                        {
                            return new WinningHand(hand2, Winner.Player2);
                        }
                    }

                }
            }

            //Two Pair vs highcard or pair
            if((hand1.HandType == HandType.TwoPair && hand2.HandType == HandType.Pair | hand1.HandType == HandType.TwoPair && hand2.HandType == HandType.HighCard))
            {
                return new WinningHand(hand1, Winner.Player1);
            }

            if(((hand1.HandType == HandType.Pair && hand2.HandType == HandType.TwoPair) | (hand2.HandType == HandType.TwoPair && hand1.HandType == HandType.HighCard)))
            {
                return new WinningHand(hand2, Winner.Player2);
            }
           
            return WinningHand.Draw;
        }

    }

}