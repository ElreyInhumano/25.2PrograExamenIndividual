using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2ExamenIndividual
{
    class PlayerUnits : Units
    {
        protected int cost;
        protected int money;

        public PlayerUnits(int life, int dmg, int cost, int money) : base(life, dmg)
        {
            this.cost = cost;
            this.money = money;
        }

        public override void ReceiveDamage(int dmg)
        {
            life -= dmg;
        }
    }
}
