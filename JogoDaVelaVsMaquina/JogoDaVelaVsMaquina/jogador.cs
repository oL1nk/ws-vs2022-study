using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace JogoDaVelha
{
	public class Player
	{
		public string name;
		public bool maquinaControlando;
		public bool vezCirculo;
		public int vencedores = 0;
		public Player(string name, bool vezCirculo)
		{
			this.vezCirculo = vezCirculo;
			if (name.Equals("") && vezCirculo)
			{
				this.name = "Jogador1";
				maquinaControlando = true;
			}
			else if (name.Equals("") && !vezCirculo)
			{
				this.name = "Jogador2";
				maquinaControlando = true;
			}
			else this.name = name;
		}
		public void Victory()
		{
			vencedores++;
			Console.WriteLine($"{name} Venceu!");
			if (vencedores > 1) Console.WriteLine($"{name} Venceu {vencedores} vezes!");
		}

		public int Jogada(Tabuleiro board)
		{
			Random random = new Random();
			int escolha = random.Next(0, 10);
			if (board.contadorTurno == 0) escolha = 5;
			else if (board.tabuleiro[0, 0].Equals(board.tabuleiro[0, 1]))
				if (board.tabuleiro[0, 2].Equals("3")) escolha = 3;
				else if (board.tabuleiro[1, 0].Equals(board.tabuleiro[1, 1]))
					
					if (board.tabuleiro[1, 2].Equals("6")) escolha = 6;
					else if (board.tabuleiro[2, 0].Equals(board.tabuleiro[2, 1]))
						
						if (board.tabuleiro[2, 2].Equals("9")) escolha = 9;
						else if (board.tabuleiro[0, 0].Equals(board.tabuleiro[1, 0]))
							
							if (board.tabuleiro[2, 0].Equals("7")) escolha = 7;
							else if (board.tabuleiro[0, 1].Equals(board.tabuleiro[1, 1]))
								
								if (board.tabuleiro[2, 1].Equals("8")) escolha = 8;
								else if (board.tabuleiro[0, 2].Equals(board.tabuleiro[1, 2]))
									
									if (board.tabuleiro[2, 2].Equals("9")) escolha = 9;
									else if (board.tabuleiro[0, 0].Equals(board.tabuleiro[1, 1]))
										
										if (board.tabuleiro[2, 2].Equals("9")) escolha = 9;
										else if (board.tabuleiro[0, 2].Equals(board.tabuleiro[1, 1]))
											if (board.tabuleiro[2, 0].Equals("7")) escolha = 7;

			return escolha;
		}
	}
}