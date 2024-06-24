namespace TriangleSwim.Domain.PositionSchemes;

public class CircularPositionScheme : IPositionScheme
{
	private int Radius { get; }

    public CircularPositionScheme(Radius radius)
    {
		Radius = radius.Length;
    }

    public Position GetPosition(PositionCount totalPositionCount, PositionIndex positionIndex)
    {
		ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(
			positionIndex.Index,
			totalPositionCount.Count);

		int count = totalPositionCount.Count;
		int index = positionIndex.Index;

		double angle = 2 * Math.PI / count * index;

		double x = Radius * Math.Cos(angle);
		double y = Radius * Math.Sin(angle);

		return new Position(x, y);
    }
}

