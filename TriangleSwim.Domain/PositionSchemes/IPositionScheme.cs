namespace TriangleSwim.Domain.PositionSchemes;

public interface IPositionScheme
{
	public Position GetPosition(PositionCount totalPositionCount, PositionIndex positionIndex);
}
