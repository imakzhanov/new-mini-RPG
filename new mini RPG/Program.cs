using System;

namespace new_mini_RPG
{
    class Program
    {
        public static int GetInt(int maxHeroCount)
        {
            int number = 0;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out number) || number <= 0 || number > maxHeroCount)
            {
                Console.WriteLine("Неправильный ввод:");
                input = Console.ReadLine();
            }
            number = number - 1;
            return number;
        }

        static void Main(string[] args)
        {
            int maxHeroSampleCount = 4;
            int maxHeroTeamCount = 3;
            Random randomGenerator = new Random();
            Teams yourTeam = new Teams();
            Teams computerTeam = new Teams();

            Console.Write("Придумай название своей команде: ");//-------------------------------Выбор названий команд
            yourTeam.Name = Console.ReadLine();
            computerTeam.Name = "Компьютер";
            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < 3; i++)//-----------------------------------------Выбор Игрока
            {
                bool flag = false;
                Console.WriteLine("Выберите персонажа:");
                Console.WriteLine("1 - Орк");
                Console.WriteLine("2 - Шаман");
                Console.WriteLine("3 - Воин");
                Console.WriteLine("4 - Маг");
                while (!flag)
                {
                    switch (GetInt(maxHeroSampleCount))
                    {
                        case 0:
                            {
                                HeroesBase hero = new Ork();
                                flag = yourTeam.HeroAdd(hero);
                                break;
                            }
                        case 1:
                            {
                                HeroesBase hero = new Shaman();
                                flag = yourTeam.HeroAdd(hero);
                                break;
                            }
                        case 2:
                            {
                                HeroesBase hero = new Knight();
                                flag = yourTeam.HeroAdd(hero);
                                break;
                            }
                        case 3:
                            {
                                HeroesBase hero = new Mag();
                                flag = yourTeam.HeroAdd(hero);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Ошибка!!!");
                                break;
                            }
                    }
                    if (flag)
                    {
                        Console.WriteLine("Вы добавили персонажа");
                        Console.Clear();
                    }
                }
            }
            Console.Clear();

            for (int i = 0; i < 3; i++)//--------------------------------------Выбор компьютера
            {
                bool flag = false;
                while (!flag)
                {
                    int number = randomGenerator.Next(4);
                    switch (number)
                    {
                        case 0:
                            {
                                HeroesBase hero = new Ork();
                                flag = computerTeam.HeroAdd(hero);
                                break;
                            }
                        case 1:
                            {
                                HeroesBase hero = new Shaman();
                                flag = computerTeam.HeroAdd(hero);
                                break;
                            }
                        case 2:
                            {
                                HeroesBase hero = new Knight();
                                flag = computerTeam.HeroAdd(hero);
                                break;
                            }
                        case 3:
                            {
                                HeroesBase hero = new Mag();
                                flag = computerTeam.HeroAdd(hero);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Ошибка!!!");
                                break;
                            }
                    }
                }
            }
            int a = 0;
            while (a == 0)//---------------------------------------------------------------основной цикл
            {
                Console.Clear();
                yourTeam.ShowInfo();
                computerTeam.ShowInfo();

                Console.WriteLine("Выбери, кем атаковать:");
                int attackingPlayerHero = GetInt(maxHeroTeamCount);
                bool death = yourTeam.PlayerDeathCheck(attackingPlayerHero);
                while (death != false)
                {
                    Console.WriteLine("Ваш герой уже мертв.");
                    Console.WriteLine("Выбери, кем атаковать:");
                    attackingPlayerHero = GetInt(maxHeroTeamCount);
                    death = yourTeam.PlayerDeathCheck(attackingPlayerHero);
                }
                Console.WriteLine("Выбери, кого атаковать:");
                int playerTarget = GetInt(maxHeroTeamCount);
                death = computerTeam.PlayerDeathCheck(playerTarget);
                while (death != false)
                {
                    Console.WriteLine("Цель уже мертва.");
                    Console.WriteLine("Выбери, кого атаковать:");
                    playerTarget = GetInt(maxHeroTeamCount);
                    death = computerTeam.PlayerDeathCheck(playerTarget);
                }
                int yourAttackingHeroDamage = yourTeam.GettingAttackingHeroDamage(attackingPlayerHero);
                string yourAttackingHeroName = yourTeam.GettingAttackingHeroName(attackingPlayerHero);
                Console.Clear();
                computerTeam.Attack(playerTarget, yourAttackingHeroDamage, yourAttackingHeroName, yourTeam.Name, computerTeam.Name);//-------------атака игрока
                Console.WriteLine("Для продолжения нажмите Enter...");
                Console.ReadLine();
                Console.Clear();

                int attackingComputerHero = randomGenerator.Next(3);
                death = computerTeam.ComputerDeathCheck(attackingComputerHero);
                while (death != false)
                {
                    attackingComputerHero = randomGenerator.Next(3);
                    death = computerTeam.ComputerDeathCheck(attackingPlayerHero);
                }
                int computerTarget = randomGenerator.Next(3);
                death = yourTeam.ComputerDeathCheck(computerTarget);
                while (death != false)
                {
                    computerTarget = randomGenerator.Next(3);
                    death = yourTeam.ComputerDeathCheck(computerTarget);
                }
                int computerAttackingHeroDamage = computerTeam.GettingAttackingHeroDamage(attackingComputerHero);
                string computerAttackingHeroName = computerTeam.GettingAttackingHeroName(attackingComputerHero);
                Console.Clear();
                yourTeam.Attack(computerTarget, computerAttackingHeroDamage, computerAttackingHeroName, computerTeam.Name, yourTeam.Name);//-------------атака компьютера
                Console.WriteLine("Для продолжения нажмите Enter...");
                Console.ReadLine();
            }


        }
    }
}
