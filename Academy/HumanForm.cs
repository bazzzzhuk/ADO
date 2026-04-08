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

namespace Academy
{
	public partial class HumanForm : Form
	{
		//protected DBtools.Connector connector;
		protected HumanForm()
		{
			InitializeComponent();
			//connector = new DBtools.Connector(ConfigurationManager.ConnectionStrings["PV_521_Import"].ConnectionString);
		}

		protected virtual void buttonOK_Click(object sender, EventArgs e)
		{ 
		}
	}
}
