using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using KorzhynskaSofiia.RobotChallange;
using Robot.Common;

namespace KorzhynskaSofiia.RobotChallenge.Test
{
	[TestClass]
	public class TestIsCellFree
	{
		[TestMethod]
		public void TestCell()
		{
			var test = new KorzhynskaSofiiaAlgorithm();
			var cell = new Position(5, 5);
			var movingRobot = new Robot.Common.Robot() { Position = new Position(10, 10) };
			var robots = new List<Robot.Common.Robot>()
				{new Robot.Common.Robot() {Energy = 200, Position = new Position(2, 3)}};

			Assert.IsTrue(test.IsCellFree(cell, movingRobot, robots));
		}

		[TestMethod]
		public void TestCell2()
		{
			var test = new KorzhynskaSofiiaAlgorithm();
			var cell = new Position(5, 5);
			var movingRobot = new Robot.Common.Robot() { Position = new Position(10, 10) };
			var robots = new List<Robot.Common.Robot>()
			{
				new Robot.Common.Robot() {Energy = 200, Position = new Position(2, 3)}, 
				new Robot.Common.Robot() {Energy = 200, Position = new Position(5, 5)}
			};

			Assert.IsFalse(test.IsCellFree(cell, movingRobot, robots));
		}
	}
}
