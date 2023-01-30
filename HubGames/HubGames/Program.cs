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

            try
            {
                Tabeleiro tab = new Tabeleiro(8, 8);
                tab.colocarPeca(new Torre(tab, Cor.PRETA), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.PRETA), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.PRETA), new Posicao(0, 0));

                TelaXadrez.imprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);

            }


          

            Console.ReadKey();

        }
    }
}
