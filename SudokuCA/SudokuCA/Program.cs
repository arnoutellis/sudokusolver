/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 16/10/2011
 * Time: 13:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SudokuSolver;

namespace SudokuCA
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Welcome To Sudoku Solver!");
			
			var ioHandler = new IOHandler();
			var th = new SudokuTestHarness();
			
			int[,] thePuzzle = th.GetSudokuTestValuesGuess();
			ioHandler.SetSudokuValues(thePuzzle);
			
			Console.WriteLine("Here is the Puzzle");
			
			ioHandler.PrintPuzzle();
			Console.WriteLine();
			
			
			if(!ioHandler.SolvePuzzle())
			{
				Console.WriteLine("Soz...couldn't solve the puzzle");
				ioHandler.PrintPuzzle();
				ioHandler.DebugQuadrant(1,1);
				
					
			} else {
			
			ioHandler.PrintPuzzle();
			}
			
			Console.WriteLine();
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}