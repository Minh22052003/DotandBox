using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Board
    {
        public List<Lines> lines { get; set; }//Danh sách đường nối hiện tại
        public int maxlines { get; set; }//Tổng số đường
        public int totallines { get; set; }//Số đường thẳng đã được vẽ
        public int aiscore { get; set; }//Điểm máy chơi
        public int playerscore { get; set; }//Điểm người chơi
        public bool aimove { get; set; }// Biến cho biết liệu đến lượt AI đi hay không.
        public int difference { get; set; }// Sự khác biệt giữa điểm số của AI và người chơi, được tính bằng aiscore - playerscore.

        public Board(List<Lines> lines,int aiscore, int playerscore)
        {
            this.lines = lines;
            this.aiscore = aiscore;
            this.playerscore = playerscore;
        }



    }
}
