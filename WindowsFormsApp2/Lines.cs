using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
	public class Lines
	{
		public Point Point1 { get; private set; }
		public Point Point2 { get; private set; }
		public Color Color { get; private set; } = Color.Black;
		public DashStyle dashStyle { get; private set; } = DashStyle.Dash;

		public bool Check { get; set; } = false;

		public Lines(Point point1, Point point2)
		{
			Point1 = point1;
			Point2 = point2;
		}

		// Thêm sự kiện click chuột cho đường nối
		public event EventHandler Click;

		protected virtual void OnClick()
		{
			Click?.Invoke(this, EventArgs.Empty);
		}

		// Xử lý sự kiện click chuột
		public void HandleClick(Point location)
		{
			if (IsClicked(location))
			{
				OnClick();
			}
		}

		// Kiểm tra xem một điểm có nằm trên đường nối hay không
		private bool IsClicked(Point point)
		{
			double distance = DistanceToPoint(Point1, Point2, point);
			return distance < 5;
		}

		// Thay đổi màu của đường nối
		public void ChangeColor(Color color)
		{
			Color = color;
		}
        public void ChangeDash(DashStyle ds)
        {
            dashStyle = ds;
        }

        // Tính khoảng cách từ một điểm đến một đoạn thẳng
        private double DistanceToPoint(Point lineStart, Point lineEnd, Point point)
		{
			double lineLength = Distance(lineStart, lineEnd);
			if (lineLength == 0) return Distance(point, lineStart);

			double u = ((point.X - lineStart.X) * (lineEnd.X - lineStart.X) +
						(point.Y - lineStart.Y) * (lineEnd.Y - lineStart.Y)) / Math.Pow(lineLength, 2);
			if (u < 0 || u > 1) // Kiểm tra xem điểm có nằm ngoài đoạn thẳng hay không
			{
				return Math.Min(Distance(point, lineStart), Distance(point, lineEnd));
			}
			else
			{
				Point intersection = new Point(
					Convert.ToInt32(lineStart.X + u * (lineEnd.X - lineStart.X)),
					Convert.ToInt32(lineStart.Y + u * (lineEnd.Y - lineStart.Y)));
				return Distance(point, intersection);
			}
		}

		// Tính khoảng cách giữa hai điểm
		private double Distance(Point p1, Point p2)
		{
			return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
		}
	}
}
