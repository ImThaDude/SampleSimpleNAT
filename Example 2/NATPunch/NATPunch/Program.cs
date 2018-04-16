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
			string ip = "127.0.0.1";
			//Port here.
			int port = 8080;
			
			UdpClient udpClient = new UdpClient();
			//Do not connect to the server because connecting to the server causes it to bind which does not let any other packets through.
			//udpClient.Connect(ip, port);
			//For p2p make sure the firewall is enabled to be able to talk to the ports. If firewall is disabled the application can easily receive the messages.
			//This is only true if it is localhost.
			//Need the application to allow the app through firewall for it to properly function. Maybe request for permission. Find a way
			IPEndPoint server = new IPEndPoint(IPAddress.Parse(ip), port);

			byte[] data = new byte[1024];
			IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

			Byte[] senddata = Encoding.ASCII.GetBytes("Hello World");
			while (true) {
				udpClient.Send (senddata, senddata.Length, server);
				Console.WriteLine ("Test");

				data = udpClient.Receive(ref sender);
				Console.WriteLine("Message received from {0}:", sender.ToString());
				Console.WriteLine (Encoding.ASCII.GetString(data, 0, data.Length));

				System.Threading.Thread.Sleep(1000);
			}
		}
	}
}
