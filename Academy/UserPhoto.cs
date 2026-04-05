using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public partial class UserPhoto : UserControl
	{
		public UserPhoto(string column_name, string path_photo = "")
		{
			InitializeComponent();
			textBoxNameColumn.Text = column_name;
			if(path_photo != "")pictureBox.Image = Image.FromFile(path_photo);
		}

		private void textBoxNameColumn_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
