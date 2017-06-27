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

            var hand=_sut.Evaluate(simpleStraightFlush);

            Assert.AreEqual(9, hand.HandType);
            Assert.AreEqual("8", hand.HighCard);
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
            Assert.AreEqual("K", hand.HighCard);
        }
    }
}
