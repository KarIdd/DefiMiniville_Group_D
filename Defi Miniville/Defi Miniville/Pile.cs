using System;
using System.Collections.Generic;
using System.Text;

namespace Defi_Miniville
{
    class Pile
    {
        List<Card> cards = new List<Card>();

        public Pile(int nbCards = 2)
        {
            for (int i = 0; i<nbCards; i++)
            {
                cards.Add(new Card());
            }
        }

        public void DisplayCards(Pile pile)
        {
            Console.WriteLine("Display cards...");
            foreach (Card card in pile.cards)
            {
                Console.WriteLine($"{card.Name}");
            }
        }

        public List<Card> GetCardByColor(Pile pile, string cardColor)
        {
            List<Card> cards = new List<Card>();
            foreach (Card card in pile.cards)
                if (card.Color == cardColor)
                    cards.Add(card);
            return cards;
        }

        public List<Card> GetCardByNumber(Pile pile, int nbr)
        {
            List<Card> cards = new List<Card>();
            foreach (Card card in pile.cards)
                if (card.Dice == nbr)
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

