using model;

namespace controllers
{
    public class Rei : Peca
    {
        public Rei(Tabeleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}