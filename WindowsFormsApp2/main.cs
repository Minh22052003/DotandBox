using LineConnectionApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
	public partial class main : Form
	{
        public bool mode = true;
		private List<Lines> lines = new List<Lines>();
        public Player player1 = new Player();
        public Player player2 = new Player();
        public int startX = 180; // Tọa độ x ban đầu
        public int startY = 130; // Tọa độ y ban đầu
        public int spacing = 70; // Khoảng cách giữa các điểm
        public main()
		{
			InitializeComponent();
			this.BackColor = Color.LightSkyBlue;
			

			// Tạo các đường nối theo hàng
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Point point1 = new Point(startX + j * spacing, startY + i * spacing);
					Point point2 = new Point(startX + (j + 1) * spacing, startY + i * spacing);
					lines.Add(new Lines(point1, point2));
				}
			}

			// Tạo các đường nối theo cột
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Point point1 = new Point(startX + i * spacing, startY + j * spacing);
					Point point2 = new Point(startX + i * spacing, startY + (j + 1) * spacing);
					lines.Add(new Lines(point1, point2));
				}
			}
			AssignClickEvents();

		}
        private void AssignClickEvents()
        {
            if (mode)
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    lines[i].Click += (sender, args) =>
                    {
                        if (!((Lines)sender).Check)
                        {
                            if (player1.Turn == false)
                            {
                                ((Lines)sender).ChangeColor(Color.Blue);
                                ((Lines)sender).ChangeDash(System.Drawing.Drawing2D.DashStyle.Solid);
                                ((Lines)sender).Check = true;
                                player1.setTurn(true);
                                player2.setTurn(false);
                                player1.setScore(TinhDiem(((Lines)sender)));
                                Score1.Text = player1.Score.ToString();
                                timer2.Start();
                                timeE2.Text = player1.timeEnd.ToString();
                                Invalidate();
                            }
                            else if (player2.Turn == false)
                            {
                                ((Lines)sender).ChangeColor(Color.Red);
                                ((Lines)sender).ChangeDash(System.Drawing.Drawing2D.DashStyle.Solid);
                                ((Lines)sender).Check = true;
                                player2.setTurn(true);
                                player1.setTurn(false);
                                player2.setScore(TinhDiem(((Lines)sender)));
                                Score2.Text = player2.Score.ToString();
                                timer1.Start();
                                timeE1.Text = player1.timeEnd.ToString();
                                Invalidate();
                            }
                        }
                    };

                }
            }
            
        }

        private int TinhDiem(Lines line)
		{
            int SoDiem = 0;
			//Kiem tra truong hop nam sat canh ben trai
			if(line.Point1.X == line.Point2.X && line.Point1.X == startX)
            {
                bool check1 = false, check2 = false, check3 = false;
                foreach (var x in lines)
				{
					if((x.Point1.X == line.Point1.X && x.Point1.Y == line.Point1.Y) && (x.Point2.X == (line.Point1.X+spacing) && x.Point2.Y == line.Point1.Y))
					{
						if (x.Check == true)
						{
							check1 = true;
						}
					}
                    if ((x.Point1.X == (line.Point1.X + spacing) && x.Point1.Y == line.Point1.Y) && (x.Point2.X == (line.Point2.X + spacing) && x.Point2.Y == line.Point2.Y))
                    {
                        if (x.Check == true)
                        {
                            check2 = true;
                        }
                    }
                    if ((x.Point1.X == line.Point2.X && x.Point1.Y == line.Point2.Y) && (x.Point2.X == (line.Point2.X + spacing) && x.Point2.Y == line.Point2.Y))
                    {
                        if (x.Check == true)
                        {
                            check3 = true;
                        }
                    }
                }
				if(check1 && check2 && check3)
				{
					SoDiem++;
				}
			}
            // Kiểm tra trường hợp nằm sát cạnh bên trên
            if (line.Point1.Y == line.Point2.Y && line.Point1.Y == startY)
            {
                bool check1 = false, check2 = false, check3 = false;
                foreach (var x in lines)
                {
                    // Kiểm tra xem các đoạn nối cạnh bên trên đã được chọn hay không
                    if ((x.Point1.Y == line.Point1.Y && x.Point1.X == line.Point1.X) &&
                        (x.Point2.Y == (line.Point1.Y + spacing) && x.Point2.X == line.Point1.X))
                    {
                        if (x.Check)
                        {
                            check1 = true;
                        }
                    }
                    if ((x.Point1.Y == (line.Point1.Y + spacing) && x.Point1.X == line.Point1.X) &&
                        (x.Point2.Y == (line.Point2.Y + spacing) && x.Point2.X == line.Point2.X))
                    {
                        if (x.Check)
                        {
                            check2 = true;
                        }
                    }
                    if ((x.Point1.Y == line.Point2.Y && x.Point1.X == line.Point2.X) &&
                        (x.Point2.Y == (line.Point2.Y + spacing) && x.Point2.X == line.Point2.X))
                    {
                        if (x.Check)
                        {
                            check3 = true;
                        }
                    }
                }

                if (check1 && check2 && check3)
                {
                    SoDiem++;
                }
            }
            // Kiểm tra trường hợp nằm sát cạnh bên dưới
            if (line.Point1.Y == line.Point2.Y && line.Point1.Y == (startY + 3 * spacing))
            {
                bool check1 = false, check2 = false, check3 = false;
                foreach (var x in lines)
                {
                    if ((x.Point1.X == line.Point1.X && x.Point1.Y == (line.Point1.Y-spacing)) &&
                        (x.Point2.X == line.Point1.X && x.Point2.Y == line.Point1.Y))
                    {
                        if (x.Check)
                        {
                            check1 = true;
                        }
                    }
                    if ((x.Point1.X == line.Point1.X && x.Point1.Y == (line.Point1.Y - spacing)) &&
                        (x.Point2.X == line.Point2.X && x.Point2.Y == (line.Point2.Y - spacing)))
                    {
                        if (x.Check)
                        {
                            check2 = true;
                        }
                    }
                    if ((x.Point1.X == line.Point2.X && x.Point1.Y == (line.Point2.Y-spacing)) &&
                        (x.Point2.X == line.Point2.X && x.Point2.Y == line.Point2.Y))
                    {
                        if (x.Check)
                        {
                            check3 = true;
                        }
                    }
                }

                if (check1 && check2 && check3)
                {
                    SoDiem++;
                }
            }
            // Kiểm tra trường hợp nằm sát cạnh bên phải
            if (line.Point1.X == line.Point2.X && line.Point1.X == startX + 3 * spacing)
            {
                bool check1 = false, check2 = false, check3 = false;
                foreach (var x in lines)
                {
                    // Kiểm tra xem các đoạn nối cạnh bên phải đã được chọn hay không
                    if ((x.Point1.X == (line.Point1.X - spacing) && x.Point1.Y == line.Point1.Y) &&
                        (x.Point2.X == line.Point1.X  && x.Point2.Y == line.Point1.Y))
                    {
                        if (x.Check)
                        {
                            check1 = true;
                        }
                    }
                    if ((x.Point1.X == (line.Point1.X - spacing) && x.Point1.Y == line.Point1.Y) &&
                        (x.Point2.X == (line.Point2.X - spacing) && x.Point2.Y == line.Point2.Y))
                    {
                        if (x.Check)
                        {
                            check2 = true;
                        }
                    }
                    if ((x.Point1.X == (line.Point2.X - spacing) && x.Point1.Y == line.Point2.Y) &&
                        (x.Point2.X == line.Point2.X && x.Point2.Y == line.Point2.Y))
                    {
                        if (x.Check)
                        {
                            check3 = true;
                        }
                    }
                }

                if (check1 && check2 && check3)
                {
                    SoDiem++;
                }
            }
            // Kiểm tra trường hợp nằm ngang giữa
            if(line.Point1.Y==line.Point2.Y && line.Point1.Y != startY && line.Point1.Y != (startY + 3 * spacing))
            {
                bool check1 = false, check2 = false, check3 = false, check4 = false, check5 = false, check6 = false;
                foreach(var x in lines)
                {
                    // Kiểm tra xem các đoạn nối cạnh bên phải đã được chọn hay không
                    if ((x.Point1.X == line.Point1.X && x.Point1.Y == (line.Point1.Y-spacing)) &&
                        (x.Point2.X == line.Point1.X && x.Point2.Y == line.Point1.Y))
                    {
                        if (x.Check)
                        {
                            check1 = true;
                        }
                    }
                    if ((x.Point1.X == line.Point1.X && x.Point1.Y == (line.Point1.Y-spacing)) &&
                        (x.Point2.X == line.Point2.X && x.Point2.Y == (line.Point2.Y-spacing)))
                    {
                        if (x.Check)
                        {
                            check2 = true;
                        }
                    }
                    if ((x.Point1.X == line.Point2.X && x.Point1.Y == (line.Point2.Y-spacing)) &&
                        (x.Point2.X == line.Point2.X && x.Point2.Y == line.Point2.Y))
                    {
                        if (x.Check)
                        {
                            check3 = true;
                        }
                    }
                    if ((x.Point1.Y == line.Point1.Y && x.Point1.X == line.Point1.X) &&
                        (x.Point2.Y == (line.Point1.Y + spacing) && x.Point2.X == line.Point1.X))
                    {
                        if (x.Check)
                        {
                            check4 = true;
                        }
                    }
                    if ((x.Point1.Y == (line.Point1.Y + spacing) && x.Point1.X == line.Point1.X) &&
                        (x.Point2.Y == (line.Point2.Y + spacing) && x.Point2.X == line.Point2.X))
                    {
                        if (x.Check)
                        {
                            check5 = true;
                        }
                    }
                    if ((x.Point1.Y == line.Point2.Y && x.Point1.X == line.Point2.X) &&
                        (x.Point2.Y == (line.Point2.Y + spacing) && x.Point2.X == line.Point2.X))
                    {
                        if (x.Check)
                        {
                            check6 = true;
                        }
                    }
                }
                if (check1 && check2 && check3)
                {
                    SoDiem++;
                }
                if (check4 && check5 && check6)
                {
                    SoDiem++;
                }
            }
            // Kiểm tra trường hợp nằm dọc giữa
            if (line.Point1.X == line.Point2.X && line.Point1.X != startX && line.Point1.X != (startX + 3 * spacing))
            {
                bool check1 = false, check2 = false, check3 = false, check4 = false, check5 = false, check6 = false;
                foreach (var x in lines)
                {
                    if ((x.Point1.X == (line.Point1.X - spacing) && x.Point1.Y == line.Point1.Y) &&
                        (x.Point2.X == line.Point1.X && x.Point2.Y == line.Point1.Y))
                    {
                        if (x.Check)
                        {
                            check1 = true;
                        }
                    }
                    if ((x.Point1.X == (line.Point1.X - spacing) && x.Point1.Y == line.Point1.Y) &&
                        (x.Point2.X == (line.Point2.X - spacing) && x.Point2.Y == line.Point2.Y))
                    {
                        if (x.Check)
                        {
                            check2 = true;
                        }
                    }
                    if ((x.Point1.X ==(line.Point2.X-spacing) && x.Point1.Y == line.Point2.Y) &&
                        (x.Point2.X == line.Point2.X && x.Point2.Y == line.Point2.Y))
                    {
                        if (x.Check)
                        {
                            check3 = true;
                        }
                    }
                    if ((x.Point1.X == line.Point1.X && x.Point1.Y == line.Point1.Y) &&
                        (x.Point2.X == (line.Point1.X + spacing) && x.Point2.Y == line.Point1.Y))
                    {
                        if (x.Check)
                        {
                            check4 = true;
                        }
                    }
                    if ((x.Point1.X == (line.Point1.X + spacing) && x.Point1.Y == line.Point1.Y) &&
                        (x.Point2.X == (line.Point2.X + spacing) && x.Point2.Y == line.Point2.Y))
                    {
                        if (x.Check)
                        {
                            check5 = true;
                        }
                    }
                    if ((x.Point1.X == line.Point2.X && x.Point1.Y == line.Point2.Y) &&
                        (x.Point2.X == (line.Point2.X + spacing) && x.Point2.Y == line.Point2.Y))
                    {
                        if (x.Check)
                        {
                            check6 = true;
                        }
                    }
                }
                if (check1 && check2 && check3)
                {
                    SoDiem++;
                }
                if (check4 && check5 && check6)
                {
                    SoDiem++;
                }
            }


            return SoDiem;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// Vẽ các đường nối
			foreach (var line in lines)
			{
                // Vẽ đường nối
                Pen pen = new Pen(line.Color);
                pen.DashStyle=line.dashStyle;
				e.Graphics.DrawLine(pen, line.Point1, line.Point2);
				pen.Dispose();

				// Vẽ các chấm tròn ở hai đầu của đường nối
				int circleRadius = 10;
				e.Graphics.FillEllipse(Brushes.Black, line.Point1.X - circleRadius / 2, line.Point1.Y - circleRadius / 2, circleRadius, circleRadius);
				e.Graphics.FillEllipse(Brushes.Black, line.Point2.X - circleRadius / 2, line.Point2.Y - circleRadius / 2, circleRadius, circleRadius);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			// Kiểm tra xem có điểm nào được click trong các đường nối không
			foreach (var line in lines)
			{
				line.HandleClick(e.Location);
			}
		}

		private void Click_Exit(object sender, EventArgs e)
		{
			this.Close();
		}

        private void timer1_Tick(object sender, EventArgs e)
        {
            player1.setTimeEnd(player1.timeEnd-1);
        }
    }
}
