using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Shared
{
    public enum CardSuit { Heart = 1, Diamond = 2, Spade = 3, Club = 4}

    public static class Conf
    { 
        // Even though working with 52 card deck now, allow for larger decks with Jokers, etc
        public static int NumCardsInDeck
        {
            get { return 52; }
        }
    }
}
