using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageDemo.Characters
{
    //each kill double strength
    //vulnerable to fire
    internal class Nazgul : Character, I_Vulnerable
    {
        public Nazgul(string name, ConsoleColor consoleColor, int strength = 10, int agility = 10, int dexterity = 10, int constitution = 10, int life = 1000, float sensibilityMultiplicator = 1.5f) : base(name, consoleColor, strength, agility, dexterity, constitution, life)
        {

        }

        public Dictionary<AttackType, float> Vulnerabilities => new Dictionary<AttackType, float> { { AttackType.FIRE, 0.5f } };

        public override bool Attack(Character target)
        {
            if(!target.IsAlive || !IsAlive) return false;
            bool attackResult = base.Attack(target);
            if (!target.IsAlive) Strength *= 2;
            return attackResult;
        }
    }
}
