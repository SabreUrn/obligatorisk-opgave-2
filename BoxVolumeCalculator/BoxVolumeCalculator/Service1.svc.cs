using System;
using System.Collections.Generic;
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
			return length * width * height;
		}

		public double GetSide(double volume, double side1, double side2) {
			return volume / (side1 * side2);
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
