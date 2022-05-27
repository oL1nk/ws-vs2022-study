using System;
namespace JogoDaVelha
{
    class Program
    {
        static char[] tabuleiro = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int solicitacaoPC = 0;
        static bool gameOver = false;
        static int verificarTabuleiro;


        static void Main()
        {

            Console.WriteLine("Computador = X");
            Console.WriteLine("Jogador = O\n");
            Console.WriteLine("This is Your Current tabuleiro ");

            updatetabuleiro();

            
            do
            {
                try
                {
                    if (player % 2 != 0)
                    {

                        if (player % 2 != 0 && verificarTabuleiro < 1)
                        {
                            tabuleiro[5] = 'X';
                            verificarTabuleiro++;
                            player++;
                        }

                        else if (tabuleiro[8] != 'X' && tabuleiro[8] != 'O' && tabuleiro[9] == 'O')
                        {
                            tabuleiro[8] = 'X';
                            verificarTabuleiro++;
                            player++;
                        }
                        //WIN CONDITION 1 - EASY
                        else if (tabuleiro[2] != 'O' && tabuleiro[2] != 'X' && tabuleiro[6] == 'O')
                        {
                            tabuleiro[2] = 'X';
                            verificarTabuleiro++;
                            player++;
                        }

                        else if (tabuleiro[4] != 'O' && tabuleiro[6] != 'O' && tabuleiro[4] != 'X' && tabuleiro[6] != 'X')
                        {
                            tabuleiro[4] = 'X';
                            verificarTabuleiro++;
                            player++;
                        }


                        else if (tabuleiro[4] == 'O' && tabuleiro[8] == 'O' && tabuleiro[5] == 'O' && tabuleiro[4] != 'X'
                            && tabuleiro[8] != 'X')
                        {
                            //CONDIÇÃO DE EMPATE
                            tabuleiro[6] = 'X';
                            verificarTabuleiro++;
                            player++;
                        }

                        else
                        {
                            Random rnd = new Random();
                            int input = rnd.Next(1, 10);
                            if (tabuleiro[1] == 'O' && tabuleiro[2] == 'O' && tabuleiro[3] != 'X')
                            {
                                tabuleiro[3] = 'X';
                            }

                            if (tabuleiro[1] == 'O' && tabuleiro[4] == 'O' && tabuleiro[7] != 'X')
                            {
                                tabuleiro[7] = 'X';
                            }

                            else if (tabuleiro[input] != 'X' && tabuleiro[input] != 'O' && input > 0)
                            {
                                tabuleiro[input] = 'X';
                                verificarTabuleiro++;
                                player++;
                            }
                            else
                            {
                                solicitacaoPC++;
                                if (solicitacaoPC > 60)
                                {
                                    gameChecker();
                                }
                                continue;

                            }

                        }

                    }
                    else
                    {
                        Console.Write("\nJogador, escolha um slot disponível: ");
                        int input = int.Parse(Console.ReadLine());
                        if (tabuleiro[input] != 'X' && tabuleiro[input] != 'O' && input > 0)
                        {
                            tabuleiro[input] = 'O';
                            verificarTabuleiro++;
                            player++;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Por Favor, Digite em campo diferente\n");
                            continue;
                        }
                    }

                    updatetabuleiro();


                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " - Números Disponíveis\n");
                    continue;

                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + " - Digite um Número de 1 - 9\n");
                    continue;

                }




            } while (gameChecker() == false);

        }

        static bool gameChecker()
        {
            //Verificar se o Jogo Acabou
            for (int i = 0; i < tabuleiro.Length; i++)
            {
                //Horizontal TOP Check P.1, P.2 
                if ((tabuleiro[1] == 'X' && tabuleiro[2] == 'X' && tabuleiro[3] == 'X') || (tabuleiro[1] == 'O' && tabuleiro[2] == 'O' && tabuleiro[3] == 'O'))
                {
                    if (tabuleiro[1] == 'X')
                    {
                        Console.WriteLine("Computador Venceu!");
                    }
                    else
                    {
                        Console.WriteLine("Jogador Venceu!");

                    }

                    return gameOver = true;
                }

                //Diagnonal TOP Check P.1, P.2 
                if ((tabuleiro[1] == 'X' && tabuleiro[5] == 'X' && tabuleiro[9] == 'X') || (tabuleiro[1] == 'O' && tabuleiro[5] == 'O' && tabuleiro[9] == 'O'))
                {
                    if (tabuleiro[1] == 'X')
                    {
                        Console.WriteLine("Computador Venceu!");
                    }
                    else
                    {
                        Console.WriteLine("Jogador Venceu!");

                    }

                    return gameOver = true;
                }

                //Vertical TOP Check P.1, P.2 
                if ((tabuleiro[1] == 'X' && tabuleiro[4] == 'X' && tabuleiro[7] == 'X') || (tabuleiro[1] == 'O' && tabuleiro[4] == 'O' && tabuleiro[7] == 'O'))
                {
                    if (tabuleiro[1] == 'X')
                    {
                        Console.WriteLine("Computador Venceu!");
                    }
                    else
                    {
                        Console.WriteLine("Jogador Venceu!");

                    }

                    return gameOver = true;
                }

                //Middle TOP Check P.1, P.2 
                if ((tabuleiro[2] == 'X' && tabuleiro[5] == 'X' && tabuleiro[8] == 'X') || (tabuleiro[2] == 'O' && tabuleiro[5] == 'O' && tabuleiro[8] == 'O'))
                {
                    if (tabuleiro[2] == 'X')
                    {
                        Console.WriteLine("Computador Venceu!");
                    }
                    else
                    {
                        Console.WriteLine("Jogador Venceu!");

                    }

                    return gameOver = true;
                }


                //Diagnonal FAR SIDE Check P.1, P.2 
                if ((tabuleiro[3] == 'X' && tabuleiro[5] == 'X' && tabuleiro[7] == 'X') || (tabuleiro[3] == 'O' && tabuleiro[5] == 'O' && tabuleiro[7] == 'O'))
                {

                    if (tabuleiro[3] == 'X')
                    {
                        Console.WriteLine("Computador Venceu!");
                    }
                    else
                    {
                        Console.WriteLine("Jogador Venceu!");

                    }

                    return gameOver = true;
                }

                //Vertical FAR SIDE Check P.1, P.2 
                if ((tabuleiro[3] == 'X' && tabuleiro[6] == 'X' && tabuleiro[9] == 'X') || (tabuleiro[3] == 'O' && tabuleiro[6] == 'O' && tabuleiro[9] == 'O'))
                {
                    if (tabuleiro[3] == 'X')
                    {
                        Console.WriteLine("Computador Venceu!");
                    }
                    else
                    {
                        Console.WriteLine("Jogador Venceu!");

                    }

                    return gameOver = true;
                }

                //Horizontal MIDDLE Check P.1, P.2 
                if ((tabuleiro[4] == 'X' && tabuleiro[5] == 'X' && tabuleiro[6] == 'X') || (tabuleiro[4] == 'O' && tabuleiro[5] == 'O' && tabuleiro[6] == 'O'))
                {
                    if (tabuleiro[4] == 'X')
                    {
                        Console.WriteLine("Computador Venceu!");
                    }
                    else
                    {
                        Console.WriteLine("Jogador Venceu!");

                    }

                    return gameOver = true;
                }

                // Verificar MEIO Horizontal P.1, P.2
                if ((tabuleiro[7] == 'X' && tabuleiro[8] == 'X' && tabuleiro[9] == 'X') || (tabuleiro[7] == 'O' && tabuleiro[8] == 'O' && tabuleiro[9] == 'O'))
                {
                    if (tabuleiro[7] == 'X')
                    {
                        Console.WriteLine("Computador Venceu!");
                    }
                    else
                    {
                        Console.WriteLine("Jogador Venceu");

                    }

                    return gameOver = true;
                }
                //verificar se os slots estão disponíveis
                if (verificarTabuleiro > 8)
                {
                    Console.WriteLine("Draw!!");
                    string val = Console.ReadLine();

                    return gameOver = true;
                }

            }

            return gameOver = false;

        }

        static void updatetabuleiro()
        {
            Console.Clear();

            Console.WriteLine("|{0}|{1}|{2}|\n" +
               "|{3}|{4}|{5}|\n" +
               "|{6}|{7}|{8}|", tabuleiro[1], tabuleiro[2], tabuleiro[3], tabuleiro[4], tabuleiro[5], tabuleiro[6], tabuleiro[7], tabuleiro[8], tabuleiro[9]);
        }
    }
}