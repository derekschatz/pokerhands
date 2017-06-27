using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace PokerHands.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void GeneratingDeckHas52NonEmptyCards()
        {
            var sut = new Deck();
            Assert.AreEqual(52,sut.Cards.Length);
            
            foreach(var c in sut.Cards)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(c.ToString()));
            }
        }

        [TestMethod]
        public void GeneratingDeckFollowsDeckingRules()
        {
            var sut = new Deck();
            var visitedSuits = new[] { Suit.C, Suit.D, Suit.H, Suit.S }.ToList();

            var grouping = sut.Cards.GroupBy(e => e.Suit);

            Assert.AreEqual(4, grouping.Count());

            foreach(var cardGrouping in grouping)
            {
                var allowableNumbers = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" }.ToList();

                foreach(var card in cardGrouping)
                {
                     Assert.IsTrue(allowableNumbers.Remove(card.Value),"no value should be duplicated or not part of standard set");
                }

                Assert.AreEqual(0, allowableNumbers.Count);

                Assert.IsTrue(visitedSuits.Remove(cardGrouping.Key));    
            }

            Assert.AreEqual(0, visitedSuits.Count);
        }
    }
}
