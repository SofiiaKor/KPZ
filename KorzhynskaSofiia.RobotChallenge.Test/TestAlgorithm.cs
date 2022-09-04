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
		}

		[TestMethod]
		public void TestMoveCommand2()
		{
			var algorithm = new KorzhynskaSofiiaAlgorithm();
			var robots = new List<Robot.Common.Robot>()
				{new Robot.Common.Robot() {Energy = 200, Position = new Position(2, 3)}};
			var map = new Map();
			var stationPosition = new Position(3, 3);
			map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition, RecoveryRate = 2 });

			var command = algorithm.DoStep(robots, 0, map);

			Assert.IsFalse(command is MoveCommand);
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

		[TestMethod]
		public void TestCollectCommand2()
		{
			var algorithm = new KorzhynskaSofiiaAlgorithm();
			var robots = new List<Robot.Common.Robot>()
				{new Robot.Common.Robot() {Energy = 200, Position = new Position(1, 1)}};
			var map = new Map();
			var stationPosition = new Position(2, 1);
			map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition, RecoveryRate = 2 });

			var command = algorithm.DoStep(robots, 0, map);

			Assert.IsTrue(command is CollectEnergyCommand);
		}

		[TestMethod]
		public void TestCollectCommand3()
		{
			var algorithm = new KorzhynskaSofiiaAlgorithm();
			var robots = new List<Robot.Common.Robot>()
				{new Robot.Common.Robot() {Energy = 200, Position = new Position(1, 1)}};
			var map = new Map();
			var stationPosition = new Position(2, 2);
			map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition, RecoveryRate = 2 });

			var command = algorithm.DoStep(robots, 0, map);

			Assert.IsTrue(command is CollectEnergyCommand);
		}

		[TestMethod]
		public void TestCollectCommand4()
		{
			var algorithm = new KorzhynskaSofiiaAlgorithm();
			var robots = new List<Robot.Common.Robot>()
				{new Robot.Common.Robot() {Energy = 200, Position = new Position(1, 1)}};
			var map = new Map();
			var stationPosition = new Position(2, 3);
			map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition, RecoveryRate = 2 });

			var command = algorithm.DoStep(robots, 0, map);

			Assert.IsFalse(command is CollectEnergyCommand);
		}

		[TestMethod]
		public void TestCreateRobotCommand()
		{
			var algorithm = new KorzhynskaSofiiaAlgorithm();
			var robots = new List<Robot.Common.Robot>()
				{new Robot.Common.Robot() {Energy = 900, Position = new Position(1, 1)}};
			var map = new Map();
			var stationPosition = new Position(1, 1);
			map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition, RecoveryRate = 2 });

			var command = algorithm.DoStep(robots, 0, map);

			Assert.IsFalse(command is CreateNewRobotCommand);
		}

		[TestMethod]
		public void TestCreateRobotCommand2()
		{
			var algorithm = new KorzhynskaSofiiaAlgorithm();
			var robots = new List<Robot.Common.Robot>()
				{new Robot.Common.Robot() {Energy = 1100, Position = new Position(1, 1)}};
			var map = new Map();
			var stationPosition = new Position(1, 1);
			var stationPosition2 = new Position(7, 5);

			map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition, RecoveryRate = 2 });
			map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition2, RecoveryRate = 2 });

			var command = algorithm.DoStep(robots, 0, map);

			Assert.IsTrue(command is CreateNewRobotCommand);
		}
	}
}
