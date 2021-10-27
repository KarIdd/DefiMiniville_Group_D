using System;
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

        // methode permettant d'afficher le nom des cartes entourés d'une box faîte de + de - et de |,
        // de manière globale
        public void DisplayTextBox(string[] messages, bool multipleSep)
        {
            // Récupération de la longueur maximale parmi les chaines contenues dans " message "
            int cardNamesLenght = 0;
            foreach (string card in Card.GetCardNames()) if (cardNamesLenght < card.Length) cardNamesLenght = card.Length;
            string sep = "+" + new string(' ', cardNamesLenght + 2) + "+";

            //affichage de la première ligne
            Console.WriteLine(sep);
            // Pour chaque nom de la carte, on l'affiche avec les bordures de la boîte
            foreach (string card in Card.GetCardNames())
            {
                Console.WriteLine("|" + card + new string(' ', cardNamesLenght - card.Length) + " |");
                Console.WriteLine(sep);
            }
        }

        //methode permettant d'afficher les actions
        public void DisplayAction()
        {

            string sep = "+--------------------+";
            string title = "| choisissez une action |";
            Console.Write(sep + "\n" + title + "\n" + sep);

        }
        //fonction chargée de créer un cursor représenté par une flèche
        public void Cursor()
        {
            string cursor = "<--";
        }

        //Affichage dès
        public void asciiArtDie()
        {
            List<string[]> asciiArtDie = new List<string[]>();

            asciiArtDie.Add(new string[5] {"- - - - -",
                                          "|        |",
                                          "|   00   |",
                                          "|        |",
                                          "_ _ _ _ _ "});

            asciiArtDie.Add(new string[5] {"- - - - -",
                                          "| 00     |",
                                          "|        |",
                                          "|      00|",
                                          "_ _ _ _ _"});

            asciiArtDie.Add(new string[5] {"- - - - -",
                                          "| 00     |",
                                          "|   00   |",
                                          "|      00|",
                                          "_ _ _ _ _"});

            asciiArtDie.Add(new string[5] {"- - - - -",
                                          "|00    00|",
                                          "|        |",
                                          "|00    00|",
                                          "_ _ _ _ _"});

            asciiArtDie.Add(new string[5] {"- - - - -",
                                          "|00    00|",
                                          "|   00   |",
                                          "|00    00|",
                                          "_ _ _ _ _"});

            asciiArtDie.Add(new string[5] {"- - - - -",
                                          "|00 00 00 |",
                                          "|         |",
                                          "|00 00 00 |",
                                          "_ _ _ _ _"});

            for (int i = 0; i < asciiArtDie.Count; i++)
            {
                if (asciiArtDie[Game.])
                {
                    Console.WriteLine(asciiArtDie[i]);
                }
            }
        }
        

        //Affichage de victoire joueur
        public void DisplayPlayerWin(int score)
        {                 
            string sep = "+-------------------+";
            string victoireJoueurTitre = "| Le joueur a gagné |";
            Console.Write(sep + "\n" + victoireJoueurTitre + "\n" + sep);
        }

        //Affichage de victoire ordinateur
        public void DisplayComputerWin(int score)
        {                 
            string sep = "+----------------------+";
            string victoireOrdinateur= "| L'ordinateur a gagné |";
            Console.Write(sep + "\n" + victoireOrdinateur + "\n" + sep);
        }
        



    }
}
