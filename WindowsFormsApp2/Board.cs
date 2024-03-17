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
        public int aiscore { get; set; }//Điểm máy chơi
        public int playerscore { get; set; }//Điểm người chơi

        public Board(List<Lines> lines,int aiscore, int playerscore)
        {
            this.lines = lines;
            this.aiscore = aiscore;
            this.playerscore = playerscore;
        }



    }
}
