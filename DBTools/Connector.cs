using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using System.Windows.



namespace DBtools
{
	public class Connector
	{

		string connection_string;
		SqlConnection connection;

		Dictionary<string, string> column_rename = new Dictionary<string, string>
			{
				["stud_id"] = "Инд.номер",
				["first_name"] = "Имя",
				["last_name"] = "Фамилия",
				["middle_name"] = "Отчество",
				["birth_date"] = "Дата Рождения",
				["photo"] = "Фото",
				["email"] = "Эл.почта",
				["phone"] = "Телефон",
				["group"] = "Группа"
			};

	public Connector(string connection_string)
		{
			//Console.WriteLine(connection_string);
			this.connection_string = connection_string;
			connection = new SqlConnection(connection_string);
		}

		public DataTable Select(string cmd)
		{
			DataTable table = new DataTable();
			connection.Open();
			SqlCommand command = new SqlCommand(cmd, connection);

			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				Console.Write(reader.GetName(i) + "\t");
				table.Columns.Add(reader.GetName(i));
			}
			Console.WriteLine();
			while (reader.Read())
			{
				DataRow	row = table.NewRow();
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}");
				for (int i = 0; i < reader.FieldCount; i++)
				{
					row[i] = reader[i];
					Console.Write($"{reader[i]}\t\t");
				}
				Console.WriteLine();
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			return table;
		}
		public DataTable Select(string fields, string tables, string condition = "")
		{
			string cmd = $"SELECT {fields} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
			cmd += ";";
			return Select(cmd);
		}

		public int scalarCount(string cmd)
		{
			connection.Open();
			SqlCommand command = new SqlCommand();
			command.CommandText = $"SELECT COUNT(*) FROM " + cmd;
			command.Connection = connection;
			//Console.WriteLine();
			//Console.WriteLine($"Количество записей:\t{command.ExecuteScalar()}");
			int c = (int)command.ExecuteScalar();
			connection.Close();
			return c;		
		}
		public string scalarNameTab(string cmd, int i)
		{
			connection.Open();
			SqlCommand command = new SqlCommand();
			command.CommandText = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{cmd}' AND COLUMNS.ORDINAL_POSITION = {i}";
			command.Connection = connection;
			//Console.WriteLine();
			//Console.WriteLine($"Количество записей:\t{command.ExecuteScalar()}");
			string c = (String)command.ExecuteScalar();
			connection.Close();
			return c;		
		}

		public string rename_column(string name)
		{
			//if(column_rename.ContainsKey(str))
			//	return column_rename[str];
			//else return str;
			
			//string s = this.ToString();
			return column_rename[name];
		}
		public void Insert(string tables, string fields, string values)
		{
			connection.Open();
			string cmd = $"INSERT {tables} ({fields}) VALUES ({values})";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Close();
		}
		public Dictionary<string, int> GetDictionary(string table, string condition="")
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			string cmd = $"SELECT {table.Substring(0, table.Length - 1)}_name,{table.Substring(0, table.Length - 1)}_id FROM {table}";
			if (condition != "") cmd += $" WHERE {condition}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while(reader.Read())
			{
				dictionary.Add(reader[0].ToString(), Convert.ToInt32(reader[1]));
			}
			reader. Close();
			connection.Close();
			return dictionary;

		}
		public object Scalar(string cmd)
		{
			object result = null;
			connection.Open();

			SqlCommand command = new SqlCommand(cmd, connection);
			result = command.ExecuteScalar();

			connection.Close();
			return result;
		}
		public int GetMaxPrimaryKey(string table)
		{
			string cmd = $"SELECT * FROM {table}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			string pk_name = reader.GetName(0);
			reader.Close();
			connection.Close();
			return (int)Scalar($"SELECT MAX({pk_name}) FROM {table}");
		}
		public int GetNextPrimaryKey(string table)
		{
			return GetMaxPrimaryKey(table) + 1;
		}
		public string GetPrimaryKeyColumnName(string table)
		{
			string raw = @"RAW string"; //RAW-строка игнорирует переносы
			string cmd = $@"SELECT	INFORMATION_SCHEMA.KEY_COLUMN_USAGE.COLUMN_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE   TABLE_NAME = N'{table}'
AND CONSTRAINT_NAME LIKE N'PK_%'";
			return (string)Scalar(cmd);
		}
		public void Insert(string cmd)
		{
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			try
			{
				command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.GetType());
				Console.WriteLine(ex.Message);
				if (ex.GetType() == typeof(SqlException) && ex.Message.Contains("_id"))
				{
					Console.WriteLine("Good");
				}
			}
			connection.Close();
		}
	}
}

