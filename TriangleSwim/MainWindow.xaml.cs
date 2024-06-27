using TriangleSwim.Application;
using System.Windows;
using TriangleSwim.Domain.PositionSchemes;
using TriangleSwim.Domain.PersonSelectionSchemes;
using System.Windows.Threading;
using TriangleSwim.Domain;
using TriangleSwim.Domain.Boundaries;
using System.Windows.Shapes;
using System.Windows.Media;

namespace TriangleSwim;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly DispatcherTimer timer = new();

	private readonly SwimService swimService;
	private readonly CanvasDrawingService canvasDrawingService;

	private DateTime? LastUpdate { get; set; } = null;

	public MainWindow()
	{
		InitializeComponent();

		swimService = new SwimService(
			10,
			new CircularPositionScheme(
				new Radius(8)),
			new PersonToTheLeftSelectionScheme(),
			new RandomPersonSelectionScheme(
				new Random()),
			new MovementSpeed(0.5),
			new PersonSize(0.8),
			new CircularBoundary(
				new Distance(12)));

		canvasDrawingService = new CanvasDrawingService(
			canvas,
			traceCanvas,
			new CanvasScale(30),
			new ColorScheme(
				new Random(4)),
			50);

		var dot = new Ellipse()
		{
			Fill = new SolidColorBrush(Colors.Black),
			Width = 50,
			Height = 50,
		};

		foreach (var person in swimService.Persons)
		{
			canvasDrawingService.RegisterPerson(person);
		}

		int numberOfPersons = swimService.Persons.Length;

		foreach (var person in swimService.Persons)
		{
			canvasDrawingService.SetRandomPersonColor(person);
		}

		timer.Interval = TimeSpan.FromMilliseconds(20);
		timer.Tick += Timer_Tick;

		Loaded += MainWindow_Loaded;
	}

	private void MainWindow_Loaded(object sender, RoutedEventArgs e)
	{
		timer.Start();
	}

	private void Timer_Tick(object? sender, EventArgs e)
	{
		var timeDelta = GetTimeDelta();

		fpsLabel.Content = Math.Round(1.0 / timeDelta.TotalSeconds);

		swimService.Update(timeDelta);

		canvasDrawingService.UpdatePersons(swimService.Persons);
	}

	private TimeSpan GetTimeDelta()
	{
		return TimeSpan.FromMilliseconds(40);
		//if (LastUpdate == null)
		//	LastUpdate = DateTime.Now;

		//DateTime currentTime = DateTime.Now;
		//TimeSpan timeDelta = currentTime - (DateTime)LastUpdate;

		//LastUpdate = currentTime;

		//return timeDelta;
	}
}