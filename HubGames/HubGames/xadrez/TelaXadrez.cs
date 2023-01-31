using model;



namespace xadrez
{
    public class TelaXadrez
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
   
            for(int i = 0; i < tab.linhas; i++)
            {
                Console.WriteLine("   ---------------------------------");
                ConsoleColor aux1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(8 - i + " " + " ");
                Console.ForegroundColor = aux1;
                Console.Write("│ ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i,j ) == null)
                    {
                        Console.Write("-");
                        Console.Write(" │ ");
                    }
                    else
                    {
                        Console.Write(tab.peca(i, j) + " │ ");
                    }
                }
                Console.WriteLine();

               
             
            }
            Console.WriteLine("   ---------------------------------");
        }
    }
}
