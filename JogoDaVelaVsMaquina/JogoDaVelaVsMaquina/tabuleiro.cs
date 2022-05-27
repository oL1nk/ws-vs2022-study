using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;

namespace JogoDaVelha
{
	public class Tabuleiro
	{
		bool jogoFinalizado = false;
		bool jogador1Turno = true;
		public int contadorTurno = 0;
		int contadorJogo = 0;
		public string[,] tabuleiro = new string[3, 3];
		Player jogador1;
		Player jogador2;
		public Tabuleiro(Player jogador1, Player jogador2)
		{
			// atribuir jogadores
			this.jogador1 = jogador1;
			this.jogador2 = jogador2;
			Reiniciar();
		}

		void AtualizarTabuleiro()
		{
			Console.Clear();
			Console.WriteLine($"Turno {contadorTurno + 1} \n");
			Console.WriteLine($"   |   |   ");
			Console.WriteLine($" {tabuleiro[0, 0]} | {tabuleiro[0, 1]} | {tabuleiro[0, 2]} ");
			Console.WriteLine($"___|___|___");
			Console.WriteLine($"   |   |   ");
			Console.WriteLine($" {tabuleiro[1, 0]} | {tabuleiro[1, 1]} | {tabuleiro[1, 2]} ");
			Console.WriteLine($"___|___|___");
			Console.WriteLine($"   |   |   ");
			Console.WriteLine($" {tabuleiro[2, 0]} | {tabuleiro[2, 1]} | {tabuleiro[2, 2]} ");
			Console.WriteLine($"   |   |   ");
		}

		void Reiniciar()
		{
			this.jogoFinalizado = false;
			this.contadorTurno = 0;
			// preencher tabuleiro com os números
			for (int i = 0; i < tabuleiro.GetLength(0); i++)
			{
				for (int j = 0; j < tabuleiro.GetLength(1); j++)
				{
					tabuleiro[i, j] = ((i * 3) + (j + 1)).ToString();
				}
			}
		}

		void MostrarResultado(bool empate)
		{
			jogoFinalizado = true;
			if (empate) Console.WriteLine("Empate!");
			else if (jogador1Turno) jogador1.Vitoria();
			else jogador2.Vitoria();
			// perguntar se quer jogar novamente
			Console.WriteLine("Aperte 'R' para uma revanche ou pressione qualquer tecla para fechar");
			string input = Console.ReadKey().Key.ToString();
			if (input.Equals("R"))
			{
				contadorJogo++;
				jogador1Turno = !jogador1Turno;
				Reiniciar();
				IniciarPartida();
			}
			else MostrarPontuacoes();
			Console.WriteLine("Aperte qualquer tecla para sair");
			Console.ReadKey();
		}

		void MostrarPontuacoes()
		{
			Console.Clear();
			Console.WriteLine($"{jogador1.name}: {jogador1.vencedores} vitórias");
			Console.WriteLine($"{jogador2.name}: {jogador2.vencedores} vitórias");
		}

		void VerificarVitoria()
		{
			// terminar o jogo se a linha horizontal estiver marcada
			if (tabuleiro[0, 0].Equals(tabuleiro[0, 1]) && tabuleiro[0, 1].Equals(tabuleiro[0, 2])) MostrarResultado(false);
			if (tabuleiro[1, 0].Equals(tabuleiro[1, 1]) && tabuleiro[1, 1].Equals(tabuleiro[1, 2])) MostrarResultado(false);
			if (tabuleiro[2, 0].Equals(tabuleiro[2, 1]) && tabuleiro[2, 1].Equals(tabuleiro[2, 2])) MostrarResultado(false);
			
			// terminar o jogo se a linha vertical estiver marcada
			if (tabuleiro[0, 0].Equals(tabuleiro[1, 0]) && tabuleiro[1, 0].Equals(tabuleiro[2, 0])) MostrarResultado(false);
			if (tabuleiro[0, 1].Equals(tabuleiro[1, 1]) && tabuleiro[1, 1].Equals(tabuleiro[2, 1])) MostrarResultado(false);
			if (tabuleiro[0, 2].Equals(tabuleiro[1, 2]) && tabuleiro[1, 2].Equals(tabuleiro[2, 2])) MostrarResultado(false);

			// terminar o jogo se a linha diagonal estiver marcada
			if (tabuleiro[0, 0].Equals(tabuleiro[1, 1]) && tabuleiro[1, 1].Equals(tabuleiro[2, 2])) MostrarResultado(false);
			if (tabuleiro[0, 2].Equals(tabuleiro[1, 1]) && tabuleiro[1, 1].Equals(tabuleiro[2, 0])) MostrarResultado(false);

			// terminar o jogo se o tabuleiro estiver completo
			if (!jogoFinalizado)
			{
				if (contadorTurno >= 8) MostrarResultado(true);
			}
		}

