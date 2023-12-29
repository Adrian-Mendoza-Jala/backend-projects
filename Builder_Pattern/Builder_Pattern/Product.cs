using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public override string ToString() => $"Name: {Name}, Price: {Price}, Description: {Description}";
    }
}
