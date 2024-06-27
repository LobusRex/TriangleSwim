namespace TriangleSwim.Domain.Boundaries;

public interface IBoundary
{
    public bool PermitsPosition(Position position, PersonSize personSize);
    public Position GetPermittedAlternativeTo(Position position, PersonSize personSize);
	public Distance DistanceUntilInside(Position position);
}
