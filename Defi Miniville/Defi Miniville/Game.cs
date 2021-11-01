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

        //Course of the game
        public void GameLoop()
        {
            display.displayWelcome();
            display.DisplayHelp();
            while (!endGame)
            {
                if (Turn)
                {
                    Console.WriteLine();
                    Console.WriteLine("\nIIIIIIIIIIIIIII [ Player turn ] IIIIIIIIIIIIIII\n");
                    Console.WriteLine("Your cards : ");
                    display.DisplayPlayerCards(player);

                    Console.Write("\nDo you want to roll 2 dice ? (o/n) \n>: ");
                    string choixDe = Console.ReadLine();
                    Console.WriteLine();
                    
                    if (choixDe == "o" || choixDe == "o") {
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

                    Console.WriteLine($"\nPlayer pieces : {player.Pieces}");

                    if (!CheckEndGame())
                    {
                        if (player.Pieces > 0)
                        {
                            Console.Write("\nDo you want to buy a new card ? (o/n) \n>: ");
                            string choixBuy = Console.ReadLine();
                            if (choixBuy == "O" || choixBuy == "o")
                            {
                                display.DisplayShop();

                                while (true)
                                {
                                    try
                                    {
                                        Console.Write("\nWhich card do you want to buy ? [ID]  -Press 0 to buy nothing-\n >: ");
                                        int choiceID = int.Parse(Console.ReadLine()) - 1;
                                        if (choiceID < -1 || choiceID > 15)
                                        {
                                            Console.WriteLine("Please enter a valid number\n");
                                        }
                                        else if (choiceID == -1)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            int lengthHand = player.PlayerCards.cards.Count;
                                            player.BuyCard(choiceID);
                                            if (lengthHand == player.PlayerCards.cards.Count)
                                            {
                                                Console.WriteLine("Please enter a valid number\n");
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter a valid number\n");
                                    }
                                }
                            }
                        }

                        dice = 0;
                        dice2 = 0;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\nIIIIIIIIIIIIIII [ AI turn ] IIIIIIIIIIIIIII\n");
                    Console.WriteLine("AI cards : ");
                    display.DisplayPlayerCards(ai);

                    Thread.Sleep(500);
                    Console.WriteLine();

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
                        Console.WriteLine($"\nAI pieces : {ai.Pieces}\n");

                        if (random.Next(0, ai.PlayerCards.cards.Count) <= 1 && ai.Pieces > 0)
                        {
                            Thread.Sleep(500);
                            Console.Write("AI buys a card\n");
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
                            Console.Write("AI doesn't buy anything\n");
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

        //Check if one of the players has won
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

        //Displays a personalized message based on the result of the players' result
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