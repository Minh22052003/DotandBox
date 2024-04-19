namespace WindowsFormsApp2
{
	partial class main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.txtName1 = new System.Windows.Forms.Label();
            this.txtName2 = new System.Windows.Forms.Label();
            this.Score1 = new System.Windows.Forms.Label();
            this.Score2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.vbButton3 = new CustomButton.VBButton();
            this.vbButton2 = new CustomButton.VBButton();
            this.vbButton1 = new CustomButton.VBButton();
            this.SuspendLayout();
            // 
            // txtName1
            // 
            this.txtName1.AutoSize = true;
            this.txtName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtName1.Location = new System.Drawing.Point(191, 170);
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(126, 32);
            this.txtName1.TabIndex = 10;
            this.txtName1.Text = "Player 1:";
            // 
            // txtName2
            // 
            this.txtName2.AutoSize = true;
            this.txtName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName2.ForeColor = System.Drawing.Color.Red;
            this.txtName2.Location = new System.Drawing.Point(855, 170);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(126, 32);
            this.txtName2.TabIndex = 11;
            this.txtName2.Text = "Player 2:";
            // 
            // Score1
            // 
            this.Score1.AutoSize = true;
            this.Score1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Score1.Location = new System.Drawing.Point(323, 170);
            this.Score1.Name = "Score1";
            this.Score1.Size = new System.Drawing.Size(30, 32);
            this.Score1.TabIndex = 12;
            this.Score1.Text = "0";
            // 
            // Score2
            // 
            this.Score2.AutoSize = true;
            this.Score2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score2.ForeColor = System.Drawing.Color.Red;
            this.Score2.Location = new System.Drawing.Point(987, 170);
            this.Score2.Name = "Score2";
            this.Score2.Size = new System.Drawing.Size(30, 32);
            this.Score2.TabIndex = 13;
            this.Score2.Text = "0";
            // 
            // vbButton3
            // 
            this.vbButton3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.vbButton3.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.vbButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton3.BorderRadius = 20;
            this.vbButton3.BorderSize = 0;
            this.vbButton3.FlatAppearance.BorderSize = 0;
            this.vbButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vbButton3.ForeColor = System.Drawing.Color.White;
            this.vbButton3.Location = new System.Drawing.Point(714, 58);
            this.vbButton3.Name = "vbButton3";
            this.vbButton3.Size = new System.Drawing.Size(150, 53);
            this.vbButton3.TabIndex = 9;
            this.vbButton3.Text = "Exit";
            this.vbButton3.TextColor = System.Drawing.Color.White;
            this.vbButton3.UseVisualStyleBackColor = false;
            this.vbButton3.Click += new System.EventHandler(this.Click_Exit);
            // 
            // vbButton2
            // 
            this.vbButton2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.vbButton2.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.vbButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton2.BorderRadius = 20;
            this.vbButton2.BorderSize = 0;
            this.vbButton2.FlatAppearance.BorderSize = 0;
            this.vbButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vbButton2.ForeColor = System.Drawing.Color.White;
            this.vbButton2.Location = new System.Drawing.Point(506, 58);
            this.vbButton2.Name = "vbButton2";
            this.vbButton2.Size = new System.Drawing.Size(150, 54);
            this.vbButton2.TabIndex = 8;
            this.vbButton2.Text = "About";
            this.vbButton2.TextColor = System.Drawing.Color.White;
            this.vbButton2.UseVisualStyleBackColor = false;
            this.vbButton2.Click += new System.EventHandler(this.vbButton2_Click);
            // 
            // vbButton1
            // 
            this.vbButton1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.vbButton1.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.vbButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton1.BorderRadius = 20;
            this.vbButton1.BorderSize = 0;
            this.vbButton1.FlatAppearance.BorderSize = 0;
            this.vbButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vbButton1.ForeColor = System.Drawing.Color.White;
            this.vbButton1.Location = new System.Drawing.Point(296, 58);
            this.vbButton1.Name = "vbButton1";
            this.vbButton1.Size = new System.Drawing.Size(150, 53);
            this.vbButton1.TabIndex = 7;
            this.vbButton1.Text = "Play Again";
            this.vbButton1.TextColor = System.Drawing.Color.White;
            this.vbButton1.UseVisualStyleBackColor = false;
            this.vbButton1.Click += new System.EventHandler(this.vbButton1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 625);
            this.Controls.Add(this.Score2);
            this.Controls.Add(this.Score1);
            this.Controls.Add(this.txtName2);
            this.Controls.Add(this.txtName1);
            this.Controls.Add(this.vbButton3);
            this.Controls.Add(this.vbButton2);
            this.Controls.Add(this.vbButton1);
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private CustomButton.VBButton vbButton1;
		private CustomButton.VBButton vbButton2;
		private CustomButton.VBButton vbButton3;
		private System.Windows.Forms.Label txtName1;
		private System.Windows.Forms.Label txtName2;
		private System.Windows.Forms.Label Score1;
		private System.Windows.Forms.Label Score2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

