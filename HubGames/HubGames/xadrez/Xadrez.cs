using model;


namespace xadrez
{
    public class Xadrez
    {

        public Xadrez()
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                     


                        Console.Clear();
                        TelaXadrez.imprimirPatida(partida);

                        Console.WriteLine();
                        Console.Write("Oringem: ");
                        Posicao origem = TelaXadrez.lerPosicaoXadres().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        TelaXadrez.imprimirTabuleiro(partida.tab, posicoesPossiveis);
                        Console.WriteLine();
                        Console.Write("Deatino: ");
                        Posicao destino = TelaXadrez.lerPosicaoXadres().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);

            }
            Console.ReadKey();

        }


    }
}
