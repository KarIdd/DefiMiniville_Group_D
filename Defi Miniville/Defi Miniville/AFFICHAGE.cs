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
            int temp = 0;
            List<int> lenghtList = new List<int>();
            foreach (CardsInfo carte in joueur.PlayerCards.cards) {
                int cardNameLenght = carte.Name.Length;

                string haut = "   " + "+" + new string('─', (cardNameLenght + 23) / 2) + carte.Cost + "$" + new string('─', (cardNameLenght + 22) / 2) + "+" + "  ";
                if ((carte.Id + 1) > 9 && carte.MinDice != carte.MaxDice) haut = "   " + "+" + new string('─', (cardNameLenght + 26 + carte.MinDice / 10 + carte.MaxDice / 10) / 2) + carte.Cost + "$" + new string('─', (cardNameLenght + 25 + carte.MinDice / 10 + carte.MaxDice / 10) / 2) + "+" + "  ";
                else if ((carte.Id + 1) > 9) haut = "   " + "+" + new string('─', (cardNameLenght + 24 + carte.MinDice / 10) / 2) + carte.Cost + "$" + new string('─', (cardNameLenght + 23 + carte.MinDice / 10) / 2) + "+" + "  ";
                else if (carte.MinDice != carte.MaxDice) haut = "   " + "+" + new string('─', (cardNameLenght + 25 + carte.MaxDice / 10) / 2) + carte.Cost + "$" + new string('─', (cardNameLenght + 24 + carte.MaxDice / 10) / 2) + "+" + "  ";
                colorCards(carte);
                Console.Write(haut);

                lenghtList.Add(haut.Length);
            }
            Console.WriteLine();

            foreach (CardsInfo carte in joueur.PlayerCards.cards) {
                string mid = "   " + "│        " + "[" + (carte.Id + 1) + "] " + carte.Name + " {" + carte.MinDice + "}" + "        │" + "  ";
                if (carte.MinDice != carte.MaxDice) mid = "   " + "│        " + "[" + (carte.Id + 1) + "] " + carte.Name + " {" + carte.MinDice + "-" + carte.MaxDice + "}" + "        │" + "  ";
                colorCards(carte);
                Console.Write(mid);
            }
            Console.WriteLine();

            foreach (CardsInfo carte in joueur.PlayerCards.cards)
            {
                var mots = carte.Effect.Split("-");
                string mid2 = "   " + "|" + new string(' ', (lenghtList[temp] - 7 - mots[0].Length) / 2) + mots[0] + new string(' ', (lenghtList[temp] - 6 - mots[0].Length) / 2) + "|" + "  ";
                colorCards(carte);
                Console.Write(mid2);
                temp += 1;
            }
            temp = 0;
            Console.WriteLine();

            foreach (CardsInfo carte in joueur.PlayerCards.cards)
            {
                var mots = carte.Effect.Split("-");
                string mid3 = "   " + "|" + new string(' ', (lenghtList[temp] - 7 - mots[1].Length) / 2) + mots[1] + new string(' ', (lenghtList[temp] - 6 - mots[1].Length) / 2) + "|" + "  ";
                colorCards(carte);
                Console.Write(mid3);
                temp += 1;
            }
            temp = 0;
            Console.WriteLine();

            foreach (CardsInfo carte in joueur.PlayerCards.cards) {
                int cardNameLenght = carte.Name.Length;
                string bas = "   " + "+" + new string('─', cardNameLenght + 24) + "+" + "  ";
                if ((carte.Id + 1) > 9 && carte.MinDice != carte.MaxDice) bas = "   " + "+" + new string('─', cardNameLenght + 27 + carte.MinDice / 10 + carte.MaxDice / 10) + "+" + "  ";
                else if ((carte.Id + 1) > 9) bas = "   " + "+" + new string('─', cardNameLenght + 24 + carte.MinDice / 5) + "+" + "  ";
                else if (carte.MinDice != carte.MaxDice) bas = "   " + "+" + new string('─', cardNameLenght + 26 + carte.MaxDice / 10) + "+" + "  ";
                colorCards(carte);
                Console.Write(bas);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayShop()
        {
            int temp = 0;

            for (int i = 0; i < 5; i++)
            {
                List<int> lenghtList = new List<int>();
                for (int j = 0; j<3; j++)
                {
                    int cardNameLenght = Card.CardShop[j+temp].Name.Length;

                    string haut = "   " + "+" + new string('─', (cardNameLenght + 23) /2) + Card.CardShop[j + temp].Cost + "$" + new string('─', (cardNameLenght + 22) / 2) + "+" + "  ";
                    if ((Card.CardShop[j + temp].Id + 1) > 9 && Card.CardShop[j + temp].MinDice != Card.CardShop[j + temp].MaxDice) haut = "   " + "+" + new string('─', (cardNameLenght + 26 + Card.CardShop[j + temp].MinDice / 10 + Card.CardShop[j + temp].MaxDice / 10) / 2) + Card.CardShop[j + temp].Cost + "$" + new string('─', (cardNameLenght + 25 + Card.CardShop[j + temp].MinDice / 10 + Card.CardShop[j + temp].MaxDice / 10) / 2) + "+" + "  ";
                    else if ((Card.CardShop[j + temp].Id + 1) > 9) haut = "   " + "+" + new string('─', (cardNameLenght + 24 + Card.CardShop[j + temp].MinDice / 10) / 2) + Card.CardShop[j + temp].Cost + "$" + new string('─', (cardNameLenght + 23 + Card.CardShop[j + temp].MinDice / 10) / 2) + "+" + "  ";
                    else if (Card.CardShop[j + temp].MinDice != Card.CardShop[j + temp].MaxDice) haut = "   " + "+" + new string('─', (cardNameLenght + 25 + Card.CardShop[j + temp].MaxDice / 10) / 2) + Card.CardShop[j + temp].Cost + "$" + new string('─', (cardNameLenght + 24 + Card.CardShop[j + temp].MaxDice / 10) / 2) + "+" + "  ";
                    colorCards(Card.CardShop[j + temp]);
                    Console.Write(haut);

                    lenghtList.Add(haut.Length);
                }
                Console.WriteLine();

                for (int j = 0; j < 3; j++)
                {
                    string mid = "   " + "│        " + "[" + (Card.CardShop[j + temp].Id + 1) + "] " + Card.CardShop[j + temp].Name + " {" + Card.CardShop[j + temp].MinDice + "}" + "        │" + "  ";
                    if (Card.CardShop[j + temp].MinDice != Card.CardShop[j + temp].MaxDice) mid = "   " + "│        " + "[" + (Card.CardShop[j + temp].Id + 1) + "] " + Card.CardShop[j + temp].Name + " {" + Card.CardShop[j + temp].MinDice + "-" + Card.CardShop[j + temp].MaxDice + "}" + "        │" + "  ";
                    colorCards(Card.CardShop[j + temp]);
                    Console.Write(mid);
                }
                Console.WriteLine();

                for (int j = 0; j < 3; j++)
                {
                    var mots = Card.CardShop[j + temp].Effect.Split("-");
                    string mid2 = " x" + Card.CardShop[j + temp].Number + "|"+ new string(' ', (lenghtList[j] - 7 - mots[0].Length) /2) + mots[0] + new string(' ', (lenghtList[j] - 6 - mots[0].Length) / 2) + "|" + "  ";
                    colorCards(Card.CardShop[j + temp]);
                    Console.Write(mid2);
                }
                Console.WriteLine();

                for (int j = 0; j < 3; j++)
                {
                    var mots = Card.CardShop[j + temp].Effect.Split("-");
                    string mid3 = "   " + "|" + new string(' ', (lenghtList[j] - 7 - mots[1].Length) / 2) + mots[1] + new string(' ', (lenghtList[j] - 6 - mots[1].Length) / 2) + "|" + "  ";
                    colorCards(Card.CardShop[j + temp]);
                    Console.Write(mid3);
                }
                Console.WriteLine();

                for (int j = 0; j < 3; j++)
                {
                    int cardNameLenght = Card.CardShop[j + temp].Name.Length;
                    string bas = "   " + "+" + new string('─', cardNameLenght + 24) + "+" + "  ";
                    if ((Card.CardShop[j + temp].Id + 1) > 9 && Card.CardShop[j + temp].MinDice != Card.CardShop[j + temp].MaxDice) bas = "   " + "+" + new string('─', cardNameLenght + 27 + Card.CardShop[j + temp].MinDice / 10 + Card.CardShop[j + temp].MaxDice / 10) + "+" + "  ";
                    else if ((Card.CardShop[j + temp].Id + 1) > 9) bas = "   " + "+" + new string('─', cardNameLenght + 24 + Card.CardShop[j + temp].MinDice/5) + "+" + "  ";
                    else if (Card.CardShop[j + temp].MinDice != Card.CardShop[j + temp].MaxDice) bas = "   " + "+" + new string('─', cardNameLenght + 26 + Card.CardShop[j + temp].MaxDice/10) + "+" + "  ";
                    colorCards(Card.CardShop[j + temp]);
                    Console.Write(bas);
                }
                Console.WriteLine();
                temp += 3;
            }
            
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

        //Affiche des dés aléatoires avant d'afficher les bons dés, pour simuler un jet de dé
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
            string AchatJoueur = "| Voulez-vous acheter une carte ? |";
            Console.WriteLine(sep + "\n" + AchatJoueur + "\n" + sep);
        }

        //Creation d'une fonction permettant de mettre les cartes sur un tableau


        //Affichage de victoire joueur
        public void DisplayPlayerWin()
        {
            string sep = "+-------------------+";
            string victoireJoueurTitre = "| Le joueur a gagné |";
            Console.Write(sep + "\n" + victoireJoueurTitre + "\n" + sep);
        }

        //Affichage de victoire ordinateur
        public void DisplayComputerWin()
        {
            string sep = "+----------------------+";
            string victoireOrdinateur = "| L'ordinateur a gagné |";
            Console.Write(sep + "\n" + victoireOrdinateur + "\n" + sep);
        }

        public void DisplayDraw()
        {
            string sep = "+---------+";
            string victoireOrdinateur = "| Egalité |";
            Console.Write(sep + "\n" + victoireOrdinateur + "\n" + sep);
        }




    }
}
