using System.Drawing;
using TriangleSwim.Domain.PersonSelectionSchemes;

namespace TriangleSwim.Domain;

public class Person
{
	public Position Position { get; }
	private MovementSpeed MovementSpeed { get; }
	public PersonSize Size { get; }

	// TODO: Private get?
	public Person? FirstPartner { get; private set; } = null;
	public Person? SecondPartner { get; private set; } = null;

	public Person(Position position, MovementSpeed movementSpeed, PersonSize size)
	{
		Position = position;
		MovementSpeed = movementSpeed;
		Size = size;
	}

	public void SelectFirstPartner(IPersonSelectionScheme scheme, Person[] personGroup)
	{
		Person newPartner = scheme.GetSelectedPerson(this, personGroup, SecondPartner);

		if (SecondPartner != null && SecondPartner == newPartner)
			throw new Exception("The selected person is already a partner of this person.");

		FirstPartner = newPartner;
	}

	public void SelectSecondPartner(IPersonSelectionScheme scheme, Person[] personGroup)
	{
		Person newPartner = scheme.GetSelectedPerson(this, personGroup, FirstPartner);

		if (FirstPartner != null && FirstPartner == newPartner)
			throw new Exception("The selected person is already a partner of this person.");

		SecondPartner = newPartner;
	}

	public void Update(TimeSpan timeDelta, CircularBoundary boundary)
	{
		// Choose the closest target point.
		(Position, Position) targets = GetTrianglePoints();
		Position target;
		if (Position.DistanceTo(targets.Item1).IsLongerThan(Position.DistanceTo(targets.Item2)))
			target = targets.Item2;
		else
			target = targets.Item1;

		// Make sure we don't get out of bounds.
		Position suggestedNewPosition = new(Position.X, Position.Y);
		suggestedNewPosition.MoveTowards(target, MovementSpeed.GetDistance(timeDelta));
		if (!boundary.PermitsPosition(suggestedNewPosition, Size))
			//return;
			target = boundary.GetSuggestion(suggestedNewPosition, Size); // Or target?

		// Make the move.
		Position.MoveTowards(target, MovementSpeed.GetDistance(timeDelta));
	}

	private (Position, Position) GetTrianglePoints()
	{
		if (FirstPartner == null || SecondPartner == null)
			throw new Exception($"{nameof(FirstPartner)} or {nameof(SecondPartner)} may not be null when running {nameof(Update)}.");

		Distance partnerDistance = FirstPartner.Position.DistanceTo(SecondPartner.Position);

		Angle partnerAngle = Angle.BetweenPoints(FirstPartner.Position, SecondPartner.Position);

		Angle triangleCornerAngle = new(Math.PI / 3.0);

		Angle angleToTarget1 = partnerAngle.Subtract(triangleCornerAngle);
		Angle angleToTarget2 = partnerAngle.Add(triangleCornerAngle);

		Position targetPosition1 = FirstPartner.Position.MovedTo(angleToTarget1, partnerDistance);
		Position targetPosition2 = FirstPartner.Position.MovedTo(angleToTarget2, partnerDistance);

		return (targetPosition1, targetPosition2);
	}
}
