using controllers;
using model;



namespace xadrez
{
    public class TelaXadrez
    {

        public static void imprimirTabuleiro(Tabuleiro tab)
        {


            for (int i = 0; i < tab.linhas; i++)
            {
                Console.WriteLine("   ---------------------------------");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + "  ");
                Console.ResetColor();
                Console.Write("│");

                for (int j = 0; j < tab.colunas; j++)
                {
                    
                    impremirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   A   B   C   D   E   F   G   H");
            Console.ResetColor();
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
           

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.WriteLine("   ---------------------------------");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + "  ");
                Console.ResetColor();
                Console.Write("│");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    impremirPeca(tab.peca(i, j));
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   A   B   C   D   E   F   G   H");
            Console.ResetColor();
        }

        public static PosicaoXadrez lerPosicaoXadres()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);

        }




        public static void impremirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write(" - ");
                Console.Write("│");
            }
            else
            {
                if (peca.cor == Cor.BRANCA)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(peca);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ResetColor();
                }
                Console.Write("│");
            }



        }

    }
}
