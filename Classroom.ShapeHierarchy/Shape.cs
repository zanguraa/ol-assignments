﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.ShapeHierarchy
{
    abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
    public class Circle : Shape 
    { 
       public double Radius { get; set; }
        public Circle(double radius) 
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
