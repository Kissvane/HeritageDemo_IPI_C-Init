using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageDemo.Characters
{
    // vulnerable to fire
    internal class Orc : Character, I_Vulnerable
    {
        public Orc(string name, ConsoleColor consoleColor, int strength = 10, int agility = 10, int dexterity = 10, int constitution = 10, int life = 1000) : base(name, consoleColor, strength, agility, dexterity, constitution, life)
        {
        }

        public Dictionary<AttackType, float> Vulnerabilities => new Dictionary<AttackType, float> { { AttackType.FIRE, 0.5f } };
    }
}
