namespace TriangleSwim.Domain.Boundaries;

public class NoBoundary : IBoundary
{
	public bool PermitsPosition(Position position, PersonSize personSize)
	{
		return true;
	}

	public Position GetPermittedAlternativeTo(Position position, PersonSize personSize)
	{
		return position;
	}
}
