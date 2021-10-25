using System;
using System.Collections.Generic;
using System.Text;

namespace Defi_Miniville
{
    class Pile
    {
        List<CardsInfo> cards = new List<CardsInfo>();

        public Pile(int nbCards = 2)
        {
            for (int i = 0; i<nbCards; i++)
            {
                cards.Add(new CardsInfo());
            }
        }

        public void DisplayCards(Pile pile)
        {
            Console.WriteLine("Display cards...");
            foreach (CardsInfo card in pile.cards)
            {
                Console.WriteLine($"{card.Name}");
            }
        }

        public List<CardsInfo> GetCardByColor(Pile pile, string cardColor)
        {
            List<CardsInfo> cards = new List<CardsInfo>();
            foreach (CardsInfo card in pile.cards)
                if (card.Color == cardColor)
                    cards.Add(card);
            return cards;
        }

        public List<CardsInfo> GetCardByNumber(Pile pile, int nbr)
        {
            List<CardsInfo> cards = new List<CardsInfo>();
            foreach (CardsInfo card in pile.cards)
                if (card.Dice == nbr)
                    cards.Add(card);
            return cards;
        }


        public CardsInfo DrawCard()
        {
            CardsInfo drawnCard = cards[-1];
            return drawnCard;
        }
    }
}

