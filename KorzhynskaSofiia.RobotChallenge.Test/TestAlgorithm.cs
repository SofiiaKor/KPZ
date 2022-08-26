using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using KorzhynskaSofiia.RobotChallange;
using Robot.Common;

namespace KorzhynskaSofiia.RobotChallenge.Test
{
	[TestClass]
	public class TestAlgorithm
	{
		[TestMethod]
		public void TestMoveCommand()
		{
			var algorithm = new KorzhynskaSofiiaAlgorithm();
			var robots = new List<Robot.Common.Robot>()
				{new Robot.Common.Robot() {Energy = 200, Position = new Position(2, 3)}};
			var map = new Map();
			var stationPosition = new Position(1, 1);
			map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition, RecoveryRate = 2 });

			var command = algorithm.DoStep(robots, 0, map);

			Assert.IsTrue(command is MoveCommand);
			Assert.AreEqual(((MoveCommand)command).NewPosition, stationPosition);
		}

		[TestMethod]
		public void TestCollectCommand()
		{
			var algorithm = new KorzhynskaSofiiaAlgorithm();
			var robots = new List<Robot.Common.Robot>()
				{new Robot.Common.Robot() {Energy = 200, Position = new Position(1, 1)}};
			var map = new Map();
			var stationPosition = new Position(1, 1);
			map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition, RecoveryRate = 2 });

			var command = algorithm.DoStep(robots, 0, map);

			Assert.IsTrue(command is CollectEnergyCommand);
		}
	}
}
