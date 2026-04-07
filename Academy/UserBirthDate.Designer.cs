namespace Academy
{
	partial class UserBirthDate
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
			this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// textBoxNameColumn
			// 
			this.textBoxNameColumn.BackColor = System.Drawing.SystemColors.Menu;
			this.textBoxNameColumn.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxNameColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxNameColumn.Location = new System.Drawing.Point(5, 7);
			this.textBoxNameColumn.Name = "textBoxNameColumn";
			this.textBoxNameColumn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.textBoxNameColumn.Size = new System.Drawing.Size(290, 15);
			this.textBoxNameColumn.TabIndex = 3;
			// 
			// dtpBirthDate
			// 
			this.dtpBirthDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpBirthDate.Location = new System.Drawing.Point(305, 4);
			this.dtpBirthDate.Name = "dtpBirthDate";
			this.dtpBirthDate.Size = new System.Drawing.Size(290, 22);
			this.dtpBirthDate.TabIndex = 4;
			// 
			// UserBirthDate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.dtpBirthDate);
			this.Controls.Add(this.textBoxNameColumn);
			this.Name = "UserBirthDate";
			this.Size = new System.Drawing.Size(600, 30);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxNameColumn;
		private System.Windows.Forms.DateTimePicker dtpBirthDate;
	}
}
