using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageDemo.Characters
{
    // random entre 0,5 et 2,5 pour la defense
    internal class Elve : Character
    {
        

        public Elve(string name, ConsoleColor consoleColor, int strength = 10, int agility = 10, int dexterity = 10, int constitution = 10, int life = 1000) 
            : base(name, consoleColor, strength, agility, dexterity, constitution, life)
        {
            attackType = AttackType.WIND;
        }

        public override float RandomDefenseRoll()
        {
            return random.NextSingle() * 2 + 0.5f;
        }
    }
}
