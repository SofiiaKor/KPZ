using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KorzhynskaSofiia.RobotChallange;
using Robot.Common;

namespace KorzhynskaSofiia.RobotChallenge.Test
{
	[TestClass]
	public class TestDistanceHelper
	{
		[TestMethod]
		public void TestDistance()
		{
			var p1 = new Position(1, 1);
			var p2 = new Position(2, 4);

			Assert.AreEqual(10, DistanceHelper.FindDistance(p1, p2));
		}
	}
}
