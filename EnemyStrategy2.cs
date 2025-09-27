using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2ExamenIndividual
{
    class EnemyStrategy2 : IEnemyStrategy
    {
        float fibonacciIndex;
        List<EnemyUnits> enemyUnits2;
        public EnemyStrategy2(float fibonacciIndex, List<EnemyUnits> enemyUnits2)
        {
            this.fibonacciIndex = fibonacciIndex;
            this.enemyUnits2 = enemyUnits2;
        }
        public void CreateEnemyUnits()
        {
            for (int i = 0; i < fibonacciIndex; i++)
            {
                EnemyUnits enemyUnits = new EnemyUnits(1, 4);
                enemyUnits2.Add(enemyUnits);
            }
        }
    }
}
