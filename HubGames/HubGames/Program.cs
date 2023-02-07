using System;

using model;
using xadrez;
using jogoDaVelha;

namespace XadrezHubGames
{
    public class Program
    {

        public static void instrocoesParaJogarXadrez()
        {
            Console.Clear();
            Console.WriteLine("Como Movimentar este jogo no console ");
            Console.WriteLine("Combine uma letra e um número");
            Console.WriteLine("a primeira combinação  selecionará a peça que você quer movimentar");
            Console.WriteLine(" a segunda combinação movimentará a peça para a casa seleccionada");
            Console.WriteLine("EXEMPLO");
            Console.WriteLine("Primeira Combinação: a2");
            Console.WriteLine("Segunda Combinação: a4");
            Console.WriteLine("Para continuar click enter");
            Console.ReadLine();
            Xadrez();
        }
        public static void Menu()
        {
            Console.WriteLine("Digite um o número que representa o seu jogo escolhido");
            Console.WriteLine("1 - Xadrez ");
            Console.WriteLine("2 - Jogo da velha");
            Console.WriteLine("3 - sair do jogo");
            Console.Write("Digite qual jogo você quer jogar: ");
      
        }
        private static void Xadrez()
        {
            Xadrez x
                = new Xadrez();
        }

        private static void JogoDaVelha()
        {
            JogoDaVelha j = new JogoDaVelha();

        }
        public static void Main(string[] args)
        {
            int optionMenu;
           Menu();

            optionMenu = int.Parse(Console.ReadLine());

            while (optionMenu != 0 && optionMenu < 5)
            {
                switch (optionMenu)
                {
                    case 0:
                        break;
                    case 1:
                      instrocoesParaJogarXadrez();
                        break;
                   case 2:
                        JogoDaVelha();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Estou Encerrando o Program....");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
             
                Console.ReadKey();
            }



        }
    }
}
