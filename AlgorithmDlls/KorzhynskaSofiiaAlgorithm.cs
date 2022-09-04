using System;
using System.Collections.Generic;
using System.Linq;
using Robot.Common;

namespace KorzhynskaSofiia.RobotChallange
{
	public class KorzhynskaSofiiaAlgorithm : IRobotAlgorithm
	{
		public string Author => "Korzhynska Sofiia";

		public int RoundCount { get; set; }

		public KorzhynskaSofiiaAlgorithm()
		{
			Logger.OnLogRound += Logger_OnLogRound;
		}

		private void Logger_OnLogRound(object sender, LogRoundEventArgs e)
		{
			RoundCount++;
		}

		public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
		{
			var movingRobot = robots[robotToMoveIndex];
			if (movingRobot.Energy > 1000 && robots.Count < map.Stations.Count && RoundCount < 40)
			{
				return new CreateNewRobotCommand();
			}

			var robotPosition = movingRobot.Position;
			var station = map.GetNearbyResources(robotPosition, 30)[0];
			var i = 1;

			while (!IsStationFree(station, movingRobot, robots))
			{
				station = map.GetNearbyResources(robotPosition, 30)[i];
				i++;
			}

			if (station == null)
				return null;

			if ((Math.Abs(station.Position.X - robotPosition.X) <= 1 &&
				Math.Abs(station.Position.Y - robotPosition.Y) <= 1) && station.Energy > 10)
				return new CollectEnergyCommand();

			var directionX = Math.Sign(station.Position.X - robotPosition.X);
			var directionY = Math.Sign(station.Position.Y - robotPosition.Y);

			return RoundCount < 20 || movingRobot.Energy < 20
				? new MoveCommand() { NewPosition = new Position() { X = robotPosition.X + directionX, Y = robotPosition.Y + directionY } }
				: new MoveCommand() { NewPosition = new Position() { X = robotPosition.X + directionX + RoundCount / 10, Y = robotPosition.Y + directionY + RoundCount / 10 } };
		}

		public Position FindNearestFreeStation(Robot.Common.Robot movingRobot, Map map,
			IList<Robot.Common.Robot> robots)
		{
			EnergyStation nearest = null;
			var minDistance = int.MaxValue;
			foreach (var station in map.Stations)
			{
				if (!IsStationFree(station, movingRobot, robots)) continue;
				var d = DistanceHelper.FindDistance(station.Position, movingRobot.Position);
				if (d >= minDistance) continue;
				minDistance = d;
				nearest = station;
			}
			return nearest?.Position;
		}
		public bool IsStationFree(EnergyStation station, Robot.Common.Robot movingRobot,
			IList<Robot.Common.Robot> robots)
		{
			return IsCellFree(station.Position, movingRobot, robots);
		}
		public bool IsCellFree(Position cell, Robot.Common.Robot movingRobot, IList<Robot.Common.Robot> robots)
		{
			return robots.Where(robot => robot != movingRobot).All(robot => robot.Position != cell);
		}

	}
}
