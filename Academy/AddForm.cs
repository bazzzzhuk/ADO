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
		DBtools.Connector connector;
		string name_tab = Ref_out.ref_add;
		int count_id;
		int count_tab;
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
			["group"] = "Группа",

			["group_name"] = "Наименование группы",
			["group_id"] = "ID группы",
			["direction"] = "Направление учёбы",
			["direction_id"] = "ID Направления",
			["direction_name"] = "Ниаменование Направления учёбы",
			["weekdays"] = "Схема обучения недели (Битно)",
			["discipline"] = "Дисциплина, номер",
			["discipline_id"] = "Дисциплина, ID",
			["discipline_name"] = "Наименование Дисциплины",
			["number_of_lessons"] = "Количество занятий",
			["teacher"] = "Номер преподавателя",
			["teacher_id"] = "ID преподавателя",
			["work_since"] = "Опыт с ",
			["rate"] = "Рейтинг",
			["start_time"] = "Начало заняти в",
			["start_date"] = "Дата начала занятий"
		};
		public AddForm()
		{
			UserStr UFlp_row;
			UserPhoto UPhoto;
			UserBirthDate UB_date;

			InitializeComponent();
			connector = new DBtools.Connector(ConfigurationManager.ConnectionStrings["PV_521_Import"].ConnectionString);
			//labelTest.Location = new Point(100, 100);
			count_id = Convert.ToInt32(connector.Scalar($"SELECT MAX({connector.scalarNameTab(name_tab, 1)}) FROM {name_tab}")) + 1;
			count_tab = connector.scalarCount($"INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = \'{name_tab}\'");
			this.Text += name_tab;
			for (int i = 1; i <= count_tab; i++)
			{
				string sc_name_tab = "";
				sc_name_tab = connector.scalarNameTab(name_tab, i);
				string values_name = "";
				if (i == 1) values_name = count_id.ToString();
				if (sc_name_tab == "photo")
				{
					UPhoto = new UserPhoto(connector.rename_column(sc_name_tab));
					UPhoto.Name = sc_name_tab;
					flp.Controls.Add(UPhoto);
				}
				else if (sc_name_tab == "birth_date" || sc_name_tab == "work_since" || sc_name_tab == "start_date")
				{
					UB_date = new UserBirthDate(connector.rename_column(sc_name_tab));
					flp.Controls.Add(UB_date);
				}
				else
				{
					UFlp_row = new UserStr(connector.rename_column(sc_name_tab), values_name);
					UFlp_row.Name = sc_name_tab;
					flp.Controls.Add(UFlp_row);
				}
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			MessageBox.Show(count_id.ToString());
			//MessageBox.Show($"{flp.Controls[0].Name.ToString()}:{flp.Controls[0].Controls[1].Text.ToString()}");
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
