using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TriangleSwim.Domain;

namespace TriangleSwim;

internal class CanvasDrawingService
{
	private Canvas Canvas { get; }
	private Canvas TraceCanvas { get; }
	private CanvasScale CanvasScale { get; }
	private ColorScheme ColorScheme { get; }
	private Dictionary<Person, Ellipse> PersonEllipses { get; } = [];
	private Dictionary<(Person, Person), Line> PersonConnectionLines { get; } = [];
	private int TraceDelay { get; }

	private int updateCounter = 0;
	

	public CanvasDrawingService(Canvas canvas, Canvas traceCanvas, CanvasScale canvasScale, ColorScheme colorScheme, int traceDelay)
	{
		Canvas = canvas;
		TraceCanvas = traceCanvas;
		CanvasScale = canvasScale;
		ColorScheme = colorScheme;
		TraceDelay = traceDelay;
	}

	public void RegisterPerson(Person person)
	{
		if (PersonEllipses.ContainsKey(person))
			throw new InvalidOperationException("This person has already been registered.");

		var ellipse = new Ellipse()
		{
			Fill = new SolidColorBrush(Colors.Black),
		};
		PersonEllipses[person] = ellipse;
		Canvas.Children.Add(ellipse);

		if (person.FirstPartner != null)
			RegisterPersonConnectionLine(person, person.FirstPartner);
		if (person.SecondPartner != null)
			RegisterPersonConnectionLine(person, person.SecondPartner);

		UpdatePerson(person, false);
	}

	private void RegisterPersonConnectionLine(Person owner, Person partner)
	{
		if (PersonConnectionLines.ContainsKey((owner, partner)))
			throw new InvalidOperationException("This couple has already been registered.");

		var line = new Line()
		{
			Stroke = new SolidColorBrush(Colors.Aqua),
			StrokeThickness = 2,
		};

		PersonConnectionLines[(owner, partner)] = line;
		Canvas.Children.Add(line);
	}

	public void SetRandomPersonColor(Person person)
	{
		Color color = ColorScheme.RandomColor;

		SetPersonColor(person, color, color, color);
	}

	public void SetPersonColor(Person person, Color color)
	{
		SetPersonColor(person, color, color, color);
	}

	public void SetPersonColor(Person person, Color personColor, Color firstPartnerColor, Color secondPartnerColor)
	{
		//SolidColorBrush personBrush = new(personColor);

		PersonEllipses.TryGetValue(person, out Ellipse? ellipse);

		if (ellipse == null)
			throw new InvalidOperationException("This person has not been registered yet.");

		ellipse.Fill = new SolidColorBrush(personColor);

		if (person.FirstPartner != null)
		{
			PersonConnectionLines.TryGetValue((person, person.FirstPartner), out Line? firstLine);
			if (firstLine != null)
				firstLine.Stroke = new SolidColorBrush(firstPartnerColor);
		}

		if (person.SecondPartner != null)
		{
			PersonConnectionLines.TryGetValue((person, person.SecondPartner), out Line? secondLine);
			if (secondLine != null)
				secondLine.Stroke = new SolidColorBrush(secondPartnerColor);
		}
	}

	public void UpdatePersons(Person[] persons)
	{
		foreach (var person in persons)
		{
			UpdatePerson(person, updateCounter % TraceDelay == 0);
		}
		updateCounter++;
	}

	public void UpdatePerson(Person person, bool drawTrace)
	{
		PersonEllipses.TryGetValue(person, out Ellipse? ellipse);

		if (ellipse == null)
			throw new InvalidOperationException("This person has not been registered yet.");

		double size = CanvasScale.SizeToScale(person.Size);
		ellipse.Width = size;
		ellipse.Height = size;

		CanvasPosition position = CanvasScale.PositionToScale(person.Position);
		Canvas.SetEllipsePosition(ellipse, position);

		if (drawTrace)
			UpdateTrace(ellipse, position);

		// TODO: Add a null check for person.FirstPartner.
		if (person.FirstPartner != null)
		{
			PersonConnectionLines.TryGetValue((person, person.FirstPartner), out Line? firstLine);

			if (firstLine != null)
			{
				CanvasPosition OwnerPosition = CanvasScale.PositionToScale(person.Position);
				CanvasPosition PartnerPosition = CanvasScale.PositionToScale(person.FirstPartner.Position);

				Canvas.SetLinePoints(firstLine, OwnerPosition, PartnerPosition);
			}
		}

		if (person.SecondPartner != null)
		{
			PersonConnectionLines.TryGetValue((person, person.SecondPartner), out Line? secondLine);

			if (secondLine != null)
			{
				CanvasPosition OwnerPosition = CanvasScale.PositionToScale(person.Position);
				CanvasPosition PartnerPosition = CanvasScale.PositionToScale(person.SecondPartner.Position);

				Canvas.SetLinePoints(secondLine, OwnerPosition, PartnerPosition);
			}
		}



		//if (person.SecondPartner != null)
		//{
		//	PersonConnectionLines.TryGetValue((person, person.SecondPartner), out Line? secondLine);
		//}
	}

	private void UpdateTrace(Ellipse ellipse, CanvasPosition position)
	{
		Ellipse trace = new()
		{
			Fill = ellipse.Fill,
			Width = 2,
			Height = 2,
		};

		//CanvasPosition position = CanvasScale.PositionToScale(person.Position);
		//Canvas.SetEllipsePosition(ellipse, position);

		Canvas.SetEllipsePosition(trace, position);
		//Canvas.SetLeft(trace, Canvas.GetLeft(position.));
		//Canvas.SetTop(trace, Canvas.GetTop(ellipse));

		TraceCanvas.Children.Add(trace);
		if (TraceCanvas.Children.Count > 1000)
		{
			TraceCanvas.Children.RemoveRange(0, 100);
		}
	}
}
