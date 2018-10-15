using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
	public class Program
	{
		static void Main(string[] args)
		{

			TicTacToe ticTacToe = new TicTacToe();

			string input = "";
			int row = 0;
			int col = 0;

			ticTacToe.InitializeBoard();

			while (true)
			{
				Console.Clear();
				ticTacToe.Print();

				Console.Write("Player " + ticTacToe.Player + ", Please enter row: ");
				input = Console.ReadLine();
				input = ticTacToe.CheckInput(input);
				row = Convert.ToInt32(input);

				Console.Write("Player " + ticTacToe.Player + ", Please enter column: ");
				input = Console.ReadLine();
				input = ticTacToe.CheckInput(input);
				col = Convert.ToInt32(input);

				while (!ticTacToe.ValidMove(row, col))
				{

					Console.WriteLine("Space has already been filled, try again.");
					Console.Write("Player " + ticTacToe.Player + ", Please enter row: ");
					input = Console.ReadLine();
					input = ticTacToe.CheckInput(input);
					row = Convert.ToInt32(input);
					Console.Write("Player " + ticTacToe.Player + ", Please enter column: ");
					input = Console.ReadLine();
					input = ticTacToe.CheckInput(input);
					col = Convert.ToInt32(input);

				}

				ticTacToe.Board[row, col] = ticTacToe.Player;

				if (ticTacToe.Win())
				{
					Console.Clear();
					ticTacToe.Print();
					Console.WriteLine(ticTacToe.Player + " has won the game!");
					break;
				}

				ticTacToe.movesPlayed = ticTacToe.movesPlayed + 1;

				if (ticTacToe.movesPlayed == 9)
				{
					Console.Clear();
					ticTacToe.Print();
					Console.WriteLine("Looks like we have a draw!");
					break;
				}
				ticTacToe.ChangeTurn();

			}
			Console.ReadLine();

		}

		
	}

	public class TicTacToe
	{

		public char[,] Board { get; set; }

		public char Player { get; set; }

		public int movesPlayed { get; set; }

		public TicTacToe()
		{
			Board = new char[3, 3];
			Player = 'X';
			movesPlayed = 0;
			InitializeBoard();
		}

		public void InitializeBoard()
		{
			for (int row = 0; row < 3; row++)
			{
				for (int col = 0; col < 3; col++)
				{
					Board[row, col] = ' ';
				}
			}

		}

		public String CheckInput(String input)
		{

			while (!ValidInput(input))
			{
				Console.Write("Please enter valid input.");
				input = Console.ReadLine();

			}
			return input;

		}

		public bool ValidInput(String input)
		{
			return (input.Equals("0") || input.Equals("1") || input.Equals("2"));
		}

		public bool ValidMove(int row, int col)
		{
			return Board[row, col] == ' ';
		}

		public Boolean Win()
		{
			return (Player == Board[0, 0] && Player == Board[0, 1] && Player == Board[0, 2]//1st Horizontal
					|| (Player == Board[1, 0] && Player == Board[1, 1] && Player == Board[1, 2])//2nd Horizontal
					|| (Player == Board[2, 0] && Player == Board[2, 1] && Player == Board[2, 2])//3rd Horizontal

					|| (Player == Board[0, 0] && Player == Board[1, 0] && Player == Board[2, 0])//1st Vertical
					|| (Player == Board[0, 1] && Player == Board[1, 1] && Player == Board[2, 1])//2nd Vertical
					|| (Player == Board[0, 2] && Player == Board[1, 2] && Player == Board[2, 2])//3rd Vertical

					|| (Player == Board[0, 0] && Player == Board[1, 1] && Player == Board[2, 2])//1st Diagonal
					|| (Player == Board[2, 0] && Player == Board[1, 1] && Player == Board[0, 2])//1st Diagonal

					);

		}


		public void ChangeTurn()
		{

			if (Player == 'X')
			{
				Player = 'O';
			}
			else
			{
				Player = 'X';
			}

		}

		public void Print()
		{
			Console.WriteLine("  | 0 | 1 | 2 |");
			for (int row = 0; row < 3; row++)
			{
				Console.Write(row + " | ");
				for (int col = 0; col < 3; col++)
				{
					Console.Write(Board[row, col]);
					Console.Write(" | ");
				}
				Console.WriteLine();
			}
		}
	}
}
