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

        private int longestLength = 0;

        
        public AFFICHAGE ()
        {
            // Récupération de la longueur de la plus longue description
            longestLength = Card.GetCard(14).Effect.Length;
        }


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

        //Methode permettant de prendre la description la plus longue.
        public void ReturnlongestDescription()
        {

        }

        // methode permettant d'afficher le nom des cartes entourés d'une box faîte de + de - et de |,
        // de manière globale
        public void DisplayTextBox(CardsInfo card)
        {

            string cardDescription = card.Effect;
            string cardname = card.Name;
            bool isTooLong = cardDescription.Length > cardname.Length;
            
            string sep = "+" + new string('-', cardname.Length + 2) + "+";



            //affichage de la première ligne
            Console.WriteLine(sep);
            // Pour chaque nom de la carte, on l'affiche avec les bordures de la boîte            
            //Console.WriteLine("+" + card + new string('-', card.Length) + "+");

            Console.WriteLine(sep);
            Console.WriteLine("|" + card + new string(' ', card.Name.Length - cardname.Length) + " |");
            Console.WriteLine("|" + card + new string(' ', card.Name.Length - cardname.Length) + " |");
            Console.WriteLine("|" + card + new string(' ', card.Name.Length - cardname.Length) + " |");
            Console.WriteLine("|" + card + new string(' ', card.Name.Length - cardname.Length) + " |");
            Console.WriteLine("|" + card + new string(' ', card.Name.Length - cardname.Length) + " |");
            Console.WriteLine(sep);
            Console.WriteLine("|" + card + new string(' ', card.Name.Length - cardname.Length) + " |");
            Console.WriteLine("|" + card + new string(' ', card.Name.Length - cardname.Length) + " |");
            Console.WriteLine(sep);

        }
        
        public void DisplayPlayerCards(Player joueur)
        {
            foreach (CardsInfo carte in joueur.PlayerCards.cards)
            {
                DisplayTextBox(carte);
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

       

        //Affichage des dèsn que l'on range dans un tableau indexé
        public void asciiArtDie(int dieNumber)
        {
            List<string> asciiArtDie = new List<string>();

            asciiArtDie.Add(@"- - - - -
                             |        |
                             |   00   |
                             |        | 
                             _ _ _ _ _ ");

            asciiArtDie.Add(@"- - - - -
                             | 00     |              
                             |        |             
                             |      00|           
                             _ _ _ _ _ ");

            asciiArtDie.Add(@"- - - - -
                             | 00     |              
                             |   00   |             
                             |      00|           
                             _ _ _ _ _ "); 

            asciiArtDie.Add(@"- - - - -
                             | 00   00|              
                             |        |             
                             | 00   00|           
                             _ _ _ _ _ ");


            asciiArtDie.Add(@"- - - - -
                             | 00   00|              
                             |    00  |             
                             | 00   00|           
                             _ _ _ _ _ ");

            asciiArtDie.Add(@"- - - - -
                             |00 00 00|              
                             |        |             
                             |00 00 00|           
                             _ _ _ _ _ ");

            Console.WriteLine(asciiArtDie[dieNumber-1]);
        }

        //fonction affichant une question demandant au joueur s'il veut acheter une carte
        public void displayAchatJoueur()
        {
            string sep =         "+--------------------------------+";
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
            string victoireOrdinateur= "| L'ordinateur a gagné |";
            Console.Write(sep + "\n" + victoireOrdinateur + "\n" + sep);
        }
        



    }
}
