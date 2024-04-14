namespace WindowsFormsApp2
{
	partial class about
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(about));
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.vbButton2 = new CustomButton.VBButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::WindowsFormsApp2.Properties.Resources.blob;
			this.pictureBox2.Location = new System.Drawing.Point(66, 83);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(1050, 150);
			this.pictureBox2.TabIndex = 5;
			this.pictureBox2.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(149, 296);
			this.label2.Margin = new System.Windows.Forms.Padding(50);
			this.label2.MaximumSize = new System.Drawing.Size(900, 3000);
			this.label2.MinimumSize = new System.Drawing.Size(300, 300);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(10);
			this.label2.Size = new System.Drawing.Size(897, 317);
			this.label2.TabIndex = 7;
			this.label2.Text = resources.GetString("label2.Text");
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
			this.vbButton2.Location = new System.Drawing.Point(66, 12);
			this.vbButton2.Name = "vbButton2";
			this.vbButton2.Size = new System.Drawing.Size(150, 54);
			this.vbButton2.TabIndex = 9;
			this.vbButton2.Text = "Back";
			this.vbButton2.TextColor = System.Drawing.Color.White;
			this.vbButton2.UseVisualStyleBackColor = false;
			this.vbButton2.Click += new System.EventHandler(this.vbButton2_Click);
			// 
			// about
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSkyBlue;
			this.ClientSize = new System.Drawing.Size(1179, 695);
			this.Controls.Add(this.vbButton2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBox2);
			this.Name = "about";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "about";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label2;
		private CustomButton.VBButton vbButton2;
	}
}