using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LineConnectionApp
{
	public partial class test : Form
	{
		private List<Line> lines = new List<Line>();

		public test()
		{
			InitializeComponent();
			InitializeLines();
		}

		private void InitializeLines()
		{
			// Khởi tạo các đường nối
			int startX = 50; // Tọa độ x ban đầu
			int startY = 50; // Tọa độ y ban đầu
			int spacing = 100; // Khoảng cách giữa các điểm

			// Tạo các đường nối theo hàng
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Point point1 = new Point(startX + j * spacing, startY + i * spacing);
					Point point2 = new Point(startX + (j + 1) * spacing, startY + i * spacing);
					lines.Add(new Line(point1, point2));
				}
			}

			// Tạo các đường nối theo cột
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Point point1 = new Point(startX + i * spacing, startY + j * spacing);
					Point point2 = new Point(startX + i * spacing, startY + (j + 1) * spacing);
					lines.Add(new Line(point1, point2));
				}
			}

			// Gán sự kiện click cho từng đường nối
			foreach (var line in lines)
			{
				line.Click += (sender, args) =>
				{
					((Line)sender).ChangeColor(Color.Red);
					Invalidate(); // Cập nhật lại giao diện
				};
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// Vẽ các đường nối
			foreach (var line in lines)
			{
				// Vẽ đường nối
				Pen pen = new Pen(line.Color)
				{
					DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
				};
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
	}

	// Định nghĩa cấu trúc Line để lưu trữ thông tin về đường nối
	public class Line
	{
		public Point Point1 { get; private set; }
		public Point Point2 { get; private set; }
		public Color Color { get; private set; } = Color.Black;

		public Line(Point point1, Point point2)
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
			return distance < 5; // Giả sử 5 là bán kính của chấm tròn, bạn có thể điều chỉnh nó tùy thích
		}

		// Thay đổi màu của đường nối
		public void ChangeColor(Color color)
		{
			Color = color;
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
