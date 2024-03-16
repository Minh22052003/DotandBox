﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace WindowsFormsApp2
{
    public class Minimax
    {
        public Board board;// Trạng thái hiện tại của trò chơi
        public List<Lines> lines ;
        public int scoreAI;
        public int scorePL;
        public int startX; // Tọa độ x ban đầu
        public int startY; // Tọa độ y ban đầu
        public int spacing; // Khoảng cách giữa các điểm
        public int size;//Size trò chơi

        public Minimax(Board board, int StartX, int StartY, int Spacing, int size)
        {
            this.board = board;
            lines = board.lines;
            scoreAI = board.aiscore;
            scorePL = board.playerscore;
            startX = StartX;
            startY = StartY;
            spacing = Spacing;
            this.size = size;
        }

        private int TinhDiem(Lines line)
        {
            int SoDiem = 0;
            //Kiem tra truong hop nam sat canh ben trai
            if (line.Point1.X == line.Point2.X && line.Point1.X == startX)
            {
                bool check1 = false, check2 = false, check3 = false;
                foreach (var x in lines)
                {
                    if ((x.Point1.X == line.Point1.X && x.Point1.Y == line.Point1.Y) && (x.Point2.X == (line.Point1.X + spacing) && x.Point2.Y == line.Point1.Y))
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
                if (check1 && check2 && check3)
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
                    if ((x.Point1.X == line.Point1.X && x.Point1.Y == (line.Point1.Y - spacing)) &&
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
                    if ((x.Point1.X == line.Point2.X && x.Point1.Y == (line.Point2.Y - spacing)) &&
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
            if (line.Point1.Y == line.Point2.Y && line.Point1.Y != startY && line.Point1.Y != (startY + size * spacing))
            {
                bool check1 = false, check2 = false, check3 = false, check4 = false, check5 = false, check6 = false;
                foreach (var x in lines)
                {
                    // Kiểm tra xem các đoạn nối cạnh bên phải đã được chọn hay không
                    if ((x.Point1.X == line.Point1.X && x.Point1.Y == (line.Point1.Y - spacing)) &&
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
                    if ((x.Point1.X == line.Point2.X && x.Point1.Y == (line.Point2.Y - spacing)) &&
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
                    if ((x.Point1.X == (line.Point2.X - spacing) && x.Point1.Y == line.Point2.Y) &&
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

        // Hàm tính toán điểm số cho trạng thái hiện tại của trò chơi
        private int Evaluate()
        {

            // Sử dụng giá trị aiScore và playerScore
            int score = scoreAI - scorePL;

            return score;
        }


        // Minimax Algorithm
        public int MinimaxAlgorithm(int depth, bool isMaximizing)
        {
            int score = Evaluate(); // Đánh giá điểm số của trạng thái hiện tại

            // Nếu đạt đến node lá hoặc trò chơi đã kết thúc, trả về điểm số
            if (depth == 0 || GameOver())
                return score;

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                int currentScore = 0;
                foreach (var move in GetPossibleMoves())
                {
                    // Thực hiện nước đi
                    MakeMove(move);
                    if (TinhDiem(move) != 0)
                    {
                        scoreAI += TinhDiem(move);
                        // Gọi đệ quy để tính toán điểm số cho nước đi tiếp theo
                        currentScore = MinimaxAlgorithm(depth - 1, true);
                    }
                    else
                    {
                        // Gọi đệ quy để tính toán điểm số cho nước đi tiếp theo
                        currentScore = MinimaxAlgorithm(depth - 1, false);
                    }

                    

                    // Hủy bỏ nước đi
                    UndoMove(move);
                    if (TinhDiem(move) != 0)
                    {
                        scoreAI -= TinhDiem(move);
                    }

                    // Cập nhật điểm số tốt nhất
                    bestScore = Math.Max(bestScore, currentScore);
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                int currentScore = 0;
                foreach (var move in GetPossibleMoves())
                {
                    // Thực hiện nước đi
                    MakeMove(move);
                    if (TinhDiem(move) != 0)
                    {
                        scorePL += TinhDiem(move);
                        // Gọi đệ quy để tính toán điểm số cho nước đi tiếp theo
                        currentScore = MinimaxAlgorithm(depth - 1, false);
                    }
                    else
                    {
                        // Gọi đệ quy để tính toán điểm số cho nước đi tiếp theo
                        currentScore = MinimaxAlgorithm(depth - 1, true);
                    }

                    

                    // Hủy bỏ nước đi
                    UndoMove(move);
                    if (TinhDiem(move) != 0)
                    {
                        scorePL -= TinhDiem(move);
                    }

                    // Cập nhật điểm số tốt nhất
                    bestScore = Math.Min(bestScore, currentScore);
                }
                return bestScore;
            }
        }

        // Kiểm tra xem trò chơi đã kết thúc chưa
        private bool GameOver()
        {
            foreach(var x in lines)
            {
                if (x.Check != true)
                {
                    return false;
                }
            }
            return true;
        }

        // Lấy danh sách các nước đi có thể
        private List<Lines> GetPossibleMoves()
        {
            List < Lines > tmp = new List<Lines>();
            foreach (var x in lines)
            {
                if (x.Check != true)
                {
                    tmp.Add(x);
                }
            }
            return tmp;
        }

        // Thực hiện một nước đi
        private void MakeMove(Lines move)
        {
            // Viết mã để thực hiện một nước đi từ trạng thái hiện tại của trò chơi
            // Thêm đoạn nối vào trạng thái của trò chơi
            move.ChangeColor(Color.Red);
            move.ChangeDash(DashStyle.Solid);
            move.Check = true;
            lines.Add(move);
        }

        // Hủy bỏ một nước đi
        private void UndoMove(Lines move)
        {
            // Viết mã để hủy bỏ một nước đi từ trạng thái hiện tại của trò chơi
            // Xóa đoạn nối khỏi trạng thái của trò chơi
            move.ChangeColor(Color.Black);
            move.ChangeDash(DashStyle.Dash);
            move.Check = false;
            lines.Remove(move);
        }

        // Chọn nước đi tốt nhất cho máy tính
        public Lines GetBestMove()
        {
            int bestScore = int.MinValue;
            int currentScore = 0;
            Lines bestMove = null;
            foreach (var move in GetPossibleMoves())
            {
                // Thực hiện nước đi
                MakeMove(move);
                if (TinhDiem(move) != 0)
                {
                    scoreAI += TinhDiem(move);
                    // Gọi thuật toán Minimax để tính toán điểm số cho nước đi tiếp theo
                    currentScore = MinimaxAlgorithm(5, true); // Độ sâu của cây tìm kiếm
                }
                else
                {
                    // Gọi thuật toán Minimax để tính toán điểm số cho nước đi tiếp theo
                    currentScore = MinimaxAlgorithm(5, false); // Độ sâu của cây tìm kiếm
                }

                

                // Hủy bỏ nước đi
                UndoMove(move);
                if (TinhDiem(move) != 0)
                {
                    scoreAI -= TinhDiem(move);
                }

                // Cập nhật nước đi tốt nhất
                if (currentScore > bestScore)
                {
                    bestScore = currentScore;
                    bestMove = move;
                }
            }
            return bestMove;
        }
    }
}