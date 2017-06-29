using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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

            Assert.IsInstanceOfType(hand, typeof(StraightFlushHand));
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

            Assert.IsInstanceOfType(hand, typeof(StraightFlushHand));
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

            Assert.IsInstanceOfType(hand, typeof(FourOfAKindHand));
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

            Assert.IsInstanceOfType(hand, typeof(FourOfAKindHand));

            var four = hand as FourOfAKindHand;

            AreCardSetEqual(new[] {
                new Card(Suit.D,"K"),
                new Card(Suit.H,"K"),
                new Card(Suit.S,"K"),
                new Card(Suit.H,"K"),
            }, four.QuadSet);
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

            Assert.IsInstanceOfType(hand, typeof(PairHand));

            var pair = hand as PairHand;

            AreCardSetEqual(new[]           {
                new Card(Suit.C, "K"),
                new Card(Suit.D, "K")},
                pair.PairSet
                );
        }

        [TestMethod]
        public void CanDetermineTwoPair()
        {
            var cards = new[]{
                new Card(Suit.H,"2"),
                new Card(Suit.H,"3"),
                new Card(Suit.S,"3"),
                 new Card(Suit.C,"K"),
                new Card(Suit.D,"K"),
            };

            var hand = _sut.Evaluate(cards);

            Assert.IsInstanceOfType(hand, typeof(TwoPairHand));

            var twoPair = hand as TwoPairHand;

            AreCardSetEqual(
                new[] {new Card(Suit.C,"K"),
                new Card(Suit.D,"K")}, twoPair.HighestPair
                );

            AreCardSetEqual(
                new[] {
                new Card(Suit.H,"3"),
                new Card(Suit.S,"3")},
                twoPair.LowestPair);
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

            Assert.IsInstanceOfType(hand, typeof(ThreeOfAKindHand));

            var three = hand as ThreeOfAKindHand;

            AreCardSetEqual(
                new[]{
                new Card(Suit.D,"3"),
                new Card(Suit.H,"3"),
                new Card(Suit.S,"3")
            }, three.TripleSet);
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

            Assert.IsInstanceOfType(hand, typeof(StraightHand));
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

            Assert.IsInstanceOfType(hand, typeof(FlushHand));
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

            Assert.IsInstanceOfType(hand, typeof(FullHouseHand));

            var fullHouse = hand as FullHouseHand;

            Card[] threeOfAKind = fullHouse.ThreeOfAKindCards;
            AreCardSetEqual(new[]{
                 new Card(Suit.C,"3"),
                new Card(Suit.D,"3"),
                new Card(Suit.H,"3") }
                , threeOfAKind);


            Card[] pair = fullHouse.PairSet;
            AreCardSetEqual(new[]{
                 new Card(Suit.C,"T"),
                new Card(Suit.D,"T") }, pair);

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

            Assert.IsInstanceOfType(hand, typeof(HighCardHand));
        }


        void AreCardSetEqual(Card[] a, Card[] b)
        {
            Assert.AreEqual(
               string.Join(",", a.Select(e => e.ToString())),
               string.Join(",", b.Select(e => e.ToString()))
               );
        }
    }
}
