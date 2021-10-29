using System;
using System.Collections.Generic;
using System.Threading;

namespace Defi_Miniville
{
    class Game
    {
        public bool Turn { get; set; }
        public int nbTurn { get; set; }
        public bool endGame;

        private Player player = new Player();
        private Player ai = new Player();
        private List<int> canAIBuy = new List<int>();

        private Random random = new Random();
        private Die De = new Die();
        public int dice = 0;
        public int dice2 = 0;

        private AFFICHAGE display = new AFFICHAGE();

        public Game()
        {
            nbTurn = 0;
            Turn = true;
        }

        public void GameLoop()
        {
            display.Affichage();
            while (!endGame)
            {
                display.DisplayShop();
                if (Turn)
                {
                    Console.WriteLine("\nIIIIIIIIIIIIIII [ TOUR DU JOUEUR ] IIIIIIIIIIIIIII\n");
                    Console.WriteLine("Vos cartes : ");
                    display.DisplayPlayerCards(player);

                    Console.Write("\nVoulez-vous lancer 2 dés ? \n>: ");
                    string choixDe = Console.ReadLine();
                    Console.WriteLine();
                    
                    if (choixDe == "O" || choixDe == "o") {
                        dice = De.Lancer();
                        dice2 = De.Lancer();
                        display.rollDice(dice, dice2);
                    }
                    else
                    {
                        dice = De.Lancer();
                        display.rollDice(dice, dice2);
                    }

                    ai.Pieces += ai.PlayerCards.GetCardGain("Blue", dice + dice2);
                    ai.Pieces += ai.PlayerCards.GetCardGain("Red", dice + dice2);

                    player.Pieces += player.PlayerCards.GetCardGain("Blue", dice + dice2);
                    player.Pieces += player.PlayerCards.GetCardGain("Green", dice + dice2);

                    Console.WriteLine($"Pièces du joueur : {player.Pieces}");

                    if (!CheckEndGame())
                    {
                        if (player.Pieces > 0)
                        {
                            Console.Write("\nVoulez-vous acheter une nouvelle carte ? \n>: ");
                            string choixBuy = Console.ReadLine();
                            if (choixBuy == "O" || choixBuy == "o")
                            {
                                display.DisplayShop();
                                Console.Write("Quelle carte voulez-vous acheter ? (ID)\n >: ");
                                player.BuyCard(int.Parse(Console.ReadLine()) - 1);
                            }
                        }

                        dice = 0;
                        dice2 = 0;
                    }
                }
                else
                {
                    Console.WriteLine("\nIIIIIIIIIIIIIII [ TOUR DE L'IA ] IIIIIIIIIIIIIII\n");
                    Console.WriteLine("Cartes de l'IA : ");
                    display.DisplayPlayerCards(ai);

                    Thread.Sleep(500);

                    if (ai.PlayerCards.needTwoDice() == true && random.Next(0, 3) <= 1) {
                        dice = De.Lancer();
                        dice2 = De.Lancer();
                        display.rollDice(dice, dice2);
                    }
                    else
                    {
                        dice = De.Lancer();
                        display.rollDice(dice, dice2);
                    }

                    player.Pieces += player.PlayerCards.GetCardGain("Blue", dice + dice2);
                    player.Pieces += player.PlayerCards.GetCardGain("Red", dice + dice2);

                    ai.Pieces += ai.PlayerCards.GetCardGain("Blue", dice + dice2);
                    ai.Pieces += ai.PlayerCards.GetCardGain("Green", dice + dice2);

                    if (!CheckEndGame())
                    {
                        Thread.Sleep(500);
                        Console.WriteLine($"\nPièces de l'IA : {ai.Pieces}\n");

                        if (random.Next(0, 2) == 1 && ai.Pieces > 0)
                        {
                            Thread.Sleep(500);
                            Console.Write("L'IA achète une carte\n");
                            for (int i = 0; i < Card.GetCardCosts().Count; i++)
                            {
                                if (ai.Pieces >= Card.GetCardCosts()[i])
                                {
                                    canAIBuy.Add(i);
                                }
                            }
                            ai.BuyCard(canAIBuy[random.Next(0, canAIBuy.Count)]);
                        }
                        else
                        {
                            Thread.Sleep(500);
                            Console.Write("L'IA n'achète rien\n");
                        }

                        dice = 0;
                        dice2 = 0;
                        canAIBuy = new List<int>();
                    }
                }

                Turn = !Turn;
                endGame = CheckEndGame();
            }
            CheckPlayerWin();
        }
        private void printList(List<int> liste)
        {
            foreach(int i in liste)
            {
                Console.Write(i);
                Console.Write(" - ");
            }
        }

        //Vérifie si l'un des joueurs a gagné
        public bool CheckEndGame()
        {
            if (player.Pieces >= 20 || ai.Pieces >= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Affiche un message personnalisé en fonction du résultat du résultat des joueurs
        public void CheckPlayerWin()
        {

            if (player.Pieces >= 20 && player.Pieces == ai.Pieces)
            {
                Console.Write("\n");
                display.DisplayDraw();
            }
            else if (player.Pieces >= 20 && player.Pieces > ai.Pieces)
            {
                Console.Write("\n");
                display.DisplayPlayerWin();
            }
            else
            {
                Console.Write("\n");
                display.DisplayComputerWin();
            }

        }

    }
}