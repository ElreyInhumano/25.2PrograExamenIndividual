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
        private static PlayerUnits instance;
        public PlayerUnits(int life, int dmg, int cost, int money) : base(life, dmg)
        {
            this.cost = cost;
            this.money = money;
        }

        public void SetPlayerUnitsInstance()
        {
            instance = this;
        }
        public static PlayerUnits GetPlayerUnitsInstance()
        {
            return instance;
        }
        public override void ReceiveDamage(int dmg)
        {
            life -= dmg;
        }
        public int GetHeal(int heal)
        {
            return life + heal;
        }
        public void UpgradeLife(int life)
        {
            this.life += life;
        }
        public void UpgradeDmg(int dmg)
        {
             this.dmg += dmg;
        }
        public void UpgradeMoney(int money)
        {
             this.money += money;
        }
        public int GetCost()
        {
             return cost;
        }
        public int GetMoney()
        {
             return money;
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
