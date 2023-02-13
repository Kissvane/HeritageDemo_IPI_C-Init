using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageDemo.Characters
{
    internal class Character
    {
        public string Name { get; set; }
        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Dexterity { get;  private set; }
        public int Constitution { get; private set;}

        public int Life { get; private set; }

        public bool IsAlive => Life > 0;

        protected Random random;
        protected ConsoleColor color;

        public Character(string name, ConsoleColor consoleColor,int strength = 10, int agility = 10, int dexterity = 10, int constitution = 10, int life = 1000)
        {
            Name = name;
            Strength = strength;
            Agility = agility;
            Dexterity = dexterity;
            Constitution = constitution;
            Life = life;
            color = consoleColor;
            random = new Random(NameToInt(Name)+(int)DateTime.Now.Ticks);
        }

        public float RandomRoll()
        {
            return random.NextSingle()*2;
        }

        public int GetInitiative()
        {
            int initiative = (int)(Agility * Dexterity * RandomRoll());
            Console.ForegroundColor = color;
            Console.WriteLine($"{Name}'s initiative is {initiative}");
            //Console.ForegroundColor = ConsoleColor.White;
            return initiative;
        }

        public virtual void Attack(Character target)
        {
            if (!IsAlive) return;
            int attackRoll = (int)(Strength * Dexterity * RandomRoll());
            Console.ForegroundColor = color;
            Console.WriteLine($"{Name} attacks {target.Name} with {attackRoll}");
            //Console.ForegroundColor = ConsoleColor.White;
            target.Defend(this,attackRoll);
        }

        public virtual void Defend(Character attacker, int attackRoll)
        {
            int defenseRoll = (int)(Agility * Constitution * RandomRoll());
            int Damages = attackRoll - defenseRoll;
            string result = $"{Name} defends against {attacker.Name} attack with {defenseRoll}.";
            if (Damages > 0)
            {
                Life -= Damages;
                result += $" {Name} take {Damages} damages. Current life :{Life}.";
            }
            else
            {
                result += $" {Name}'s defense is successful.";
            }
            Console.ForegroundColor = color;
            Console.WriteLine(result);
            //Console.ForegroundColor = ConsoleColor.White;
        }

        protected int NameToInt(string name)
        {
            int result = 0;
            int letterIndex = 1;
            foreach (char c in name)
            {
                result += c * letterIndex;
                letterIndex++;
            }

            return result;
        }
    }
}
