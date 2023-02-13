using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageDemo.Characters
{
    // defense X * 2 attack / 2
    internal class Hobbit : Character
    {
        public Hobbit(string name, ConsoleColor consoleColor, int strength = 10, int agility = 10, int dexterity = 10, int constitution = 10, int life = 1000) : base(name, consoleColor, strength, agility, dexterity, constitution, life)
        {
            attackType = AttackType.FIRE;
        }

        public override float RandomAttackRoll()
        {
            return base.RandomAttackRoll() / 2;
        }

        public override float RandomDefenseRoll()
        {
            return base.RandomDefenseRoll() * 2;
        }


    }
}
