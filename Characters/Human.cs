using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageDemo.Characters
{
    // successful attack augment strength
    // successful defense augment constitution
    internal class Human : Character
    {
        public Human(string name, ConsoleColor consoleColor, int strength = 10, int agility = 10, int dexterity = 10, int constitution = 10, int life = 1000) : base(name, consoleColor, strength, agility, dexterity, constitution, life)
        {
            attackType = AttackType.NONE;
        }

        public override bool Attack(Character target)
        {
            bool attackResult = base.Attack(target);
            if (attackResult)
            {
                Strength++;
            }
            return attackResult;
        }

        public override bool Defend(Character attacker, int attackRoll)
        {
            bool defenseResult = base.Defend(attacker, attackRoll);
            if (defenseResult)
            {
                Constitution++;
            }
            return defenseResult;
        }
    }
}
