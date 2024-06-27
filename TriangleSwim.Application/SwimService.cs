using TriangleSwim.Domain;
using TriangleSwim.Domain.Boundaries;
using TriangleSwim.Domain.PersonSelectionSchemes;
using TriangleSwim.Domain.PositionSchemes;

namespace TriangleSwim.Application;

public class SwimService
{
	public Person[] Persons { get; }
	public IBoundary Boundary { get; }

	public SwimService(
		int personCount,
		IPositionScheme positionScheme,
		IPersonSelectionScheme firstPartnerSelectionScheme,
		IPersonSelectionScheme secondPartnerSelectionScheme,
		MovementSpeed movementSpeed,
		PersonSize personSize,
		IBoundary boundary)
	{
		Persons = new Person[personCount];
		Boundary = boundary;

		for (int i = 0; i < personCount; i++)
		{
			Person person = new(
				positionScheme.GetPosition(
					new PositionCount(personCount),
					new PositionIndex(i)),
				movementSpeed,
				personSize);

			Persons[i] = person;
		}

		foreach (Person person in Persons)
		{
			person.SelectFirstPartner(
				firstPartnerSelectionScheme,
				Persons);
			person.SelectSecondPartner(
				secondPartnerSelectionScheme,
				Persons);
		}
	}

	public void Update(TimeSpan timeDelta)
	{
		foreach (Person person in Persons)
			person.Update(timeDelta, Boundary);
	}
}
