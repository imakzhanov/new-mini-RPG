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
        
        public bool PlayerDeathCheck(int playerTarget)
        {
            bool death;
            if (Heroes[playerTarget].HP <= 0)
            {
                death = true;
            }
            else 
            {
                death = false;
            }
            return death;
        }
            //-----------------------------------------------------------------------------------------
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
        //-------------------------------------------------------------------------------------------атака
        public int GettingAttackingHeroDamage(int attackingHero)
        {
            return Heroes[attackingHero].Damage;
        }
        public string GettingAttackingHeroName(int attackingHero)
        {
            return Heroes[attackingHero].Name;
        }
        public void Attack(int target, int attackingHeroDamage, string attackingHeroName, string attackingTeamName, string targetTeamName)
        {
            Heroes[target].Damaging(attackingHeroDamage);
            AttackInfo(target, attackingHeroDamage, attackingHeroName, attackingTeamName, targetTeamName);
        }
        public void AttackInfo(int target, int attackingHeroDamage, string attackingHeroName, string attackingTeamName, string targetTeamName)
        {
            Console.WriteLine($"{attackingHeroName}({attackingTeamName}) нанес {attackingHeroDamage} урона {Heroes[target].Name}у({targetTeamName}).");
        }
            //-------------------------------------------------------------------------------------------атака
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
