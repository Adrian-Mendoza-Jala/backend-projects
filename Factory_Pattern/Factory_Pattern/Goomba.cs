using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Pattern
{
    public class Goomba :IEnemy
    {
        public void Attack()
        {
            Console.WriteLine("Goomba stomps!");
        }
    }
}
