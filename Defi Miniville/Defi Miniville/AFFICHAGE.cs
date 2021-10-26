﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Defi_Miniville
{
    // Classe qui gère l'affichage
    class AFFICHAGE
    {
        public Card card = new Card();

        public void Affichage()
        {
            string sep = " + ----------------------------------- +";
            string title = " |  BIENVENUE DANS CE JEU DE MINIVILE  |";
            Console.WriteLine(sep + "\n" + title + "\n" + sep);
        }

         

        public void Displaycards()
        {
            for ( int item =0; item < 8; item++  )
            {
                Console.WriteLine(Card.GetCard(item).Name);

            }
        }

        // methode permettant des messages entourés d'une box faîte de + de - et de |,
        // de manière globale
        public void DisplayTextBox(string[] messages, bool multipleSep)
        {
            // Récupération de la longueur maximale parmi les chaines contenues dans " message "
            int cardNamesLenght = 0;
            foreach (string card in Card.deck.Keys) if (cardNamesLenght < card.Length) cardNamesLenght = card.Length;
            string sep = "+" + new string(' ', cardNamesLenght + 2) + "+";
            Console.WriteLine(sep);
        }



    }
}
