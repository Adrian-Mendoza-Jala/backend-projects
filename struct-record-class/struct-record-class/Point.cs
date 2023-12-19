﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace struct_record_class
{
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void DisplayCoordinates()
        {
            Console.WriteLine($"Point Coordinates: ({X}, {Y})");
        }
    }
}
