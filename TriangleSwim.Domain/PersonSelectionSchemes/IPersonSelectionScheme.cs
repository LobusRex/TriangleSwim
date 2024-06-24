namespace TriangleSwim.Domain.PersonSelectionSchemes;

public interface IPersonSelectionScheme
{
	public Person GetSelectedPerson(Person selector, Person[] people);
	public Person GetSelectedPerson(Person selector, Person[] people, Person? alreadySelected);
}
