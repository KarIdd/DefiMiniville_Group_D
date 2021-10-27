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
        public bool twoDice;

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
                    if (Console.ReadLine() == "O" || Console.ReadLine() == "o")
                    {
                        twoDice = true;
                        dice2 = De.Lancer();
                    }
                    dice = De.Lancer();

                    ai.Pieces += ai.PlayerCards.GetCardGain("blue", dice);
                    ai.Pieces += ai.PlayerCards.GetCardGain("red", dice);

                    player.Pieces += player.PlayerCards.GetCardGain("blue", dice);
                    player.Pieces += player.PlayerCards.GetCardGain("green", dice);

                    Console.Write("Voulez-vous acheter une nouvelle carte ? \n>: ");
                    if (Console.ReadLine() == "O" || Console.ReadLine() == "o")
                    {
                        Console.Write("Quelle carte voulez-vous acheter ? (ID)\n >: ");
                        player.BuyCard(int.Parse(Console.ReadLine()));
                    }
                }
                else
                {
                    if ()
                        dice = De.Lancer();

                    player.Pieces += player.PlayerCards.GetCardGain("blue", dice);
                    player.Pieces += player.PlayerCards.GetCardGain("red", dice);

                    ai.Pieces += ai.PlayerCards.GetCardGain("blue", dice);
                    ai.Pieces += ai.PlayerCards.GetCardGain("green", dice);

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
                }
                Turn = !Turn;
                CheckEndGame();
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
            else if(player.Pieces >= 20 && player.Pieces > ai.Pieces)
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
