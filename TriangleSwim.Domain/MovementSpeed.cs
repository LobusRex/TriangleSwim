namespace TriangleSwim.Domain;

public class MovementSpeed
{
	public double DistancePerSecond { get; }

	public MovementSpeed(double distancePerSecond)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(distancePerSecond, nameof(distancePerSecond));

		DistancePerSecond = distancePerSecond;
	}

	public Distance GetDistance(TimeSpan time)
	{
		return new Distance(DistancePerSecond * time.TotalSeconds);
	}
}
