using System;
using System.Runtime.ConstrainedExecution;
using controllers;
using model;
using xadrez;


namespace XadrezHubGames
{
    public class Program
    {
        private static void Menu()
        {
            Console.WriteLine("Digite um o número que representa o seu jogo escolhido");
            Console.WriteLine("1 - Xadrez ");
            Console.WriteLine("2 - Jogo da aelha");
            Console.WriteLine("3 - sair do jogo");

        }

        private static void Xadrez()
        {
            Xadrez x = new Xadrez();
        }

   /*     private static void JogoDaVelha()
        {
            JogoDaVelha j = new JogoDaVelha();
          
        }*/
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
                        Xadrez();

                        break;

                    /*case 2:
                        JogoDaVelha();


                        break;
*/
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
