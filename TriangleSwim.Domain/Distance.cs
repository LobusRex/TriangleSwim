namespace TriangleSwim.Domain;

public class Distance
{
	public double Value { get; }

	public Distance(double value)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(value));

		Value = value;
	}

	public bool IsLongerThan(Distance other)
	{
		return this.Value > other.Value;
	}

	public bool IsShorterThan(Distance other)
	{
		return this.Value < other.Value;
	}

	public static Distance Shortest(Distance distance1, Distance distance2)
	{
		if (distance1.IsLongerThan(distance2))
			return distance2;
		else
			return distance1;
	}

	public Position AtAngle(Angle angle)
	{
		double X = angle.NormalizedX * Value;
		double Y = angle.NormalizedY * Value;

		return new Position(X, Y);
	}
}
