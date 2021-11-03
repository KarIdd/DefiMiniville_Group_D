using System;
using System.Collections.Generic;
using System.Threading;

namespace Defi_Miniville
{
    // Classe qui gère l'affichage
    class Display
    {
        private Card card = new Card();
        private Random random = new Random();
        private int nbdice;

        //Affiche un message de bienvenu
        public void DisplayWelcome()
        {
            string sep = " + ------------------------------------ +";
            string title = " |    WELCOME TO THIS MINIVILLE GAME    |";
            Console.WriteLine(sep + "\n" + title + "\n" + sep);
        }

        //Change la couleur de fond de texte en fonction de la couleur de la carte renseignée
        public void ColorCards(CardsInfo card)
        {
            if(card.Color == "Red") {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (card.Color == "Blue")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            if (card.Color == "Green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        //Affiche toutes les cartes du joueur renseigné
        public void DisplayPlayerCards(Player joueur)
        {
            int temp = 0;
            List<int> lenghtList = new List<int>();
            List<CardsInfo> sameList = new List<CardsInfo>();

            foreach (CardsInfo carte in joueur.PlayerCards.cards)
            {
                sameList.Add(carte);
            }
            List<CardsInfo> partList = new List<CardsInfo>();
            int iteration;
            while (sameList.Count != 0)
            {
                if (sameList.Count < 4)
                {
                    iteration = sameList.Count;
                }
                else
                {
                    iteration = 4;
                }
                for (int i = 0; i < iteration; i++)
                {
                    partList.Add(sameList[0]);
                    sameList.Remove(sameList[0]);
                }


                foreach (CardsInfo carte in partList)
                {
                    int cardNameLenght = carte.Name.Length;

                    string haut = " " + "+" + new string('─', (cardNameLenght + 23) / 2) + carte.Cost + "$" + new string('─', (cardNameLenght + 22) / 2) + "+" + " ";
                    if ((carte.Id + 1) > 9 && carte.MinDice != carte.MaxDice) haut = " " + "+" + new string('─', (cardNameLenght + 26 + carte.MinDice / 10 + carte.MaxDice / 10) / 2) + carte.Cost + "$" + new string('─', (cardNameLenght + 25 + carte.MinDice / 10 + carte.MaxDice / 10) / 2) + "+" + " ";
                    else if ((carte.Id + 1) > 9) haut = " " + "+" + new string('─', (cardNameLenght + 24 + carte.MinDice / 10) / 2) + carte.Cost + "$" + new string('─', (cardNameLenght + 23 + carte.MinDice / 10) / 2) + "+" + " ";
                    else if (carte.MinDice != carte.MaxDice) haut = " " + "+" + new string('─', (cardNameLenght + 25 + carte.MaxDice / 10) / 2) + carte.Cost + "$" + new string('─', (cardNameLenght + 24 + carte.MaxDice / 10) / 2) + "+" + " ";
                    ColorCards(carte);
                    Console.Write(haut);

                    lenghtList.Add(haut.Length);
                }
                Console.WriteLine();

                foreach (CardsInfo carte in partList)
                {
                    string mid = " " + "│        " + "[" + (carte.Id + 1) + "] " + carte.Name + " {" + carte.MinDice + "}" + "        │" + " ";
                    if (carte.MinDice != carte.MaxDice) mid = " " + "│        " + "[" + (carte.Id + 1) + "] " + carte.Name + " {" + carte.MinDice + "-" + carte.MaxDice + "}" + "        │" + " ";
                    ColorCards(carte);
                    Console.Write(mid);
                }
                Console.WriteLine();

                foreach (CardsInfo carte in partList)
                {
                    var mots = carte.Effect.Split("-");
                    string mid2 = " " + "│" + new string(' ', (lenghtList[temp] - 4 - mots[0].Length) / 2) + mots[0] + new string(' ', (lenghtList[temp] - 3 - mots[0].Length) / 2) + "│" + " ";
                    ColorCards(carte);
                    Console.Write(mid2);
                    temp += 1;
                }
                temp = 0;
                Console.WriteLine();

                foreach (CardsInfo carte in partList)
                {
                    var mots = carte.Effect.Split("-");
                    string mid3 = " " + "│" + new string(' ', (lenghtList[temp] - 4 - mots[1].Length) / 2) + mots[1] + new string(' ', (lenghtList[temp] - 3 - mots[1].Length) / 2) + "│" + " ";
                    ColorCards(carte);
                    Console.Write(mid3);
                    temp += 1;
                }
                temp = 0;
                Console.WriteLine();

                foreach (CardsInfo carte in partList)
                {
                    int cardNameLenght = carte.Name.Length;
                    string bas = " " + "+" + new string('─', cardNameLenght + 24) + "+" + " ";
                    if ((carte.Id + 1) > 9 && carte.MinDice != carte.MaxDice) bas = " " + "+" + new string('─', cardNameLenght + 27 + carte.MinDice / 10 + carte.MaxDice / 10) + "+" + " ";
                    else if ((carte.Id + 1) > 9) bas = " " + "+" + new string('─', cardNameLenght + 24 + carte.MinDice / 5) + "+" + " ";
                    else if (carte.MinDice != carte.MaxDice) bas = " " + "+" + new string('─', cardNameLenght + 26 + carte.MaxDice / 10) + "+" + " ";
                    ColorCards(carte);
                    Console.Write(bas);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                partList = new List<CardsInfo>();
                lenghtList = new List<int>();
            }
        }

        //Affiche toutes les cartes disponibles à l'achat
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
                    ColorCards(Card.CardShop[j + temp]);
                    Console.Write(haut);

                    lenghtList.Add(haut.Length);
                }
                Console.WriteLine();

                for (int j = 0; j < 3; j++)
                {
                    string mid = "   " + "│        " + "[" + (Card.CardShop[j + temp].Id + 1) + "] " + Card.CardShop[j + temp].Name + " {" + Card.CardShop[j + temp].MinDice + "}" + "        │" + "  ";
                    if (Card.CardShop[j + temp].MinDice != Card.CardShop[j + temp].MaxDice) mid = "   " + "│        " + "[" + (Card.CardShop[j + temp].Id + 1) + "] " + Card.CardShop[j + temp].Name + " {" + Card.CardShop[j + temp].MinDice + "-" + Card.CardShop[j + temp].MaxDice + "}" + "        │" + "  ";
                    ColorCards(Card.CardShop[j + temp]);
                    Console.Write(mid);
                }
                Console.WriteLine();

                for (int j = 0; j < 3; j++)
                {
                    var mots = Card.CardShop[j + temp].Effect.Split("-");
                    string mid2 = " x" + Card.CardShop[j + temp].Number + "│" + new string(' ', (lenghtList[j] - 7 - mots[0].Length) /2) + mots[0] + new string(' ', (lenghtList[j] - 6 - mots[0].Length) / 2) + "│" + "  ";
                    ColorCards(Card.CardShop[j + temp]);
                    Console.Write(mid2);
                }
                Console.WriteLine();

                for (int j = 0; j < 3; j++)
                {
                    var mots = Card.CardShop[j + temp].Effect.Split("-");
                    string mid3 = "   " + "│" + new string(' ', (lenghtList[j] - 7 - mots[1].Length) / 2) + mots[1] + new string(' ', (lenghtList[j] - 6 - mots[1].Length) / 2) + "│" + "  ";
                    ColorCards(Card.CardShop[j + temp]);
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
                    ColorCards(Card.CardShop[j + temp]);
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
            string title = "│ choisissez une action │";
            Console.Write(sep + "\n" + title + "\n" + sep);

        }



        //fonction chargée de créer un cursor représenté par une flèche
        public void Cursor()
        {
            string cursor = "<--";
        }



        //Affiche entre un et deux dés 6 en focntion des valeurs renseignées 
        public void AsciiArtDie(int dieNumber1, int dieNumber2)
        {
            List<List<string>> AsciiArtDie = new List<List<string>>();
            if (dieNumber2 == 0)
            {
                nbdice = 1;
            }
            else
            {
                nbdice = 2;
            }

            AsciiArtDie.Add(new List<string> { "       ", "   0   ", "       " });

            AsciiArtDie.Add(new List<string> { " 0     ", "       ", "     0 " });

            AsciiArtDie.Add(new List<string> { " 0     ", "   0   ", "     0 " });

            AsciiArtDie.Add(new List<string> { " 0   0 ", "       ", " 0   0 " });

            AsciiArtDie.Add(new List<string> { " 0   0 ", "   0   ", " 0   0 " });

            AsciiArtDie.Add(new List<string> { " 0   0 ", " 0   0 ", " 0   0 " });



            for (int i = 0; i < nbdice; i++)
            {
                Console.Write("+───────+   ");
            }
            Console.Write("\n");
            for (int i = 0; i < nbdice; i++)
            {
                if (i==0)
                    Console.Write("|{0}|   ", AsciiArtDie[dieNumber1 - 1][0]);
                else
                    Console.Write("|{0}|   ", AsciiArtDie[dieNumber2 - 1][0]);
            }
            Console.Write("\n");
            for (int i = 0; i < nbdice; i++)
            {
                if (i == 0)
                    Console.Write("|{0}|   ", AsciiArtDie[dieNumber1 - 1][1]);
                else
                    Console.Write("|{0}|   ", AsciiArtDie[dieNumber2 - 1][1]);
            }
            Console.Write("\n");
            for (int i = 0; i < nbdice; i++)
            {
                if (i == 0)
                    Console.Write("|{0}|   ", AsciiArtDie[dieNumber1 - 1][2]);
                else
                    Console.Write("|{0}|   ", AsciiArtDie[dieNumber2 - 1][2]);
            }
            Console.Write("\n");
            for (int i = 0; i < nbdice; i++)
            {
                Console.Write("+───────+   ");
            }
            Console.Write("\n");
        }

        //Affiche des dés aléatoires avant d'afficher les bons dés, pour simuler un jet de dé
        public void RollDice(int dieNumber1, int dieNumber2)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(left, top);
                Thread.Sleep(100);
                if (dieNumber2 == 0)
                    AsciiArtDie(random.Next(1, 7), 0);
                else
                    AsciiArtDie(random.Next(1, 7), random.Next(1, 7));
            }
            Console.SetCursorPosition(left, top);
            AsciiArtDie(dieNumber1, dieNumber2);
        }


        //fonction affichant une question demandant au joueur s'il veut acheter une carte
        public void displayAchatJoueur()
        {
            string sep = "+─────────────────────────+";
            string AchatJoueur = "│ Voulez-vous acheter une carte ? │";
            Console.WriteLine(sep + "\n" + AchatJoueur + "\n" + sep);
        }

        //Affichage de victoire joueur
        public void DisplayPlayerWin()
        {
            string sep = "+────────────────+";
            string victoireJoueurTitre = "│ The player won │";
            Console.Write("\n" + sep + "\n" + victoireJoueurTitre + "\n" + sep + "\n");
        }

        //Affichage de victoire ordinateur
        public void DisplayComputerWin()
        {
            string sep = "+──────────────────+";
            string victoireOrdinateur = "│ The computer won │";
            Console.Write("\n" + sep + "\n" + victoireOrdinateur + "\n" + sep + "\n");
        }

        //Affichage de l'égalité
        public void DisplayDraw()
        {
            string sep = "+──────+";
            string victoireOrdinateur = "│ Draw │";
            Console.Write("\n" + sep + "\n" + victoireOrdinateur + "\n" + sep + "\n");
        }

        //Affichage de l'aide
        public void DisplayHelp()
        {
            string pres = "\n Cards' functioning :\n";
            string sep1 = "                      Card name                     ";
            string sep2 = "                             │  Card price          ";
            string sep3 = "                             │   │                  ";
            string sep4 = "                             │   ▼                  ";
            string sep5 = "               +─────────────▼───1$────────────────+";
            string sep6 = "  Card ID─────────────►[1] Wheat field {1}◄────────────Card activation value(s)";
            string sep7 = "               │            Get 1 coin             │";
            string sep8 = "               │                ▲                  │";
            string sep9 = "               +────────────────│──────────────────+";
            string sep10= "                                │                   ";
            string sep11= "                           Card effect              ";

            Console.Write(pres + "\n" + sep1 + "\n" + sep2 + "\n" + sep3 + "\n" + sep4 + "\n" + sep5 + "\n" + sep6 + "\n" + sep7 + "\n" + sep8 + "\n" + sep9 + "\n" + sep10 + "\n" + sep11+ "\n");
        } 


    }
}
