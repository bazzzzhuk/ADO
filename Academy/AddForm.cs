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
			labelTest.Location = new Point( 100, 100);
			connector = new DBtools.Connector(ConfigurationManager.ConnectionStrings["PV_521_Import"].ConnectionString);
			string name_tab = Ref_out.ref_add;
			this.Text += name_tab;
			int count_tab = connector.scalarCount($"INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = \'{name_tab}\'");
			//for (int i = 0; i < count_tab; i++)
			//{
				UserStr str = new UserStr();
			// = connector.scalarNameTab(name_tab, 1);
			str.Show();
			//}
		}

	}
}
