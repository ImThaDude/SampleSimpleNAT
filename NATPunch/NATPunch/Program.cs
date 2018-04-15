using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NATPunch
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string ip = "server ip here";
			//Port here.
			int port = 8080;
			
			UdpClient udpClient = new UdpClient();
			udpClient.Connect(ip, port);

			byte[] data = new byte[1024];
			IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

			Byte[] senddata = Encoding.ASCII.GetBytes("Hello World");
			while (true) {
				udpClient.Send (senddata, senddata.Length);
				Console.WriteLine ("Test");

				data = udpClient.Receive(ref sender);
				Console.WriteLine("Message received from {0}:", sender.ToString());

				System.Threading.Thread.Sleep(1000);
			}
		}
	}
}
