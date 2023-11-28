namespace Class_6
{
    public class Car : Vehicle
    {
        public Car(string make, string model) : base(make, model) {
            
             Type = nameof(Car);  // Check this 

        }

        public override void Start()
        {
            Console.WriteLine($"Putting the Key.");
            Console.WriteLine($"Starting: {this}"); // Check this instead of this.ToString() or ToString()

        }

        public override void Stop() 
        { 
            Console.WriteLine($"Stopping: {this}"); 
        }
    }
}
