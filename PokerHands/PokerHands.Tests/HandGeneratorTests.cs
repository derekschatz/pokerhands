using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerHands.Tests
{
    [TestClass]
    public class HandGeneratorTests
    {
        Deck cardDeck= new Deck();

        [TestMethod]
        public void GeneratingCards_Produce_2_Hands_With_5_Cards()
        {
            var sut = new HandGen();

            var hands = sut.Generate(cardDeck);

            Assert.AreEqual(2, hands.Count);

            hands.ToList().ForEach(hand => Assert.AreEqual(5, hand.Length));
        }

        [TestMethod]
        public void Hands_Should_Be_Different()
        {
            var sut = new HandGen();

            var hands = sut.Generate(cardDeck);

            var hashSet = new HashSet<Card>();

            foreach(var hand in hands)
            {
                foreach(var card in hand)
                {
                    Assert.IsTrue(hashSet.Add(card), 
                        "new card value should not already be present in the hand");
                }
            }

            Assert.AreEqual(10, hashSet.Count);
        }
    }
}
