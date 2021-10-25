using System;
using System.Collections.Generic;
using System.Text;

namespace Defi_Miniville
{
    class Pile
    {
        List<Card> cards = new List<Card>();

        public List<Card> GetCards(Pile pile, string cardColor)
        {
            List<Card> cards = new List<Card>();
            foreach (Card card in pile.cards)
                if (card.Color == cardColor)
                    cards.Add(card);
            return cards;
        }

        public Card DrawCard()
        {
            Card drawnCard = cards[-1];
            return drawnCard;
        }

    }
}

