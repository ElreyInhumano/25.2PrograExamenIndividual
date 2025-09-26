using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2ExamenIndividual
{
    class EnemyUnits : Units
    {

        public EnemyUnits(int life, int dmg) : base(life, dmg)
        {
        }

        public override void ReceiveDamage(int dmg)
        {
            life -= dmg;
        }
    }
}
