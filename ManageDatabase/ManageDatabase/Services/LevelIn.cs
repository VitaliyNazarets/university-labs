using System.Collections.Generic;

namespace ManageDatabase
{
	public class LevelIn
	{
		private Database Database { get; set; }
		private Table Table { get; set; }
		private DBs Databases { get; set; }
		public LevelIn(bool usingfile = false)
		{
			if (usingfile)
				Databases = FileWorker.GetDatabase();
			else Databases = new DBs();
		}
		public DBs GetDatabases()
		{
			return Databases;
		}
		public void LevelUp(object obj)
		{
			if (obj.GetType().Name.Equals(typeof(Database).Name) && Database == null)
				Database = (Database)obj;
			else if (obj.GetType().Name.Equals(typeof(Table).Name) && Table == null)
				Table = (Table)obj;
		}
		public void LevelDown()
		{
			if (Table != null)
				Table = null;
			else if (Database != null)
				Database = null;
		}

		public LevelInEnum GetCurrentLevelEnum()
		{
			if (Table != null)
				return LevelInEnum.Table;
			if (Database != null)
				return LevelInEnum.Database;
			return LevelInEnum.Databases;
		}
		public object GetLevel()
		{
			if (Table != null)
				return Table;
			if (Database != null)
				return Database;
			return Databases;
		}
	}

}
