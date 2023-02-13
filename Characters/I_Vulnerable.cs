using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HeritageDemo.Characters
{


    internal interface I_Vulnerable
    {
        public Dictionary<AttackType, float> Vulnerabilities { get; }
        public int Vulnerability(AttackType attackType, int damages, Character vulnerable)
        {
            if (Vulnerabilities.ContainsKey(attackType))
            {
                int fireDamages = (int)(damages * Vulnerabilities[attackType]);
                vulnerable.Life -= fireDamages;
                Console.WriteLine($" {vulnerable.Name} take {fireDamages} vulnerability damages. Current life :{vulnerable.Life}.");
                return fireDamages;
            }
            return 0;
        }
    }
}
