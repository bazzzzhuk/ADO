namespace Academy
{
	partial class UserStr
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBoxNameColumn = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(305, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(290, 20);
			this.textBox1.TabIndex = 1;
			// 
			// textBoxNameColumn
			// 
			this.textBoxNameColumn.BackColor = System.Drawing.SystemColors.Menu;
			this.textBoxNameColumn.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxNameColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxNameColumn.Location = new System.Drawing.Point(5, 6);
			this.textBoxNameColumn.Name = "textBoxNameColumn";
			this.textBoxNameColumn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.textBoxNameColumn.Size = new System.Drawing.Size(290, 15);
			this.textBoxNameColumn.TabIndex = 2;
			this.textBoxNameColumn.TextChanged += new System.EventHandler(this.textBoxNameColumn_TextChanged);
			// 
			// UserStr
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.textBoxNameColumn);
			this.Controls.Add(this.textBox1);
			this.Name = "UserStr";
			this.Size = new System.Drawing.Size(600, 30);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBoxNameColumn;
	}
}
