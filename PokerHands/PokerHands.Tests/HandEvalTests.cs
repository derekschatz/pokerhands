using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands.Tests
{
    [TestClass]
    public class HandEvalTests
    {
        HandEval _sut = new HandEval();

        [TestMethod]
        public void CanDetectSimpletStraighFlushes()
        {
            var simpleStraightFlush = new[]
            {
                new Card(Suit.C,"4"),
                new Card(Suit.C,"5"),
                new Card(Suit.C,"6"),
                new Card(Suit.C,"7"),
                new Card(Suit.C,"8"),
            };

            var hand = _sut.Evaluate(simpleStraightFlush);

            Assert.AreEqual(9, hand.HandType);
        }

        [TestMethod]
        public void CanDetectComplexStraighFlushes()
        {
            var complexStraightFlush = new[]
            {
                new Card(Suit.C,"9"),
                new Card(Suit.C,"T"),
                new Card(Suit.C,"J"),
                new Card(Suit.C,"Q"),
                new Card(Suit.C,"K"),
            };

            var hand = _sut.Evaluate(complexStraightFlush);

            Assert.AreEqual(9, hand.HandType);
        }

        [TestMethod]
        public void CanDetermineWhenNotAStraightFlushDueToSuit()
        {
            var complexStraightFlush = new[]
            {
                new Card(Suit.C,"9"),
                new Card(Suit.D,"T"),
                new Card(Suit.C,"J"),
                new Card(Suit.S,"Q"),
                new Card(Suit.H,"K"),
            };

            var hand = _sut.Evaluate(complexStraightFlush);

            Assert.AreNotEqual(9, hand.HandType);
        }

        [TestMethod]
        public void CanDetermineWhenNotAStraightFlushDueToValue()
        {
            var complexStraightFlush = new[]
            {
                new Card(Suit.C,"T"),
                new Card(Suit.C,"T"),
                new Card(Suit.C,"J"),
                new Card(Suit.C,"A"),
                new Card(Suit.C,"K"),
            };

            var hand = _sut.Evaluate(complexStraightFlush);

            Assert.AreNotEqual(9, hand.HandType);
        }

        [TestMethod]
        public void CanDetermineWhenFourOfAKind()
        {
            var cards = new[]
            {
                 new Card(Suit.C,"9"),
                new Card(Suit.D,"9"),
                new Card(Suit.H,"9"),
                new Card(Suit.S,"9"),
                new Card(Suit.H,"K"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.AreEqual(8, hand.HandType);
        }

        [TestMethod]
        public void CanDetermineFourOfKindWhenNoNumberUsed()
        {
            var cards = new[]
            {
                 new Card(Suit.C,"Q"),
                new Card(Suit.D,"K"),
                new Card(Suit.H,"K"),
                new Card(Suit.S,"K"),
                new Card(Suit.H,"K"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.AreEqual(8, hand.HandType);
        }

        [TestMethod]
        public void CanDetermineWhenNotAFourOfAKind()
        {
            var cards = new[]
            {
                 new Card(Suit.C,"K"),
                new Card(Suit.D,"K"),
                new Card(Suit.H,"3"),
                new Card(Suit.S,"K"),
                new Card(Suit.H,"A"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.AreNotEqual(8, hand.HandType);
        }

        [TestMethod]
        public void CanDeterminePair()
        {
            var cards = new[]
           {
                 new Card(Suit.C,"K"),
                new Card(Suit.D,"K"),
                new Card(Suit.H,"3"),
                new Card(Suit.S,"4"),
                new Card(Suit.H,"2"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.AreEqual(2, hand.HandType);
        }

        [TestMethod]
        public void CanDetermineTwoPair()
        {
            var cards = new[]{
                 new Card(Suit.C,"K"),
                new Card(Suit.D,"K"),
                new Card(Suit.H,"3"),
                new Card(Suit.S,"3"),
                new Card(Suit.H,"2"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.AreEqual(3, hand.HandType);
        }

        [TestMethod]
        public void CanEvaluateThreeOfAKind()
        {
            var cards = new[]{
                 new Card(Suit.C,"K"),
                new Card(Suit.D,"3"),
                new Card(Suit.H,"3"),
                new Card(Suit.S,"3"),
                new Card(Suit.H,"2"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.AreEqual(4, hand.HandType);
        }

        [TestMethod]
        public void CanEvaluateStraight()
        {
            var cards = new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"4"),
                new Card(Suit.H,"5"),
                new Card(Suit.S,"6"),
                new Card(Suit.H,"7"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.AreEqual(5, hand.HandType);
        }

        [TestMethod]
        public void CanEvaluateAFlush()
        {
            var cards = new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.C,"4"),
                new Card(Suit.C,"5"),
                new Card(Suit.C,"T"),
                new Card(Suit.C,"7"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.AreEqual(6, hand.HandType);
        }

        [TestMethod]
        public void CanEvaluateAFullHouse()
        {
            var cards = new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"3"),
                new Card(Suit.H,"3"),
                new Card(Suit.C,"T"),
                new Card(Suit.D,"T"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.AreEqual(7, hand.HandType);
        }

        [TestMethod]
        public void CanEvaluateAHighCard()
        {
            var cards = new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"T"),
                new Card(Suit.H,"K"),
                new Card(Suit.C,"A"),
                new Card(Suit.D,"5"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.AreEqual(1, hand.HandType);
        }
    }
}
