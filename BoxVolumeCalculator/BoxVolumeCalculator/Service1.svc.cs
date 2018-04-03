using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BoxVolumeCalculator {
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IService1 {
		public double GetVolume(double length, double width, double height) {
			double volume = length * width * height;
			InsertData("BOX_VOL", volume, length, width, height);
			return volume;
		}

		public double GetSide(double volume, double side1, double side2) {
			double side3 = volume / (side1 * side2);
			InsertData("BOX_SIDE", volume, side1, side2, side3);
			return side3;
		}

		private void InsertData(string request, double volume,
		double length, double width, double height) {
			DateTime time = DateTime.Now;
			string connectionString = "Server=tcp:touchpoint-db-server.database.windows.net,1433;Initial Catalog=TouchpointDB;Persist Security Info=False;User ID=admeme;Password=aaaAAA111!!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			string cmdText = "INSERT INTO BoxCalc" +
				"( [Time], [Request], [Volume], [Length], [Width], [Height] )" +
				"VALUES (@Time, @Request, @Volume, @Length, @Width, @Height)";

			using (SqlConnection connection = new SqlConnection(connectionString)) {
				SqlCommand command = new SqlCommand(cmdText, connection);
				command.Parameters.AddWithValue("@Time", time);
				command.Parameters.AddWithValue("@Request", request);
				command.Parameters.AddWithValue("@Volume", volume);
				command.Parameters.AddWithValue("@Length", length);
				command.Parameters.AddWithValue("@Width", width);
				command.Parameters.AddWithValue("@Height", height);
				//command.Parameters.Add("@Time", SqlDbType.DateTime);
				//command.Parameters["@Time"].Value = time;
				//command.Parameters.Add("@Request", SqlDbType.NVarChar);
				//command.Parameters["@Request"].Value = request;
				//command.Parameters.Add("@Volume", SqlDbType.Float);
				//command.Parameters["@Volume"].Value = volume;
				//command.Parameters.Add("@Length", SqlDbType.Float);
				//command.Parameters["@Length"].Value = length;
				//command.Parameters.Add("@Height", SqlDbType.Float);
				//command.Parameters["@Height"].Value = height;
				//command.Parameters.Add("@Width", SqlDbType.Float);
				//command.Parameters["@Width"].Value = width;


				connection.Open();
				int rows = command.ExecuteNonQuery();
				connection.Close();
			}
		}

		/*
		public string GetData(int value) {
			return string.Format("You entered: {0}", value);
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite) {
			if (composite == null) {
				throw new ArgumentNullException("composite");
			}
			if (composite.BoolValue) {
				composite.StringValue += "Suffix";
			}
			return composite;
		}
		*/
	}
}
