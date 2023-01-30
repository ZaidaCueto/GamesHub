using model;



namespace xadrez
{
    public class TelaXadrez
    {
        public static void imprimirTabuleiro(Tabeleiro tab)
        {
   
            for(int i = 0; i < tab.linhas; i++)
            {

                Console.WriteLine("---------------------------------------");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i,j ) == null)
                    {
                        Console.Write("-");
                        Console.Write("  │ ");
                    }
                    else
                    {
                        Console.Write(tab.peca(i, j) + "  │ ");
                    }
                }
                Console.WriteLine();

               
             
            }
            Console.WriteLine("---------------------------------------");
        }
    }
}
