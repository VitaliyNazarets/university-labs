using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace ManageDatabase
{
	public static class FileWorker
	{
		private readonly static string fileUrl = "Data.txt";
		public static DBs GetDatabase()
		{
			if (!File.Exists(fileUrl))
			{ 
				var fs = File.Create(fileUrl);
				fs.Close();
				return new DBs();
			}
			StreamReader streamReader = new StreamReader(fileUrl);
			DBs dbs = JsonConvert.DeserializeObject<DBs>(streamReader.ReadToEnd());
			streamReader.Close();
			if (dbs == null)
				return new DBs();
			return dbs;
		}
		public static void SetDatabase(DBs databases)
		{
			string text = JsonConvert.SerializeObject(databases, Formatting.Indented);
			File.WriteAllText(fileUrl, text);
		}
	}
}
