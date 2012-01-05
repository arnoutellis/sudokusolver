/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 12/10/2011
 * Time: 19:14
 * 
 */
using System;
using SudokuSolver.SudokuEntities;

namespace SudokuSolver
{
	/// <summary>
	/// Acts as a layer to interface to a program shell.
	/// </summary>
	public class IOHandler
	{
		private Solver solver;
		
		public IOHandler()
		{
			solver = new Solver();
		}
		
		
		/// <summary>
		/// First action on the IOHandler, sets the sudoku puzzle into the solver
		/// </summary>
		/// <param name="sVals">a 9x9 array of int. 0 marks a blank square</param>
		public void SetSudokuValues(int[,] sVals)
		{
			solver.LoadSudokuMap(sVals);
		}
	
		
		/// <summary>
		/// Should be called by the interface, this triggers the solver to solve the puzzle.
		/// True is returned on successful completion, false is returned if it can't solve it.
		/// </summary>
		/// <returns></returns>
		public bool SolvePuzzle()
		{
			return solver.SolvePuzzle();
		}
		
		
		/// <summary>
		/// Returns an int array 9x9 containing all values in the solver. Can be called at any time,
		/// but normally would be called after SolvePuzzle() to retrieve the Sudoku Solution.
		/// </summary>
		/// <returns></returns>
		public int[,] GetSudokuValues()
		{
			Square[,] sVals = new Square[9,9];
			sVals = solver.GetSudokuSquareMap();
			
			int[,] sIntVals = new int[9,9];
			
	       	for (int i=0; i < 9; i++) 
	      	{
	        	for (int j=0; j < 9; j++)
	        	{	        		
	        		sIntVals[i,j] = sVals[i,j].CurrentValue;
	        	
	        	}
	        	
	       	}
	       	return sIntVals;
		}
		
		
	/// <summary>
	/// There is a selection of debug commands. There is also a PrintPuzzle which can be used
	/// by a command line interface which displays a formatted version of the Sudoku Puzzle
	/// </summary>
	#region Debugs
		
		public void DebugPrint()
		{
			solver.DebugPrint();
		}
		
		public void DebugCol(int colId)
		{
			solver.DebugCol(colId);
		}
		
		public void DebugSquare(int xId, int yId)
		{
			solver.DebugSquare(xId, yId);
		}
		
		public void DebugRow(int rowId)
		{
			solver.DebugRow(rowId);
		}
		
		public void DebugQuadrant(int xId, int yId)
		{
			solver.DebugQuadrant(xId, yId);
		}
		
		public void PrintPuzzle() 
	   	{
			Square[,] sVals = new Square[9,9];
			sVals = solver.GetSudokuSquareMap();
			string val = string.Empty;
						
	       	for (int y=0; y < 9; y++) 
	      	{
	       		Console.Write("| ");
	        	for (int x=0; x < 9; x++)
	        	{
	        		if(sVals[x,y].CurrentValue == 0)
	        			val = " ";
	        		else
	        			val = Convert.ToString(sVals[x,y].CurrentValue);
	        		
	        		Console.Write("{0} | ",val);	
	        	}
	        	Console.Write(Environment.NewLine);
	        	for (int h=0; h < 9; h++)
	        	{
	        		Console.Write("----");
	        	}
	        	Console.Write(Environment.NewLine);
	       	}
	   	}
		
		#endregion
		
	}
}
