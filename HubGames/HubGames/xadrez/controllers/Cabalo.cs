using model;

namespace controllers
{

   
    public class Cabalo : Peca
    {
        public Cabalo(Tabuleiro tab, Cor cor) : base(tab, cor) { }


        public override string ToString()
        {
            return " C ";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tab.linhas, tab.colunas];

            // Posicao pos = new Posicao(0, 0);
            Posicao pos = new(0, 0);

            
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha - 2, posicao.coluna - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha - 2, posicao.coluna + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 2, posicao.coluna + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 2, posicao.coluna - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            return matriz;
        }




    }
}







