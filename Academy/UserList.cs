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
			string able = table.Substring(1, table.Length-1) + "s";
			string big_name_table = table.First().ToString().ToUpper()+able;
			//table.ToLower().Substring(0, table.Length - 1);
			//string small_name_table = table.ToLower().Substring(0, table.Length - 1);
			MessageBox.Show(table);
			InitializeComponent();
			textBoxNameColumn.Text = column_name;
			DataTable tab_data = DataBase.Connector.Select($"SELECT * FROM {big_name_table}");
			//cbGroup.DataSource = groups;
			this.cb.DataSource = tab_data;
			cb.DisplayMember = $"{table}_name";
			cb.ValueMember = $"{table}_id";
		}
	}
}
