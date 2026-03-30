using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;


namespace Academy
{
	public partial class MainForm : Form
	{
		Query[] queries =
		{
			new Query
				(
				"last_name,first_name,middle_name,group_name,direction_name",
				"Students, Groups, Directions",
				"[group]=group_id AND direction=direction_id",
				"last_name"
				),
			new Query
				(
				"*",
				"Groups,Directions",
				"direction=direction_id",
				"direction_id"
				),
			new Query("*","Directions"),
			new Query("*","Disciplines"),
			new Query("*","Teachers"),
			new Query("discipline_name,last_name",
				"Teachers,TeachersDisciplinesRelation, Disciplines",
				"teacher=teacher_id AND discipline=discipline_id",
				"discipline_name"
				)
		};
		string[] status_messages =
		{
			"Количество студентов",
			"Количество групп",
			"Количество направлений",
			"Количество дисциплин",
			"Количество преподавателей",
			"Количество преподавателей"
		};

		DataGridView[] tables;

		DBtools.Connector connector;
		public MainForm()
		{
			//int ii = (int)(filter_discipline_Teachers.GetLength(0));
			//tsi_arr = new ToolStripItem[ii];

			//for (int i = 0; i < ii; i++)
			//{
			//	Console.WriteLine(filter_discipline_Teachers[i, 0]);
			//	tsi_arr[i] = new ToolStripMenuItem($"{filter_discipline_Teachers[i, 1]}");
			//}

			InitializeComponent();
			InitTeachersDisciplinesFilter();

			tables = new DataGridView[] { dgvStudents, dgvGroups, dgvDirections, dgvDisciplines, dgvTeachers, dgvDisciplineTeachers };
			connector = new DBtools.Connector(ConfigurationManager.ConnectionStrings["PV_521_Import"].ConnectionString);
			//dgvDirections.DataSource = connector.Select("*", "Directions");
			//toolStripStatusLabel.Text = $"Количество направлений обучения: {dgvDirections.Rows.Count - 1}";
			//toolStripStatusLabel.Text = $"Количество направлений обучения: {connector.Scalar("SELECT COUNT(*) FROM Directions")}";
			tabControl_SelectedIndexChanged(tabControl, null);
		}

		private void InitTeachersDisciplinesFilter()
		{
			ToolStripItem[] tsi_arr;

			string[,] filter_discipline_Teachers =
			{
				{ "FIO", "ФИО" } ,
				{ "Disc", "Дисциплине" },
				{ "Disc", "Проверка" }
			};


			//this.toolStripStatusLabel1});
			//this.statusStrip1.Location = new System.Drawing.Point(0, 493);
			//this.statusStrip1.Name = "statusStrip1";
			//this.statusStrip1.Size = new System.Drawing.Size(800, 22);
			//this.statusStrip1.TabIndex = 2;
			//this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripFilters
			// 

			int ii = (int)(filter_discipline_Teachers.GetLength(0));
			tsi_arr = new ToolStripItem[ii];
			for (int i = 0; i < ii; i++)
			{
				Console.WriteLine(filter_discipline_Teachers[i, 0]);
				tsi_arr[i] = new ToolStripMenuItem($"{filter_discipline_Teachers[i, 0]}", null, null, $"{filter_discipline_Teachers[i, 1]}");
			}
			this.toolStripFilters.DropDownItems.AddRange(tsi_arr);
			this.statusStrip1.Items.Add(this.toolStripFilters as ToolStripSplitButton);

			//Console.WriteLine($"Пункт 0? --> {tsi_arr[0]}");
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			int i = tabControl.SelectedIndex;
			tables[tabControl.SelectedIndex].DataSource = connector.Select(queries[i].ToString());
			toolStripStatusLabel.Text = $"{status_messages[i]}: {tables[i].RowCount - 1}";
			//toolStripFilters.DropDownItems.AddRange
		}

		private void toolStripFilters_ButtonClick(object sender, EventArgs e)
		{
			Console.WriteLine("!!!!!!");
		}


	}

}
