using System;

namespace Defi_Miniville
{
    class Player
    {
        public int Pieces { get; set; }
        public Pile PlayerCards { get; set; }

        public Player()
        {
            PlayerCards = new Pile();
        }

        public void BuyCard(Card card)
        {
            if(Pieces > card.Cost)
            {
                //PlayerCards.Enpiler();
            }
        }
    }
}
