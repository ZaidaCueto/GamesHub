
using controllers;
using System.Reflection;

namespace model
{
    public class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.BRANCA;
            terminada = false;
            ColocarPecas();
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            turno++;
            nudarJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("não é sua vez!");
            }
            if(!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
if(!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("POsicão de destino inválido!");
            }
        }

        private void nudarJogador()
        {
      if (jogadorAtual == Cor.BRANCA)
            {
                jogadorAtual = Cor.PRETA;
            }
            else
            {
                jogadorAtual = Cor.BRANCA;
            }

        }

        private void ColocarPecas()
        {
            tab.ColocarPeca(new Torre(tab, Cor.BRANCA), new PosicaoXadrez('c', 1).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.BRANCA), new PosicaoXadrez('c', 2).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.BRANCA), new PosicaoXadrez('d', 2).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.BRANCA), new PosicaoXadrez('e', 2).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.BRANCA), new PosicaoXadrez('e', 1).toPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.BRANCA), new PosicaoXadrez('d', 1).toPosicao());

            tab.ColocarPeca(new Torre(tab, Cor.PRETA), new PosicaoXadrez('c', 7).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.PRETA), new PosicaoXadrez('c', 8).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.PRETA), new PosicaoXadrez('d', 5).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.PRETA), new PosicaoXadrez('e', 7).toPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.PRETA), new PosicaoXadrez('e', 8).toPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.PRETA), new PosicaoXadrez('d', 8).toPosicao());
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }
        

    }
}
