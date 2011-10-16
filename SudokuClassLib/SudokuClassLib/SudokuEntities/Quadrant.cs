/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 12/10/2011
 * Time: 19:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace SudokuSolver.SudokuEntities
{
	/// <summary>
	/// Description of Quadrant.
	/// </summary>
	public class Quadrant : SquareCollection
	{
		
		
		public Quadrant(int xID, int yID, Square[,] sMap)
		{
			int minX = 0;
			int minY = 0;
			int maxX = 0;
			int maxY = 0;
			
			QuadrantMapping(xID, yID, ref minX, ref minY, ref maxX, ref maxY);
			
			for(int y = minY; y <= maxY; y++)
			{
				for(int x = minX; x <= maxX; x++)
				{
					listOfSquares.Add(sMap[x,y]);
				}
			}
		}
		
		private void QuadrantMapping(int xID, int yID, ref int minX, ref int minY, ref int maxX, ref int maxY)
		{
			if(xID < 3) {
				minX = 0;
				maxX = 2;
			} else if(xID > 2 & xID < 6) {
				minX = 3;
				maxX = 5;
			} else if(xID > 5){
				minX = 6;
				maxX = 8;
			}
			
			if(yID < 3) {
				minY = 0;
				maxY = 2;
			} else if(yID > 2 & yID < 6) {
				minY = 3;
				maxY = 5;
			} else if(yID > 5){
				minY = 6;
				maxY = 8;
			}
			
		}
	}
}
