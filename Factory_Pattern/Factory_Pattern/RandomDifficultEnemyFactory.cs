using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Pattern
{
    public class RandomDifficultEnemyFactory : EnemyFactory
    {
        private Random random = new Random();

        public IEnemy CreateEnemy()
        {
            // Bowser is the only difficult enemy
            return new Bowser();
        }
    }
}
