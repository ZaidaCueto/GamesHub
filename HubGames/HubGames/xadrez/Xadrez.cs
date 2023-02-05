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

                while(!partida.terminada) 
                {

                    Console.Clear();
                    TelaXadrez.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Oringem: ");
                    Posicao origem = TelaXadrez.lerPosicaoXadres().toPosicao();

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    TelaXadrez.imprimirTabuleiro(partida.tab, posicoesPossiveis);
                    Console.WriteLine();
                    Console.Write("Deatino: ");
                    Posicao destino = TelaXadrez.lerPosicaoXadres().toPosicao();

                    partida.ExecutarMovimento(origem, destino);
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
