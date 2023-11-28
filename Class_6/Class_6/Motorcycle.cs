using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_6
{
    namespace Class_6
    {
        public class Motorcycle : Vehicle
        {
            public Motorcycle(string make, string model) : base(make, model)
            {
                Type = "Motorcycle";
            }

            public override void Start()
            {
                Console.WriteLine($"Starting: {this.ToString()}");
            }

            public override void Stop()
            {
                Console.WriteLine($"Stopping: {this.ToString()}");
            }
        }
    }

}
