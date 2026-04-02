namespace Academy
{
	partial class AddForm
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
			this.labelTest = new System.Windows.Forms.Label();
			this.flp = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// labelTest
			// 
			this.labelTest.AutoSize = true;
			this.labelTest.Location = new System.Drawing.Point(29, 33);
			this.labelTest.Name = "labelTest";
			this.labelTest.Size = new System.Drawing.Size(0, 13);
			this.labelTest.TabIndex = 0;
			// 
			// flp
			// 
			this.flp.Location = new System.Drawing.Point(12, 12);
			this.flp.Name = "flp";
			this.flp.Size = new System.Drawing.Size(776, 426);
			this.flp.TabIndex = 1;
			// 
			// AddForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.flp);
			this.Controls.Add(this.labelTest);
			this.Name = "AddForm";
			this.Text = "Добавление ";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTest;
		private System.Windows.Forms.FlowLayoutPanel flp;
	}
}