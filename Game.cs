using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2ExamenIndividual
{
    class Game
    {
        Func<int> playerLife, playerDmg;
        Func<int> enemyLife, enemyDmg;
        Action<int> playerReceiveDmg, playerUpgradeLife, playerUpgradeDmg, playerUpgradeMoney;
        Action<int> enemyReceiveDmg;
        private static PlayerUnits playerUnits = new PlayerUnits(1, 1, 1, 1);
        private static EnemyUnits enemyUnits = new EnemyUnits(1, 1);
        private int basePlayerLife, baseEnemyLife;
        private int turn, money, chooseUnitOption;
        List<PlayerUnits> playerUnitsList = new List<PlayerUnits>();
        public void StartGame()
        {
            playerUnits.SetPlayerUnitsInstance();
            enemyUnits.SetEnemyUnitsInstance();
            SetBasesLife();
            SetFuncsActions();
            SetGame();
        }
        public void SetGame()
        {
            PlayerTurn();
            
        }
        void SetBasesLife()
        {
            basePlayerLife = 20;
            baseEnemyLife = 20;
        }
        void SetFuncsActions()
        {
            playerLife = PlayerUnits.GetPlayerUnitsInstance().GetLife;
            playerDmg = PlayerUnits.GetPlayerUnitsInstance().GetDmg;

            enemyLife = EnemyUnits.GetEnemyUnitsInstance().GetLife;
            enemyDmg = EnemyUnits.GetEnemyUnitsInstance().GetDmg;

            enemyReceiveDmg = EnemyUnits.GetEnemyUnitsInstance().ReceiveDamage;
            
            playerReceiveDmg = PlayerUnits.GetPlayerUnitsInstance().ReceiveDamage;
            playerUpgradeLife = PlayerUnits.GetPlayerUnitsInstance().UpgradeLife;
            playerUpgradeDmg = PlayerUnits.GetPlayerUnitsInstance().UpgradeDmg;
            playerUpgradeMoney = PlayerUnits.GetPlayerUnitsInstance().UpgradeMoney;

        }

        void PlayerTurn()
        {
            bool playerTurn = true;
            Console.WriteLine($"Turn {turn}. Es tu turno");
            Console.WriteLine($"Tu base tiene {basePlayerLife} de vida");
            if (basePlayerLife >= basePlayerLife / 2)
            {
                money += 15;
                Console.WriteLine($"Tu base generó 15 de monedas");
            }
            else
            {
                money += 7;
                Console.WriteLine($"Tu base generó 7 de monedas");
            }            
            while (playerTurn)
            {
                Console.WriteLine($"Tienes {money} monedas");
                Console.WriteLine($"Escoge tu acción");
                Console.WriteLine($"1. Para comprar una unidad de ataque");
                Console.WriteLine($"2. Para comprar una unidad de recolección");
                Console.WriteLine($"3. Para mejorar una unidad");
                Console.WriteLine($"4. Terminar");
                string opt;
                opt = Console.ReadLine();
                if(int.TryParse(opt, out chooseUnitOption))
                {
                    switch (chooseUnitOption)
                    {
                        case 1:
                            CreatePlayerAtackUnits();
                            break;
                        case 2:
                            CreatePlayerRecolectionUnits();
                            break;
                        case 3:
                            UpgradePlayerUnits();
                            break;
                        case 4:
                            playerTurn = false;
                            break;
                        default:
                            Console.WriteLine($"Esa no es una opción");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Esa no es una opción");
                    Console.ReadLine();
                }
            }
        }
        void CreatePlayerAtackUnits()
        {
            string conf;
            int confirm;
            Console.WriteLine($"Confirmar pagar 5 monedas");
            Console.WriteLine($"1. Sí");
            Console.WriteLine($"2. No");
            conf = Console.ReadLine();
            if (int.TryParse(conf, out confirm))
            {
                switch (confirm)
                {
                    case 1:
                        if (money >= 5)
                        {
                            PlayerUnits playerUnit = new PlayerUnits(1, 3, 5, 1);
                            playerUnitsList.Add(playerUnit);
                            money -= 5;
                        }
                        else
                        {
                            Console.WriteLine($"No tiene suficientes monedas");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine($"Canceló la compra");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine($"Esa no es una opción");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Esa no es una opción");
                Console.ReadLine();
            }
        }
        void CreatePlayerRecolectionUnits()
        {
            string conf;
            int confirm;
            Console.WriteLine($"Confirmar pagar 8 monedas");
            Console.WriteLine($"1. Sí");
            Console.WriteLine($"2. No");
            conf = Console.ReadLine();
            if(int.TryParse(conf, out confirm))
            {
                switch (confirm)
                {
                    case 1:
                        if (money >= 8)
                        {
                            PlayerUnits playerUnit = new PlayerUnits(3, 1, 8, 3);
                            playerUnitsList.Add(playerUnit);
                            money -= 8;
                        }
                        else
                        {
                            Console.WriteLine($"No tiene suficientes monedas");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine($"Canceló la compra");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine($"Esa no es una opción");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Esa no es una opción");
                Console.ReadLine();
            }
        }
        void UpgradePlayerUnits()
        {
            string opt;            
            int option;            
            if (playerUnitsList.Count > 0)
            {
                Console.WriteLine($"Escoja la unidad a mejorar");
                ShowPlayerUnits();
                opt = Console.ReadLine();
                try
                {
                    if(int.TryParse(opt, out option))
                    {
                        if (option < playerUnitsList.Count)
                        {
                            string select;
                            int selection;
                            Console.WriteLine($"Escoja la mejora");
                            Console.WriteLine($"1. Ataque");
                            Console.WriteLine($"2. Monedas Generadas");
                            Console.WriteLine($"3. Vida");
                            select = Console.ReadLine();
                            if (int.TryParse(select, out selection))
                            {
                                switch (selection)
                                {
                                    case 1:
                                        UpgradePlayerAtackUnits(option);
                                        break;
                                    case 2:
                                        UpgradePlayerLifeUnits(option);
                                        break;
                                    case 3:
                                        UpgradePlayerRecolectionUnits(option);
                                        break;
                                    default:
                                        Console.WriteLine($"Esa no es una opción");
                                        Console.ReadLine();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Esa no es una opción");
                                Console.ReadLine();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Esa no es una opción");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine($"Esa opción no está disponible");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine($"Todavía no tiene unidades");
                Console.ReadLine();
            }
        }
        void UpgradePlayerAtackUnits(int index)
        {
            string conf;
            int confirm;
            Console.WriteLine($"Confirmar pagar 4 monedas");
            Console.WriteLine($"1. Sí");
            Console.WriteLine($"2. No");
            conf = Console.ReadLine();
            if (int.TryParse(conf, out confirm))
            {
                switch (confirm)
                {
                    case 1:
                        if (money >= 4)
                        {
                            playerUnitsList[index].UpgradeDmg(1);
                            money -= 4;
                        }
                        else
                        {
                            Console.WriteLine($"No tiene suficientes monedas");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine($"Canceló la compra");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine($"Esa no es una opción");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Esa no es una opción");
                Console.ReadLine();
            }
        }
        void UpgradePlayerLifeUnits(int index)
        {
            string conf;
            int confirm;
            Console.WriteLine($"Confirmar pagar 3 monedas");
            Console.WriteLine($"1. Sí");
            Console.WriteLine($"2. No");
            conf = Console.ReadLine();
            if (int.TryParse(conf, out confirm))
            {
                switch (confirm)
                {
                    case 1:
                        if (money >= 3)
                        {
                            playerUnitsList[index].UpgradeLife(1);
                            money -= 3;
                        }
                        else
                        {
                            Console.WriteLine($"No tiene suficientes monedas");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine($"Canceló la compra");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine($"Esa no es una opción");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Esa no es una opción");
                Console.ReadLine();
            }
        }
        void UpgradePlayerRecolectionUnits(int index)
        {
            string conf;
            int confirm;
            Console.WriteLine($"Confirmar pagar 3 monedas");
            Console.WriteLine($"1. Sí");
            Console.WriteLine($"2. No");
            conf = Console.ReadLine();
            if (int.TryParse(conf, out confirm))
            {
                switch (confirm)
                {
                    case 1:
                        if (money >= 3)
                        {
                            playerUnitsList[index].UpgradeMoney(1);
                            money -= 3;
                        }
                        else
                        {
                            Console.WriteLine($"No tiene suficientes monedas");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine($"Canceló la compra");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine($"Esa no es una opción");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Esa no es una opción");
                Console.ReadLine();
            }
        }

        void ShowPlayerUnits()
        {
            int position = 0;
            foreach (PlayerUnits playerUnit in playerUnitsList)
            {
                Console.WriteLine($"{position}. Unidad {position+1} tiene {playerUnit.GetLife()} de vida, hace {playerUnit.GetDmg()} de daño y genera {playerUnit.GetMoney()} de dinero");
                position++;
            }
        }
    }
}
