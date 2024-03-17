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
	public partial class setting : Form
	{
        public SettingGame stG = new SettingGame();
		public setting(SettingGame settingGame)
		{
            stG = settingGame;
			InitializeComponent();
            //name
            txtName1.Text = stG.NamePL1;
            txtName2.Text = stG.NamePL2;
            //mode
            if (stG.mode == "PVP")
            {
                rbpvp.Checked = true;
                rbpve.Checked = false;
            }
            else
            {
                rbpvp.Checked = false;
                rbpve.Checked = true;
            }
            //level
            if (stG.level == "Eazy")
            {
                rbea.Checked = true;
                rbno.Checked = false;
                rbha.Checked = false;
            }
            else if(stG.level == "Normal")
            {
                rbea.Checked = false;
                rbno.Checked = true;
                rbha.Checked = false;
            }
            else
            {
                rbea.Checked = false;
                rbno.Checked = false;
                rbha.Checked = true;
            }
            //time
            if (stG.time == "3 minute")
            {
                rb3.Checked = true;
                rb5.Checked = false;
                rb10.Checked = false;
            }
            else if(stG.time == "5 minute")
            {
                rb3.Checked = false;
                rb5.Checked = true;
                rb10.Checked = false;
            }
            else
            {
                rb3.Checked = false;
                rb5.Checked = false;
                rb10.Checked = true;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            if (rbpvp.Checked)
            {
                stG.mode = "PVP";
            }
            else if(rbpve.Checked)
            {
                stG.mode = "PVE";
            }
            MessageBox.Show(stG.mode);
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            this.Hide();
            start s = new start(stG);
            s.ShowDialog();
            this.Show();
        }
    }
}
