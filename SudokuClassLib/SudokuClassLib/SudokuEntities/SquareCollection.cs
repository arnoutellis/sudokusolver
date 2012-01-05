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
	/// Description of Line.
	/// </summary>
	public abstract class SquareCollection
	{
		public List<Square> listOfSquares = new List<Square>();
		
		public bool ContainsValue(int val)
		{
			foreach(var s in listOfSquares)
			{
				if(s.CurrentValue == val) return true;				
			}
			return false;
		}
		
		public void DebugPrint()
		{
			foreach(var s in listOfSquares)
			{
				Console.WriteLine("xID={0} yID={1} currentValue={2}",
				                  s.XLoc, s.YLoc, s.CurrentValue);
				foreach(var i in s.PossibleValues) {
					Console.WriteLine("possible values: {0}", i);
					
				}
			}
		}
	}
}
