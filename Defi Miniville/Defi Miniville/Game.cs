﻿using System;
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
            player.Pieces = 18;
            while (!endGame)
            {
                if (Turn)
                {
                    display.DisplayPlayerCards(player);

                    Console.Write("\nVoulez-vous lancer 2 dés ? \n>: ");
                    string choixDe = Console.ReadLine();
                    Console.WriteLine();
                    if (choixDe == "O" || choixDe == "o") {
                        dice2 = De.Lancer();
                        Console.WriteLine("\nDé 2 : {0}", dice2);
                    }
                    dice = De.Lancer();
                    Console.WriteLine("Dé : {0}", dice);

                    ai.Pieces += ai.PlayerCards.GetCardGain("blue", dice + dice2);
                    ai.Pieces += ai.PlayerCards.GetCardGain("red", dice + dice2);

                    player.Pieces += player.PlayerCards.GetCardGain("blue", dice + dice2);
                    player.Pieces += player.PlayerCards.GetCardGain("green", dice + dice2);

                    Console.WriteLine($"Gold : {player.Pieces}");

                    Console.Write("\nVoulez-vous acheter une nouvelle carte ? \n>: ");
                    string choixBuy = Console.ReadLine();
                    if (choixBuy == "O" || choixBuy == "o") {
                        Console.Write("Quelle carte voulez-vous acheter ? (ID)\n >: ");
                        player.BuyCard(int.Parse(Console.ReadLine())-1);
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