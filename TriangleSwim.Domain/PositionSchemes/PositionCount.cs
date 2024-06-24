namespace TriangleSwim.Domain.PositionSchemes;

public class PositionCount
{
	public int Count { get; }

	public PositionCount(int count)
	{
		if (count <= 0)
			throw new ArgumentException("The count must be larger than zero", nameof(count));

		Count = count;
	}
}
