using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2ExamenIndividual
{
    class EnemyStrategy1: IEnemyStrategy
    {
        float fibonacciIndex;
        List<EnemyUnits> enemyUnits1;
        public EnemyStrategy1(float fibonacciIndex, List<EnemyUnits> enemyUnits1)
        {
            this.fibonacciIndex = fibonacciIndex;
            this.enemyUnits1 = enemyUnits1;
        }
        public void CreateEnemyUnits()
        {
            for (int i = 0; i < fibonacciIndex; i++)
            {
                EnemyUnits enemyUnits = new EnemyUnits(3, 2);
                enemyUnits1.Add(enemyUnits);
            }
        }
    }
}
