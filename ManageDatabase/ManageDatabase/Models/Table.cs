using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManageDatabase
{
	public class Table : IDatabaseStructure
	{
		public string Name { get; set; }
		public ICollection<Row> Rows { get; set; }
		public ICollection<Column> Columns { get; set; }

		public Table()
		{
			Rows = new List<Row>();
			Columns = new List<Column>();
		}
		public Table(string Name, ICollection<Column> columns)
		{
			this.Name = Name;
			Rows = new List<Row>();
			Columns = columns;
		}
		public Table(string Name)
		{
			this.Name = Name;
			Rows = new List<Row>();
			Columns = new List<Column>();
		}

		public void Create(string data)
		{
			Rows.Add(new Row(CreateSpecific.Row(Columns)));
		}

		public string GetData()
		{
			if (Columns.Count == 0)
				return "";
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat("{0,-20}", "id");
			foreach (var column in Columns)
				sb.AppendFormat("|{0,-20}", column.Name);
			if (Rows.Count == 0)
				return sb.ToString();
			sb.AppendLine();
			for (int i = 0; i < Rows.Count; ++i)
			{
				JObject jObject = JObject.Parse(Rows.ElementAt(i).Data);
				sb.AppendFormat("{0, -20}", i.ToString());
				foreach (var column in Columns)
				{
					sb.AppendFormat("|{0,-20}", jObject[column.Name].ToString());
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}

		public object Select(string Name)
		{
			throw new System.MethodAccessException();
		}

		public void Delete(string Name)
		{
			if (!int.TryParse(Name, out int id) || Rows.Count <= id)
				throw new System.ArgumentException();
			Rows.Remove(Rows.ElementAt(id));
		}

		public void Edit(string data, string newdata)
		{
			if (!int.TryParse(data, out int id) || Rows.Count <= id)
				throw new System.ArgumentException();
			var rowEdit = Rows.ElementAt(id);
			var RowData = CreateSpecific.Row(Columns);
			rowEdit.Data = RowData;
			//ДОПИСАТИ
		}
	}
}
