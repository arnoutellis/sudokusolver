/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 12/10/2011
 * Time: 19:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SudokuSolver.SudokuEntities
{
	/// <summary>
	/// Description of SudokuMap.
	/// </summary>
	public class SudokuMap
	{
		private Square[,] _sudokuMap = new Square[9,9];
		public Square[,] SudokuSquareMap
		{
			get { return _sudokuMap;}
		}
		
		private int _outstandingBoxes = 0;
		public int OutstandingBoxes
		{
			get { return _outstandingBoxes;}
		}
		
		
		public SudokuMap()
		{
		}
		
		public void PopulateSudokuMap(int[,] sudokuvalues)
		{			
			
			for(int y = 0; y < 9; y++)
			{
				for(int x = 0; x < 9; x++)
				{
					_sudokuMap[x,y] = new Square(x,y,sudokuvalues[x,y]);
					
					SetOutstandingBoxes(sudokuvalues[x,y]);
				}
			}			
		}
		
		private void SetOutstandingBoxes(int sVal)
		{
			if(sVal == 0) _outstandingBoxes++;
		}
		
		
		public void SolveSquare(int xId, int yId, int val)
		{
			Square sq = _sudokuMap[xId, yId];
			sq.CurrentValue = val;
			sq.PossibleValues.Clear();
			sq.IsSet = true;
			
			_outstandingBoxes--;
			
			RemoveValueFromPossibleValues(xId, yId, val);
		}
		
		private void RemoveValueFromPossibleValues(int xId, int yId, int val)
		{
			RemoveFromRow(xId, yId, val);
			RemoveFromCol(xId, yId, val);
			RemoveFromQuadrant(xId, yId, val);
			
		}
		
		void RemoveFromQuadrant(int xId, int yId, int val)
		{
			Quadrant quad = GetQuadrant(xId, yId);
			
			foreach(Square sq in quad.listOfSquares)
			{
				sq.RemovePossibleValue(val);
			}
		}
		
		void RemoveFromCol(int xId, int yId, int val)
		{
			Column col = GetCol(xId);
			
			foreach(Square sq in col.listOfSquares)
			{
				sq.RemovePossibleValue(val);
			}
		}
		
		void RemoveFromRow(int xId, int yId, int val)
		{
			Row row = GetRow(yId);
			
			foreach(Square sq in row.listOfSquares)
			{
				sq.RemovePossibleValue(val);
			}
		}
		
		public Quadrant GetQuadrant(int xID, int yID)
		{
			return new Quadrant(xID, yID, _sudokuMap);
		}
		
		public Row GetRow(int rowNumber)
		{
			return new Row(rowNumber, _sudokuMap);
		}
		
		public Column GetCol(int colNumber)
		{
			return new Column(colNumber, _sudokuMap);
		}
		
		public Square GetSquare(int locX, int locY)
		{
			return _sudokuMap[locX, locY];
		}
	}
}
