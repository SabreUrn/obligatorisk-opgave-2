using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BoxCalcTCPServer {
	public static class ClientService {
		private static ServiceReference1.Service1Client _service;

		public static void DoClient(TcpClient client) {
			using (NetworkStream ns = client.GetStream())
			using (StreamWriter sw = new StreamWriter(ns))
			using (StreamReader sr = new StreamReader(ns)) {
				sw.AutoFlush = true;
				 _service = new ServiceReference1.Service1Client();

				while (true) {
					string message = "";
					try {
						message = sr.ReadLine();
						sw.WriteLine(message);
					} catch (IOException) {
						Console.WriteLine("Client connection closed.");
					}
				}
			}
		}

		private static double InterpretProtocol(string message) {
			double value = -1.0;

			string protocol = message.Split(' ')[0];
			if(protocol == "BOX_VOL") {
				value = HandleVolume(message);
			} else if(protocol == "BOX_SIDE") {
				value = HandleSide(message);
			}

			return value;
		}

		private static double HandleVolume(string message) {
			string[] arguments = message.Split(' ');
			double length = Double.Parse(arguments[1]);
			double width = Double.Parse(arguments[2]);
			double height = Double.Parse(arguments[3]);

			return _service.GetVolume(length, width, height);
		}

		private static double HandleSide(string message) {
			string[] arguments = message.Split(' ');
			double volume = Double.Parse(arguments[1]);
			double side1 = Double.Parse(arguments[2]);
			double side2 = Double.Parse(arguments[3]);

			return _service.GetSide(volume, side1, side2);
		}
	}
}
