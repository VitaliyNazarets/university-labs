namespace ManageDatabase
{
	public static class ParserCommand
	{
		public static string ParseData(string command)
		{
			if (command.Length == 0)
				throw new System.ArgumentException();
			var values_array = command.Trim().ToLower().Split(' ');
			if (values_array.Length < 2)
				throw new System.ArgumentException();
			return values_array[1];
		}

		public static string ParseNewData(string command)
		{
			var values_array = command.Trim().ToLower().Split(' ');
			if (values_array.Length < 3)
				throw new System.ArgumentException();
			return values_array[2];
		}

		public static CommandsEnum ParseMainCommand(string command)
		{
			if (command.Length == 0)
				throw new System.ArgumentException();
			string value = command.Trim().Replace("  "," ").ToLower().Split(' ')[0];
			if (value.Equals("create"))
				return CommandsEnum.Create;
			if (value.Equals("delete"))
				return CommandsEnum.Delete;
			if (value.Equals("edit"))
				return CommandsEnum.Edit;
			if (value.Equals("select"))
				return CommandsEnum.Select;
			if (value.Equals("stop"))
				return CommandsEnum.Stop;
			if (value.Equals("exit"))
				return CommandsEnum.Exit;
			if (value.Equals("save"))
				return CommandsEnum.Save;
			if (value.Equals("getdata"))
				return CommandsEnum.GetData;
			if (value.Equals("difference"))
				return CommandsEnum.Difference;
			throw new System.InvalidOperationException();
		}
	}

}
