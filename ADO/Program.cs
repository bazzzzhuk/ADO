using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies_PV_521;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			
			//string cmd = "SELECT * FROM Directors";
			Connector connector = new Connector(connection_string);

			connector.Insert("INSERT Directors (first_name, last_name) VALUES (N'Guy', N'Richi');");
			Console.WriteLine($"Последний РК MAX:\t{connector.GetMaxPrimaryKey("Directors")}");
			//string cmd = "SELECT movie_id, title, release_date, first_name, last_name FROM Movies, Directors WHERE director = director_id";

			//connector.Select(cmd);
			connector.Select("*", "Directors");
			Console.WriteLine("──────────────────────────────────────────");
			connector.Select("SELECT * FROM Directors");
			Console.WriteLine($"Количество записей: {connector.Scalar("SELECT COUNT(*)FROM Directors")}");
			Console.WriteLine("──────────────────────────────────────────");

			connector.Select(
				"title,release_date,first_name,last_name",
				"Movies,Directors",
				"director=director_id");
			Console.WriteLine($"Количество записей: {connector.Scalar("SELECT COUNT(*)FROM Movies")}");

			//command.CommandText = "SELECT COUNT(*) FROM Movies";
			//Console.WriteLine($"Количество записей:\t{command.ExecuteScalar()}");
			//connection.Close();
			//---//


			//PrintHW.table(connection_string, cmd);
			//PrintHW.scalarCount(connection_string, "Movies");
		}
		
	}
}
