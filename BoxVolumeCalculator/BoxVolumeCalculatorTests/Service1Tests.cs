using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxVolumeCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxVolumeCalculator.Tests {
	[TestClass()]
	public class Service1Tests {
		[TestMethod()]
		public void GetVolumeTest_NormalNumbers() {
			//arrange
			Service1 service = new Service1();
			double expected = 100.0;

			//act
			double actual = service.GetVolume(5, 5, 4);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void GetVolumeTest_OneZero() {
			//arrange
			Service1 service = new Service1();
			double expected = 0;

			//act
			double actual = service.GetVolume(5, 5, 0);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void GetSideTest_NormalNumbers() {
			//arrange
			Service1 service = new Service1();
			double expected = 3.0;

			//act
			double actual = service.GetSide(27, 3, 3);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void GetSideTest_VolumeZero() {
			//arrange
			Service1 service = new Service1();
			double expected = 0.0;

			//act
			double actual = service.GetSide(0, 3, 3);

			//assert
			Assert.AreEqual(expected, actual);
		}
	}
}