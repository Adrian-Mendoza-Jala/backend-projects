using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_6
{
    public abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }

        public string Type { get; protected set; }

        protected Vehicle(string make, string model)
        {
            Make = make;
            Model = model;
        }

        public abstract void Start();
        public abstract void Stop();

        public override string ToString() 
        { 
            return $"{Type}: {Make} - {Model}"; 
        }
    }
}
