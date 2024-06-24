using System.Windows.Controls;
using System.Windows.Shapes;

namespace TriangleSwim;

internal static class Extensions
{
	public static void SetEllipsePosition(
		this Canvas canvas,
		Ellipse ellipse,
		CanvasPosition position)
	{
		double left = position.FromLeft
			+ canvas.Width / 2
			+ -ellipse.Width / 2;

		double top = position.FromTop
			+ canvas.Height / 2
			+ -ellipse.Height / 2;

		Canvas.SetTop(ellipse, -ellipse.Height/2 + canvas.Height/2 + position.FromTop);
		Canvas.SetLeft(ellipse, -ellipse.Width/2 + canvas.Width/2 + position.FromLeft);
	}

	public static void SetLinePoints(
		this Canvas canvas,
		Line line,
		CanvasPosition startPosition,
		CanvasPosition stopPosition)
	{
		line.X1 = startPosition.FromLeft;
		line.Y1 = startPosition.FromTop;
		line.X2 = stopPosition.FromLeft;
		line.Y2 = stopPosition.FromTop;

		Canvas.SetLeft(line, canvas.Width / 2);
		Canvas.SetTop(line, canvas.Height / 2);
	}
}
