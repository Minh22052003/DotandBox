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
	public partial class start : Form
	{
		public start()
		{
			InitializeComponent();
		}

		private void Click_Start(object sender, EventArgs e)
		{
			this.Hide();
			main m = new main();
			m.ShowDialog();
			m = null;
			this.Show();
		}

		private void Click_Setting(object sender, EventArgs e)
		{
			this.Hide();
			setting st = new setting();
			st.ShowDialog();
			st = null;
			this.Show();
		}
	}
}
