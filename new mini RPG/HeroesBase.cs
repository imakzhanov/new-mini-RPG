using System;
using System.Collections.Generic;
using System.Text;

namespace new_mini_RPG
{
    class HeroesBase
    {
        
        public int HP;
        public int Damage;
        public string Name;
        public HeroesBase( int hp, int damage, string name)
        {            
            HP = hp;
            Damage = damage;
            Name = name;
        }
        public void Damaging(int damage)
        {
            if (HP <= damage)
            {
                HP = 0;
            }
            else
            {
                HP = HP - damage;
            }
            
        }
        
    }
}
