namespace TriangleSwim.Domain.PersonSelectionSchemes;

public class PersonToTheLeftSelectionScheme : IPersonSelectionScheme
{
	public Person GetSelectedPerson(Person selector, Person[] people)
	{
		var peopleList = people.ToList();

		if (!peopleList.Contains(selector))
			throw new ArgumentException("The selector must be one of the people", nameof(people));

		int selectedIndex = peopleList.IndexOf(selector) - 1;

		// TODO: Does this reslult in the correct index?
		return people[(selectedIndex + people.Length) % people.Length];
	}

	public Person GetSelectedPerson(Person selector, Person[] people, Person? alreadySelected)
	{
		//if (alreadySelected == null)
		//	return GetSelectedPerson(selector, people);

		var firstToLeft = GetSelectedPerson(selector, people);

		if (alreadySelected == null)
			return firstToLeft;

		if (firstToLeft != alreadySelected)
			return firstToLeft;

		// Go another step left if the selected person is already selected.
		return GetSelectedPerson(firstToLeft, people);
	}
}
