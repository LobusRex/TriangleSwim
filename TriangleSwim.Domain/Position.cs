namespace TriangleSwim.Domain
{
	public class Position
	{
		public double X { get; private set; }
		public double Y { get; private set; }

		public Position(double x, double y)
		{
			X = x;
			Y = y;
		}

		public void MoveTowards(Position target, Distance maxTravelDistance)
		{
			Angle angle = Angle.BetweenPoints(this, target);

			Distance travelDistance = Distance.Shortest(DistanceTo(target), maxTravelDistance);

			// TODO: Use MoveTo instead.
			Position movement = travelDistance.AtAngle(angle);

			X += movement.X;
			Y += movement.Y;
		}

		public Position MovedTo(Angle angle, Distance distance)
		{
			Position movement = distance.AtAngle(angle);

			return new Position(
				X + movement.X,
				Y + movement.Y);
		}

		public Distance DistanceTo(Position other)
		{
			double xDelta = other.X - X;
			double yDelta = other.Y - Y;

			return new Distance(Math.Sqrt(yDelta * yDelta + xDelta * xDelta));
		}

		public static Position BetweenTwoPositions(Position firstPosition, Position secondPosition)
		{
			return new Position(
				MoreMath.Avg(firstPosition.X, secondPosition.X),
				MoreMath.Avg(firstPosition.Y, secondPosition.Y));
		}
	}
}
