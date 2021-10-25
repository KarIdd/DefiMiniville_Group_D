using System;
using System.Collections.Generic;
using System.Text;

namespace Defi_Miniville
{
    class PlayerPile
    {
        List<CardsInfo> cards = new List<CardsInfo>();
        Player player;

        public PlayerPile(Player player)
        {
            this.player = player;
            
            for (int i = 0; i<2; i++)
            {
                cards.Add(CardsInfo.GetCards());
                cards.Add();
            }
        }

        public void DisplayCards(PlayerPile pile)
        {
            Console.WriteLine("Display cards...");
            foreach (CardsInfo card in pile.cards)
            {
                Console.WriteLine($"{card.Name}");
            }
        }

        public List<CardsInfo> GetCardByColor(PlayerPile pile, string cardColor)
        {
            List<CardsInfo> cards = new List<CardsInfo>();
            foreach (CardsInfo card in pile.cards)
                if (card.Color == cardColor)
                    cards.Add(card);
            return cards;
        }

        public List<CardsInfo> GetCardByNumber(PlayerPile pile, int nbr)
        {
            List<CardsInfo> cards = new List<CardsInfo>();
            foreach (CardsInfo card in pile.cards)
                if (card.Dice == nbr)
                    cards.Add(card);
            return cards;
        }
    }
}

