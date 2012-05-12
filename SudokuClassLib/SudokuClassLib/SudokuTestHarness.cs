/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 14/10/2011
 * Time: 12:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SudokuSolver
{
	/// <summary>
	/// Description of SudokuTestHarness.
	/// </summary>
	public class SudokuTestHarness
	{
		public SudokuTestHarness()
		{
		}
		
		
		public int[,] GetSudokuTestValuesEasy()
		{
			int[,] tempvals = new int[9,9]
				{
					{5,9,0,0,3,0,0,6,1},
					{7,0,0,0,0,0,0,0,2},
					{0,0,0,1,2,6,0,0,0}, 
					{0,0,9,3,8,7,6,0,0},
					{6,0,1,2,0,4,5,0,8},
					{0,0,8,6,1,5,9,0,0}, 
					{0,0,0,8,7,3,0,0,0},
					{8,0,0,0,0,0,0,0,7},
					{9,2,0,0,6,0,0,3,5}
				};
			return tempvals;
			
		}
		
		public int[,] GetSudokuTestValuesMedium()
		{
			int[,] tempvals = new int[9,9]
				{
					{7,6,0,0,0,0,0,0,0},
					{0,8,5,6,4,0,0,0,0},
					{2,9,4,0,8,0,0,3,0}, 
					{4,0,7,0,0,8,0,0,0},
					{0,0,0,5,0,4,0,0,0},
					{0,0,0,1,0,0,4,0,6}, 
					{0,4,0,0,7,0,8,2,1},
					{0,0,0,0,2,9,3,6,0},
					{0,0,0,0,0,0,0,4,9}
				};
			return tempvals;
			
		}
		
		public int[,] GetSudokuTestValuesHard()
		{
			int[,] tempvals = new int[9,9]
				{
					{0,9,2,6,0,0,7,0,0},
					{0,1,0,0,7,0,9,5,0},
					{7,0,0,0,0,0,0,0,0}, 
					{0,5,0,8,0,0,3,6,0},
					{3,0,0,1,0,5,0,0,7},
					{0,8,9,0,0,3,0,2,0}, 
					{0,0,0,0,0,0,0,0,3},
					{0,6,5,0,3,0,0,4,0},
					{0,0,3,0,0,9,6,7,0}
				};
			return tempvals;
			
		}

		public int[,] GetSudokuTestValuesExtreme()
		{
			int[,] tempvals = new int[9,9]
				{
					{0,2,9,0,0,1,7,0,0},
					{8,0,0,0,0,0,3,0,6},
					{0,0,7,0,0,0,0,0,4}, 
					{1,0,0,0,0,5,0,0,0},
					{6,0,0,0,2,3,0,0,9},
					{9,0,0,0,0,8,0,0,0}, 
					{0,0,4,0,0,0,0,0,3},
					{5,0,0,0,0,0,4,0,2},
					{0,1,3,0,0,2,5,0,0}
				};
			return tempvals;
			
		}		
		
		public int[,] GetSudokuTestValuesGuess()
		{
			
			
			int[,] tempvals2 = new int[9,9]
				{
					{0,0,0,0,0,4,0,0,7},
					{0,0,0,0,9,0,2,6,0},
					{0,7,5,6,8,0,0,0,1}, 
					{0,0,0,0,1,7,5,0,3},
					{0,0,3,5,0,0,0,0,0},
					{0,4,0,0,0,0,0,0,0}, 
					{9,6,1,0,0,0,0,0,5},
					{0,0,0,0,0,9,0,8,0},
					{2,0,0,0,0,0,0,0,0}
				};
			
			return tempvals2;
			
		}		
		
		
		
	}
}
