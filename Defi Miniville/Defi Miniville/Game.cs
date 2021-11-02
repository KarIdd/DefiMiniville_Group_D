using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Defi_Miniville
{
    class Game
    {
        public bool Turn { get; set; }
        public int nbTurn { get; set; }
        public bool endGame;
        public int scoreGoal;
        public int difficulty;

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

            Console.WriteLine("\nChoose the game mode : \n");
            Console.WriteLine("1-Fast (10 points)");
            Console.WriteLine("2-Normal (20 points)");
            Console.WriteLine("3-Long (30 points)");
            Console.Write("4-Expert (30 points and own each in at least one copy)\n\n>: ");
            while (true)
            {
                try
                {
                    difficulty = int.Parse(Console.ReadLine());
                    if (difficulty < 1 || difficulty > 4)
                    {
                        Console.Write("\nPlease enter a valid number\n >: ");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.Write("\nPlease enter a valid number\n >: ");
                }
            }
            switch (difficulty)
            {
                case 1 :
                    scoreGoal = 10;
                    break;
                case 2 :
                    scoreGoal = 20;
                    break;
                case 3 :
                    scoreGoal = 30;
                    break;
                case 4 :
                    scoreGoal = 30;
                    break;
                default :
                    scoreGoal = 20;
                    break;

            }

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

                    if (!CheckEndGame(scoreGoal, difficulty))
                    {
                        if (player.Pieces > 0)
                        {
                            Console.Write("\nDo you want to buy a new card ? (o/n) \n>: ");
                            string choiceBuy = Console.ReadLine();
                            if (choiceBuy == "O" || choiceBuy == "o")
                            {
                                display.DisplayShop();

                                Console.Write("\nWhich card do you want to buy ? [ID]  -Press 0 to buy nothing-\n >: ");
                                while (true)
                                {
                                    try
                                    {
                                        int choiceID = int.Parse(Console.ReadLine()) - 1;
                                        if (choiceID < -1 || choiceID > 15)
                                        {
                                            Console.Write("\nPlease enter a valid number\n >: ");
                                        }
                                        else if (choiceID == -1)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            if (Card.CardShop[choiceID].Number == 0)
                                            {
                                                Console.Write("\nPlease enter a valid number\n >: ");
                                            }
                                            else
                                            {
                                                player.BuyCard(choiceID);
                                                break;
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        Console.Write("\nPlease enter a valid number\n >: ");
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

                    if (!CheckEndGame(scoreGoal, difficulty))
                    {
                        Thread.Sleep(500);
                        Console.WriteLine($"\nAI pieces : {ai.Pieces}\n");

                        if (random.Next(0, ai.PlayerCards.cards.Count) <= 1 && ai.Pieces > 0)
                        {
                            Thread.Sleep(500);
                            string aiChoice;
                            for (int i = 0; i < Card.GetCardCosts().Count; i++)
                            {
                                if (ai.Pieces >= Card.GetCardCosts()[i])
                                {
                                    canAIBuy.Add(i);
                                }
                            }
                            if (canAIBuy.Contains(Card.CardShop[0].Id) && Card.CardShop[0].Number == 0)
                            {
                                if (canAIBuy.Contains(Card.CardShop[1].Id) && Card.CardShop[1].Number == 0)
                                {
                                    if (random.Next(0, 100) <= 35)
                                    {
                                        ai.BuyCard(random.Next(0, 2));
                                    }
                                    else
                                    {
                                        ai.BuyCard(canAIBuy[random.Next(0, canAIBuy.Count)]);
                                    }
                                }
                                else if ((random.Next(0, 100) <= 35))
                                {
                                    ai.BuyCard(0);
                                }
                                else
                                {
                                    ai.BuyCard(canAIBuy[random.Next(0, canAIBuy.Count)]);
                                }
                            }
                            else if (canAIBuy.Contains(Card.CardShop[1].Id) && Card.CardShop[1].Number == 0)
                            {
                                if (random.Next(0, 100) <= 35)
                                {
                                    ai.BuyCard(1);
                                }
                                else
                                {
                                    ai.BuyCard(canAIBuy[random.Next(0, canAIBuy.Count)]);
                                }
                            }
                            else
                            {
                                ai.BuyCard(canAIBuy[random.Next(0, canAIBuy.Count)]);
                            }
                            aiChoice = ai.PlayerCards.cards.Last().Name;
                            if (aiChoice == "Orchard")
                            {
                                Console.Write("AI buys an Orchard\n");
                            }
                            else
                            {
                                Console.Write($"AI buys a {aiChoice}\n");
                            }
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
                endGame = CheckEndGame(scoreGoal, difficulty);
            }
            CheckPlayerWin(scoreGoal);
        }

        //Check if one of the players has won
        public bool CheckEndGame(int scoreGoal, int difficulty)
        {
            if (difficulty == 4)
            {
                IEnumerable<CardsInfo> distinctPlayerCards = player.PlayerCards.cards.Distinct();
                IEnumerable<CardsInfo> distinctAICards = player.PlayerCards.cards.Distinct();
                if (player.Pieces >= scoreGoal && distinctPlayerCards.Count() == 15 || ai.Pieces >= scoreGoal && distinctAICards.Count() == 15)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (player.Pieces >= scoreGoal || ai.Pieces >= scoreGoal)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Displays a personalized message based on the result of the players' result
        public void CheckPlayerWin(int scoreGoal)
        {

            if (player.Pieces >= scoreGoal && player.Pieces == ai.Pieces)
            {
                Console.Write("\n");
                display.DisplayDraw();
            }
            else if (player.Pieces >= scoreGoal && player.Pieces > ai.Pieces)
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