
namespace tabuleiro
{
    public class Peca
    {
     
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected  set; }
        public Tabeleiro tab { get; protected set; }



        public Peca(Posicao posicao, Cor cor, Tabeleiro tab)
        {
            this.posicao = posicao;
            this.cor = cor;
            this.qteMovimentos = 0;
            this.tab = tab;
        }

    }
  
 

}
