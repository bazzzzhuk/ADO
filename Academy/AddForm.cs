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
using System.Configuration;

using System.Windows.Forms;

namespace Academy
{
	public partial class AddForm : Form
	{
		Dictionary<string, string> column_rename = new Dictionary<string, string>
		{
			["stud_id"] = "Инд.номер",
			["last_name"] = "Фамилия",
			["first_name"] = "Имя",
			["middle_name"] = "Отчество",
			["birth_date"] = "Дата Рождения",
			["email"] = "Эл.почта",
			["phone"] = "Телефон",
			["photo"] = "Фото",
			["group"] = "Группа"
		};
		DBtools.Connector connector;
		public AddForm()
		{

			InitializeComponent();
			labelTest.Location = new Point(100, 100);
			connector = new DBtools.Connector(ConfigurationManager.ConnectionStrings["PV_521_Import"].ConnectionString);
			string name_tab = Ref_out.ref_add;
			int count_id = Convert.ToInt32(connector.Scalar($"SELECT MAX({connector.scalarNameTab(name_tab, 1)}) FROM {name_tab}")) + 1;
			this.Text += name_tab;
			int count_tab = connector.scalarCount($"INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = \'{name_tab}\'");
			for (int i = 1; i <= count_tab; i++)
			{
				string values_name = "";
				if (i == 1) values_name = count_id.ToString();
				UserStr str = new UserStr(column_rename[connector.scalarNameTab(name_tab, i)], values_name);
				// = connector.scalarNameTab(name_tab, 1);
				flp.Controls.Add(str);
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			string name_tab = Ref_out.ref_add;
			//print_dict("stud_id");
			//string s = connector.scalarNameTab(name_tab, 0);
			//MessageBox.Show(connector.rename_column(connector.scalarNameTab(name_tab, 1)));
		}
		public void print_dict(string str/*Dictionary<string, string> ss*/)
		{
			//string str = "";
				//str += $"{key} = {ss[key]}\n";
			//MessageBox.Show(str);
			//string name_tab = Ref_out.ref_add;
			//int count_tab = connector.scalarCount($"INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = \'{name_tab}\'");

			//for (int i = 1; i <= count_tab; i++)
			//{
			//	str += connector.scalarNameTab(name_tab, i) + "\n";
			//}
			//MessageBox.Show(connector.rename_column(str));
		}
	}
}
