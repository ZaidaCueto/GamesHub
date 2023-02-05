using model;

namespace controllers
{

    // movimentos do Rei uma casa para todas as direções
    public class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) { }


        public override string ToString()
        {
            return " R ";
        }

        private bool podeMover(Posicao pos)
        {
           Peca p  = tab.peca(pos);
         return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tab.linhas, tab.colunas];

           // Posicao pos = new Posicao(0, 0);
            Posicao pos = new(0, 0);

            //validar movimento acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            if(tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //validar movimento noreste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna +1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //validar movimento direita
            pos.DefinirValores(posicao.linha , posicao.coluna + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //validar movimento sudeste
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1 );
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //validar movimento abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1 );
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //validar movimento sudoeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //validar movimento esquerda
            pos.DefinirValores(posicao.linha , posicao.coluna -1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //validar movimento noroeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna -1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            return matriz;
        }
    }
}
