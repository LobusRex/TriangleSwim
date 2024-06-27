namespace TriangleSwim.Domain.Boundaries;

public class CircularBoundary : IBoundary
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

    public Position GetPermittedAlternativeTo(Position position, PersonSize personSize)
    {
        // TODO: Account for personSize.

        // Find the closest possible position within the boundary.
        // return it as the suggested move.

        Position suggestion = new(0, 0);
        suggestion.MoveTowards(position, Radius);

        return suggestion;
    }
}
