using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2ExamenIndividual
{
    class EnemyUnits : Units
    {
        private static EnemyUnits instance;
        public EnemyUnits(int life, int dmg) : base(life, dmg)
        {
        }

        public void SetEnemyUnitsInstance()
        {
            instance = this;
        }
        public static EnemyUnits GetEnemyUnitsInstance()
        {
            return instance;
        }
        public override void ReceiveDamage(int dmg)
        {
            life -= dmg;
        }
        public override int GetLife()
        {
            return life;
        }
        public override int GetDmg()
        {
            return dmg;
        }
    }
}
