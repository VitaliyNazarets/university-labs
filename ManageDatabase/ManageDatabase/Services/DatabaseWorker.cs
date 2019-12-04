using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ManageDatabase
{
	public class DatabaseWorker
	{
		private LevelIn LevelIn { get; set; }

		private MethodInfo GetMethod(object obj, string MethodName)
		{
			Type t = obj.GetType();
			MethodInfo method = t.GetMethod(MethodName);
			return method;
		}
		public DatabaseWorker()
		{
			LevelIn = new LevelIn(usingfile:true);
		}

		public void Difference(string Table1, string Table2)
		{
			object obj = LevelIn.GetLevel();
			if (obj.GetType() == typeof(Database))
			{
				var method = GetMethod(obj, "Difference");
				var Result = method.Invoke(obj, new object[] { Table1, Table2 });
				Console.WriteLine(Result);
			}
			else
				throw new MethodAccessException();
		}
		public void Create(string Name)
		{
			object obj = LevelIn.GetLevel();
			var method = GetMethod(obj, "Create");
			method.Invoke(obj, new object[] { Name });
		}
		public void Edit(string Data, string newdata)
		{
			object obj = LevelIn.GetLevel();
			var method = GetMethod(obj, "Edit");
			method.Invoke(obj, new object[] { Data, newdata });
		}
		public void GetData()
		{
			object obj = LevelIn.GetLevel();
			var method = GetMethod(obj, "GetData");
			var objectResult = method.Invoke(obj, null);
			//
			ConsoleWriter.Write((string)objectResult);
		}
		public void Save()
		{
			FileWorker.SetDatabase(LevelIn.GetDatabases());
		}
		public void Select(string Name)
		{
			object obj = LevelIn.GetLevel();
			var method = GetMethod(obj, "Select");
			var objectResult = method.Invoke(obj, new object[] { Name });
			LevelIn.LevelUp(objectResult);
		}
		public void Delete(string Name) //Need write
		{

			object obj = LevelIn.GetLevel();
			var method = GetMethod(obj, "Delete");
			method.Invoke(obj, new object[] { Name });
		}
		public void Exit()
		{
			LevelIn.LevelDown();
		}
	}
}
