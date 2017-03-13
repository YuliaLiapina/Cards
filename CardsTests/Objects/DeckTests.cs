using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cards.Objects;
using Cards.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Objects.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod()]
        public void TestDeckSize()
        {
            var deck = new Deck();
            Assert.IsTrue(deck.Cards.Length == Conf.NumCardsInDeck, "Deck contains wrong number of cards");
        }

        [TestMethod()]
        public void TestDeckSort()
        {
            var deck = new Deck();

            deck.Shuffle();
            Assert.IsFalse(IsDeckInOrderBySuit(deck), "Deck is sorted when it should not be");

            deck.Sort();
            Assert.IsTrue(IsDeckInOrderBySuit(deck), "Deck is not sorted when it should be");
        }

        [TestMethod()]
        public void TestDeckShuffle()
        {
            var deck = new Deck();

            deck.Sort();
            Assert.IsTrue(IsDeckInOrderBySuit(deck), "Deck is not sorted when it should be");

            deck.Shuffle();
            Assert.IsFalse(IsDeckInOrderBySuit(deck), "Deck is sorted when it should not be");
        }


        [TestMethod()]
        public void TestDeckRandomNess()
        {
            // Note: Technically this test could fail. The shuffling is a randon process
            //       and it is possible that a shuffle could even wind up with the cards
            //       all in order.

            // TODO: Based on above, and on the fact that we are just checking indivdual
            //       card positions, would be good to figure how to beef up this test to
            //       better determine randomnsess of shuffle result. Maybe do multiple 
            //       cycles and say that at most one cycle can fail by having more than n
            //       cards in the same spot. Also maybe check for subsequences in the list
            //       of cards which are the same.

            var deck = new Deck();
            var prevDeck = new Deck();
            int totCardsSame = 0;
            int numShuffles = 100;

            for (int i = 1; i <= numShuffles; i++)
            {
                deck.Cards.CopyTo(prevDeck.Cards,0);
                deck.Shuffle();
                int numCardsSame = NumCardsSame(deck, prevDeck);
                totCardsSame += numCardsSame;
            }
            double avgCardsSame = (double)totCardsSame / (double)numShuffles;
            Assert.IsTrue(avgCardsSame <= 2.0, "More than 2 cards the same on average (possible)");
        }

        private bool IsDeckInOrderBySuit(Deck deck)
        {
            Card lastCard = null;
            foreach (var card in deck.Cards)
            {
                if (lastCard == null)
                {
                    lastCard = card;
                }
                else
                    if (card.KeyBySuit <= lastCard.KeyBySuit)
                    {
                        return false;
                    }
            }
            return true;
        }

        private int NumCardsSame(Deck deck, Deck prevDeck)
        {
            int numCardsSame = 0;
            for (int i = 0; i <= deck.Cards.Length - 1; i++)
            {
                if (deck.Cards[i].IsEqual(prevDeck.Cards[i]))
                {
                    numCardsSame++;
                }
            }
            return numCardsSame;
        }

    }
}