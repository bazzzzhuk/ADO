using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace ADO
{
	internal class Connector
	{

		string connection_string;
		SqlConnection connection;

		public Connector(string connection_string)
		{
			Console.WriteLine(connection_string);
			this.connection_string = connection_string;
			connection = new SqlConnection(connection_string);
		}

		public void Select(string cmd)
		{
			connection.Open();
			SqlCommand command = new SqlCommand(cmd, connection);

			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				Console.Write(reader.GetName(i) + "\t");
			}
			Console.WriteLine();
			Console.WriteLine("──────────────────────────────────────────");
			while (reader.Read())
			{
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}");
				for (int i = 0; i < reader.FieldCount; i++)
					Console.Write($"{reader[i]}\t\t");
				Console.WriteLine();
			}
			Console.WriteLine("──────────────────────────────────────────");
			reader.Close();
			connection.Close();
		}
		public void Select(string fields, string tables, string condition = "")
		{
			string cmd = $"SELECT {fields} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
			cmd += ";";
			Select(cmd);
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
		public string GetFieldName(string table, int field_num = 0)
		{
			string cmd = $"SELECT * FROM {table}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			string pk_name = reader.GetName(field_num);
			reader.Close();
			connection.Close();
			return pk_name;
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
		public bool CheckNotExists(string table, string values)
		{
			string[] inValues = values.Split(',', ' ');
			string cmd = $"SELECT {GetFieldName(table)} FROM {table} ";
			if (inValues.Length > 1) cmd += $" WHERE {GetFieldName(table, 1)} = N'{inValues[0]}'";
			for (int i = 1; i < inValues.Length; i++)cmd += $" AND {GetFieldName(table, i + 1)} = N'{inValues[i]}'";
			return (Scalar(cmd) == null ? false : true);
		}
		public void Insert(string table, string values = "")
		{
			if (CheckNotExists(table, values))
			{
				Console.WriteLine($"Такие данные ({values}) есть в таблице {table}!!!");
				return; 
			}
			string fields = GetFieldName(table, 0);
			string values_insert = Convert.ToString(GetNextPrimaryKey(table));
			string[] inValues = values.Split(',', ' ');
			for (int i = 1; i < inValues.Length + 1; i++) fields += "," + GetFieldName(table, i);
			for (int i = 0; i < inValues.Length; i++) values_insert += $",N'{inValues[i]}'";
			string cmd = $"INSERT {table} ({fields}) VALUES ({values_insert});";
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

