using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBtools;

namespace Academy
{
	public partial class UserList : UserControl
	{
		public UserList(string column_name, string table)
		{
			InitializeComponent();
			textBoxNameColumn.Text = column_name;
			DataTable table_data = DataBase.Connector.Select($"SELECT * FROM {table}");
			//cbGroup.DataSource = groups;
			cb.DataSource = table_data;
		}
	}
}
