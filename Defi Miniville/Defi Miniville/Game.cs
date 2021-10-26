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

        private Die De = new Die();
        private int dice;
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
