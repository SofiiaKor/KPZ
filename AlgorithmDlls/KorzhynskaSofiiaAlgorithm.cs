using System.Collections.Generic;
using System.Linq;
using Robot.Common;

namespace KorzhynskaSofiia.RobotChallange
{
	public class KorzhynskaSofiiaAlgorithm : IRobotAlgorithm
	{
		public string Author => "Korzhynska Sofiia";

		public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
		{
			var movingRobot = robots[robotToMoveIndex];
			if (movingRobot.Energy > 500 && robots.Count < map.Stations.Count)
			{
				return new CreateNewRobotCommand();
			}

			var stationPosition = FindNearestFreeStation(robots[robotToMoveIndex], map, robots);

			if (stationPosition == null)
				return null;
			if (stationPosition == movingRobot.Position)
				return new CollectEnergyCommand();

			return new MoveCommand() { NewPosition = stationPosition };
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
