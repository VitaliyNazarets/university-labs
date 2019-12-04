using System;
using System.Collections.Generic;
using System.Reflection;

namespace ManageDatabase
{

	public class ConsoleInterface
	{
		private readonly DatabaseWorker DatabaseWorker;
		public ConsoleInterface()
		{
			DatabaseWorker = new DatabaseWorker();
		}
		public bool Run(string stringcommand)
		{
			try
			{
				try
				{
					CommandsEnum command = ParserCommand.ParseMainCommand(stringcommand);
					if (command == CommandsEnum.Stop)
						return false;
					if (command == CommandsEnum.Create)
						DatabaseWorker.Create(ParserCommand.ParseData(stringcommand));
					else if (command == CommandsEnum.Exit)
						DatabaseWorker.Exit();
					else if (command == CommandsEnum.Delete)
						DatabaseWorker.Delete(ParserCommand.ParseData(stringcommand));
					else if (command == CommandsEnum.Edit)
					{
						DatabaseWorker.Edit(ParserCommand.ParseData(stringcommand), ParserCommand.ParseNewData(stringcommand));
					}
					else if (command == CommandsEnum.Select)
						DatabaseWorker.Select(ParserCommand.ParseData(stringcommand));
					else if (command == CommandsEnum.Save)
						DatabaseWorker.Save();
					else if (command == CommandsEnum.Difference)
						DatabaseWorker.Difference(ParserCommand.ParseData(stringcommand), ParserCommand.ParseNewData(stringcommand));
					if (command == CommandsEnum.GetData)
						DatabaseWorker.GetData();
					else 
						DatabaseWorker.GetData();
				}
				catch (TargetInvocationException tie)
				{
					throw tie.InnerException;
				}
			}
			catch (NotEqualsColumnsException)
			{
				ConsoleWriter.Write("Can't get difference between tables, becouse tables columns aren't equals");
			}
			catch (MethodAccessException)
			{
				ConsoleWriter.Write("Method cannot be called in this level in");
			}
			catch (InvalidOperationException)
			{
				ConsoleWriter.Write("Invalid operation");
			}
			catch (ArgumentException)
			{
				ConsoleWriter.Write("Invalid argument");
			}
			catch (KeyNotFoundException)
			{
				ConsoleWriter.Write("Object not found");
			}
			catch (RepetableNameException)
			{
				ConsoleWriter.Write("Repetable name");
			}
			catch (System.Exception e)
			{
				ConsoleWriter.Write("Unexpected error");
			}

			return true;
		}
	}

}
