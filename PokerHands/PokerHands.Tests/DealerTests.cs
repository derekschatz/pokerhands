using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands.Tests
{
    [TestClass]
    public class DealerTests
    {
        /*
        [TestMethod]
        public void HighCardWinsOverHighCardBasedOnHighestCardValue()
        {
            var hand1 = new HandValue(HandType.HighCard, new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"5"),
                new Card(Suit.D,"A")}

                );

            var hand2 = new HandValue(HandType.HighCard, new[]{
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
        public void HighCardWinsOverHighCardBasedOnHighestCardValue_NoMatterThePositionOfTheHand()
        {
            var hand1 = new HandValue(HandType.HighCard, new[]{
                 new Card(Suit.C,"3"),
                 new Card(Suit.D,"5"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"A"),
            });

            var hand2 = new HandValue(HandType.HighCard, new[]{
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
            var hand1 = new HandValue(HandType.HighCard, new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"J"),
                new Card(Suit.H,"Q"),
                new Card(Suit.C,"K"),
                new Card(Suit.D,"A") });

            var hand2 = new HandValue(HandType.HighCard, new[]{
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
            var hand1 = new HandValue(HandType.Pair, new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"3"),
                new Card(Suit.H,"Q"),
                new Card(Suit.C,"K"),
                new Card(Suit.D,"A") });

            var hand2 = new HandValue(HandType.HighCard, new[]{
                 new Card(Suit.C,"T"),
                new Card(Suit.D,"J"),
                new Card(Suit.H,"Q"),
                new Card(Suit.C,"A"),
                new Card(Suit.D,"K") });

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player1, res.Winner);
        }


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
