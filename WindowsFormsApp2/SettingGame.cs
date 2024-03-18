using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class SettingGame
    {
        public int startX = 150; // Tọa độ x ban đầu
        public int startY = 110; // Tọa độ y ban đầu
        public int length = 280; // Kích thước ma trận trò chơi
        public int size = 3;//Size trò chơi
        //Tên người chơi một
        public string NamePL1 { get; set; } = "Player1";
        //Tên người chơi hai
        public string NamePL2 { get; set; } = "Player2";
        //Chế độ chơi
        public string mode { get; set; } = "PVE";
        //Độ khó
        public string level { get; set; } = "Eazy";
        //Thời gian tối đa để chơi 
        public string time { get; set; } = "5 minute";
        public SettingGame(){}
        //Trả về độ sâu của thuât toán mini max
        public int returnDepth()
        {
            int l = 0;
            if (level == "Eazy")
            {
                l= 1;
            }
            else if (level == "Normal")
            {
                l= 3;
            }
            else if (level == "Hard")
            {
                l= 5;
            }
            return l;
        }
        //Trả về thời gian chơi
        public int returnTime()
        {
            int t = 0;
            if (time == "3 minute")
            {
                t = 180;
            }
            else if (time == "5 minute")
            {
                t = 300;
            }
            else if (time == "10 minute")
            {
                t = 600;
            }
            return t;
        }
        //Trả về khoảng cách giữa các điểm
        public int returnSpacing()
        {
            return length / size;
        }
    }
}
