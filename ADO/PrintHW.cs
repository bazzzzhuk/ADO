using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
	internal class PrintHW
	{
		public static void table(string connection_string, string cmd)
		{
			SqlConnection connection = new SqlConnection(connection_string);
			connection.Open();
			SqlCommand command = new SqlCommand(cmd, connection);
			SqlDataReader reader2 = command.ExecuteReader();
			
			int[] cont = new int[reader2.FieldCount];
			while (reader2.Read())
			{
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}");
				for (int i = 0; i < reader2.FieldCount; i++)
				{
					if (reader2[i].ToString().Length > cont[i]) cont[i] = reader2[i].ToString().Length;
					//Console.WriteLine(cont[i]);
				}
			}
			reader2.Close();
			SqlDataReader reader3 = command.ExecuteReader();
			reader3.Read();
			for (int i = 0; i < reader3.FieldCount; i++)
			{
				Console.Write(reader3.GetName(i));
				for (int j = 0; j < ((cont[i]) / 8 - (reader3.GetName(i).ToString().Length) / 8 + 2); j++) Console.Write("\t");
			}
			reader3.Close();
			Console.WriteLine();
			int o = cont.Sum();
			for (int oo = 0; oo < (o-8)*2; oo++)Console.Write("─");
			Console.WriteLine();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}");
				for (int i = 0; i < reader.FieldCount; i++)
				{
					Console.Write($"{reader[i]}");
					for (int j = 0; j < ((cont[i])/8-(reader[i].ToString().Length)/8 +2); j++) Console.Write("\t");
				}
				Console.WriteLine();
			}
			reader.Close();
			connection.Close();
		for (int oo = 0; oo<(o-8)*2; oo++)Console.Write("─");
		}
		public static void scalarCount(string connection_string, string cmd)
		{
			SqlConnection connection = new SqlConnection(connection_string);
			connection.Open();
			SqlCommand command = new SqlCommand();
			command.CommandText = $"SELECT COUNT(*) FROM " + cmd;
			command.Connection = connection;
			Console.WriteLine();
			Console.WriteLine($"Количество записей:\t{command.ExecuteScalar()}");
			connection.Close();
		}
	}
}
