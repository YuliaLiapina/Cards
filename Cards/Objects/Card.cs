using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Shared;

namespace Cards.Objects
{
    
    public class Card
    {

        #region Properties

        public CardSuit Suit;
        public int Face;

        public int KeyBySuit
        {
            get
            {
                return (((int)Suit - 1) * 13) + (Face);
            }
        }

        #endregion

        #region Constructors

        public Card() { }

        public Card(CardSuit suit, int face)
        {
            Suit = suit;
            Face = face;
        }

        #endregion

        #region Public Methods

        public bool IsEqual(Card otherCard)
        {
            return ((this.Suit == otherCard.Suit) && (this.Face == otherCard.Face));
        }

        public override string ToString()
        {
            return Suit.ToString() + ":" + Face.ToString() + ":" + KeyBySuit.ToString();
        }

        #endregion

    }
}
