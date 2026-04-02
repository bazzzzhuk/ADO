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

namespace Academy
{
	public partial class AddForm : Form
	{
		DBtools.Connector connector;
		public AddForm()
		{
			InitializeComponent();
			//labelTest.
			connector = new DBtools.Connector(ConfigurationManager.ConnectionStrings["PV_521_Import"].ConnectionString);
			string name_tab = Ref_out.ref_add;
			this.Text += name_tab;
			MainForm F = new MainForm();
			//int count_tab = connector.scalarCount($"INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = \'{name_tab}\'");
			labelTest.Text = connector.scalarNameTab(name_tab, 1);
		}

	}
}