		public void IniciarPartida()
		{
			int espacoEmBranco;
			AtualizarTabuleiro();
			while (!jogoFinalizado)
			{
				if (jogador1Turno)
				{
					Console.WriteLine($"{jogador1.name}, escolha uma posição para marcar");
					if (jogador1.maquinaControlando)
					{
						Thread.Sleep(1500);
						try
						{
							MarcarEspaco(false, jogador1.Jogada(this));
							contadorTurno++;
							jogador1Turno = false;
						}
						catch (ArgumentException)
						{
							continue;
						}
					}
					else if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out espacoEmBranco))
					{
						try
						{
							MarcarEspaco(false, espacoEmBranco);
							contadorTurno++;
							jogador1Turno = false;
						}
						catch (ArgumentException)
						{
							Console.WriteLine($" Espaço já ocupado pelo {jogador2.name}");
							continue;
						}
					}
					else
					{
						Console.WriteLine("Número inválido");
						continue;
					}
				}
				else
				{
					Console.WriteLine($"{jogador2.name}, escolha uma posição para marcar");
					if (jogador2.maquinaControlando)
					{
						Thread.Sleep(1500);
						try
						{
							MarcarEspaco(true, jogador2.Jogada(this));
							contadorTurno++;
							jogador1Turno = true;
						}
						catch (ArgumentException)
						{
							continue;
						}
					}
					else if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out espacoEmBranco))
					{
						try
						{
							MarcarEspaco(true, espacoEmBranco);
							contadorTurno++;
							jogador1Turno = true;
						}
						catch (ArgumentException)
						{
							Console.WriteLine($"Espaço já ocupado pelo {jogador1.name}");
							continue;
						}
					}
					else
					{
						Console.WriteLine("Número Inválido");
						continue;
					}
				}
			}
		}

		void MarcarEspaco(bool jogador, int espacoEmBranco)
		// false: -1: jogador 1, true: -2: jogador 2
		{
			switch (espacoEmBranco)
			{
				case 1:
					if (!tabuleiro[0, 0].Equals("x") && !tabuleiro[0, 0].Equals("o"))
					{
						if (jogador) tabuleiro[0, 0] = "x";
						else tabuleiro[0, 0] = "o";
					}
					else throw new ArgumentException();
					break;
				case 2:
					if (!tabuleiro[0, 1].Equals("x") && !tabuleiro[0, 1].Equals("o"))
					{
						if (jogador) tabuleiro[0, 1] = "x";
						else tabuleiro[0, 1] = "o";
					}
					else throw new ArgumentException();
					break;
				case 3:
					if (!tabuleiro[0, 2].Equals("x") && !tabuleiro[0, 2].Equals("o"))
					{
						if (jogador) tabuleiro[0, 2] = "x";
						else tabuleiro[0, 2] = "o";
					}
					else throw new ArgumentException();
					break;
				case 4:
					if (!tabuleiro[1, 0].Equals("x") && !tabuleiro[1, 0].Equals("o"))
					{
						if (jogador) tabuleiro[1, 0] = "x";
						else tabuleiro[1, 0] = "o";
					}
					else throw new ArgumentException();
					break;
				case 5:
					if (!tabuleiro[1, 1].Equals("x") && !tabuleiro[1, 1].Equals("o"))
					{
						if (jogador) tabuleiro[1, 1] = "x";
						else tabuleiro[1, 1] = "o";
					}
					else throw new ArgumentException();
					break;
				case 6:
					if (!tabuleiro[1, 2].Equals("x") && !tabuleiro[1, 2].Equals("o"))
					{
						if (jogador) tabuleiro[1, 2] = "x";
						else tabuleiro[1, 2] = "o";
					}
					else throw new ArgumentException();
					break;
				case 7:
					if (!tabuleiro[2, 0].Equals("x") && !tabuleiro[2, 0].Equals("o"))
					{
						if (jogador) tabuleiro[2, 0] = "x";
						else tabuleiro[2, 0] = "o";
					}
					else throw new ArgumentException();
					break;
				case 8:
					if (!tabuleiro[2, 1].Equals("x") && !tabuleiro[2, 1].Equals("o"))
					{
						if (jogador) tabuleiro[2, 1] = "x";
						else tabuleiro[2, 1] = "o";
					}
					else throw new ArgumentException();
					break;
				case 9:
					if (!tabuleiro[2, 2].Equals("x") && !tabuleiro[2, 2].Equals("o"))
					{
						if (jogador) tabuleiro[2, 2] = "x";
						else tabuleiro[2, 2] = "o";
					}
					else throw new ArgumentException();
					break;
				default:
					break;
			}
			AtualizarTabuleiro();
			VerificarVitoria();
		}
	}
}