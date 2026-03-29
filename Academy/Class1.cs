using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Query
	{
		public string Fields { get; set; }
		public string Tables { get; set; }
		public string Condition { get; set; }
		public string Order { get; set; }
		public Query(string fields, string tables, string condition = "", string order = "") 
		{
			Fields = fields;
			Tables = tables;
			Condition = condition;
			Order = order;
		}
		public override string ToString()
		{
			string query = $"SELECT {Fields} FROM {Tables}";
			if (Condition != "") query += $" WHERE {Condition}";
			if (Order != "") query += $" ORDER BY {Order}";
			return query;
		}
	}
}
