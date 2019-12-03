using Client.ServiceChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, ServiceChat.IServiceChatCallback
	{
		bool isConnected = false;
		ServiceChatClient client;
		int clientId;
		public MainWindow()
		{
			InitializeComponent();
		}

		void ConnectUser()
		{
			if (!isConnected)
			{
				client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
				isConnected = true;
				clientId = client.Connect(tbUserName.Text);
				tbUserName.IsEnabled = false;
				bCD.Content = "Disconnect";
			}
		}
		void DisconnectUser()
		{
			if (isConnected)
			{
				client.Disconnect(clientId);
				client = null;
				isConnected = false;
				tbUserName.IsEnabled = true;
				bCD.Content = "Connect";
			}
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (isConnected)
			{
				DisconnectUser();
			}
			else
				ConnectUser();
		}

		public void MsgCallBack(string msg)
		{
			lbChat.Items.Add(msg);
			lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DisconnectUser();
		}

		private void tbMessage_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				if (client != null)
				{ 
					client.SendMsg(tbMessage.Text, clientId);
					tbMessage.Text = "";
				}
			}
		}

	}
}
