using System;
using System.Collections.Generic;

namespace ManageDatabase
{
	class Program
	{
		static void Main(string[] args)
		{
			// build and run service host
			ConsoleWriter.Write("Commands: getdata, select, create, edit, delete, difference, exit, stop.");
			ConsoleWriter.Write("getdata/exit/stop using without parameters");
			ConsoleWriter.Write("create/select/delete use with parameter - name or id (for rows)");
			ConsoleWriter.Write("edit/difference use with 2 parameters: name or id (for rows)");
			ConsoleWriter.Write(new string('-', 25));
			ConsoleInterface consoleInterface = new ConsoleInterface();
			bool Ok = true;
			while (Ok)
			{
				string command = Console.ReadLine();
				Ok = consoleInterface.Run(command);
			}
			string str;
			do
			{
				ConsoleWriter.Write("Save changes? (yes/no)");
				str = Console.ReadLine();
			}
			while (!str.Equals("yes") && !str.Equals("no"));
			if (str.Equals("yes"))
				consoleInterface.Run("save");


		}
	}
}
