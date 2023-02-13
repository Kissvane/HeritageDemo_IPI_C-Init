using HeritageDemo.Characters;

Character character1 = new Character("Toto", ConsoleColor.Red);
Character character2 = new Character("Tata", ConsoleColor.Green);

while (character1.IsAlive && character2.IsAlive)
{
    int Initiative1 = character1.GetInitiative();
    int Initiative2 = character2.GetInitiative();
    Console.ForegroundColor = ConsoleColor.White;
    if (Initiative1 > Initiative2)
    {
        Console.WriteLine($"{character1.Name} attacks first !");
        character1.Attack(character2);
        character2.Attack(character1);
    }
    else
    {
        Console.WriteLine($"{character2.Name} attacks first !");
        character2.Attack(character1);
        character1.Attack(character2);
    }
}

Character winner = character1.IsAlive ? character1 : character2;

Console.WriteLine($"{winner.Name} win the fight");

