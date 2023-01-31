﻿

using controllers;

namespace model
{
    public class PartidaDeXadrez
    {
      public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.BRANCA;
            colocarPecas();
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.BRANCA), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.BRANCA), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.BRANCA), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.BRANCA), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.BRANCA), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.BRANCA), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.PRETA), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.PRETA), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.PRETA), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.PRETA), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.PRETA), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.PRETA), new PosicaoXadrez('d', 8).toPosicao());
        }

        public void executarMovimento(Posicao Origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(Origem);
            p.incrementarQtdMovimentos();
          Peca pecaCapturada =   tab.retirarPeca(destino);
        }

    }
}