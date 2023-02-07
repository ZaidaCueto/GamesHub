
using controllers;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace model
{
    public class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xaque { get; private set; }
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.MAGENTA;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
            xaque = false;
        }


        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.MAGENTA)
            {
                return Cor.AMARELO;
            }
            else
            {
                return Cor.MAGENTA;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] matriz = x.movimentosPossiveis();
                if (matriz[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public Peca ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        private void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.RetirarPeca(destino);
            p.deCrementarQtdMovimentos();
            if (pecaCapturada != null)
            {
                tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.ColocarPeca(p, origem);

        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutarMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xaque");
            }
            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xaque = true;

            }
            else
            {
                xaque = false;
            }
            if (testeXaqueMate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                nudarJogador();
            }


        }



        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("não é sua vez!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posicão de destino inválido!");
                throw new TabuleiroException("Digete outra posição!");
            }
        }

        private void nudarJogador()
        {
            if (jogadorAtual == Cor.MAGENTA)
            {
                jogadorAtual = Cor.AMARELO;
            }
            else
            {
                jogadorAtual = Cor.MAGENTA;
            }

        }
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }


        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public bool testeXaqueMate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in pecasEmJogo(cor))
            {
                bool[,] matriz = x.movimentosPossiveis();
                for (int i = 0; i < tab.linhas; jogadorAtual++)
                {
                    for (int j = 0; j < tab.colunas; j++)
                    {
                        if (matriz[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutarMovimento(origem, destino);
                            bool testeXaque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXaque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        private void ColocarPecas()
        {
            colocarNovaPeca('a', 1, new Torre(tab, Cor.MAGENTA));
            colocarNovaPeca('b', 1, new Cabalo(tab, Cor.MAGENTA));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.MAGENTA));
            colocarNovaPeca('d', 1, new Dama(tab, Cor.MAGENTA));
            colocarNovaPeca('e', 1, new Rei(tab, Cor.MAGENTA));
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.MAGENTA));
            colocarNovaPeca('g', 1, new Cabalo(tab, Cor.MAGENTA));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.MAGENTA));
            colocarNovaPeca('a', 2, new Peao(tab, Cor.MAGENTA));
            colocarNovaPeca('b', 2, new Peao(tab, Cor.MAGENTA));
            colocarNovaPeca('c', 2, new Peao(tab, Cor.MAGENTA));
            colocarNovaPeca('d', 2, new Peao(tab, Cor.MAGENTA));
            colocarNovaPeca('e', 2, new Peao(tab, Cor.MAGENTA));
            colocarNovaPeca('f', 2, new Peao(tab, Cor.MAGENTA));
            colocarNovaPeca('g', 2, new Peao(tab, Cor.MAGENTA));
            colocarNovaPeca('h', 2, new Peao(tab, Cor.MAGENTA));

            colocarNovaPeca('a', 8, new Torre(tab, Cor.AMARELO));
            colocarNovaPeca('b', 8, new Cabalo(tab, Cor.AMARELO));
            colocarNovaPeca('c', 8, new Bispo(tab, Cor.AMARELO));
            colocarNovaPeca('d', 8, new Dama(tab, Cor.AMARELO));
            colocarNovaPeca('e', 8, new Rei(tab, Cor.AMARELO));
            colocarNovaPeca('f', 8, new Bispo(tab, Cor.AMARELO));
            colocarNovaPeca('g', 8, new Cabalo(tab, Cor.AMARELO)); ;
            colocarNovaPeca('h', 8, new Torre(tab, Cor.AMARELO));
            colocarNovaPeca('a', 7, new Peao(tab, Cor.AMARELO));
            colocarNovaPeca('b', 7, new Peao(tab, Cor.AMARELO));
            colocarNovaPeca('c', 7, new Peao(tab, Cor.AMARELO));
            colocarNovaPeca('d', 7, new Peao(tab, Cor.AMARELO));
            colocarNovaPeca('e', 7, new Peao(tab, Cor.AMARELO));
            colocarNovaPeca('f', 7, new Peao(tab, Cor.AMARELO));
            colocarNovaPeca('g', 7, new Peao(tab, Cor.AMARELO));
            colocarNovaPeca('h', 7, new Peao(tab, Cor.AMARELO));


        }




    }
}
