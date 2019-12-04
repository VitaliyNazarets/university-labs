using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManageDatabase
{
	public static class ConsoleAdditionalInterface
	{
		public static bool ColumnRun(string command, out Column column)
		{
			column = null;
			try
			{
				if (command.Trim().ToLower().Equals("end"))
					return false;
				column = ParserColumns.ParseColumn(command);
			}
			catch (InvalidOperationException)
			{
				ConsoleWriter.Write("Invalid operation");
			}
			catch (ArgumentException)
			{
				ConsoleWriter.Write("Invalid argument");
			}
			catch (NotSupportedTypeException)
			{
				ConsoleWriter.Write("Not supported type");
			}
			catch (Exception)
			{
				ConsoleWriter.Write("Unexpected error");
			}
			return true;
		}

		public static bool RowRun(string command, Column column, out string data)
		{
			data = "";
			try
			{
				data = ParserRowData.ParseRowData(command, column);
				return true;
			}
			catch (InvalidOperationException)
			{
				ConsoleWriter.Write("Invalid operation");
			}
			catch (ArgumentException)
			{
				ConsoleWriter.Write("Invalid argument");
			}
			catch (NotSupportedTypeException)
			{
				ConsoleWriter.Write("Not supported type");
			}
			catch (Exception)
			{
				ConsoleWriter.Write("Unexpected error");
			}
			return false;
		}
	}

	public static class CreateSpecific
	{
		public static string Row(ICollection<Column> columns)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			ConsoleWriter.Write(new string('-', 25));
			ConsoleWriter.Write("Input row in table:");
			foreach (var column in columns)
			{

				if (column.ColumnType == ColumnType.ColorInvl)
					ConsoleWriter.Write("Input " + column.Name + " (type: " + Enum.GetName(typeof(ColumnType), column.ColumnType) + " min: " + column.Min + " max: " + column.Max +"):");
				else
					ConsoleWriter.Write("Input " +column.Name + " (type: " + Enum.GetName(typeof(ColumnType), column.ColumnType) + "):");
				
				
				string data;
				while (!ConsoleAdditionalInterface.RowRun(Console.ReadLine(), column, out data)) ;
				dictionary.Add(column.Name, data);
			}
			return JsonConvert.SerializeObject(dictionary);
		}
		public static List<Column> Columns()
		{
			var list = new List<Column>();
			ConsoleWriter.Write(new string('-', 25));
			ConsoleWriter.Write("Supported types: integer, real, char, string, color, colorinvl");
			ConsoleWriter.Write("Example: Name integer");
			ConsoleWriter.Write("Example2: MyColor colorInvl 5 10");
			ConsoleWriter.Write("Write \"end\" for stop");
			ConsoleWriter.Write(new string('-', 25));
			ConsoleWriter.Write("Input columns: ");
			bool Ok = true;
			while (Ok)
			{
				string Command = Console.ReadLine();
				Ok = ConsoleAdditionalInterface.ColumnRun(Command, out Column column);
				if (Ok && column != null)
				{
					if (list.Where(f => f.Name.Equals(column.Name)).Any())
					{
						ConsoleWriter.Write("Repetable name");
					}
					else
					{
						list.Add(column);
						ConsoleWriter.Write("Column added");
					}
				}
			}
			ConsoleWriter.Write(new string('-', 25));
			return list;
		}
	}
}
