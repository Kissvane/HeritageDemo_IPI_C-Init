using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageDemo.Characters
{
    public enum AttackType { NONE = 0, FIRE = 1, WATER = 2, EARTH = 3, WIND = 4 };

    internal class Character
    {
        public string Name;
        public int Strength;
        public int Agility;
        public int Dexterity;
        public int Constitution;

        public AttackType attackType;

        public int Life;

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

        public int Initiative()
        {
            if (!IsAlive) return 0;
            int initiative = (int)(Agility * Dexterity * RandomInitiativeRoll());
            Console.ForegroundColor = color;
            Console.WriteLine($"{Name}'s initiative is {initiative}");
            //Console.ForegroundColor = ConsoleColor.White;
            return initiative;
        }

        public virtual bool Attack(Character target)
        {
            if (!IsAlive) return false;
            int attackRoll = (int)(Strength * Dexterity * RandomAttackRoll());
            Console.ForegroundColor = color;
            Console.WriteLine($"{Name} attacks {target.Name} with {attackRoll}");
            //Console.ForegroundColor = ConsoleColor.White;
            return !target.Defend(this,attackRoll);
        }
        public virtual float RandomDefenseRoll()
        {
            return RandomRoll();
        }

        public virtual float RandomAttackRoll()
        {
            return RandomRoll();
        }

        public virtual float RandomInitiativeRoll()
        {
            return RandomRoll();
        }

        public virtual bool Defend(Character attacker, int attackRoll)
        {
            if (!IsAlive) return false;
            bool defenseResult = false;
            int defenseRoll = (int)(Agility * Constitution * RandomDefenseRoll());
            int Damages = attackRoll - defenseRoll;
            string result = $"{Name} defends against {attacker.Name} attack with {defenseRoll}.";
            if (Damages > 0)
            {
                TakeDamages(attacker.attackType,Damages);
                result += $" {Name} take {Damages} damages. Current life :{Life}.";
            }
            else
            {
                result += $" {Name}'s defense is successful.";
                defenseResult = true;
            }
            Console.ForegroundColor = color;
            Console.WriteLine(result);
            //Console.ForegroundColor = ConsoleColor.White;
            return defenseResult;
        }

        public virtual void TakeDamages(AttackType attackType, int damages)
        {
            Life -= damages;
            Console.WriteLine($" {Name} take {damages} damages. Current life :{Life}.");
            if(this is I_Vulnerable vulnerable)
                ManageVulnerabilities(attackType, damages, this);
        }

        public void ManageVulnerabilities(AttackType attackType, int damages, Character vulnerable)
        {
            ((I_Vulnerable)vulnerable).Vulnerability(attackType, damages,vulnerable);
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
