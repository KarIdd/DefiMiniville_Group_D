using System;

namespace Defi_Miniville
{
    class Game
    {
        public bool Tour { get; set; }
        public int nbTours { get; set; }

        private Player joueur = new Player();
        private Player ordinateur = new Player();

        private Die De = new Die();

    }
}
