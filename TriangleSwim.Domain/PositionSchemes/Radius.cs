namespace TriangleSwim.Domain.PositionSchemes;

public class Radius
{
	internal int Length { get; }

	public Radius(int length)
	{
		if (length <= 0)
			throw new ArgumentException("The radius length must be larger than zero", nameof(length));
	
		Length = length;
	}
}
