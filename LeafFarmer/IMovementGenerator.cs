using System.Collections.Generic;

namespace LeafFarmer
{
    interface IMovementGenerator
    {
        /// <summary>
        /// Generate points to cover the entire area within the rectangle given by height, width.
        /// </summary>
         List<Point> GenerateMovement(int height_min, int height_max,
            int width_min, int width_max);
    }

    public struct Point
    {
        public int x;
        public int y;

        public Point(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }
}
