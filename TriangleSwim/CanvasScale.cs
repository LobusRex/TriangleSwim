using TriangleSwim.Domain;

namespace TriangleSwim;

internal class CanvasScale
{
	private double Scale { get; }

	public CanvasScale(double scale)
	{
		if (scale <= 0)
			throw new ArgumentException("The scale must be larger than zero", nameof(scale));

		Scale = scale;
	}

	public double SizeToScale(PersonSize personSize)
	{
		return personSize.ToDouble() * Scale;
	}

	public CanvasPosition PositionToScale(Position position)
	{
		var canvasPosition = CanvasPosition.MapFromPosition(position);

		return new CanvasPosition(
			canvasPosition.FromLeft * Scale,
			canvasPosition.FromTop * Scale);
	}
}