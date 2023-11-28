using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_6
{
    public class Helicopter : Vehicle 
    {
        public Helicopter(string make, string model) : base(make, model)
        {
            Type = "Helicopter";
        }

        public override void Start()
        {
            Console.WriteLine($"Checking helicopter controls");
            Console.WriteLine($"Starting: {this.ToString()}");
        }

        public override void Stop()
        {
            Console.WriteLine($"Stopping: {this.ToString()}");
        }
    }
}
