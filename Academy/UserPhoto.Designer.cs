namespace Academy
{
	partial class UserPhoto
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.textBoxNameColumn = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox.Location = new System.Drawing.Point(179, 13);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(150, 172);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// textBoxNameColumn
			// 
			this.textBoxNameColumn.BackColor = System.Drawing.SystemColors.Menu;
			this.textBoxNameColumn.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxNameColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxNameColumn.Location = new System.Drawing.Point(3, 13);
			this.textBoxNameColumn.Name = "textBoxNameColumn";
			this.textBoxNameColumn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.textBoxNameColumn.Size = new System.Drawing.Size(165, 15);
			this.textBoxNameColumn.TabIndex = 3;
			this.textBoxNameColumn.TextChanged += new System.EventHandler(this.textBoxNameColumn_TextChanged);
			// 
			// UserPhoto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.textBoxNameColumn);
			this.Controls.Add(this.pictureBox);
			this.Name = "UserPhoto";
			this.Size = new System.Drawing.Size(531, 201);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.TextBox textBoxNameColumn;
	}
}
