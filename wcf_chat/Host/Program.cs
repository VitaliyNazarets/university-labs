﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Host
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var host = new ServiceHost(typeof(wcf_chat.ServiceChat)))
			{
				host.Open();
				Console.WriteLine("Host started");
				Console.ReadLine();	
			}
		}
	}
}
