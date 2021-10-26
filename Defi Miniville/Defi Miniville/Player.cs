using System;

namespace Defi_Miniville
{
    class Player
    {
        public int Pieces { get; protected set; }
        public PlayerPile PlayerCards { get; set; }

        public Player()
        {
            PlayerCards = new PlayerPile();
        }

        public void BuyCard(int Id)
        {
            if(Pieces > Card.GetCard(Id).Cost && Card.GetCard(Id).Number > 0)
            {
                
            }
        }
    }
}
