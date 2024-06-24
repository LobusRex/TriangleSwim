namespace TriangleSwim.Domain;

public class PersonSize
{
	private double Size { get; }

	public PersonSize(double size)
	{
		if (size <= 0)
			throw new ArgumentException("The size must be larger than zero.", nameof(size));
		
		Size = size;
	}

	public double ToDouble()
	{
		return Size;
	}
}
