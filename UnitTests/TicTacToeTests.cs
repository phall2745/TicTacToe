using NUnit.Framework;
using Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Tests
{
	[TestFixture()]
	public class TicTacToeTests
	{
		[Test]
		public void ChangeTurnTest()
		{
			TicTacToe ticTacToe = new TicTacToe();
			ticTacToe.Player = 'X';
			ticTacToe.ChangeTurn();
			Assert.AreEqual(ticTacToe.Player, 'O');
			ticTacToe.ChangeTurn();
			Assert.AreEqual(ticTacToe.Player, 'X');

		}

		[Test]
		public void WinTest()
		{
			TicTacToe ticTacToe = new TicTacToe();
			ticTacToe.Player = 'X';
			ticTacToe.InitializeBoard();
			Assert.AreEqual(ticTacToe.Win(), false);

			ticTacToe.Board[0, 0] = 'X';
			ticTacToe.Board[0, 1] = 'X';
			ticTacToe.Board[0, 2] = 'X';
			Assert.AreEqual(ticTacToe.Win(),true);

		}

		[Test]
		public void ValidMoveTest()
		{
			TicTacToe ticTacToe = new TicTacToe();
			ticTacToe.Player = 'X';
			ticTacToe.InitializeBoard();
			ticTacToe.Board[0, 0] = 'X';
			Assert.AreEqual(ticTacToe.ValidMove(0, 0), false);
			Assert.AreEqual(ticTacToe.ValidMove(0, 1), true);
		}

		[Test]
		public void ValidInputTest()
		{
			TicTacToe ticTacToe = new TicTacToe();
			Assert.AreEqual(ticTacToe.ValidInput("0"), true);
			Assert.AreEqual(ticTacToe.ValidInput("1"), true);
			Assert.AreEqual(ticTacToe.ValidInput("2"), true);
			Assert.AreEqual(ticTacToe.ValidInput("something else"), false);
		}
	}
}