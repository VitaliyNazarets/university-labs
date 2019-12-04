using System;

namespace ManageDatabase
{
	public static class ParserColumns
	{
		public static Column ParseColumn(string command)
		{
			ColumnType columnType = ParserColumns.ParseColumnType(command);
			if (columnType == ColumnType.ColorInvl)
				return new Column(ParseName(command), columnType, ParseMin(command), ParseMax(command));
			else
				return new Column(ParseName(command), columnType);
		}
		public static string ParseName(string command)
		{
			if (command.Length == 0)
				throw new InvalidOperationException();
			return command.Trim().Split(' ')[0];
		}
		public static ColumnType ParseColumnType(string command)
		{
			var commandArray = command.Trim().ToLower().Split(' ');
			if (commandArray.Length < 2)
				throw new ArgumentException();
			string columnType = commandArray[1];
			if (columnType.Equals("integer"))
				return ColumnType.Integer;
			if (columnType.Equals("real"))
				return ColumnType.Real;
			if (columnType.Equals("string"))
				return ColumnType.String;
			if (columnType.Equals("color"))
				return ColumnType.Color;
			if (columnType.Equals("colorinvl"))
				return ColumnType.ColorInvl;
			if (columnType.Equals("char"))
				return ColumnType.Char;
			throw new NotSupportedTypeException();
		}
		public static int ParseMin(string command)
		{
			var commandArray = command.Trim().ToLower().Split(' ');
			if (commandArray.Length < 3)
				throw new ArgumentException();
			if (!int.TryParse(commandArray[2], out int min))
				throw new ArgumentException();
			return min;
		}
		public static int ParseMax(string command)
		{
			var commandArray = command.Trim().ToLower().Split(' ');
			if (commandArray.Length < 4)
				throw new ArgumentException();
			if (!int.TryParse(commandArray[3], out int max))
				throw new ArgumentException();
			return max;
		}
	}
}
