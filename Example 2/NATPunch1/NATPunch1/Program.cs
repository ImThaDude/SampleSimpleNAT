using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NATPunch1
{
	class MainClass
	{

		//Natpuch 1 will try to infiltrate by asking for the port to be communicating and the ip to be sending to. This will simulate a cluent being able to talk to a UDP port over internet.

		public static void Main (string[] args)
		{
			Console.WriteLine ("What is the ip:");
			string ip = Console.ReadLine ();
			//Port here.
			Console.WriteLine("What is the port: ");
			int port = int.Parse(Console.ReadLine());

			UdpClient udpClient = new UdpClient();
			//udpClient.Connect(ip, port);
			IPEndPoint server = new IPEndPoint(IPAddress.Parse(ip), port);

			Byte[] senddata = Encoding.ASCII.GetBytes("Got Message from NatPunch1!");
			while (true) {
				udpClient.Send (senddata, senddata.Length, server);
				Console.WriteLine ("Sent Infiltration Message.");

				System.Threading.Thread.Sleep(1000);
			}
		}
	}
}
