using System;
using System.Collections.Generic;
using System.Text;

namespace Defi_Miniville
{
    class Pile
    {
        List<Card> cards = List<Card>();

        public List<Card> GetCards(Pile pile, string cardColor)
        {
            List<Card> cards = List<Card>();
            foreach (Card card in pile)
            {
                if (card)
            }
            return cards
        }

        public Card DrawCard()
        {
            Card drawnCard = cards[-1];
            return drawnCard;
        }

    }
}

