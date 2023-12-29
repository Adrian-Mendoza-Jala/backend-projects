using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Pattern
{
    public class RandomEnemyFactory : EnemyFactory
    {
        private Random random = new Random();

        public IEnemy CreateEnemy()
        {
            // Assume there's an equal chance to spawn Goomba, Koopa, or Boo
            int choice = random.Next(3);
            return choice switch
            {
                0 => new Goomba(),
                1 => new Koopa(),
                _ => new Boo(),
            };
        }
    }

}
