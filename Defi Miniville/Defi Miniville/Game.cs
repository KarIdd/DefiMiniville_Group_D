using System;

namespace Defi_Miniville
{
    class Game
    {
        public bool Turn { get; set; }
        public int nbTurn { get; set; }
        public bool endGame;

        private Player player = new Player();
        private Player ai = new Player();

        private Random random = new Random();
        private Die De = new Die();
        public static int dice;
        private Card carte = new Card();

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
                    dice = De.Lancer();

                    ai.Pieces += ai.PlayerCards.GetCardGain("blue", dice);
                    ai.Pieces += ai.PlayerCards.GetCardGain("red", dice);

                    player.Pieces += player.PlayerCards.GetCardGain("blue", dice);
                    player.Pieces += player.PlayerCards.GetCardGain("green", dice);

                    Console.Write("Voulez-vous acheter une nouvelle carte ? \n>: ");
                    if(Console.ReadLine() == "O" || Console.ReadLine() == "o")
                    {
                        Console.Write("Quelle carte voulez-vous acheter ? (ID)\n >: ");
                        player.BuyCard(int.Parse(Console.ReadLine()));
                    }

                    Turn = !Turn;
                }
                else
                {
                    dice = De.Lancer();

                    player.Pieces += player.PlayerCards.GetCardGain("blue", dice);
                    player.Pieces += player.PlayerCards.GetCardGain("red", dice);

                    ai.Pieces += ai.PlayerCards.GetCardGain("blue", dice);
                    ai.Pieces += ai.PlayerCards.GetCardGain("green", dice);

                    if (random.Next(0, 2) == 1){
                        ai.BuyCard(random.Next(0,8));
                    }

                    Turn = !Turn;
                }
            }
        }


        public void CheckEndGame()
        {
            if(player.Pieces >= 20)
            {
                Console.WriteLine($"Le joueur a gagné avec {player.Pieces} !");
            }
            if(ai.Pieces >= 20)
            {
                Console.WriteLine($"L'IA a gagné avec {ai.Pieces} !");
            }
            
        }

    }
}
