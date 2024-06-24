namespace TriangleSwim.Domain.Tests;

[TestClass]
public class Angle_Tests
{
	[TestMethod]
	[DataRow(0, 0, 1, 1, 0, Math.PI / 2)]
	[DataRow(0, 0, -1, 1, Math.PI / 2, Math.PI)]
	[DataRow(0, 0, -1, -1, Math.PI, 3 * Math.PI / 2)]
	[DataRow(0, 0, 1, -1, 3 * Math.PI / 4, 2 * Math.PI)]
	public void AngleBetweenPoints_IsCorrectDirection(
		double x1, double y1,
		double x2, double y2,
		double lowerBound, double upperBound)
	{
		Angle angle = Angle.BetweenPoints(
			new Position(x1, y1),
			new Position(x2, y2));

		Assert.IsTrue(angle.Radians > lowerBound && angle.Radians < upperBound);
	}
}
