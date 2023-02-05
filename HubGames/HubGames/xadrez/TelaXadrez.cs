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
                Console.Write(8 - i + " " + " ");
                Console.ResetColor();
                Console.Write("│ ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("-");
                        Console.Write(" │ ");
                    }
                    else
                    {
                        impremirPeca(tab.peca(i, j));

                        Console.Write(" │ ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     A   B   C   D   E   F   G   H");
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

        }

    }
}
