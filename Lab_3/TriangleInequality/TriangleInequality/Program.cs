﻿using System;

namespace TriangleInequality
{
    public class Program
    {
        public static bool IsTriangle(double x, double y, double z)
        {
            return (x + y > z && x < y + z && y < x + z && x != 0 && y != 0 && z != 0);
        }

        static void Main(string[] args)
        {

        }
    }
}