using model;

namespace controllers
{
  public class Torre : Peca
    {


     // movimentos do Torre todas as casas até o final do tabuleiro ou até encontrar algma peca direçao acima, direita, equierda e abaixo
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString()
        {
            return " T ";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //verificação para acima
            pos.DefinirValores(posicao.linha -1, posicao.coluna);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;  
            }

            //verificação para abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            //verificação para direira
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            //verificação para esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }


            return matriz;
        }


    }
}
