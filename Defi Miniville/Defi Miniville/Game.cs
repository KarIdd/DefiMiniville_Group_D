using System;
using System.Collections.Generic;

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
        public static int dice = 0;
        public static int dice2 = 0;

        public Game()
        {
            nbTurn = 0;
        }

        public void GameLoop()
        {
            while (!endGame)
            {
                if (Turn)
                {
                    Console.Write("Voulez-vous lancer 2 dés ? \n>: ");
                    if (Console.ReadLine() == "O" || Console.ReadLine() == "o") {
                        dice2 = De.Lancer();
                    }
                    dice = De.Lancer();

                    ai.Pieces += ai.PlayerCards.GetCardGain("blue", dice + dice2);
                    ai.Pieces += ai.PlayerCards.GetCardGain("red", dice + dice2);

                    player.Pieces += player.PlayerCards.GetCardGain("blue", dice + dice2);
                    player.Pieces += player.PlayerCards.GetCardGain("green", dice + dice2);

                    Console.Write("Voulez-vous acheter une nouvelle carte ? \n>: ");
                    if (Console.ReadLine() == "O" || Console.ReadLine() == "o")
                    {
                        Console.Write("Quelle carte voulez-vous acheter ? (ID)\n >: ");
                        player.BuyCard(int.Parse(Console.ReadLine()));
                    }

                    dice = 0;
                    dice2 = 0;
                }
                else
                {
                    if (ai.PlayerCards.needTwoDice() == true && random.Next(0, 3) <= 1) {
                        dice2 = De.Lancer();
                    }
                    dice = De.Lancer();

                    player.Pieces += player.PlayerCards.GetCardGain("blue", dice + dice2);
                    player.Pieces += player.PlayerCards.GetCardGain("red", dice + dice2);

                    ai.Pieces += ai.PlayerCards.GetCardGain("blue", dice + dice2);
                    ai.Pieces += ai.PlayerCards.GetCardGain("green", dice + dice2);

                    if (random.Next(0, 2) == 1 && ai.Pieces > 0)
                    {
                        for (int i = 0; i < Card.GetCardCosts().Count; i++)
                        {
                            if (ai.Pieces >= Card.GetCardCosts()[i])
                            {
                                canAIBuy.Add(i);
                            }
                        }

                        ai.BuyCard(canAIBuy[random.Next(0, canAIBuy.Count)]);
                    }

                    dice = 0;
                    dice2 = 0;
                }

                Turn = !Turn;
                endGame = CheckEndGame();
            }
            CheckPlayerWin();
        }

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

        public void CheckPlayerWin()
        {

            if (player.Pieces >= 20 && player.Pieces == ai.Pieces)
            {
                Console.WriteLine($"Egalité, avec {player.Pieces} !");
            }
            else if (player.Pieces >= 20 && player.Pieces > ai.Pieces)
            {
                Console.WriteLine($"Le joueur a gagné avec {player.Pieces} !");
            }
            else
            {
                Console.WriteLine($"L'IA a gagné avec {ai.Pieces} !");
            }

        }

    }
}