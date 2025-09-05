using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineCore.Collision
{
    public readonly struct Circle : IEquatable<Circle>
    {
        private static readonly Circle s_empty = new Circle();

        /// <summary>
        /// The x-coordinate of the center of this circle.
        /// </summary>
        public readonly int X;

        /// <summary>
        /// The y-coordinate of the center of this circle.
        /// </summary>
        public readonly int Y;

        /// <summary>
        /// The length, in pixels, from the center of this circle to the edge.
        /// </summary>
        public readonly int Radius;

        /// <summary>
        /// Gets the location of the center of this circle.
        /// </summary>
        public readonly Point Location => new Point(X, Y);

        /// <summary>
        /// Gets a circle with X=0, Y=0, and Radius=0.
        /// </summary>
        public static Circle Empty => s_empty;

        /// <summary>
        /// Gets a value that indicates whether this circle has a radius of 0 and a location of (0, 0).
        /// </summary>
        public readonly bool IsEmpty => X == 0 && Y == 0 && Radius == 0;

        /// <summary>
        /// Gets the y-coordinate of the highest point on this circle.
        /// </summary>
        public readonly int Top => Y - Radius;

        /// <summary>
        /// Gets the y-coordinate of the lowest point on this circle.
        /// </summary>
        public readonly int Bottom => Y + Radius;

        /// <summary>
        /// Gets the x-coordinate of the leftmost point on this circle.
        /// </summary>
        public readonly int Left => X - Radius;

        /// <summary>
        /// Gets the x-coordinate of the rightmost point on this circle.
        /// </summary>
        public readonly int Right => X + Radius;

        /// <summary>
        /// Creates a new circle with the specified position and radius.
        /// </summary>
        /// <param name="x">The x-coordinate of the center of the circle.</param>
        /// <param name="y">The y-coordinate of the center of the circle..</param>
        /// <param name="radius">The length from the center of the circle to an edge.</param>
        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        /// <summary>
        /// Creates a new circle with the specified position and radius.
        /// </summary>
        /// <param name="location">The center of the circle.</param>
        /// <param name="radius">The length from the center of the circle to an edge.</param>
        public Circle(Point location, int radius)
        {
            X = location.X;
            Y = location.Y;
            Radius = radius;
        }

        public bool Equals(Circle other)
        {
            throw new NotImplementedException();
        }
    }
}
