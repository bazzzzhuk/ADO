using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Configuration;
using DBtools;
using System.Collections.ObjectModel;

namespace AcademyWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Connector connector;
		DataGrid[] tables;
		Dictionary<string, int> d_directions;
		Dictionary<string, int> d_groups;

		public MainWindow()
		{
			InitializeComponent();
			connector = new Connector(ConfigurationManager.ConnectionStrings["PV_521_Import"].ConnectionString);
			tables = new DataGrid[] { dgvStudents, dgvGroups, dgvDirections, dgvDisciplines, dgvTeachers };
			tabControl.SelectedIndex = 0;
			d_directions = connector.GetDictionary("Directions");
			d_groups = connector.GetDictionary("Groups");

			foreach (var dict in d_groups)
				cb_StudentsGroups.Items.Add(dict.Key);
			foreach (var dict in d_directions)
				cb_StudentsDirections.Items.Add(dict.Key);
		}

		private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			cb_StudentsGroups.SelectedIndex = -1;
			cb_StudentsDirections.SelectedIndex = -1;
			int i = (sender as TabControl).SelectedIndex;
			tables[i].ItemsSource = connector.
				Select($"SELECT * FROM {((sender as TabControl).Items[i] as TabItem).Header.ToString()}").DefaultView;
			if(tabControl.SelectedIndex==1)cb_StudentsGroups.IsEnabled = false;
			if(tabControl.SelectedIndex==1)cb_StudentsGroups.Visibility = Visibility.Collapsed;
			StatusBarCount.Text = $"Количество записей: {tables[i].Items.Count - 1}";
		}

		private void cb_StudentsDirections_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string s = (tabControl.SelectedValue as TabItem).Header.ToString();
			string fields = "";
			string tables_select="";
			string where_select = "";

			//MessageBox.Show(s.ToString());
			switch (s)
			{
				case "Students":
					fields = "stud_id,last_name,first_name,middle_name,group_name,direction_name";
					tables_select = "Students, Groups, Directions";
					where_select = "[group]=group_id AND direction=direction_id";
					break;
				case "Groups":
					fields = "*";
					tables_select = "Groups,Directions";
					where_select= "direction=direction_id";
					break;
			}
			tables[tabControl.SelectedIndex].ItemsSource = connector.
				Select($"SELECT {fields} FROM {tables_select} WHERE {where_select} AND direction={cb_StudentsDirections.SelectedIndex + 1}").DefaultView;
		}
	}
}
