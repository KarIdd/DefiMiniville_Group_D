using System;

namespace Defi_Miniville
{
    public class Die
    {
        private int NbFaces;
        private Random random = new Random();
        public int Face { get; set; }

        public Die(int NbFaces)
        {
            this.NbFaces = NbFaces;
        }

        public Die()
        {
            this.NbFaces = 6;
        }

        public virtual int Lancer()
        {
            return Face = random.Next(1, NbFaces + 1);
        }

        public override string ToString()
        {
            string tostring = String.Format("Vous avez fait un {0}", this.Face);
            return tostring;
        }
    }
}