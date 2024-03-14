using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
	internal class Model
	{
		private bool boxes;
		public Model() 
		{
			this.boxes = true;
		}
		public bool GetBoxes()
		{
			return boxes;
		}
		public void SetBoxes(bool boxes)
		{
			this.boxes = boxes;
		}
	}
}
