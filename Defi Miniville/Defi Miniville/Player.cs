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

        public void BuyCard(CardsInfo card)
        {
            if(Pieces > card.Cost)
            {
                //PlayerCards.Enpiler();
            }
        }
    }
}
