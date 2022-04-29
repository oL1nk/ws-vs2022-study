using System;
using System.Threading;

class Program
{
    static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int jogador = 1;
    static int vez;
    static int situacao = 0;

    public static bool gameOver = true;

    static void Main()
    {
        //Thread j1 = new Thread(Tabuleiro);
        //j1.Start();
        //j1.Join();

        //Thread j2 = new Thread(JogadorA);
        //j2.Start();
        //j2.Join();

        //Thread j3 = new Thread(JogadorB);
        //j3.Start();
        //j3.Join();

        //Thread j4 = new Thread(VerificarVencedor);
        //j4.Start();
        //j4.Join();


        ThreadTabuleiro();


        while (gameOver == true)
        {
            while (situacao == 0)
            {
                if (jogador % 2 == 0)
                {
                    ThreadJogadorB();
                    VerificarVitoria();
                }
                else
                {
                    ThreadJogadorA();
                    VerificarVitoria();
                }
            }
        }
        ThreadTabuleiro();
    }

    public static void ThreadTabuleiro()
    {
        Thread j1 = new Thread(Tabuleiro);
        j1.Start();
        j1.Join();
    }

    public static void Tabuleiro()
    {       
        Console.Clear();

        Console.WriteLine("Jogador 1: X e Jogador 2: O");
        Console.WriteLine("\n");

        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
        Console.WriteLine("     |     |      ");
    }

    public static void ThreadJogadorA()
    {
        Thread j1 = new Thread(JogadorA);
        j1.Start();
        j1.Join();

    }


    public static void JogadorA()
    {
        Console.Write("Jogador 1 vez a posição entre 1 e 9 que esteja disponível: ");

        vez = int.Parse(Console.ReadLine());

        if (arr[vez] != 'X' && arr[vez] != 'O')
        {
            if (jogador % 2 == 0)
            {
                arr[vez] = 'O';
                jogador++;
            }
            else
            {
                arr[vez] = 'X';
                jogador++;
            }

        }
        ThreadTabuleiro();
    }

    public static void ThreadJogadorB()
    {
        Thread j1 = new Thread(JogadorB);
        j1.Start();
        j1.Join();

    }

    public static void JogadorB()
    {
        Console.Write("Jogador 2 vez a posição entre 1 e 9 que esteja disponível: ");
        vez = int.Parse(Console.ReadLine());

        if (arr[vez] != 'X' && arr[vez] != 'O')
        {
            if (jogador % 2 == 0)
            {
                arr[vez] = 'O';
                jogador++;
            }
            else
            {
                arr[vez] = 'X';
                jogador++;
            }

        }
        ThreadTabuleiro();
    }
    
    public static void VerificarVitoria()
    {
        #region Condição de Vitória na Horizontal
        if (arr[1] == arr[2] && arr[2] == arr[3])
        {
            situacao = 1;
            
        }
        else if (arr[4] == arr[5] && arr[5] == arr[6])
        {
            situacao = 1;
            
        }
        else if (arr[7] == arr[8] && arr[8] == arr[9])
        {
            situacao = 1;
            
        }
        #endregion
        #region Condição de Vitória na Horizontal
        else if (arr[1] == arr[4] && arr[4] == arr[7])
        {
            situacao = 1;
            
        }
        else if (arr[2] == arr[5] && arr[5] == arr[8])
        {
            situacao = 1;
            
        }
        else if (arr[3] == arr[6] && arr[6] == arr[9])
        {
            situacao = 1;
            
        }
        #endregion
        #region Condição de Vitória na Diagonal
        else if (arr[1] == arr[5] && arr[5] == arr[9])
        {
            situacao = 1;
            
        }
        else if (arr[3] == arr[5] && arr[5] == arr[7])
        {
            situacao = 1;
            
        }
        #endregion
        #region Verificando Empate
        else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
        {
            situacao = -1;
           
        }
        #endregion
        else
        {
            situacao = 0;         
        }
        ThreadVerificarVencedor();
    }

    public static void ThreadVerificarVencedor()
    {
        Thread j1 = new Thread(VerificarVencedor);
        j1.Start();
        j1.Join();
    }

    public static void VerificarVencedor()
    {
        if (situacao == 1)
        {
            Console.WriteLine("Jogador {0} Ganhou!!", (jogador % 2) + 1);
        }
        else if (situacao == -1)
        {
            Console.WriteLine("EMPATE!!!");
        }
        else
        {
            
        }
    }
}