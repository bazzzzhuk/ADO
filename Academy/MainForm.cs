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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using DBtools;

namespace Academy
{
	public partial class MainForm : Form
	{
		Query[] queries =
		{
			new Query
				(
				"last_name,first_name,middle_name,group_name,birth_date,direction_name",
				"Students, Groups, Directions",
				"[group]=group_id AND direction=direction_id"
				),
			new Query
				(
				"*",
				"Groups,Directions",
				"direction=direction_id"
				),
			new Query("*","Directions"),
			new Query("*","Disciplines"),
			new Query("*","Teachers")
		};
		string[] status_messges =
		{
			"Количество студентов",
			"Количество групп",
			"Количество направлений",
			"Количество дисциплин",
			"Количество преподавателей"
		};
		DataGridView[] tables;

		DBtools.Connector connector;
		/// //////////
		Dictionary<string, int> d_directions;
		Dictionary<string, int> d_groups;
		public MainForm()
		{
			InitializeComponent();
			tables = new DataGridView[] { dgvStudents, dgvGroups, dgvDirections, dgvDisciplines, dgvTeachers };
			connector = new DBtools.Connector(ConfigurationManager.ConnectionStrings["PV_521_Import"].ConnectionString);
			//dgvDirections.DataSource = connector.Select("*", "Directions");
			//toolStripStatusLabel.Text = $"Количество направлений обучения: {dgvDirections.Rows.Count - 1}";
			//toolStripStatusLabel.Text = $"Количество направлений обучения: {connector.Scalar("SELECT COUNT(*) FROM Directions")}";
			tabControl_SelectedIndexChanged(tabControl, null);
			d_directions = connector.GetDictionary("Directions");
			d_groups = connector.GetDictionary("Groups");

			cbStudentsGroup.Items.AddRange(d_groups.Keys.ToArray());
			cbGroupsDirection.Items.AddRange(d_directions.Keys.ToArray());
			cbStudentsDirection.Items.AddRange(d_directions.Keys.ToArray());
			//DataSet, SqlDataAdapter.
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			int i = tabControl.SelectedIndex;
			tables[tabControl.SelectedIndex].DataSource = connector.Select(queries[i].ToString());
			toolStripStatusLabel.Text = $"{status_messges[i]}: {tables[i].RowCount - 1}";
		}

		private void cbGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			dgvGroups.DataSource = connector.Select
				(
				queries[1].ToString() +
				$" AND direction={d_directions[cbGroupsDirection.SelectedItem.ToString()]}");
			toolStripStatusLabel.Text = $"{status_messges[1]}:{dgvGroups.RowCount - 1}";
		}

		private void cbStudentsDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			d_groups = connector.GetDictionary("Groups", $"direction ={d_directions[cbStudentsDirection.SelectedItem.ToString()]}");
			cbStudentsGroup.Items.Clear();
			cbStudentsGroup.Items.AddRange (d_groups.Keys.ToArray());
			dgvStudents.DataSource = connector.Select
				(
					queries[0].ToString()+
				$" AND direction={d_directions[cbStudentsDirection.SelectedItem.ToString()]}"
				);
			toolStripStatusLabel.Text = $"{status_messges[0]}:{dgvStudents.RowCount - 1}";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string name_tab = tables[tabControl.SelectedIndex].Name.Substring(3, tables[tabControl.SelectedIndex].Name.Length - 3).ToString();
			int count_tab = connector.scalarCount($"INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = \'{name_tab}\'");
			string fields = "";
			string nameColumn = "";
			for (int i = 1; i <= count_tab; i++)
			{
				nameColumn = connector.scalarNameTab(name_tab, i);
				fields += ",";
				fields += nameColumn;

			}
			fields = fields.Substring(1, fields.Length-1);
			//SELECT	MAX([date])	FROM Schedule WHERE [group]	=	@group_id)
			int count_id = Convert.ToInt32(connector.Scalar($"SELECT MAX({connector.scalarNameTab(name_tab,1)}) FROM {name_tab}"))+1;
			string values_tab = count_id.ToString()+",";
			for (int i = 2; i <= count_tab; i++)
			{
				nameColumn = connector.scalarNameTab(name_tab, i);
				try
				{
				values_tab += tables[tabControl.SelectedIndex].Rows[tables[tabControl.SelectedIndex].RowCount - 2].Cells[nameColumn].Value.ToString();
				}
				catch (Exception)
				{
					values_tab += "";
				}
				values_tab += ",";
			}
			values_tab = values_tab.Substring(0, values_tab.Length-1);


			//toolStripStatusLabel.Text = tables[tabControl.SelectedIndex].Rows[tables[tabControl.SelectedIndex].RowCount - 2].Cells["first_name"].Value.ToString();
			//toolStripStatusLabel.Text = dgvStudents.Columns[0].HeaderText.ToString();
			//toolStripStatusLabel.Text = dgvStudents.Columns.Count.ToString();
			//toolStripStatusLabel.Text = dgvDirections.Name.Substring(3, dgvDirections.Name.Length - 3).ToString();
			//toolStripStatusLabel.Text = tables[tabControl.SelectedIndex].Name.Substring(3, tables[tabControl.SelectedIndex].Name.Length - 3).ToString();
			//toolStripStatusLabel.Text = count_tab.ToString();
			//toolStripStatusLabel.Text = connector.scalarNameTab("Groups", 3);			
			//toolStripStatusLabel.Text = fields;
			//toolStripStatusLabel.Text = values_tab.ToString();

			string add_to_text = tables[tabControl.SelectedIndex].Name.Substring(3, tables[tabControl.SelectedIndex].Name.Length - 3).ToString();
			string add2 = add_to_text;
			Ref_out ref_Out = new Ref_out();
			Ref_out.ref_add = add2;
			;
			AddForm addForm = new AddForm();
			addForm.ShowDialog();
		}
		
	}
}
