﻿using System.Windows.Media;

namespace TriangleSwim;

internal class ColorScheme
{
	Random Random { get; }

	public ColorScheme(Random random)
	{
		Random = random;
	}
	
	public Color RandomColor => VisibleColors[Random.Next(VisibleColors.Length)];

	public Color[] VisibleColors =>
	[
		Colors.Black,
		Colors.Navy,
		Colors.DarkBlue,
		Colors.MediumBlue,
		Colors.Blue,
		Colors.DarkGreen,
		Colors.Green,
		Colors.Teal,
		Colors.DarkCyan,
		Colors.DeepSkyBlue,
		Colors.DarkTurquoise,
		Colors.MediumSpringGreen,
		Colors.Lime,
		Colors.SpringGreen,
		Colors.Aqua,
		Colors.Cyan,
		Colors.MidnightBlue,
		Colors.DodgerBlue,
		Colors.LightSeaGreen,
		Colors.ForestGreen,
		Colors.SeaGreen,
		Colors.DarkSlateGray,
		Colors.LimeGreen,
		Colors.MediumSeaGreen,
		Colors.Turquoise,
		Colors.RoyalBlue,
		Colors.SteelBlue,
		Colors.DarkOrchid,
		Colors.Indigo,
		Colors.DarkOliveGreen,
		Colors.CadetBlue,
		Colors.CornflowerBlue,
		Colors.DimGray,
		Colors.SlateBlue,
		Colors.OliveDrab,
		Colors.SlateGray,
		Colors.MediumSlateBlue,
		Colors.LawnGreen,
		Colors.Chartreuse,
		Colors.Aquamarine,
		Colors.Maroon,
		Colors.Purple,
		Colors.Olive,
		Colors.Gray,
		Colors.SkyBlue,
		Colors.LightSkyBlue,
		Colors.BlueViolet,
		Colors.DarkRed,
		Colors.DarkMagenta,
		Colors.SaddleBrown,
		Colors.DarkSeaGreen,
		Colors.LightGreen,
		Colors.MediumPurple,
		Colors.DarkViolet,
		Colors.PaleGreen,
		Colors.DarkGoldenrod,
		Colors.Sienna,
		Colors.Brown,
		Colors.DarkGray,
		Colors.GreenYellow,
		Colors.LightSteelBlue,
		Colors.Firebrick,
		Colors.DarkKhaki,
		Colors.MediumOrchid,
		Colors.RosyBrown,
		Colors.DarkSalmon,
		Colors.LightSlateGray,
		Colors.PaleVioletRed,
		Colors.MediumVioletRed,
		Colors.IndianRed,
		Colors.Peru,
		Colors.Chocolate,
		Colors.Tan,
		Colors.Orchid,
		Colors.Goldenrod,
		Colors.Crimson,
		Colors.Plum,
		Colors.BurlyWood,
		Colors.DarkOrange,
		Colors.HotPink,
		Colors.SandyBrown,
		Colors.Salmon,
		Colors.LightCoral,
		Colors.Violet,
		Colors.YellowGreen,
		Colors.DarkTurquoise,
		Colors.MediumTurquoise,
		Colors.DarkOrchid,
		Colors.MediumOrchid,
		Colors.Magenta,
		Colors.Fuchsia,
		Colors.RoyalBlue,
		Colors.SkyBlue,
		Colors.SlateBlue,
		Colors.SteelBlue,
		Colors.Turquoise,
		Colors.Violet,
		Colors.YellowGreen
	];
}
