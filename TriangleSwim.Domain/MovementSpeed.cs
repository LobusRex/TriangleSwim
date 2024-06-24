namespace TriangleSwim.Domain;

public class MovementSpeed
{
	public double Value { get; }

	public MovementSpeed(double value)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, nameof(value));

		Value = value;
	}

	public Distance GetDistance(TimeSpan time)
	{
		return new Distance(Value * time.TotalSeconds);
	}
}
