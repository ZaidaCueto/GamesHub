using jogoDaVelha;

namespace jogoDaVelha
{
 public  class JogoDaVelha
    {
        public string[] posicao = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public  JogoDaVelha()
        {
            int escolha = 0, vez = 1, pontuação1 = 0, pontuação2 = 0;

            bool winFlag = false, Jogar = true, entrada = false;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("*************** Bem-vindos ao jogo da Velha ***********************");
            Console.WriteLine("*******************************************************************");
            Console.WriteLine();
            Console.ResetColor();

            Console.WriteLine("Qual o nome do primeiro jogador(a)?");
            string jogador1 = Console.ReadLine();
            Console.WriteLine("Qual o nome do primeiro jogador(a)");
            string jogador2 = Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{jogador1} é  O ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{jogador2} é X.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{jogador1} vai primeiro.");
            Console.ResetColor();
            Console.WriteLine("Digite ok e aperte enter");
            Console.ReadLine();
            Console.Clear();


            while (Jogar == true)
            {
                while (winFlag == false)
                {
                    TabuleiroJogoDaVelha();
                    Console.WriteLine("");

                    Console.WriteLine($"Puntuação: {jogador1} - {pontuação1}     {jogador2} - {pontuação2}");
                    if (vez == 1)
                    {
                        Console.WriteLine($" Vez  de  (O)  {jogador1}");
                    }
                    if (vez == 2)
                    {
                        Console.WriteLine($"vez de (X) {jogador2}");
                    }

                    while (entrada == false)
                    {
                        Console.WriteLine("Digite  um número  de 1 a 9 que esteja disponive na tabela");
                        escolha = int.Parse(Console.ReadLine());
                        if (escolha > 0 && escolha < 10)
                        {
                            entrada = true;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    entrada = false; // Reset 

                    if (vez == 1)
                    {
                        if (posicao[escolha] == "X") // Verifica se a posicaoição  já está ocupada
                        {
                            Console.WriteLine("posicaoição não disponível! ");
                            Console.Write("por favor digite outro número.");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            posicao[escolha] = "O";
                        }
                    }
                    if (vez == 2)
                    {
                        if (posicao[escolha] == "O") // Verifica se a posicaoição  já está ocupada
                        {
                            Console.WriteLine("posicaoição não disponível! ");
                            Console.WriteLine("por favor digite outro número.");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            posicao[escolha] = "X";
                        }
                    }

                    winFlag = VerificarVitória();

                    if (winFlag == false)
                    {
                        if (vez == 1)
                        {
                            vez = 2;
                        }
                        else if (vez == 2)
                        {
                            vez = 1;
                        }
                        Console.Clear();
                    }
                }

                Console.Clear();

                  TabuleiroJogoDaVelha();

                for (int i = 1; i < 10; i++) // reinicialização de Tabuleiro
                {
                    posicao[i] = i.ToString();
                }

                if (winFlag == false) // Empate
                {
                    Console.WriteLine("Empate!");
                    Console.WriteLine($"Pontuação: {jogador1} - {pontuação1}     {jogador2} - {pontuação2}");
                    Console.WriteLine();
                    Console.WriteLine("O que você gostaria de fazer agora?");
                    Console.WriteLine("1. Jogar de novo");
                    Console.WriteLine("2. Sair");
                

                    while (entrada == false)
                    {
                        Console.WriteLine("Digite sua opção: ");
                        escolha = int.Parse(Console.ReadLine());

                        if (escolha > 0 && escolha < 3)
                        {
                            entrada = true;
                        }
                    }

                    entrada = false; // Reset

                    switch (escolha)
                    {
                        case 1:
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Encerrando o jogo...");
                            Console.ReadLine();
                            Jogar = false;
                            break;
                    }
                }

                if (winFlag == true) // verificar ganhador
                {
                    if (vez == 1)
                    {
                        pontuação1++;
                        Console.WriteLine($"{jogador1} wins!");
                        Console.WriteLine("O que você gostaria de fazer agora?");
                        Console.WriteLine("1. Jogar de novo");
                        Console.WriteLine("2. Sair");

                        while (entrada == false)
                        {
                            Console.WriteLine("Digite sua opção: ");
                            escolha = int.Parse(Console.ReadLine());

                            if (escolha > 0 && escolha < 3)
                            {
                                entrada = true;
                            }
                        }

                        entrada = false; // Reset --------------

                        switch (escolha)
                        {
                            case 1:
                                Console.Clear();
                                winFlag = false;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Encerrando o jogo...");
                                Console.ReadLine();
                                Jogar = false;
                                break;
                        }
                    }

                    if (vez == 2)
                    {
                        pontuação2++;
                        Console.WriteLine($"Parabéns {jogador2} GAMHOU!!!");
                        Console.WriteLine("O que você gostaria de fazer agora?");
                        Console.WriteLine("1. Jogar de novo");
                        Console.WriteLine("2. Sair");

                        while (entrada == false)
                        {
                            Console.WriteLine("Digite sua opção: ");
                            escolha = int.Parse(Console.ReadLine());

                            if (escolha > 0 && escolha < 3)
                            {
                                entrada = true;
                            }
                            else
                            {
                                Console.WriteLine("Por favor escolha a opcão 1 ou 2");
                            }
                        }

                        entrada = false; // Reset -----------------

                        switch (escolha)
                        {
                            case 1:
                                Console.Clear();
                                winFlag = false;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Encerrando o jogo...");
                                Console.ReadLine();
                                Jogar = false;
                                break;
                        }
                    }
                }
            }
        }

        private void TabuleiroJogoDaVelha()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {posicao[1]}  |  {posicao[2]}  |  {posicao[3]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {posicao[4]}  |  {posicao[5]}  |  {posicao[6]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {posicao[7]}  |  {posicao[8]}  |  {posicao[9]}  ");
            Console.WriteLine("     |     |     ");
            Console.WriteLine();
            Console.ResetColor();
        }

        //Função 
       public  bool VerificarVitória()
        {
            // Horizontal 
            if (posicao[1] == "O" && posicao[2] == "O" && posicao[3] == "O")
            {
                return true;
            }
            else if (posicao[4] == "O" && posicao[5] == "O" && posicao[6] == "O")
            {
                return true;
            }
            else if (posicao[7] == "O" && posicao[8] == "O" && posicao[9] == "O")
            {
                return true;
            }
            // Diagonal
            else if (posicao[1] == "O" && posicao[5] == "O" && posicao[9] == "O")
            {
                return true;
            }
            else if (posicao[7] == "O" && posicao[5] == "O" && posicao[3] == "O")
            {
                return true;
            }

            // Coloumns

            else if (posicao[1] == "O" && posicao[4] == "O" && posicao[7] == "O")
            {
                return true;
            }
            else if (posicao[2] == "O" && posicao[5] == "O" && posicao[8] == "O")
            {
                return true;
            }
            else if (posicao[3] == "O" && posicao[6] == "O" && posicao[9] == "O")
            {
                return true;
            }

            if (posicao[1] == "X" && posicao[2] == "X" && posicao[3] == "X")
            {
                return true;
            }
            // Horizontal
            else if (posicao[4] == "X" && posicao[5] == "X" && posicao[6] == "X")
            {
                return true;
            }
            else if (posicao[7] == "X" && posicao[8] == "X" && posicao[9] == "X")
            {
                return true;
            }
            // Diagonal

            else if (posicao[1] == "X" && posicao[5] == "X" && posicao[9] == "X")
            {
                return true;
            }
            else if (posicao[7] == "X" && posicao[5] == "X" && posicao[3] == "X")
            {
                return true;
            }
            // columnas

            else if (posicao[1] == "X" && posicao[4] == "X" && posicao[7] == "X")
            {
                return true;
            }
            else if (posicao[2] == "X" && posicao[5] == "X" && posicao[8] == "X")
            {
                return true;
            }
            else if (posicao[3] == "X" && posicao[6] == "X" && posicao[9] == "X")
            {
                return true;
            }
            //Nenhum ganhado
            else
            {
                return false;
            }
        }
    }
}

