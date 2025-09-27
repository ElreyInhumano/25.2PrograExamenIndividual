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
        bool game;
        List<PlayerUnits> playerUnitsList = new List<PlayerUnits>();
        List<EnemyUnits> enemyUnitsList = new List<EnemyUnits>();
        IEnemyStrategy currentEnemyStrategy;
        public void StartGame()
        {
            playerUnits.SetPlayerUnitsInstance();
            enemyUnits.SetEnemyUnitsInstance();
            currentEnemyStrategy = new EnemyStrategy1(fibonacciIndex, enemyUnitsList);
            SetBasesLife();
            SetFuncsActions();
            SetGame();
        }
        public void SetGame()
        {
            game = true;
            turn = 1;
            while (game)
            {
                PlayerTurn();
                PlayerUnitsAttack();
                CheckBasesLife();
                Console.ReadLine();
                EnemyTurn();
                EnemyUnitsAttack();
                Console.ReadLine();
                CheckBasesLife();
                turn++;
            }
            
        }
        void SetBasesLife()
        {
            basePlayerLife = 30;
            baseEnemyLife = 30;
        }
        void CheckBasesLife()
        {
            if (basePlayerLife <= 0)
            {
                Console.WriteLine($"Lástima has perdido. Fin del juego. La partida duró {turn} de turnos");
                Console.ReadLine();
                game = false;
                return;
            }
            else if(baseEnemyLife <= 0)
            {
                Console.WriteLine($"Felicidades has ganado. Fin del juego.  La partida duró {turn} de turnos");
                Console.ReadLine();
                game = false;
                return;
            }
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
            GetPlayerMoney();   
            while (playerTurn)
            {
                Console.WriteLine($"Tienes {money} monedas");
                Console.WriteLine($"Escoge tu acción");
                Console.WriteLine($"1. Para comprar una unidad de ataque");
                Console.WriteLine($"2. Para comprar una unidad de recolección");
                Console.WriteLine($"3. Para mejorar una unidad");
                Console.WriteLine($"4. Para ver las unidades");
                Console.WriteLine($"5. Para ver las unidades del enemigo");
                Console.WriteLine($"6. Terminar");
                string opt;
                opt = Console.ReadLine();
                if(int.TryParse(opt, out chooseUnitOption))
                {
                    switch (chooseUnitOption)
                    {
                        case 1:
                            CreatePlayerAttackUnits();
                            break;
                        case 2:
                            CreatePlayerRecolectionUnits();
                            break;
                        case 3:
                            UpgradePlayerUnits();
                            break;
                        case 4:
                            if (playerUnitsList.Count > 0)
                            {
                                ShowPlayerUnits();
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"No tienes unidades");
                                Console.ReadLine();
                            }
                            break;
                        case 5:
                            if (enemyUnitsList.Count > 0)
                            {
                                ShowEnemyUnits();
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"El enemigo no tiene unidades");
                                Console.ReadLine();
                            }
                            break;
                        case 6:
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
        void CreatePlayerAttackUnits()
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
                            Console.WriteLine($"2. Vida");
                            Console.WriteLine($"3. Monedas Generadas");
                            select = Console.ReadLine();
                            if (int.TryParse(select, out selection))
                            {
                                switch (selection)
                                {
                                    case 1:
                                        UpgradePlayerAttackUnits(option);
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
                Console.WriteLine($"No tienes unidades");
                Console.ReadLine();
            }
        }
        void UpgradePlayerAttackUnits(int index)
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
        void PlayerUnitsAttack()
        {
            bool playerAttacking = true;
            List<PlayerUnits> unitsPlayerAttack = new List<PlayerUnits>();
            unitsPlayerAttack.Clear();
            for(int i = 0; i < playerUnitsList.Count; i++)
            {
                unitsPlayerAttack.Add(playerUnitsList[i]);
            }
            while(playerAttacking)
            {
                if(unitsPlayerAttack.Count > 0)
                {
                    if (enemyUnitsList.Count > 0)
                    {
                        Console.WriteLine("Tus unidades atacan a las unidades del enemigo");
                        for (int i = 0; i < unitsPlayerAttack.Count; i++)
                        {
                            if (enemyUnitsList.Count > 0 && unitsPlayerAttack.Count > 0)
                            {
                                enemyUnitsList[0].ReceiveDamage(unitsPlayerAttack[0].GetDmg());
                                unitsPlayerAttack.RemoveAt(0);
                                if(enemyUnitsList[0].GetLife() <= 0)
                                {
                                    enemyUnitsList.RemoveAt(0);
                                }
                            }
                        }
                    }
                    else
                    {
                        
                        Console.WriteLine("Tus unidades atacan a la base del enemigo");
                        for (int i = 0; i < unitsPlayerAttack.Count; i++)
                        {
                            int damageDealt = 0;
                            if (unitsPlayerAttack.Count > 0)
                            {
                                baseEnemyLife -= unitsPlayerAttack[0].GetDmg();
                                damageDealt += unitsPlayerAttack[0].GetDmg();
                                Console.WriteLine($"Tus unidades infligieron {damageDealt} a la base del enemigo");
                                Console.WriteLine($"A la base del enemigo le queda {baseEnemyLife} de vida");
                                unitsPlayerAttack.RemoveAt(0);
                            }                            
                        }
                        
                    }
                }
                else
                {
                    playerAttacking = false;
                }
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
        void ShowEnemyUnits()
        {
            int position = 0;
            foreach (EnemyUnits enemyUnit in enemyUnitsList)
            {
                Console.WriteLine($"{position}. Unidad {position + 1} tiene {enemyUnit.GetLife()} de vida, hace {enemyUnit.GetDmg()} de daño");
                position++;
            }
        }
        void GetPlayerMoney()
        {
            int moneyGenerated = 0;
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
            if(playerUnitsList.Count > 0)
            {
                foreach (PlayerUnits playerUnit in playerUnitsList)
                {
                    money += playerUnit.GetMoney();
                    moneyGenerated += playerUnit.GetMoney();
                }
                Console.WriteLine($"Tus unidades generaron {moneyGenerated} de dinero esta ronda");
            }            
        }

        float fibonacciIndex;
        void EnemyTurn()
        {
            Console.WriteLine($"Turn {turn}. Es turno del enemigo");
            Fibonacci();
            if (fibonacciIndex > 0)
            {
                if (fibonacciIndex % 2 == 0)
                {
                    currentEnemyStrategy = new EnemyStrategy1(fibonacciIndex, enemyUnitsList);
                    currentEnemyStrategy.CreateEnemyUnits();
                    Console.WriteLine($"El enemigo creó {fibonacciIndex} enemigos con {enemyUnitsList[enemyUnitsList.Count - 1].GetLife()} de vida y {enemyUnitsList[enemyUnitsList.Count - 1].GetDmg()} de daño");
                }
                else
                {
                    currentEnemyStrategy = new EnemyStrategy2(fibonacciIndex, enemyUnitsList);
                    currentEnemyStrategy.CreateEnemyUnits();
                    if(fibonacciIndex == 1)
                    {
                        Console.WriteLine($"El enemigo creó {fibonacciIndex} enemigo con {enemyUnitsList[enemyUnitsList.Count - 1].GetLife()} de vida y {enemyUnitsList[enemyUnitsList.Count - 1].GetDmg()} de daño");
                    }
                    else
                    {
                        Console.WriteLine($"El enemigo creó {fibonacciIndex} enemigos con {enemyUnitsList[enemyUnitsList.Count - 1].GetLife()} de vida y {enemyUnitsList[enemyUnitsList.Count - 1].GetDmg()} de daño");
                    }
                    
                }
            }
            else
            {
                Console.WriteLine($"El enemigo creó {fibonacciIndex} enemigos");
            }
        }
        void Fibonacci()
        {
            float a = 0, b = 1;
            for (int i = 0; i < turn; i++)
            {
                if (i <= 1)
                {
                    fibonacciIndex = i;
                    Console.WriteLine($"fibonacciIndex = {fibonacciIndex} ");
                }
                else
                {
                    fibonacciIndex = a + b;
                    a = b;
                    b = fibonacciIndex;
                    Console.WriteLine($"a = {a} ");
                    Console.WriteLine($"b = {b} ");
                    Console.WriteLine($"fibonacciIndex = {fibonacciIndex} ");
                }
            }
        }
        void EnemyUnitsAttack()
        {
            bool enemyAttacking = true;
            List<EnemyUnits> unitsEnemyAttack = new List<EnemyUnits>();
            unitsEnemyAttack.Clear();
            for (int i = 0; i < enemyUnitsList.Count; i++)
            {
                unitsEnemyAttack.Add(enemyUnitsList[i]);
            }
            while (enemyAttacking)
            {
                if (unitsEnemyAttack.Count > 0)
                {
                    if (playerUnitsList.Count > 0)
                    {
                        Console.WriteLine("Las unidades enemigas atacan a tus unidades");
                        for (int i = 0; i < unitsEnemyAttack.Count; i++)
                        {
                            if (unitsEnemyAttack.Count > 0 && playerUnitsList.Count > 0)
                            {
                                playerUnitsList[0].ReceiveDamage(unitsEnemyAttack[0].GetDmg());
                                unitsEnemyAttack.RemoveAt(0);
                                if (playerUnitsList[0].GetLife() <= 0)
                                {
                                    playerUnitsList.RemoveAt(0);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Las unidades enimgas atacan a tu base");
                        for (int i = 0; i < unitsEnemyAttack.Count; i++)
                        {
                            int damageDealt = 0;
                            if (unitsEnemyAttack.Count > 0)
                            {
                                basePlayerLife -= unitsEnemyAttack[0].GetDmg();
                                damageDealt += unitsEnemyAttack[0].GetDmg();
                                unitsEnemyAttack.RemoveAt(0);
                                Console.WriteLine($"Las unidades enemigas infligieron {damageDealt} a tu base");
                                Console.WriteLine($"A tu base le queda {basePlayerLife} de vida");
                            }
                        }
                        
                    }
                }
                else
                {
                    enemyAttacking = false;
                }
            }
        }
    }    
}
