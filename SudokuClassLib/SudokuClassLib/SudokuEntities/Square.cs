/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 12/10/2011
 * Time: 19:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace SudokuSolver.SudokuEntities
{
	/// <summary>
	/// Description of Square.
	/// </summary>
	public class Square
	{
		private int currentValue = 0;
		public int CurrentValue
		{
			get{ return currentValue; }
			set{ currentValue = value;}
		}
		
		private bool isSet = false;
		public bool IsSet
		{
			get{ return isSet;}
			set{ isSet = value;}
		}
		
		private bool isNative = false;
		public bool IsNative
		{
			get{ return isNative;}			
		}
		
		private List<int> _possibleValues = new List<int>();
		public List<int> PossibleValues
		{
			get{ return _possibleValues;}
		}
		
		public void AddPossibleValue(int possibleVal)
		{
			if(!_possibleValues.Contains(possibleVal))
				_possibleValues.Add(possibleVal);
		}
		
		public void AddPossibleValue(List<int> possibleVals)
		{
			foreach (var val in possibleVals)
			{
				if(!_possibleValues.Contains(val))
					_possibleValues.Add(val);
			}
		}
		
		public void RemovePossibleValue(int possibleVal)
		{
			if(_possibleValues.Contains(possibleVal))
				_possibleValues.Remove(possibleVal);
		}
		
		public void RemovePossibleValue(List<int> possibleVals)
		{
			foreach (var val in possibleVals)
			{
				if(_possibleValues.Contains(val))
					_possibleValues.Remove(val);
			}
		}
		
		public bool ContainsPossibleValue(int possValue)
		{
			return _possibleValues.Contains(possValue);
		}
		
		
		private int xLoc;
		public int XLoc
		{
			get{ return xLoc;}
			set{ xLoc = value;}
		}
		
		private int yLoc;
		public int YLoc
		{
			get{ return yLoc;}
			set{ yLoc = value;}
		}
		
		public Square()
		{
		}
		
		public Square(int x, int y, int currentVal)
		{			
			xLoc = x;
			yLoc = y;
			
			if(currentVal > 0)
			{
				currentValue = currentVal;
				isNative = true;
				isSet = true;
			} else {
				currentValue = 0;
				isNative = false;
				isSet = false;
			}
		}
	}
}
