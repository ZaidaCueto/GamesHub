using System;
using Tabuleiro;

namespace XadrezHubGames
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            Posicao p;
            p =  new Posicao(3, 4);

            Console.WriteLine("Posiçao:" + p);

            Console.ReadKey();

        }
    }
}
