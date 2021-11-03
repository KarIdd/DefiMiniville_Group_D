using System;

namespace Defi_Miniville
{
    public class Die
    {
        private int facesNb;
        private Random random = new Random();
        public int face { get; set; }

        // Initialise le dé avec la valeur renseignée
        public Die(int facesNb)
        {
            this.facesNb = facesNb;
        }

        //Initialise le dé avec la valeur de base
        public Die()
        {
            this.facesNb = 6;
        }

        //Retourne un nombre aléatoire compris dans les faces possibles
        public virtual int Roll()
        {
            return face = random.Next(1, facesNb + 1);
        }

        public override string ToString()
        {
            string tostring = String.Format("You made a {0}", this.face);
            return tostring;
        }
    }
}