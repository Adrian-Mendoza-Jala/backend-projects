using System;

namespace Factory_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            // Simulate enemy spawning and attacking 10 times
            for (int i = 0; i < 10; i++)
            {
                IEnemy enemy = game.SpawnEnemy();
                enemy.Attack();
            }

            EnemyFactory factory;

            // Example of using the RandomEnemyFactory
            factory = new RandomEnemyFactory();
            IEnemy randomEnemy = factory.CreateEnemy();
            randomEnemy.Attack();

            // Example of using the RandomDifficultEnemyFactory
            factory = new RandomDifficultEnemyFactory();
            IEnemy difficultEnemy = factory.CreateEnemy();
            difficultEnemy.Attack();

            // Example of using the GoombaFactory
            factory = new GoombaFactory();
            IEnemy goomba = factory.CreateEnemy();
            goomba.Attack();
        }
    }
}