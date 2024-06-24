namespace TriangleSwim.Domain.Tests;

[TestClass]
public class Position_Tests
{
	[TestMethod]
	public void CreateNewPosition_Success()
	{
		Position position = new(0.5, 0.5);
	}

	[TestMethod]
	public void CreateNewPosition_HasCoordinates()
	{
		Position position = new(0.5, 0.5);

		Assert.AreEqual(0.5, position.X);
		Assert.AreEqual(0.5, position.Y);
	}
}