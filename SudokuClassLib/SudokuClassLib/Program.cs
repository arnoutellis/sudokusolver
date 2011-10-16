/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 12/10/2011
 * Time: 19:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SudokuSolver
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Welcome To Sudoku Solver!");
			
			
			
			var ioHandler = new IOHandler();
			var th = new SudokuTestHarness();
			
			int[,] thePuzzle = th.GetSudokuTestValuesExtreme();
			ioHandler.SetSudokuValues(thePuzzle);
			
			Console.WriteLine("Here is the Puzzle");
			
			
			ioHandler.PrintPuzzle();
			Console.WriteLine();
			Console.WriteLine("now solved for ruthie");
			
			
			if(!ioHandler.SolvePuzzle())
			{
				Console.WriteLine("Soz...couldn't solve the puzzle");
			} else {
			
			ioHandler.PrintPuzzle();
			}
			
			Console.WriteLine();
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}