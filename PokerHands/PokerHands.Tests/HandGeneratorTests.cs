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
        Deck cardDeck = new Deck();

        List<string> orderedCardSequence = Deck.OrderedNumbers.ToList();

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

            foreach (var hand in hands)
            {
                foreach (var card in hand)
                {
                    Assert.IsTrue(hashSet.Add(card),
                        "new card value should not already be present in the hand");
                }
            }

            Assert.AreEqual(10, hashSet.Count);
        }

        [TestMethod]
        public void Hands_Should_Have_Cards_In_Order()
        {
            var sut = new HandGen();

            var hands = sut.Generate(cardDeck);

            foreach (var hand in hands)
            {                 
                var currentPositions = 
                    hand.Select(card =>
                            orderedCardSequence.IndexOf(card.Value))
                        .ToArray();

                var expectedOrder = currentPositions.ToList();
                expectedOrder.Sort();
                
               for(var i =0; i < currentPositions.Length; i++)
                {
                    Assert.AreEqual(orderedCardSequence[expectedOrder[i]],
                        orderedCardSequence[currentPositions[i]], $"Values should be equal at index {i}");
                }

            }
        }

    }
}
