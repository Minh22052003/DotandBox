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
        public start ST = new start();
		public setting(start st)
		{
            ST = st;
            stG = st.settingGame;
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
            if(stG.size == 3)
            {
                rb10.Checked = true;
                rb5.Checked = false;
                rb3.Checked = false;
            }else if(stG.size == 4)
            {
                rb10.Checked = false;
                rb5.Checked = false;
                rb3.Checked = true;
            }
            else
            {
                rb10.Checked = false;
                rb5.Checked = true;
                rb3.Checked = false;
            }
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            if (rbpvp.Checked)
            {
                ST.settingGame.mode = "PVP";
            }
            else if(rbpve.Checked)
            {
                ST.settingGame.mode = "PVE";
            }
        }
        public void updateMode()
        {
            if (rbpvp.Checked)
            {
                ST.settingGame.mode = "PVP";
            }
            else if (rbpve.Checked)
            {
                ST.settingGame.mode = "PVE";
            }
        }
        public void updateLevel()
        {
            if (rbea.Checked)
            {
                ST.settingGame.level = "Eazy";
            }
            else if (rbno.Checked)
            {
                ST.settingGame.level = "Normal";
            }
            else
            {
                ST.settingGame.level = "Hard";
            }
        }
        public void updateName()
        {
            ST.settingGame.NamePL1 = txtName1.Text;
            ST.settingGame.NamePL2 = txtName2.Text;
        }
        public void updateSize()
        {
            if (rb3.Checked)
            {
                ST.settingGame.size = 4;
            }
            else if (rb5.Checked)
            {
                ST.settingGame.size = 2;
            }
            else if (rb10.Checked)
            {
                ST.settingGame.size = 3;
            }
        }
        public void UpdateSetting()
        {
            updateLevel();
            updateMode();
            updateName();
            updateSize();
        }
        private void Apply_Click(object sender, EventArgs e)
        {
            UpdateSetting();
            ST.Show();
            this.Hide();
        }
    }
}
