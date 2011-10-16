/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 12/10/2011
 * Time: 19:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SudokuSolver.SudokuEntities
{
	/// <summary>
	/// Description of Row.
	/// </summary>
	public class Row : SquareCollection
	{
		public Row(int yID, Square[,] sMap)
		{
			for(int x = 0; x < 9; x++)
			{
				listOfSquares.Add(sMap[x,yID]);
			}
		}
	}
}
