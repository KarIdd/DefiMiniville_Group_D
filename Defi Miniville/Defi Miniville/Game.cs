using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Defi_Miniville
{
    class Game
    {
        public bool Turn;
        public bool endGame;
        public int scoreGoal;
        public int difficulty;
        public int gameMode;

        private Player player = new Player();
        private Player player2 = new Player();
        private Player ai = new Player();
        private Player ai2 = new Player();

        Player protagonist;
        Player opponent;

        private List<int> canAIBuy = new List<int>();

        private Random random = new Random();
        private Die die = new Die();
        public int dice = 0;
        public int dice2 = 0;

        private Display display = new Display();

        public Game()
        {
            Turn = true;
        }

        //Déroulement du jeu
        public void GameLoop()
        {
            display.DisplayWelcome();
            display.DisplayHelp();

            Console.WriteLine("\nChoose the game mode : \n");
            Console.WriteLine("1-Player vs AI");
            Console.WriteLine("2-Player vs Player");
            Console.Write("3-AI vs AI\n\n >: ");

            while (true)
            {
                try
                {
                    gameMode = int.Parse(Console.ReadLine());
                    if (gameMode < 1 || gameMode > 3)
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

            switch (gameMode)
            {
                case 1:
                    protagonist = player;
                    opponent = ai;
                    break;
                case 2:
                    protagonist = player;
                    opponent = player2;
                    break;
                case 3:
                    protagonist = ai;
                    opponent = ai2;
                    break;
                default:
                    protagonist = player;
                    opponent = ai;
                    break;

            }

            Console.WriteLine("\nChoose the game's speed : \n");
            Console.WriteLine("1-Fast (10 points)");
            Console.WriteLine("2-Normal (20 points)");
            Console.WriteLine("3-Long (30 points)");
            Console.Write("4-Expert (30 points and own each in at least one copy)\n\n >: ");
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

            switch (gameMode)
            {
                case 1:
                    while (!endGame)
                    {
                        if (Turn)
                        {
                            PlayerTurn(protagonist, opponent,"");
                        }
                        else
                        {
                            AITurn(opponent, protagonist, "");
                        }

                        Turn = !Turn;
                        endGame = CheckEndGame(scoreGoal, difficulty);
                    }
                    CheckPlayerWin(scoreGoal);
                    break;
                case 2:
                    while (!endGame)
                    {
                        if (Turn)
                        {
                            PlayerTurn(protagonist, opponent, "'1");
                        }
                        else
                        {
                            PlayerTurn(opponent, protagonist, "'2");
                        }

                        Turn = !Turn;
                        endGame = CheckEndGame(scoreGoal, difficulty);
                    }
                    CheckPlayerWin(scoreGoal);
                    break;
                case 3:
                    while (!endGame)
                    {
                        if (Turn)
                        {
                            AITurn(protagonist, opponent, "'1");
                        }
                        else
                        {
                            AITurn(opponent, protagonist, "'2");
                        }

                        Turn = !Turn;
                        endGame = CheckEndGame(scoreGoal, difficulty);
                    }
                    CheckPlayerWin(scoreGoal);
                    break;
                default:
                    while (!endGame)
                    {
                        if (Turn)
                        {
                            PlayerTurn(protagonist, opponent, "");
                        }
                        else
                        {
                            AITurn(opponent, protagonist, "");
                        }

                        Turn = !Turn;
                        endGame = CheckEndGame(scoreGoal, difficulty);
                    }
                    CheckPlayerWin(scoreGoal);
                    break;

            }
        }

        //Execute le tour d'un joueur
        public void PlayerTurn(Player player, Player opponent, string number)
        {
            Console.WriteLine();
            Console.WriteLine("\nIIIIIIIIIIIIIII [ Player{0} turn ] IIIIIIIIIIIIIII\n", number);
            Console.WriteLine($"Player{number} cards : ");
            display.DisplayPlayerCards(player);

            Console.Write("\nDo you want to roll 2 dice ? (o/n) \n>: ");
            string choixDe = Console.ReadLine();
            Console.WriteLine();

            if (choixDe == "o" || choixDe == "o")
            {
                dice = die.Roll();
                dice2 = die.Roll();
                display.RollDice(dice, dice2);
            }
            else
            {
                dice = die.Roll();
                display.RollDice(dice, dice2);
            }

            opponent.Pieces += opponent.PlayerCards.GetCardGain("Blue", dice + dice2);
            if (player.Pieces < opponent.PlayerCards.GetCardGain("Red", dice + dice2))
            {
                opponent.Pieces += player.Pieces;
            }
            else
            {
                opponent.Pieces += opponent.PlayerCards.GetCardGain("Red", dice + dice2);
            }

            player.Pieces += player.PlayerCards.GetCardGain("Blue", dice + dice2);
            player.Pieces += player.PlayerCards.GetCardGain("Green", dice + dice2);
            player.Pieces -= opponent.PlayerCards.GetCardGain("Red", dice + dice2);

            if (player.Pieces < 0)
            {
                player.Pieces = 0;
            }

            Console.WriteLine($"\nPlayer{number} pieces : {player.Pieces}");

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
                                    int playerNumberCard = player.PlayerCards.cards.Count;
                                    player.BuyCard(choiceID);
                                    if (playerNumberCard == player.PlayerCards.cards.Count)
                                    {
                                        Console.Write("\nPlease enter a valid number\n >: ");
                                    }
                                    else
                                    {
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

        //Execute le tour d'une IA
        public void AITurn(Player ai, Player opponent, string number)
        {
            Console.WriteLine();
            Console.WriteLine("\nIIIIIIIIIIIIIII [ AI{0} turn ] IIIIIIIIIIIIIII\n", number);
            Console.WriteLine($"AI{number} cards : ");
            display.DisplayPlayerCards(ai);

            Thread.Sleep(500);
            Console.WriteLine();

            if (ai.PlayerCards.needTwoDice() == true && random.Next(0, 3) <= 1)
            {
                dice = die.Roll();
                dice2 = die.Roll();
                display.RollDice(dice, dice2);
            }
            else
            {
                dice = die.Roll();
                display.RollDice(dice, dice2);
            }

            opponent.Pieces += opponent.PlayerCards.GetCardGain("Blue", dice + dice2);
            if (ai.Pieces < opponent.PlayerCards.GetCardGain("Red", dice + dice2))
            {
                opponent.Pieces += ai.Pieces;
            }
            else
            {
                opponent.Pieces += opponent.PlayerCards.GetCardGain("Red", dice + dice2);
            }

            ai.Pieces += ai.PlayerCards.GetCardGain("Blue", dice + dice2);
            ai.Pieces += ai.PlayerCards.GetCardGain("Green", dice + dice2);
            ai.Pieces -= opponent.PlayerCards.GetCardGain("Red", dice + dice2);

            if (ai.Pieces < 0)
            {
                ai.Pieces = 0;
            }

            Console.WriteLine($"\nAI{number} pieces : {ai.Pieces}\n");

            if (!CheckEndGame(scoreGoal, difficulty))
            {
                int scoredifficulty = ai.PlayerCards.cards.Count;
                Thread.Sleep(500);
                if (difficulty == 4)
                {
                    scoredifficulty = 2;
                }
                if (random.Next(0, scoredifficulty) <= 1 && ai.Pieces > 0)
                {
                    string aiChoice;
                    for (int i = 0; i < Card.GetCardCosts().Count; i++)
                    {
                        if (ai.Pieces >= Card.GetCardCosts()[i] && Card.CardShop[i].Number != 0)
                        {
                            canAIBuy.Add(i);
                        }
                    }

                    if (canAIBuy.Contains(Card.CardShop[0].Id))
                    {
                        if (canAIBuy.Contains(Card.CardShop[1].Id))
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
                    else if (canAIBuy.Contains(Card.CardShop[1].Id) && Card.CardShop[1].Number != 0)
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
                        Console.Write($"AI{number} buys an Orchard\n");
                    }
                    else
                    {
                        Console.Write($"AI{number} buys a {aiChoice}\n");
                    }
                }
                else
                {
                    Thread.Sleep(500);
                    Console.Write($"AI{number} doesn't buy anything\n");
                }

                dice = 0;
                dice2 = 0;
                canAIBuy = new List<int>();
            }
        }


        //Vérifie si l'un des joueurs a gagné
        public bool CheckEndGame(int scoreGoal, int difficulty)
        {
            if (difficulty == 4)
            {
                List<CardsInfo> distinctPlayerCards = new List<CardsInfo>();
                List<CardsInfo> distinctAICards = new List<CardsInfo>();
                foreach (CardsInfo card in protagonist.PlayerCards.cards)
                {
                    if (distinctPlayerCards.Contains(card) == false)
                    {
                        distinctPlayerCards.Add(card);
                    }
                }
                foreach (CardsInfo card in opponent.PlayerCards.cards)
                {
                    if (distinctAICards.Contains(card) == false)
                    {
                        distinctAICards.Add(card);
                    }
                }

                if (protagonist.Pieces >= scoreGoal && distinctPlayerCards.Count() == 15 || opponent.Pieces >= scoreGoal && distinctAICards.Count() == 15)
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
                if (protagonist.Pieces >= scoreGoal || opponent.Pieces >= scoreGoal)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Affiche un message personnalisé en fonction des résultats des joueurs
        public void CheckPlayerWin(int scoreGoal)
        {

            if (protagonist.Pieces >= scoreGoal && protagonist.Pieces == opponent.Pieces)
            {
                display.DisplayDraw();
            }
            else if (protagonist.Pieces >= scoreGoal && protagonist.Pieces > opponent.Pieces)
            {
                switch (gameMode)
                {
                    case 1:
                        display.DisplayPlayerWin("");
                        break;
                    case 2:
                        display.DisplayPlayerWin("'1");
                        break;
                    case 3:
                        display.DisplayComputerWin("'1");
                        break;
                }
            }
            else
            {
                switch (gameMode)
                {
                    case 1:
                        display.DisplayComputerWin("");
                        break;
                    case 2:
                        display.DisplayPlayerWin("'2");
                        break;
                    case 3:
                        display.DisplayComputerWin("'2");
                        break;
                }
            }

        }

    }
}