
namespace model
{
    public class Peca
    {
     
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected  set; }
        public Tabeleiro tab { get; protected set; }



        public Peca(Tabeleiro tab, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.qteMovimentos = 0;
            this.tab = tab;
        }

    
    }
  
 

}
