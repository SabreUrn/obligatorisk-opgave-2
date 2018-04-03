using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxCalculatorUser {
	class Program {
		private static ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

		static void Main(string[] args) {
			bool run = true;
			while (run) {
				Console.WriteLine("Choose option.");
				Console.WriteLine("1. Calculate volume");
				Console.WriteLine("2. Calculate side");
				Console.WriteLine("3. Exit");


				bool goodResponse = false;
				while (!goodResponse) {
					string response = Console.ReadLine();

					switch (response) {
						case "1":
							CalculateVolume();
							goodResponse = true;
							break;
						case "2":
							CalculateSide();
							goodResponse = true;
							break;
						case "3":
							run = false;
							goodResponse = true;
							break;
						default:
							Console.WriteLine("Invalid response. Input \"1\", \"2\", or \"3\".");
							break;
					}
				}
			}

			Console.WriteLine("Loop exited. Press any key to exit.");
			Console.ReadKey();
		}
		
		static void CalculateVolume() {
			Console.Write("Enter length: ");
			double length = Double.Parse(Console.ReadLine());

			Console.Write("Enter width: ");
			double width = Double.Parse(Console.ReadLine());

			Console.Write("Enter height: ");
			double height = Double.Parse(Console.ReadLine());

			Console.WriteLine("Volume is " + service.GetVolume(length, width, height));
		}

		static void CalculateSide() {
			Console.Write("Enter volume: ");
			double volume = Double.Parse(Console.ReadLine());

			Console.Write("Enter side 1: ");
			double side1 = Double.Parse(Console.ReadLine());

			Console.Write("Enter side 2: ");
			double side2 = Double.Parse(Console.ReadLine());

			Console.WriteLine("Side 3 is " + service.GetSide(volume, side1, side2));
		}
	}
}
