/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 12/10/2011
 * Time: 19:20
 * 
 */
using System;
using SudokuSolver.SudokuEntities;
using SudokuSolver.SudokuLogic;

namespace SudokuSolver
{
	/// <summary>
	/// Description of Solver.
	/// </summary>
	public class Solver
	{
		private SudokuMap _sudokuMap;
			
		
		public Solver()
		{
		}
		
		/// <summary>
		/// Load a Sudoku puzzling into the solver
		/// </summary>
		/// <param name="sudokuVals">contains a 9x9 int array. 0 denotes an empty box</param>
		public void LoadSudokuMap(int[,] sudokuVals)
		{			
			_sudokuMap = new SudokuMap();
			_sudokuMap.PopulateSudokuMap(sudokuVals);			
		}
		
		
		/// <summary>
		/// Returns the Sudoku Square Map: This is a 9x9 array of Square()
		/// </summary>
		/// <returns></returns>
		public Square[,] GetSudokuSquareMap()
		{
			return _sudokuMap.SudokuSquareMap;
		}
		
		
		/// <summary>
		/// Triggers the solve puzzle code. Returns True if it can be solved, False if it cant
		/// </summary>
		/// <returns></returns>
		public bool SolvePuzzle()
		{
			CalculatePossibleValues();
			SetValues();
			
			return (_sudokuMap.OutstandingBoxes == 0);
		}
		
		
		
		/// <summary>
		/// Once possible values are determined, the SolvingAlgorithm is used to set each square
		/// and set the square value.
		/// A max of 100 attempts are made
		/// </summary>
		private void SetValues()
		{
			var sa = new SolvingAlgorithm();
			int[] solutions;
			int iterationCount = 0;
			
			while(iterationCount < 100 & _sudokuMap.OutstandingBoxes > 0)
			{
				foreach(Square sq in _sudokuMap.SudokuSquareMap)
				{
					solutions = sa.SolveSquare(sq,
				                           _sudokuMap.GetCol(sq.XLoc),
				                           _sudokuMap.GetRow(sq.YLoc),
				                           _sudokuMap.GetQuadrant(sq.XLoc, sq.YLoc));
					
					//The SolveSquare returns an array which contains 2 cells.
					//The first indicates whether the square could be solved (-1 or 1)
					//and the second indicates the value of the square if it could be solved.
					
					if(solutions[0] == 1)
						_sudokuMap.SolveSquare(sq.XLoc, sq.YLoc, solutions[1]);					
				}
				iterationCount++;
			}
			
		}
		
		
		private void CalculatePossibleValues()
		{
			var sa = new SolvingAlgorithm();
			foreach(var s in _sudokuMap.SudokuSquareMap)
			{
				
				if(!s.IsSet && !s.IsNative)					
					s.AddPossibleValue(
						sa.ReturnPossibleValues(
							_sudokuMap.GetCol(s.XLoc),
							_sudokuMap.GetRow(s.YLoc),
							_sudokuMap.GetQuadrant(s.XLoc, s.YLoc)
						)
					);
						
			}
			
		}
		
		
		
		
		#region debugs
		public void DebugPrint()
		{
			for (int y=0; y < 9; y++) 
	      	{
	        	for (int x=0; x < 9; x++)
	        	{
	        		Console.Write("{0} ",_sudokuMap.GetSquare(x, y).CurrentValue);
	        	}
	        	Console.Write(Environment.NewLine);
			}
		}
		
		public void DebugCol(int colId)
		{
			var col = _sudokuMap.GetCol(colId);
			col.DebugPrint();
		}
		public void DebugRow(int rowId)
		{
			var row = _sudokuMap.GetRow(rowId);
			row.DebugPrint();
		}
		public void DebugQuadrant(int xId, int yId)
		{
			var quad = _sudokuMap.GetQuadrant(xId, yId);
			quad.DebugPrint();
		}
		public void DebugSquare(int xId, int yId)
		{
			var sq = _sudokuMap.GetSquare(xId, yId);
			Console.WriteLine("xLoc= {0} yLoc= {1} CurrentValue= {2}", sq.XLoc, sq.YLoc, sq.CurrentValue);
			foreach(int pv in sq.PossibleValues)
			{
				Console.WriteLine("PV: {0}", pv);
			}
		}
		#endregion
		
	}
}
