using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2ExamenIndividual
{
    abstract class Units : IReceiveDamage, IGetLife, IGetDmg
    {
        protected int life;
        protected int dmg;
        public Units(int life, int dmg)
        {
            this.life = life;
            this.dmg = dmg;
        }
        public abstract void ReceiveDamage(int dmg);
        public abstract int GetLife();
        public abstract int GetDmg();
    }
}
