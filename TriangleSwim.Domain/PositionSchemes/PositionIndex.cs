namespace TriangleSwim.Domain.PositionSchemes;

public class PositionIndex
{
	public int Index { get; }

	public PositionIndex(int index)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(index, nameof(index));

		Index = index;
	}
}
