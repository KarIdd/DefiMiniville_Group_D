using System;
using System.Collections.Generic;
using System.Text;

namespace Defi_Miniville
{
    class PlayerPile
    {
        List<CardsInfo> cards = new List<CardsInfo>();

        public PlayerPile()
        {
            for (int i = 0; i<2; i++)
            {
                // Ajoute les cartes "Champs de blé" et "Boulangerie"
                cards.Add(CardsInfo.GetCard(0));
                cards.Add(CardsInfo.GetCard(2));
            }
        }

        public void DisplayCards()
        {
            Console.WriteLine("Display cards...");
            foreach (CardsInfo card in this.cards)
            {
                Console.WriteLine($"{card.Name}");
            }
        }

        public int GetCardGain(string cardColor, int diceScore)
        {
            int totalGain = 0;
            List<CardsInfo> validCards = new List<CardsInfo>();
            validCards = GetCardByColor(validCards, cardColor);
            validCards = GetCardByNumber(validCards, diceScore);

            foreach (CardsInfo card in validCards)
            {
                totalGain += card.Gain;
            }
            return totalGain
        }


        private List<CardsInfo> GetCardByColor(List<CardsInfo> pile, string cardColor)
        {
            List<CardsInfo> cards = new List<CardsInfo>();
            foreach (CardsInfo card in this.cards)
                if (card.Color == cardColor)
                    cards.Add(card);
            return cards;
        }

        private List<CardsInfo> GetCardByNumber(List<CardsInfo> pile, int nbr)
        {
            List<CardsInfo> cards = new List<CardsInfo>();
            foreach (CardsInfo card in this.cards)
                if (card.MinDice <= nbr && card.MaxDice >= nbr)
                    cards.Add(card);
            return cards;
        }
    }
}

