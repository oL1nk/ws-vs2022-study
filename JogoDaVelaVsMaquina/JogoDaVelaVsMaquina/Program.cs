using System;
using System.Diagnostics;
using System.Reflection;

namespace JogoDaVelha
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Insira o nome do Jogador 1 ou pressione enter para que o máquina jogue");
			Player jogador1 = new Player(Console.ReadLine(), true);
			Console.WriteLine("Insira o nome do Jogador 2 ou pressione enter para que o máquina jogue");
			Player jogador2 = new Player(Console.ReadLine(), false);
			Tabuleiro board = new Tabuleiro(jogador1, jogador2);
			board.IniciarJogo();


		}
	}
}