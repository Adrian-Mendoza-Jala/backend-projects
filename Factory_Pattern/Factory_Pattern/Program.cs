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
        }
    }
}