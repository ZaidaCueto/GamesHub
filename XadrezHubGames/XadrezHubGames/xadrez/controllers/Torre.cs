using model;

namespace controllers
{
  public class Torre : Peca
    {
        public Torre(Tabeleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
