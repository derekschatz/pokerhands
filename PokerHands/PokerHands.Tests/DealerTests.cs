using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands.Tests
{
    [TestClass]
    public class DealerTests
    {

        [TestMethod]
        public void HighCardWinsOverHighCardBasedOnHighestCardValue()
        {
            var hand1 = new HighCardHand(new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"5"),
                new Card(Suit.D,"A")}

                );

            var hand2 = new HighCardHand(new[]{
                 new Card(Suit.C,"3"),
                 new Card(Suit.D,"5"),
                new Card(Suit.D,"T"),

                new Card(Suit.C,"Q"),
                new Card(Suit.H,"K"),
            }

                );

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player1, res.Winner);
        }

        [TestMethod]
        public void CanDetermineDrawOnHighCard()
        {
            var hand1 = new HighCardHand(new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"5"),
                new Card(Suit.D,"A")}

                );

            var hand2 = new HighCardHand(new[]{
                 new Card(Suit.D,"3"),
                new Card(Suit.C,"T"),
                new Card(Suit.S,"K"),
                new Card(Suit.H,"5"),
                new Card(Suit.S,"A")}

     );

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Draw, res.Winner);
        }


        [TestMethod]
        public void PairoverPairWithHigherPair()
        {
            var hand1 = new PairHand(new[]{
                new Card(Suit.C,"3"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"A"),
                new Card(Suit.D,"A")}
            , new[]
            {
                new Card(Suit.C,"A"),
                new Card(Suit.D,"A")
            }
                );

            var hand2 = new PairHand(new[]{
                 new Card(Suit.D,"3"),
                new Card(Suit.C,"T"),
                new Card(Suit.S,"K"),
                new Card(Suit.H,"K"),
                new Card(Suit.S,"A")}
            , new[]
            {
                new Card(Suit.S,"K"),
                new Card(Suit.H,"K"),
            }
     );

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player1, res.Winner);
        }

        [TestMethod]
        public void PairoverPairWithHighCard()
        {
            var hand1 = new PairHand(new[]{
                new Card(Suit.C,"3"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"A"),
                new Card(Suit.D,"A")}
            , new[]
            {
                new Card(Suit.C,"A"),
                new Card(Suit.D,"A")
            }
                );

            var hand2 = new PairHand(new[]{
                 new Card(Suit.D,"3"),
                new Card(Suit.C,"T"),
                new Card(Suit.S,"Q"),
                new Card(Suit.H,"A"),
                new Card(Suit.S,"A")}
            , new[]
            {
                new Card(Suit.S,"A"),
                new Card(Suit.H,"A"),
            }
     );

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player1, res.Winner);
        }
        [TestMethod]
        public void PairoverTwoPairWithHigherPair()
        {
            var hand1 = new TwoPairHand(new[]{
                new Card(Suit.C,"6"),
                new Card(Suit.D,"9"),
                new Card(Suit.H,"9"),
                new Card(Suit.C,"K"),
                new Card(Suit.D,"K")}
            , new[]
            { new Card(Suit.C, "K"),
              new Card(Suit.D, "K")
            }
            , new[]
            {
                new Card(Suit.D,"9"),
                new Card(Suit.H,"9"),
            }

          );


            var hand2 = new TwoPairHand(new[]{
                 new Card(Suit.D,"3"),
                new Card(Suit.C,"T"),
                new Card(Suit.S,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.S,"K")}
            , new[]
            {
                new Card(Suit.S,"K"),
                new Card(Suit.H,"K"),
            }
            , new[]
            {
                new Card(Suit.C,"T"),
                new Card(Suit.S,"T"),
            }
     );

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player2, res.Winner);
        }


        [TestMethod]
        public void ThreeOfAKindOverTHreeofAKindWith()
        {
            var hand1 = new ThreeOfAKindHand(new[]{
                new Card(Suit.C,"6"),
                new Card(Suit.D,"9"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"K"),
                new Card(Suit.D,"K")}
            , new[]
            {
                new Card(Suit.H,"K"),
                new Card(Suit.C,"K"),
                new Card(Suit.D,"K")
            }

          );
            var hand2 = new ThreeOfAKindHand(new[]{
                 new Card(Suit.D,"3"),
                new Card(Suit.C,"T"),
                new Card(Suit.S,"A"),
                new Card(Suit.H,"A"),
                new Card(Suit.S,"A")}
            , new[]
            {
               new Card(Suit.S,"A"),
                new Card(Suit.H,"A"),
                new Card(Suit.S,"A")
            }

     );

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player2, res.Winner);
        }

        [TestMethod]
        public void StraightHandOverStraightHandWithHigherCard()
        {
            var hand1 = new StraightHand(new[]{
                new Card(Suit.C,"3"),
                new Card(Suit.D,"4"),
                new Card(Suit.H,"5"),
                new Card(Suit.C,"6"),
                new Card(Suit.D,"7")}
            

          );
            var hand2 = new StraightHand(new[]{
                 new Card(Suit.D,"3"),
                new Card(Suit.C,"4"),
                new Card(Suit.S,"5"),
                new Card(Suit.H,"6"),
                new Card(Suit.S,"7")}
            

     );

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Draw, res.Winner);
        }

        
        [TestMethod]
        public void HighCardWinsOverHighCardBasedOnHighestCardValue_NoMatterThePositionOfTheHand()
        {
            var hand1 = new HighCardHand( new[]{
                 new Card(Suit.C,"3"),
                 new Card(Suit.D,"5"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"A"),
            });

            var hand2 = new HighCardHand(new[]{
                 new Card(Suit.C,"3"),
                 new Card(Suit.D,"5"),
                new Card(Suit.D,"T"),

                new Card(Suit.C,"Q"),
                new Card(Suit.H,"K"),

            }

                );

            var res = Dealer.DetermineWinner(hand2, hand1);

            Assert.AreEqual(Winner.Player2, res.Winner);
        }


        [TestMethod]
        public void HighCardWinsOverHighCardBasedOnHighestCardValue_WhenSomeCards_Match()
        {
            var hand1 = new HighCardHand(new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"J"),
                new Card(Suit.H,"Q"),
                new Card(Suit.C,"K"),
                new Card(Suit.D,"A") });

            var hand2 = new HighCardHand(new[]{
                 new Card(Suit.C,"T"),
                new Card(Suit.D,"J"),
                new Card(Suit.H,"Q"),
                new Card(Suit.C,"K"),
                new Card(Suit.D,"A") });

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player2, res.Winner);
        }


        [TestMethod]
        public void PairWinsOverHighCard()
        {
            var hand1 = new PairHand( new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"3"),
                new Card(Suit.H,"4"),
                new Card(Suit.C,"5"),
                new Card(Suit.D,"6") }, new[] { new Card(Suit.C,"3"),
                new Card(Suit.D,"7")});

            var hand2 = new HighCardHand(new[]{
                 new Card(Suit.C,"9"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"Q"),
                new Card(Suit.D,"A") });

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player1, res.Winner);
        }

        [TestMethod]
        public void PairWinsOverHighCardIrregardlessOfPosition()
        {
            var hand1 = new PairHand(new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"3"),
                new Card(Suit.H,"4"),
                new Card(Suit.C,"5"),
                new Card(Suit.D,"6") },
                
                new[] { new Card(Suit.C,"3")
               });

            var hand2 = new HighCardHand(new[]{
                 new Card(Suit.C,"9"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"Q"),
                new Card(Suit.D,"A") });

            var res = Dealer.DetermineWinner(hand1,hand2);

            Assert.AreEqual(Winner.Player1, res.Winner);
        }
        [TestMethod]
        public void TwoPairWinsOverPairIrregardlessOfPosition()
        {
            var hand1 = new PairHand(new[]{
                new Card(Suit.C,"3"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"A"),
                new Card(Suit.D,"A")}
            , new[]
            {
                new Card(Suit.C,"A"),
                new Card(Suit.D,"A")
            }
                );

            var hand2 = new TwoPairHand(new[]{
                 new Card(Suit.D,"3"),
                new Card(Suit.C,"T"),
                new Card(Suit.S,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.S,"K")}
            , new[]
            {
                new Card(Suit.S,"K"),
                new Card(Suit.H,"K"),
            }
            , new[]
            {
                new Card(Suit.C,"T"),
                new Card(Suit.S,"T"),
            }
     );

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player2, res.Winner);
        }

        /*
[TestMethod]
public void PairWinsOverPairIfPairingHighCardIsGreater()
{
    var hand1 = new HandValue(HandType.Pair, new[]{
         new Card(Suit.C,"3"),
        new Card(Suit.D,"3"),
        new Card(Suit.H,"Q"),
        new Card(Suit.C,"K"),
        new Card(Suit.D,"A") });

    var hand2 = new HandValue(HandType.Pair, new[]{
         new Card(Suit.C,"T"),
        new Card(Suit.D,"J"),
        new Card(Suit.H,"Q"),
        new Card(Suit.C,"A"),
        new Card(Suit.D,"A") });

    var res = Dealer.DetermineWinner(hand1, hand2);

    Assert.AreEqual(Winner.Player2, res.Winner);
}

[TestMethod]
public void PairWinsOverPairWhenValuesAreTheSameIfNonPairingHighCardIsGreater()
{
    var hand1 = new HandValue(HandType.Pair, new[]{
         new Card(Suit.C,"T"),
        new Card(Suit.D,"J"),
        new Card(Suit.H,"K"),
        new Card(Suit.C,"A"),
        new Card(Suit.D,"A") });

    var hand2 = new HandValue(HandType.Pair, new[]{
         new Card(Suit.C,"3"),
        new Card(Suit.D,"J"),
        new Card(Suit.H,"K"),
        new Card(Suit.C,"A"),
        new Card(Suit.D,"A") });

    var res = Dealer.DetermineWinner(hand1, hand2);

    Assert.AreEqual(Winner.Player1, res.Winner);

}

[TestMethod]
public void TwoPairWinsOverPair()
{
    var hand1 = new HandValue(HandType.Pair, new[]{
         new Card(Suit.C,"T"),
        new Card(Suit.D,"J"),
        new Card(Suit.H,"K"),
        new Card(Suit.C,"A"),
        new Card(Suit.D,"A") });

    var hand2 = new HandValue(HandType.TwoPair, new[]{
         new Card(Suit.C,"3"),
        new Card(Suit.D,"K"),
        new Card(Suit.H,"K"),
        new Card(Suit.C,"A"),
        new Card(Suit.D,"A") });

    var res = Dealer.DetermineWinner(hand1, hand2);

    Assert.AreEqual(Winner.Player2, res.Winner);

}

[TestMethod]
public void TwoPairWinsOverHighCard()
{
    var hand1 = new HandValue(HandType.HighCard, new[]{
         new Card(Suit.C,"2"),
        new Card(Suit.D,"3"),
        new Card(Suit.H,"Q"),
        new Card(Suit.C,"K"),
        new Card(Suit.D,"A") });

    var hand2 = new HandValue(HandType.TwoPair, new[]{
         new Card(Suit.C,"3"),
        new Card(Suit.D,"3"),
        new Card(Suit.H,"4"),
        new Card(Suit.C,"6"),
        new Card(Suit.D,"2") });

    var res = Dealer.DetermineWinner(hand1, hand2);

    Assert.AreEqual(Winner.Player2, res.Winner);
}
[TestMethod]
public void TwoPairWinsOverTwoPairWhenOneHigherPairIsGreater()
{
    var hand1 = new HandValue(HandType.TwoPair, new[]{
         new Card(Suit.C,"2"),
        new Card(Suit.D,"Q"),
        new Card(Suit.H,"Q"),
        new Card(Suit.C,"A"),
        new Card(Suit.D,"A") });

    var hand2 = new HandValue(HandType.TwoPair, new[]{
         new Card(Suit.C,"3"),
        new Card(Suit.D,"K"),
        new Card(Suit.H,"K"),
        new Card(Suit.C,"A"),
        new Card(Suit.D,"A") });

    var res = Dealer.DetermineWinner(hand1, hand2);

    Assert.AreEqual(Winner.Player2, res.Winner);
}
*/
    }
}
