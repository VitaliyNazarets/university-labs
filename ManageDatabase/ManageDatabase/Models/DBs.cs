using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManageDatabase
{

	public class DBs : IDatabaseStructure 
	{
		//private static string name = "Databases: ";
		//public static string Name { get { return name; } }
		public ICollection<Database> Databases { get; set; }
		public void Create(string Name)
		{
			if (Databases.Where(f => f.Name.Equals(Name)).Any())
				throw new RepetableNameException();
			Databases.Add(new Database(Name));
		}

		public string GetData()
		{
			if (Databases.Count == 0)
				return "";
			return string.Join(",", Databases.Select(f => f.Name));
		}

		public object Select(string Name)
		{

			var objSelect  = Databases.Where(f => f.Name.Equals(Name)).FirstOrDefault();
			if (objSelect == null)
				throw new KeyNotFoundException();
			return objSelect;
		}

		public void Delete(string Name)
		{
			var objDelete = Databases.Where(f => f.Name.Equals(Name)).FirstOrDefault();
			if (objDelete == null)
				throw new KeyNotFoundException();
			Databases.Remove(objDelete);
		}

		public void Edit(string data, string newdata)
		{
			var objEdit = Databases.Where(f => f.Name.Equals(data)).FirstOrDefault();
			if (objEdit == null)
				throw new KeyNotFoundException();
			if (data.Equals(newdata))
				return;
			if (Databases.Where(f => f.Name.Equals(newdata)).Any())
				throw new RepetableNameException();
			objEdit.Name = newdata;
		}

		public DBs()
		{
			Databases = new List<Database>();
		}
	}
}
