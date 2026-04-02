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

namespace Academy
{
	public partial class UserStr : UserControl
	{
		DBtools.Connector connector;
		public UserStr(string s)
		{
			InitializeComponent();
			label1.Text = s;			
		}
	}
}
