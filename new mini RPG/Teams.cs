using System;
using System.Collections.Generic;
using System.Text;

namespace new_mini_RPG
{
    class Teams
    {
        public string Name;
        private List<HeroesBase> Heroes;
        public Teams()
        {
            Heroes = new List<HeroesBase>();
        }
        public bool HeroAdd(HeroesBase hero)
        {
            Type t = hero.GetType();
            for (int i = 0; i < Heroes.Count; i++)
            {
                Type t1 = Heroes[i].GetType();
                if (t == t1)
                {
                    Console.WriteLine("Герой уже Выбран.");
                    return false;
                }
            }
            Heroes.Add(hero);
            return true;
        }
            //----------------------------------------------------------------------------------------
        public int GettingYourAttackingHeroDamage(int attackingPlayerHero)
        {
            return Heroes[attackingPlayerHero - 1].Damage;
        }
        public string GettingYourAttackingHeroName(int attackingPlayerHero)
        {
            return Heroes[attackingPlayerHero - 1].Name;
        }
        public bool PlayerDeathCheck(int playerTarget)
        {
            bool death;
            if (Heroes[playerTarget - 1].HP <= 0)
            {
                death = true;
            }
            else 
            {
                death = false;
            }
            return death;
        }
        public void YourAttack(int playerTarget,int yourAttackingHeroDamage,string yourAttackingHeroName)
        {
            Heroes[playerTarget - 1].Damaging(yourAttackingHeroDamage);
            YourAttackInfo(playerTarget, yourAttackingHeroDamage, yourAttackingHeroName);
        }
        public void YourAttackInfo(int playerTarget, int yourAttackingHeroDamage, string yourAttackingHeroName)
        {
            Console.WriteLine($"Ваш {yourAttackingHeroName} нанес {yourAttackingHeroDamage} урона {Heroes[playerTarget - 1].Name}у компьютера.");
        }
            //-----------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------
        public int GettingComputerAttackingHeroDamage(int attackingComputerHero)
        {
            return Heroes[attackingComputerHero].Damage;
        }
        public string GettingComputerAttackingHeroName(int attackingComputerHero)
        {
            return Heroes[attackingComputerHero].Name;
        }
        public bool ComputerDeathCheck(int computerTarget)
        {
            bool death;
            if (Heroes[computerTarget].HP <= 0)
            {
                death = true;
            }
            else
            {
                death = false;
            }
            return death;
        }
        public void ComputerAttack(int computerTarget, int computerAttackingHeroDamage, string computerAttackingHeroName)
        {
            Heroes[computerTarget].Damaging(computerAttackingHeroDamage);
            ComputerAttackInfo(computerTarget, computerAttackingHeroDamage, computerAttackingHeroName);
        }
        public void ComputerAttackInfo(int computerTarget, int computerAttackingHeroDamage, string computerAttackingHeroName)
        {
            Console.WriteLine($"{computerAttackingHeroName} компьютера нанес {computerAttackingHeroDamage} урона вашему {Heroes[computerTarget].Name}у.");
        }
            //-------------------------------------------------------------------------------------------
        public void ShowInfo()
        {
            Console.WriteLine("----------");
            Console.WriteLine($"Команда:{Name}");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i + 1}) Герой:{Heroes[i].Name}|");
                Console.Write($"Урон:{Heroes[i].Damage}|");
                Console.WriteLine($"Здоровье:{Heroes[i].HP}");
            }
            Console.WriteLine("----------");
        }
    }
}
