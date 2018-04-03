using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BoxCalcTCPServer {
	class Program {
		static void Main(string[] args) {
			IPAddress ip = IPAddress.Parse("127.0.0.1");
			int port = 24680;
			TcpListener serverSocket = new TcpListener(ip, port);
			serverSocket.Start();

			while(true) {
				TcpClient client = serverSocket.AcceptTcpClient();
				Task.Factory.StartNew(() => ClientService.DoClient(client));
			}
		}


	}
}
