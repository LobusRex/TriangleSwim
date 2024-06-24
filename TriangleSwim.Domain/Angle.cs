namespace TriangleSwim.Domain;

public class Angle
{
	public double Radians { get; }
	public double NormalizedX => Math.Cos(Radians);
	public double NormalizedY => Math.Sin(Radians);

	public Angle(double radians)
	{
		while (radians < 0)
			radians += 2 * Math.PI;

		Radians = radians;
	}

	public static Angle BetweenPoints(Position originPoint, Position targetPoint)
	{
		double xDelta = targetPoint.X - originPoint.X;
		double yDelta = targetPoint.Y - originPoint.Y;

		double radians = Math.Atan2(yDelta, xDelta);

		return new Angle(radians);
	}

	public Angle Perpendicular()
	{
		return new Angle(Radians + Math.PI);
	}

	public Angle Subtract(Angle other)
	{
		return new Angle(Radians - other.Radians);
	}

	public Angle Add(Angle other)
	{
		return new Angle(Radians + other.Radians);
	}
}
