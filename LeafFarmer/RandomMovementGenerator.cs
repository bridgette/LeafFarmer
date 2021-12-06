using System;
using System.Collections.Generic;

namespace LeafFarmer
{
    /// <summary>
    /// Randomly walks 
    /// </summary>
    class RandomMovementGenerator : IMovementGenerator
    {
        private static Random rand;

        public RandomMovementGenerator() {
            rand = new Random();
        }

        public List<Point> GenerateMovement(int height_min, int height_max, 
            int width_min, int width_max)
        {
            List<Point> ret = new List<Point>();

            int randomHeight = rand.Next(height_min, height_max);
            int randomWidth = rand.Next(width_min, width_max);
            ret.Add(new Point(randomWidth, randomHeight));        
            return ret;
        }
    }
}
