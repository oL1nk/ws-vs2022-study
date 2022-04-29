using System;


namespace JogoDaVelha
{
    class JogoDaVelha
    {
        private char vez;
        private char[] posicoes;
        private int camposPreenchidos;
        private bool gameOver;

        public JogoDaVelha()
        {
            gameOver = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            camposPreenchidos = 0;
        }

        public void Iniciar()
        {
            while (!gameOver)
            {
                DesenharTabela();
                LerEscolhaDoJogador();
                DesenharTabela();
                VerificargameOver();
                MudarVez();
            }
        }

        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        private void VerificargameOver()
        {
            if (camposPreenchidos < 5)
                return;
            
            if(HaVitoriaDiagonal() || HaVitoriaHorizontal() || HaVitoriaVertical())
            {
                gameOver = true;
                Console.WriteLine($"Game Over!! Vitória de {vez}");
                return;
            }

            if(camposPreenchidos is 9)
            {
                gameOver = true;
                Console.WriteLine("Game Over!! EMPATE");
            }
        }

        private bool HaVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool HaVitoriaVertical()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool HaVitoriaDiagonal()
        {

            bool vitoriaLinha1 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];
            bool vitoriaLinha2 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];

            return vitoriaLinha1 || vitoriaLinha2;
        }

        private void LerEscolhaDoJogador()
        {
            Console.WriteLine($"Agora é a vez de {vez}, digite um número entre 1 a 9 que esteja disponível.");

            bool converter = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!converter || !ValidarEscolhaJogador(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 1 a 9 que esteja inocupado.");
                converter = int.TryParse(Console.ReadLine(), out  posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida -1;

            posicoes[indice] = vez;
            camposPreenchidos++;
        }

        private bool ValidarEscolhaJogador(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            if(posicoes[indice] == 'O' || posicaoEscolhida == 'X')
                return false;
            return true;
        }

        private void DesenharTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  ";
        }
    }
}
