using System;
using controllers;
using model;
using xadrez;


namespace XadrezHubGames
{
    public class Program
    {
        public static void Main(string[] args)
        {

          PosicaoXadrez pos = new PosicaoXadrez ( 'c', 7);

            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosicao);

            Console.ReadKey();

        }
    }
}
