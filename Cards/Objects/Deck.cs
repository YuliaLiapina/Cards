using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Shared;

namespace Cards.Objects
{
    public class Deck
    {
        public Card[] Cards;

        #region Constructors

        public Deck()
        {
            Cards = new Card[Conf.NumCardsInDeck];
            int posInDeck = 0;
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int face = 1; face <= 13; face++)
                {
                    Cards[posInDeck++] = new Card((CardSuit)suit, face);
                }
            }
        }

        #endregion

        #region Public Properties

        public void Shuffle()
        {
            int seed = (int)(DateTime.Now.Ticks % 100000L);
            var randomGenerator = new Random(seed);

            for (int i = 0; i <= Cards.Length - 1; i++)
            {
                int cardToMove = randomGenerator.Next(i, Cards.Length);
                Swap(i, cardToMove);
            }
        }
   
        public void Sort()
        {
            for (int toIndex = 0; toIndex <= Cards.Length - 1; toIndex++)
            {
                int fromIndex = GetIndexByKey(toIndex + 1,toIndex, Cards.Length - 1);
                Swap(toIndex, fromIndex);
            }

        }

        public void Sort2()
        {
            Cards = Cards.OrderBy(c => c.KeyBySuit).ToArray();
        }

        public void Print()
        {
            foreach (var card in Cards)
            {
                Console.WriteLine(card.ToString());
            }
        }

        public void Swap(int a, int b)
        {
            Card holdCard = Cards[a];
            Cards[a] = Cards[b];
            Cards[b] = holdCard;
        }

        public int GetIndexByKey(int key, int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (Cards[i].KeyBySuit == key)
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

    }
}
