using model;

namespace controllers
{
  public class Peao : Peca
    {


 
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString()
        {
            return " P ";
        }

        private bool existeCorOposto(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }
        private bool posicaoEstaLivre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            if(cor == Cor.MAGENTA)
            {
                pos.DefinirValores(posicao.linha - 1, posicao.linha);
                if(tab.PosicaoValida(pos) && posicaoEstaLivre(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 2, posicao.linha);
                if (tab.PosicaoValida(pos) && posicaoEstaLivre(pos) && qteMovimentos == 0)
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.linha - 1);
                if (tab.PosicaoValida(pos) && existeCorOposto(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.linha + 1);
                if (tab.PosicaoValida(pos) && existeCorOposto(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(posicao.linha + 1, posicao.linha);
                if (tab.PosicaoValida(pos) && posicaoEstaLivre(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 2, posicao.linha);
                if (tab.PosicaoValida(pos) && posicaoEstaLivre(pos) && qteMovimentos == 0)
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.linha - 1);
                if (tab.PosicaoValida(pos) && existeCorOposto(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.linha + 1);
                if (tab.PosicaoValida(pos) && existeCorOposto(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
            }

            return matriz;
        }
       

    }
}
