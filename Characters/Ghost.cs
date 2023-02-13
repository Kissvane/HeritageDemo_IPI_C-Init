using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageDemo.Characters
{
    // invulnerable to attack of type NONE
    internal class Ghost : Character
    {
        public Ghost(string name, ConsoleColor consoleColor, int strength = 10, int agility = 10, int dexterity = 10, int constitution = 10, int life = 1000) : base(name, consoleColor, strength, agility, dexterity, constitution, life)
        {

        }

        public override void TakeDamages(AttackType attackType, int Damages)
        {
            if (attackType == AttackType.NONE)
            {
                Console.WriteLine("{Name} is immune to NONE damages");
                return;
            }
            base.TakeDamages(attackType, Damages);
        }
    }
}
