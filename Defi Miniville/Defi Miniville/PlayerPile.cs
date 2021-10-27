﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Defi_Miniville
{
    class PlayerPile
    {
        public List<CardsInfo> cards = new List<CardsInfo>();

        // Initialise la pile avec les cartes de base
        public PlayerPile()
        {
            Push(0);
            Push(1);
            Push(4);
            Push(8);
            Push(12);

        }

        // Retourne le gain en prenant la couleur et le score des dés
        public int GetCardGain(string cardColor, int diceScore)
        {
            int totalGain = 0;
            List<CardsInfo> validCards = new List<CardsInfo>();

            validCards = GetCardByColor(cards, cardColor);
            validCards = GetCardByNumber(validCards, diceScore);

            foreach (CardsInfo card in validCards)
                totalGain += card.Gain;
            //Console.Write(totalGain);
            return totalGain;
        }

        // Retourne les cartes de la pile ayant la couleur passée en argument
        private List<CardsInfo> GetCardByColor(List<CardsInfo> pile, string cardColor)
        {
            List<CardsInfo> cards = new List<CardsInfo>();
            foreach (CardsInfo card in pile)
                if (card.Color == cardColor)
                    cards.Add(card);
            return cards;
        }

        // Retourne les cartes de la pile s'activant avec le score passé en argument
        private List<CardsInfo> GetCardByNumber(List<CardsInfo> pile, int nbr)
        {
            List<CardsInfo> cards = new List<CardsInfo>();
            foreach (CardsInfo card in pile)
                if (card.MinDice <= nbr && card.MaxDice >= nbr)
                    cards.Add(card);
            return cards;
        }

        // Retourne true si une carte de la pile demande un score de dé de plus de 6.
        public bool needTwoDice()
        {
            foreach(CardsInfo card in cards)
            {
                if(card.MinDice > 6)
                {
                    return true;
                }
            }
            return false;
        }

        // Ajoute une carte a la pile
        public void Push(int Id)
        {
            cards.Add(Card.GetCard(Id));
        }
    }
}

