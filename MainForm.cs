/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 9/27/2024
 * Time: 12:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace graficaRapida
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public Graphics g;
		public Pen p = new Pen(Color.Red,1);
		public Font f;
		public Brush b = new SolidBrush(Color.Black);
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			g.DrawLine(p,1,1,this.panel1.Width,this.panel1.Height);
			g.DrawString(GetDistance(1,1,this.panel1.Width,this.panel1.Height).ToString(),f,b,Width/2,Height/2);
			
		}
		
		public double GetDistance(double x1, double y1, double x2, double y2)
{
   return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
}
		void MainFormLoad(object sender, EventArgs e)
		{
			g = this.panel1.CreateGraphics();
			f = this.Font;
			
		}
		
		public int ismousedown = 0;
		public int startx ;
		public int starty ;
		public int currentx;
		public int currenty;
		public string direction = "stop";
		void Panel1MouseDown(object sender, MouseEventArgs e)
		{
			ismousedown=1;
			startx = e.X;
			starty = e.Y;
		}
		void Panel1MouseUp(object sender, MouseEventArgs e)
		{
			ismousedown=0;
		}
		void Panel1MouseMove(object sender, MouseEventArgs e)
		{	
			if(ismousedown==1)
			{
				currentx = e.X;
				currenty = e.Y;
				int x = currentx - startx;
				int y = currenty - starty;
				int tox = 0;
				int toy = 0;
				
				double distanta = GetDistance((double)startx,(double)starty,(double)currentx,(double)currenty);
				
				
				if(x>0){tox= 1;}
				else if(x<0){tox= -1;}
				if(y>0){toy= 1;}
				else if(y<0){toy= -1;}
				
				if(tox == 1 && toy == 1 ){direction = "toRightDown";}
				else if(tox == 1 && toy == 0 ){direction = "toRight";}
				else if(tox == 1 && toy == -1 ){direction = "toRightUp";}
				
				else if(tox == -1 && toy == 1 ){direction = "toLeftDown";}
				else if(tox == -1 && toy == 0 ){direction = "toLeft";}
				else if(tox == -1 && toy == -1 ){direction = "toLeftUp";}
				
				else if(tox == 0 && toy == 1 ){direction = "toDown";}
				else if(tox == 0 && toy == 0 ){direction = "Stop";}
				else if(tox == 0 && toy == -1 ){direction = "toUp";}
				
				
				
				Text = distanta.ToString() + " : " + direction  + " : " + tox.ToString()  + " : " + toy.ToString();
				g.Clear(this.panel1.BackColor);
				g.DrawLine(p,startx,starty,currentx,currenty);
				
				
				
				
			}
		}
	}
}
