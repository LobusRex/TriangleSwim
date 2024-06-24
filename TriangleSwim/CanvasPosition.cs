using TriangleSwim.Domain;

namespace TriangleSwim;

internal class CanvasPosition
{
	public double FromLeft { get; }
	public double FromTop { get; }

	public CanvasPosition(double fromLeft, double fromTop)
	{
		FromLeft = fromLeft;
		FromTop = fromTop;
	}

	public static CanvasPosition MapFromPosition(Position position)
	{
		return new CanvasPosition(position.X, -position.Y);
	}
}
