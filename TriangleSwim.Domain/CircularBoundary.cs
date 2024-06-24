using TriangleSwim.Domain.PositionSchemes;

namespace TriangleSwim.Domain;

public class CircularBoundary
{
	private Position Center { get; } = new Position(0, 0);
	private Distance Radius { get; }

	public CircularBoundary(Distance radius)
	{
		Radius = radius;
	}

	public bool PermitsPosition(Position position, PersonSize personSize)
	{
		// TODO: Account for personSize.

		return position
			.DistanceTo(Center)
			.IsShorterThan(Radius);
	}

	public Position GetSuggestion(Position position, PersonSize personSize)
	{
		// TODO: Account for personSize.

		// Find the closest possible position within the boundary.
		// return it as the suggested move.

		Position suggestion = new(0, 0);
		suggestion.MoveTowards(position, Radius);

		return suggestion;
	}
}
