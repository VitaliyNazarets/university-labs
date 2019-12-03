using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

	public class ServiceChat : IServiceChat
	{
		ICollection<User> serverUsers;
		int nextId;
		public ServiceChat()
		{
			serverUsers = new List<User>();
			nextId = 1;
		}
		public int Connect(string name)
		{
			User user = new User(nextId, name, OperationContext.Current);
			nextId++;
			SendMsg(": " + user.Name + " connect to chat!", 0);
			serverUsers.Add(user);
			return user.ID;
		}

		public void Disconnect(int id)
		{
			if (FindUser(id, out User user))
			{
				serverUsers.Remove(user);
				SendMsg(": " + user.Name + " disconnect from chat!", 0);
			}
		}

		public bool FindUser(int id, out User user)
		{
			user = serverUsers.FirstOrDefault(f => f.ID.Equals(id));
			if (user == null)
				return false;
			return true;
		}

		public void SendMsg(string message, int id)
		{
			if (message.StartsWith("/w "))
			{
				var SubMessage = message.Substring("/w ".Length);
				var userFirst = serverUsers.Where(f => SubMessage.StartsWith(f.Name)).FirstOrDefault();
				if (userFirst != null)
				{
					string answer = DateTime.Now.ToShortTimeString() + " private message ";
					if (FindUser(id, out User userById))
						answer += "from " + userById.Name + " : ";
					answer += SubMessage.Substring(userFirst.Name.Length + 1);
					userFirst.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallBack(answer);
				}

			}
			else
			{
				foreach (var user in serverUsers)
				{
					string answer = DateTime.Now.ToShortTimeString();
					if (FindUser(id, out User userById))
					{
						answer += ": " + userById.Name + " : ";
					}
					answer += message;
					user.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallBack(answer);
				}
			}
		}
	}
}
