using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManageDatabase
{
	public class Database : IDatabaseStructure
	{
		public string Name { get; set; }
		public ICollection<Table> Tables {get; set;}
		public Database()
		{
			Tables = new List<Table>();
		}
		public Database(string Name)
		{
			this.Name = Name;
			Tables = new List<Table>();
		}

		public string Difference(string Table1, string Table2)
		{
			var tableReduced = Tables.Where(f => f.Name == Table1).FirstOrDefault();
			var tableNegative = Tables.Where(f => f.Name == Table2).FirstOrDefault();
			if (tableReduced == null || tableNegative == null)
				throw new ArgumentException();
			return DifferenceTables(tableReduced, tableNegative);
		}
		public string DifferenceTables(Table tableReduced, Table tableNegative)
		{
			var tableReducerDict = tableReduced.Columns.ToDictionary(f => f.Name, f => f.ColumnType);
			var tableNegativeDict = tableNegative.Columns.ToDictionary(f => f.Name, f => f.ColumnType);
			foreach (var kvp in tableReducerDict)
			{
				if (tableNegativeDict.ContainsKey(kvp.Key) && tableNegativeDict[kvp.Key] == tableReducerDict[kvp.Key])
					tableNegativeDict.Remove(kvp.Key);
				else
					throw new NotEqualsColumnsException();
			}
			if (tableNegativeDict.Count() > 0)
				throw new NotEqualsColumnsException();
			Table temporarytable = new Table("", tableReduced.Columns);
			ICollection<Row> rowsNegative = tableNegative.Rows.ToList();
			foreach (var rowReduced in tableReduced.Rows)
			{
				//bool IsEquals = false;
				JObject jObjectReduced = JObject.Parse(rowReduced.Data);
				bool IsEquals = true;
				foreach (var rowNegative in rowsNegative.ToList())
				{
					IsEquals = true;
					JObject jObjectNegative = JObject.Parse(rowNegative.Data);
					foreach (var key in tableReducerDict.Keys)
					{
						if (!(jObjectReduced[key].ToString().Trim().Equals(jObjectNegative[key].ToString().Trim())))
						{
							IsEquals = false;
							break;
						}
					}
					if (IsEquals)
					{
						rowsNegative.Remove(rowNegative);
						break;
					}
				}
				if (!IsEquals)
				{
					temporarytable.Rows.Add(rowReduced);
				}
				
				//bool equals 
			}
			return temporarytable.GetData();
		}

		public void Create(string Name)
		{
			if (Tables.Where(f => f.Name.Equals(Name)).Any())
				throw new RepetableNameException();
			ICollection<Column> columns = CreateSpecific.Columns();
			Tables.Add(new Table(Name, columns));
		}

		public void Delete(string Name)
		{
			var objRemove = Tables.Where(f => f.Name.Equals(Name)).FirstOrDefault();
			if (objRemove == null)
				throw new KeyNotFoundException();
			Tables.Remove(objRemove);
		}

		public string GetData()
		{
			if (Tables.Count == 0)
				return "";
			return string.Join(",", Tables.Select(f => f.Name));
		}

		public object Select(string Name)
		{
			var objSelect = Tables.Where(f => f.Name.Equals(Name)).FirstOrDefault();
			if (objSelect == null)
				throw new KeyNotFoundException();
			return objSelect;
		}

		public void Edit(string data, string newdata)
		{
			var objSelect = Tables.Where(f => f.Name.Equals(data)).FirstOrDefault();
			if (objSelect == null)
				throw new KeyNotFoundException();
			if (data.Equals(newdata))
				return;
			if (Tables.Where(f => f.Name.Equals(newdata)).Any())
				throw new RepetableNameException();
			objSelect.Name = newdata;
		}


	}
}
