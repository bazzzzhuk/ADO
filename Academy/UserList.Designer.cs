namespace Academy
{
	partial class UserList
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
			this.textBoxNameColumn = new System.Windows.Forms.TextBox();
			this.cb = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
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
			this.textBoxNameColumn.TabIndex = 3;
			// 
			// cb
			// 
			this.cb.FormattingEnabled = true;
			this.cb.Location = new System.Drawing.Point(305, 5);
			this.cb.Name = "cb";
			this.cb.Size = new System.Drawing.Size(290, 21);
			this.cb.TabIndex = 4;
			// 
			// UserList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cb);
			this.Controls.Add(this.textBoxNameColumn);
			this.Name = "UserList";
			this.Size = new System.Drawing.Size(600, 30);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxNameColumn;
		private System.Windows.Forms.ComboBox cb;
	}
}
