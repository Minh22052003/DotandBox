using LineConnectionApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
	public partial class main : Form
	{
        public bool mode = false;
		private List<Lines> lines = new List<Lines>();
        public Player player1 = new Player();
        public Player player2 = new Player();
        public int startX = 180; // Tọa độ x ban đầu
        public int startY = 130; // Tọa độ y ban đầu
        public int spacing = 70; // Khoảng cách giữa các điểm
        public int size = 3;//Size trò chơi
        public main()
		{
			InitializeComponent();
			this.BackColor = Color.LightSkyBlue;
			

			for (int i = 0; i < size+1; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Point point1 = new Point(startX + j * spacing, startY + i * spacing);
					Point point2 = new Point(startX + (j + 1) * spacing, startY + i * spacing);
					lines.Add(new Lines(point1, point2));
				}
			}

			for (int i = 0; i < size+1; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Point point1 = new Point(startX + i * spacing, startY + j * spacing);
					Point point2 = new Point(startX + i * spacing, startY + (j + 1) * spacing);
					lines.Add(new Lines(point1, point2));
				}
			}
            if (!mode)
            {
                foreach (var line in lines)
                {
                    line.Click += LineClickHandler;
                }
            }
            
            AssignClickEvents();

		}
        public Board board;
        public Minimax mnm;
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
                                ((Lines)sender).ChangeDash(DashStyle.Solid);
                                ((Lines)sender).Check = true;
                                player1.setTurn(true);
                                player2.setTurn(false);
                                if (TinhDiem(((Lines)sender)) != 0)
                                {
                                    player1.setTurn(false);
                                    player2.setTurn(true);
                                    timer2.Stop();
                                }
                                player1.setScore(TinhDiem(((Lines)sender)));
                                Score1.Text = player1.Score.ToString();
                                timer2.Start();
                                timeE2.Text = player2.timeEnd.ToString();
                                Invalidate();
                            }
                            else if (player2.Turn == false)
                            {
                                ((Lines)sender).ChangeColor(Color.Red);
                                ((Lines)sender).ChangeDash(DashStyle.Solid);
                                ((Lines)sender).Check = true;
                                player2.setTurn(true);
                                player1.setTurn(false);
                                
                                if (TinhDiem(((Lines)sender)) != 0)
                                {
                                    player2.setTurn(false);
                                    player1.setTurn(true);
                                    timer1.Stop();
                                }
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
            else//bug
            {
                
            }

        }
        private bool nextMoveByComputer = false;

        void LineClickHandler(object sender, EventArgs e)
        {
            Lines clickedLine = (Lines)sender;
            if (!clickedLine.Check)
            {
                clickedLine.ChangeColor(Color.Blue);
                clickedLine.ChangeDash(DashStyle.Solid);
                clickedLine.Check = true;
                nextMoveByComputer = true;
                if (TinhDiem(clickedLine) != 0)
                {
                    nextMoveByComputer = false;
                }
                player1.setScore(TinhDiem(clickedLine));
                Score1.Text = player1.Score.ToString();
                Invalidate();
                    
            }
        }


        private void MakeComputerMove()
        {
            board = new Board(lines, int.Parse(Score2.Text), int.Parse(Score1.Text));
            mnm = new Minimax(board, startX, startY, spacing, size);
            Lines bestMove = mnm.GetBestMove();
            int bestMoveIndex = lines.FindIndex(line => line == bestMove);
            lines[bestMoveIndex].ChangeColor(Color.Red);
            lines[bestMoveIndex].ChangeDash(DashStyle.Solid);
            lines[bestMoveIndex].Check = true;
            nextMoveByComputer = false;
            int moveScore = TinhDiem(lines[bestMoveIndex]);
            if (moveScore != 0 || GameOver())
            {
                player2.setScore(moveScore);
                Score2.Text = player2.Score.ToString();
            }
            else
            {
                nextMoveByComputer = true;
            }
            if (moveScore != 0 && !GameOver())
            {
                MakeComputerMove();
            }
            Invalidate();
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
            if (line.Point1.Y == line.Point2.Y && line.Point1.Y == (startY + size * spacing))
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
            if (line.Point1.X == line.Point2.X && line.Point1.X == startX + size * spacing)
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
            if(line.Point1.Y==line.Point2.Y && line.Point1.Y != startY && line.Point1.Y != (startY + size * spacing))
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
            if (line.Point1.X == line.Point2.X && line.Point1.X != startX && line.Point1.X != (startX + size * spacing))
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
                Pen pen = new Pen(line.Color);
                pen.DashStyle=line.dashStyle;
				e.Graphics.DrawLine(pen, line.Point1, line.Point2);
				pen.Dispose();

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

            // Nếu biến flag được đặt thành true, gọi MakeComputerMove và đặt lại biến flag
            if (nextMoveByComputer)
            {
                MakeComputerMove();
                
            }
        }
        private bool GameOver()
        {
            foreach (var x in lines)
            {
                if (x.Check != true)
                {
                    return false;
                }
            }
            return true;
        }

        private void Click_Exit(object sender, EventArgs e)
		{
			this.Close();
		}

        private void timer1_Tick(object sender, EventArgs e)
        {
            player1.setTimeEnd(player1.timeEnd-1);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            player2.setTimeEnd(player2.timeEnd - 1);
        }
        
    }
}
