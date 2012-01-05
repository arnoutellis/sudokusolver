/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 14/10/2011
 * Time: 14:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SudokuSolver.SudokuEntities;
using System.Collections.Generic;

namespace SudokuSolver.SudokuLogic
{
	/// <summary>
	/// Description of SolvingAlgorithm.
	/// </summary>
	public class SolvingAlgorithm
	{
		public SolvingAlgorithm()
		{
		}
		
		public List<int> ReturnPossibleValues(Column col, Row row, Quadrant quad)
		{
			List<int> possibleValues = new List<int>();
			
			for(int i = 1; i <= 9; i++)
			{
				if(
					!col.ContainsValue(i) &&
					!row.ContainsValue(i) &&
					!quad.ContainsValue(i))				
						possibleValues.Add(i);
				
			}
			
			return possibleValues;
		}
		
		
		public int[] SolveSquare(Square sq, Column col, Row row, Quadrant quad)
		{
			//This array is returned with the info as to whether the square was solved.
			//It's values are:
			//solveInfo[0] = -1 / 1 : indicates if the square was solved
			//solveInfo[1] = int : indicates the solved value. 0 if it couldn't be solved.
			int[] solveInfo = new int[2]{-1,0};
			
			foreach(int number in sq.PossibleValues)
			{
				//Is this a possible value elsewhere in the quad? If not, then it's the correct value
				if(!NumberIsPossibleElsewhereInQuad(number, quad))
				{
					solveInfo[0] = 1;
					solveInfo[1] = number;
					return solveInfo;
				}
				
				if(!NumberIsPossibleElsewhereInRow(number, row))
				{
					solveInfo[0] = 1;
					solveInfo[1] = number;
					return solveInfo;
				}
				
				if(!NumberIsPossibleElsewhereInCol(number, col))
				{
					solveInfo[0] = 1;
					solveInfo[1] = number;
					return solveInfo;
				}
				
				if(HasOnlyOnePossibleValue(sq)) {
					solveInfo[0] = 1;
					solveInfo[1] = number;
					return solveInfo;
				}
				   
			}
			
			return solveInfo;
		}
		
		private bool HasOnlyOnePossibleValue(Square sq) {
			if(sq.PossibleValues.Count == 1) {
				return true;
			} else {
				return false;
			}
		}
		
		private bool NumberIsPossibleElsewhereInQuad(int number, Quadrant quad)
		{
			bool existsElsewhere = false;
			int numCount = 0;
			
			foreach(Square sq in quad.listOfSquares)
			{
				if(sq.PossibleValues.Contains(number))
					numCount++;
			}
			
			if(numCount > 1)
				existsElsewhere = true;
			
			return existsElsewhere;
		}
		
		private bool NumberIsPossibleElsewhereInRow(int number, Row row)
		{
			bool existsElsewhere = false;
			int numCount = 0;
			
			foreach(Square sq in row.listOfSquares)
			{
				if(sq.PossibleValues.Contains(number))
					numCount++;
			}
			
			if(numCount > 1)
				existsElsewhere = true;
			
			return existsElsewhere;
		}
		
		private bool NumberIsPossibleElsewhereInCol(int number, Column col)
		{
			bool existsElsewhere = false;
			int numCount = 0;
			
			foreach(Square sq in col.listOfSquares)
			{
				if(sq.PossibleValues.Contains(number))
					numCount++;
			}
			
			if(numCount > 1)
				existsElsewhere = true;
			
			return existsElsewhere;
		}
	}
}
