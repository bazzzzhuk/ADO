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
	public partial class StudentForm : HumanForm
	{
		internal Models.Student student;
		public StudentForm()
		{
			InitializeComponent();
			DataTable groups = DataBase.Connector.Select("SELECT * FROM Groups");
			//cbGroup.DataSource = groups;
			this.cbGroup.DataSource = groups;
			cbGroup.DisplayMember = "group_name";
			cbGroup.ValueMember = "group_id";

			tbLastName.Text = "Фамилия";
			tbFirstName.Text = "Имя";
			tbMiddleName.Text = "Отчество";
			dtp_BirthDate.Value = Convert.ToDateTime("2000-01-02");
			tbEmail.Text = "mbILo@dasha.ru";
			tbPhone.Text = "+7(911)123-45-67";

		}
		public StudentForm(int id):this()
		{
			DataTable data = DataBase.Connector.Select("*","Students",$"stud_id={id}");
			//object[] arr = data.Rows[0].;
			student = new Models.Student(data.Rows[0].ItemArray);
			human = student;
			Extract();
			cbGroup.SelectedValue = student.group;
		}
		protected override void buttonOK_Click(object sender, EventArgs e)
		{
			base.buttonOK_Click(sender, e);
			student = new Models.Student(human,Convert.ToInt32(cbGroup.SelectedValue));
			DataBase.Connector.Insert("Students", $"{student.GetNames()}", $"{student.GetValues()}");
			//DataBase.Connector.Insert
			//	(
			//	"Students",
			//	"last_name,first_name,middle_name,birth_date,email,phone,[group]",
			//	$"{tbLastName.Text},{tbFirstName.Text},{tbMiddleName.Text},{dtp_BirthDate.Value.ToString("yyyy-MM-dd")},{tbEmail.Text},{tbPhone.Text},{cbGroup.SelectedValue}"
			//	);
		}
	}
}
