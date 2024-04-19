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
		public SettingGame settingGame = new SettingGame();
		public start()
		{
			InitializeComponent();
		}
		public start(SettingGame settingGame)
		{
			this.settingGame = settingGame;
		}

		private void Click_Start(object sender, EventArgs e)
		{
			this.Hide();
			main m = new main(settingGame);
			m.ShowDialog();
			m = null;
			this.Show();
		}

		private void Click_Setting(object sender, EventArgs e)
		{
			setting st = new setting(this);
			this.Hide();
			st.ShowDialog();
			st = null;
		}

        private void Click_About(object sender, EventArgs e)
        {
            about ab = new about();
            ab.ShowDialog();
        }
    }
}
