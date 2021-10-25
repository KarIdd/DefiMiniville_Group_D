uusing System;

namespace Defi_Miniville
{
    public class De
    {
        private int NbFaces;
        private Random random = new Random();
        public int Face { get; set; }

        public De(int NbFaces)
        {
            this.NbFaces = NbFaces;
        }

        public De()
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