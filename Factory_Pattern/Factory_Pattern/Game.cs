using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Pattern
{
    public class Game
    {
        private Random random = new Random();

        public IEnemy SpawnEnemy()
        {
            double randomNumber = random.NextDouble();
            if (randomNumber > 0.66)
            {
                return new Koopa();
            }
            else if (randomNumber > 0.33)
            {
                return new Goomba();
            }
            else
            {
                return new Boo();
            }
        }

        public void GameLogic()
        {
            // ... more code above

            if (ShouldSpawnEnemy())
            {
                IEnemy enemy = SpawnEnemy();
                enemy.Attack();
            }

            // ... more code below, use enemy
        }

        private bool ShouldSpawnEnemy()
        {
            // Logic to determine if an enemy should spawn
            return true;
        }
    }
}
