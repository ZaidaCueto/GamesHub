using System;
using tabuleiro;
using xadrez;

namespace XadrezHubGames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tabeleiro tab = new Tabeleiro(8, 8);

            TelaXadrez.imprimirTabuleiro(tab);

            Console.ReadKey();

        }
    }
}
