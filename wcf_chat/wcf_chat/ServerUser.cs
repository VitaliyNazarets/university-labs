using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace wcf_chat
{
	public class User
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public OperationContext operationContext { get; set; }
		public User()
		{

		}
		public User(int _ID, string _Name, OperationContext _operationContext)
		{
			ID = _ID;
			Name = _Name;
			operationContext = _operationContext;
		}
	}
}
