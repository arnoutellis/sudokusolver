/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 12/10/2011
 * Time: 19:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SudokuSolver.SudokuEntities
{
	/// <summary>
	/// Description of Column.
	/// </summary>
	public class Column : SquareCollection
	{
		public Column(int xID, Square[,] sMap)
		{
			for(int y = 0; y < 9; y++)
			{
				listOfSquares.Add(sMap[xID,y]);
			}
		}
	}
}
