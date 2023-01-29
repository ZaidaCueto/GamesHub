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
            Tabeleiro tab = new Tabeleiro(8, 8);
            tab.colocarPeca(new Torre(tab, Cor.PRETA), new Posicao(0,0));
            tab.colocarPeca(new Torre(tab, Cor.PRETA), new Posicao(1,3));
            tab.colocarPeca(new Rei(tab, Cor.PRETA), new Posicao(2, 4));
            


            TelaXadrez.imprimirTabuleiro(tab);

            Console.ReadKey();

        }
    }
}
