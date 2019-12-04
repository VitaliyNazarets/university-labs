using System;

namespace ManageDatabase
{
	public static class ParserRowData
	{
		public static string ParseRowData(string data, Column column)
		{
			var commandArray = data.Trim().ToLower().Split(' ');
			switch (column.ColumnType)
			{
				case ColumnType.Char:
					if (data.Length > 1)
						throw new ArgumentException();
					return data;
				case ColumnType.String:
					return data;
				case ColumnType.Integer:
					bool correct = int.TryParse(data, out int result);
					if (correct)
						return result.ToString();
					throw new ArgumentException();
				case ColumnType.Real:
					correct = double.TryParse(data, out double res);
					if (correct)
						return res.ToString();
					throw new ArgumentException();
				case ColumnType.Color:
					if (commandArray.Length < 3)
						throw new ArgumentException();
					if (!int.TryParse(commandArray[0], out int red) || red < 0 || red > 255 || !int.TryParse(commandArray[1], out int green) || green < 0 || green > 255 || !int.TryParse(commandArray[2], out int blue) || blue < 0 || blue > 255)
						throw new ArgumentException();
					return ("r: " + red.ToString() + " g: " + green.ToString() + " b: " + blue.ToString());
				case ColumnType.ColorInvl:
					if (commandArray.Length < 3)
						throw new ArgumentException();
					if (!int.TryParse(commandArray[0], out  red) || red < column.Min || red > column.Max || !int.TryParse(commandArray[1], out  green) || green < column.Min || green > column.Max || !int.TryParse(commandArray[2], out  blue) || blue < column.Min || blue > column.Max)
						throw new ArgumentException();
					return ("r: " + red.ToString() + " g: " + green.ToString() + " b: " + blue.ToString());
				default:
					throw new Exception();
			}
		}
	}
}
