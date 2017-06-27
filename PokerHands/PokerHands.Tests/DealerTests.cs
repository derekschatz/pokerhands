using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands.Tests
{
    [TestClass]
    public class DealerTests
    {
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
        public void PairWinsOverPairIfPairingHighCardIsGreater()
        {
            var hand1 = new HandValue(HandType.HighCard, new[]{
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
                new Card(Suit.D,"A") });

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player2, res.Winner);
        }

        [TestMethod]
        public void PairWinsOverPairWhenValuesAreTheSameIfNonPairingHighCardIsGreater()
        {
            var hand1 = new HandValue(HandType.HighCard, new[]{
                 new Card(Suit.C,"T"),
                new Card(Suit.D,"J"),
                new Card(Suit.H,"Q"),
                new Card(Suit.C,"A"),
                new Card(Suit.D,"A") });

            var hand2 = new HandValue(HandType.HighCard, new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"J"),
                new Card(Suit.H,"Q"),
                new Card(Suit.C,"A"),
                new Card(Suit.D,"A") });

            var res = Dealer.DetermineWinner(hand1, hand2);

            Assert.AreEqual(Winner.Player1, res.Winner);

        }

    }
}
