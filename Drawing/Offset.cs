﻿using System;
using System.Drawing;

namespace Extender.Drawing;

/// <remarks>
/// Class to calculate and store the difference between X and Y co-ordinates belonging to a variety of 2D geometry.
/// </remarks>
public class Offset
{
    /// <summary>
    /// Resulting difference along the X-axis.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Resulting difference along the Y-axis.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// (Read-Only) Gets a rounded figure representing half of the X property.
    /// </summary>
    public int HalfX => (int) Math.Round(X / 2f);

    /// <summary>
    /// (Read-Only) Gets a rounded figure representing half of the Y property.
    /// </summary>
    public int HalfY => (int) Math.Round(Y / 2f);

    /// <summary>
    /// Constructs a new Offset from the provided offset values.
    /// </summary>
    public Offset(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Constructs a new Offset representing the translation between two points.
    /// </summary>
    public Offset(Point a, Point b)
    {
        X = a.GetOffset(b).X;
        Y = a.GetOffset(b).Y;
    }

    /// <summary>
    /// Constructs a new Offset representing the difference in two Size's dimensions.
    /// </summary>
    public Offset(Size a, Size b)
    {
        X = a.Width  - b.Width;
        Y = a.Height - b.Height;
    }

    /// <summary>
    /// Constructs a new Offset representing the difference between two Rectangle's dimensions.
    /// </summary>
    public Offset(Rectangle a, Rectangle b)
    {
        X = a.Right  - b.Right;
        Y = a.Bottom - b.Bottom;
    }

    /// <summary>
    /// Constructs a new Offset representing between the translation between two points.
    /// </summary>
    public static Offset FromPoints(Point a, Point b) { return new Offset(a, b); }


    /// <summary>
    /// Constructs a new Offset representing the difference in two Size's dimensions.
    /// </summary>
    public static Offset FromSizes(Size a, Size b) { return new Offset(a, b); }


    /// <summary>
    /// Constructs a new Offset representing the difference between two Rectangle's dimensions.
    /// </summary>
    public static Offset FromRectangles(Rectangle a, Rectangle b) { return new Offset(a, b); }
}