namespace TriangleSwim.Domain.PersonSelectionSchemes
{
	public class RandomPersonSelectionScheme : IPersonSelectionScheme
	{
		private Random Random { get; }

		public RandomPersonSelectionScheme(Random random)
		{
			Random = random;
		}

		// TODO: Consider removing this method and only use the other one.
		public Person GetSelectedPerson(Person selector, Person[] people)
		{
			var candidateList = people
				.Where(e  => e != selector)
				.ToArray();

			int selectedIndex = Random.Next(candidateList.Length);

			return candidateList[selectedIndex];
		}

		public Person GetSelectedPerson(Person selector, Person[] people, Person? alreadySelected)
		{
			if (alreadySelected == null)
				return GetSelectedPerson(selector, people);

			var notSelected = people
				.Where(e => e != alreadySelected)
				.ToArray();

			return GetSelectedPerson(selector, notSelected);
		}
	}
}
