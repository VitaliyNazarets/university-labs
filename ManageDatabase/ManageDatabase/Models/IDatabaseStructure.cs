using System;
using System.Collections.Generic;
using System.Text;

namespace ManageDatabase
{
	public interface IDatabaseStructure
	{
		 void Create(string Name);
		 string GetData();
		void Edit(string data, string newdata);
		void Delete(string Name);
		 object Select(string Name);
	}
}
