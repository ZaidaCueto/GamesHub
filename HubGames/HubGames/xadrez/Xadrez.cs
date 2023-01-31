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


                TelaXadrez.imprimirTabuleiro(partida.tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);

            }




            Console.ReadKey();

        }
            

    }
}
