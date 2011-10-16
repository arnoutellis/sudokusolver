using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using SudokuSolver;

/*
 * Created by SharpDevelop.
 * User: Arnout
 * Date: 16/10/2011
 * Time: 15:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SudokuInterface
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		/// 
		private ComboBox[,] boxes;
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(415, 22);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(122, 43);
			this.button1.TabIndex = 0;
			this.button1.Text = "Solve!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(415, 82);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(122, 43);
			this.button2.TabIndex = 0;
			this.button2.Text = "Clear";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(549, 310);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.ResumeLayout(false);
			
			
			boxes = new ComboBox[9,9];
            Font font = null;

			for(int x = 0; x < 9; x++)
				for(int y = 0; y < 9; y++)
				{
					ComboBox comboBox = new ComboBox();
                    if(font == null)
                        font = new Font(comboBox.Font, FontStyle.Bold);
                    comboBox.Font = font;

					String[] items = new String[]{"","1","2","3","4","5","6","7","8","9"};
					comboBox.Items.AddRange(items);
					comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
					comboBox.Location = new Point(x*40 + 10,y*30 + 10);
					comboBox.Size = new Size(36, 21);
					comboBox.SelectedIndex = 0;
					comboBox.MaxDropDownItems = 10;
					this.Controls.Add(comboBox);
					boxes[y,x] = comboBox;
				}
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		
		void Button1Click(object sender, EventArgs e)
		{
			IOHandler sIOHandler = new IOHandler();
			
			sIOHandler.SetSudokuValues(GetData());
			sIOHandler.SolvePuzzle();
			SetData(sIOHandler.GetSudokuValues());
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			for(int y = 0; y < 9; y++)
				for(int x = 0; x < 9; x++)
					boxes[y,x].SelectedIndex = 0;
		}
		
		
		private int[,] GetData()
		{
			int[,] d = new int[9,9];
			for(int y = 0; y < 9; y++)
				for(int x = 0; x < 9; x++)
					d[y,x] = (int)boxes[y,x].SelectedIndex;

			return d;
		}

		private void SetData(int[,] d)
		{
			for(int y = 0; y < 9; y++)
				for(int x = 0; x < 9; x++)
					boxes[y,x].SelectedIndex = d[y,x];
		}
	}
}
