using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBtools;

namespace Academy
{
	public partial class UserStr : UserControl
	{
		DBtools.Connector connector;
		public UserStr(string column_name, string column_values="")
		{
			InitializeComponent();
			//label1.Text = s;	
			textBoxNameColumn.Text = column_name;
			textBox1.Text = column_values;
		}

		private void textBoxNameColumn_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
