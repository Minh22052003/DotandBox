
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
        public SettingGame stG;
		private List<Lines> lines = new List<Lines>();
        public Player player1 = new Player();
        public Player player2 = new Player();
        public Board board;
        public Minimax mnm;
        public bool checkEnd=false;
        private bool nextMoveByComputer = false;
        public int startX; // Tọa độ x ban đầu
        public int startY; // Tọa độ y ban đầu
        public int spacing; // Khoảng cách giữa các điểm
        public int size;//Size trò chơi
        public int Depth;//Độ sâu minimax
        public main(SettingGame stg)
		{
			InitializeComponent();
			this.BackColor = Color.LightSkyBlue;
            this.stG = stg;
            startX = stG.startX;
            startY = stG.startY;
            spacing = stG.returnSpacing();
            size = stG.size;
            Depth = stG.returnDepth();

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
            
            if (stG.mode != "PVP")
            {
                foreach (var line in lines)
                {
                    line.Click += LineClickHandler;
                }
            }
            else
            {
                AssignClickEvents();
                returnEnd();
            }
		}
        private void AssignClickEvents()
        {
            if (stG.mode== "PVP")
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
                                if (Scoring(((Lines)sender)) != 0)
                                {
                                    player1.setTurn(false);
                                    player2.setTurn(true);
                                    timer2.Stop();
                                }
                                player1.setScore(Scoring(((Lines)sender)));
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
                                
                                if (Scoring(((Lines)sender)) != 0)
                                {
                                    player2.setTurn(false);
                                    player1.setTurn(true);
                                    timer1.Stop();
                                }
                                player2.setScore(Scoring(((Lines)sender)));
                                Score2.Text = player2.Score.ToString();
                                timer1.Start();
                                timeE1.Text = player1.timeEnd.ToString();
                                Invalidate();
                            }
                            if (GameOver())
                            {
                                if (player1.Score > player2.Score)
                                {
                                    MessageBox.Show("Player 1 Win");
                                }
                                else if (player2.Score > player1.Score)
                                {
                                    MessageBox.Show("Player 2 Win");
                                }
                                else
                                {
                                    MessageBox.Show("No Player Win");
                                }
                            }
                        }
                    };
                }
                
            }

        }

        void LineClickHandler(object sender, EventArgs e)
        {
            Lines clickedLine = (Lines)sender;
            if (!clickedLine.Check)
            {
                clickedLine.ChangeColor(Color.Blue);
                clickedLine.ChangeDash(DashStyle.Solid);
                clickedLine.Check = true;
                nextMoveByComputer = true;
                if (Scoring(clickedLine) != 0)
                {
                    nextMoveByComputer = false;
                }
                player1.setScore(Scoring(clickedLine));
                Score1.Text = player1.Score.ToString();
                Invalidate();
                    
            }
        }


        private void MakeComputerMove()
        {
            board = new Board(lines, int.Parse(Score2.Text), int.Parse(Score1.Text));
            mnm = new Minimax(board, startX, startY, spacing, size,Depth);
            Lines bestMove = mnm.GetBestMove();
            int bestMoveIndex = lines.FindIndex(line => line == bestMove);
            lines[bestMoveIndex].ChangeColor(Color.Red);
            lines[bestMoveIndex].ChangeDash(DashStyle.Solid);
            lines[bestMoveIndex].Check = true;
            nextMoveByComputer = false;
            int moveScore = Scoring(lines[bestMoveIndex]);
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
            returnEnd();
            Invalidate();
        }


        private int Scoring(Lines line)
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
                Pen pen = new Pen(line.Color,3);
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
            bool check = false;
            // Kiểm tra xem có điểm nào được click trong các đường nối không
            foreach (var line in lines)
            {
                if (line.HandleClick1(e.Location))
                {
                    if (line.Check)
                    {
                        check = true;
                    }
                }
                line.HandleClick(e.Location);
                

            }
            returnEnd();
            if (!check && nextMoveByComputer )
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

        private void returnEnd()
        {
            if (GameOver()&& !checkEnd)
            {
                if (player1.Score > player2.Score)
                {
                    MessageBox.Show("Player 1 Win");
                    checkEnd = true;
                }
                else if (player2.Score > player1.Score)
                {
                    MessageBox.Show("Player 2 Win");
                    checkEnd = true;
                }
                else
                {
                    MessageBox.Show("No Player Win");
                    checkEnd = true;
                }

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

        private void timer2_Tick(object sender, EventArgs e)
        {
            player2.setTimeEnd(player2.timeEnd - 1);
        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            main m = new main(stG);
            m.ShowDialog();
            m = null;
            this.Show();
        }
    }
}
