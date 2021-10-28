using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Text;

namespace Defi_Miniville
{
    // Classe qui gère l'affichage
    class AFFICHAGE
    {
        public Card card = new Card();
        public Random random = new Random();
        int nbdice;

        public void Affichage()
        {
            string sep = " + ------------------------------------ +";
            string title = " |  BIENVENUE DANS CE JEU DE MINIVILLE  |";
            Console.WriteLine(sep + "\n" + title + "\n" + sep);
        }



        public void Displaycards()
        {
            for (int item = 0; item < 8; item++)
            {
                Console.WriteLine(Card.GetCard(item).Name);
            }
        }

        public void colorCards(CardsInfo card)
        {
            if(card.Color == "Red") {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (card.Color == "Blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            if (card.Color == "Green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        public void DisplayPlayerCards(Player joueur)
        {
            
            foreach (CardsInfo carte in joueur.PlayerCards.cards) {
                int cardNameLenght = carte.Name.Length;
                string haut = "+" + new string('─', cardNameLenght + 8) + "+" + "  ";
                if ((carte.Id + 1) > 9) haut = "+" + new string('─', cardNameLenght + 9) + "+" + "  ";
                colorCards(carte);
                Console.Write(haut);
            }
            Console.WriteLine();

            foreach (CardsInfo carte in joueur.PlayerCards.cards) {
                string mid = "│  " + "[" + (carte.Id+1) + "] " + carte.Name + "  │" + "  ";
                colorCards(carte);
                Console.Write(mid);
            }
            Console.WriteLine();

            foreach (CardsInfo carte in joueur.PlayerCards.cards) {
                int cardNameLenght = carte.Name.Length;
                string bas = "+" + new string('─', cardNameLenght + 8) + "+" + "  ";
                if((carte.Id + 1) > 9) bas = "+" + new string('─', cardNameLenght + 9) + "+" + "  ";
                colorCards(carte);
                Console.Write(bas);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
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



        //Affichage des dèsn que l'on range dans un tableau indexé
        public void asciiArtDie(int dieNumber1, int dieNumber2)
        {
            List<List<string>> asciiArtDie = new List<List<string>>();
            if (dieNumber2 == 0)
            {
                nbdice = 1;
            }
            else
            {
                nbdice = 2;
            }

            asciiArtDie.Add(new List<string> { "       ", "   0   ", "       " });

            asciiArtDie.Add(new List<string> { " 0     ", "       ", "     0 " });

            asciiArtDie.Add(new List<string> { " 0     ", "   0   ", "     0 " });

            asciiArtDie.Add(new List<string> { " 0   0 ", "       ", " 0   0 " });

            asciiArtDie.Add(new List<string> { " 0   0 ", "   0   ", " 0   0 " });

            asciiArtDie.Add(new List<string> { " 0   0 ", " 0   0 ", " 0   0 " });



            for (int i = 0; i < nbdice; i++)
            {
                Console.Write("- - - - -   ");
            }
            Console.Write("\n");
            for (int i = 0; i < nbdice; i++)
            {
                if (i==0)
                    Console.Write("|{0}|   ", asciiArtDie[dieNumber1 - 1][0]);
                else
                    Console.Write("|{0}|   ", asciiArtDie[dieNumber2 - 1][0]);
            }
            Console.Write("\n");
            for (int i = 0; i < nbdice; i++)
            {
                if (i == 0)
                    Console.Write("|{0}|   ", asciiArtDie[dieNumber1 - 1][1]);
                else
                    Console.Write("|{0}|   ", asciiArtDie[dieNumber2 - 1][1]);
            }
            Console.Write("\n");
            for (int i = 0; i < nbdice; i++)
            {
                if (i == 0)
                    Console.Write("|{0}|   ", asciiArtDie[dieNumber1 - 1][2]);
                else
                    Console.Write("|{0}|   ", asciiArtDie[dieNumber2 - 1][2]);
            }
            Console.Write("\n");
            for (int i = 0; i < nbdice; i++)
            {
                Console.Write("- - - - -   ");
            }
            Console.Write("\n");
        }

        public void rollDice(int dieNumber1, int dieNumber2)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(left, top);
                Thread.Sleep(100);
                if (dieNumber2 == 0)
                    asciiArtDie(random.Next(1, 7), 0);
                else
                    asciiArtDie(random.Next(1, 7), random.Next(1, 7));
            }
            Console.SetCursorPosition(left, top);
            asciiArtDie(dieNumber1, dieNumber2);
        }


        //fonction affichant une question demandant au joueur s'il veut acheter une carte
        public void displayAchatJoueur()
        {
            string sep = "+--------------------------------+";
            string AchatJoueur = "| voulez-vous acheter une carte ?|";
            Console.WriteLine(sep + "\n" + AchatJoueur + "\n" + sep);
        }

        //Creation d'une fonction permettant de mettre les cartes sur un tableau


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
            string victoireOrdinateur = "| L'ordinateur a gagné |";
            Console.Write(sep + "\n" + victoireOrdinateur + "\n" + sep);
        }




    }
}
