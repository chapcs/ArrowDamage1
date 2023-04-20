using System;
using System.Diagnostics;
using SwordDamage;

internal class Program
{
    static Random random = new Random();
    private static void Main(string[] args)
    {
        SwordDamage.SwordDamage sword = new SwordDamage.SwordDamage(RollDice(3));
        ArrowDamage arrow = new ArrowDamage(RollDice(1));

        while(true)
        {
            Console.Write("\n0 for no abilities, 1 for magic, 2 for flaming, 3 for both; press any other key to quit: ");
            char key = Console.ReadKey().KeyChar;
            if (key != '0' && key != '1' && key != '2' && key != '3') return;

            Console.Write("S for sword, A for arrow, anything else to quit: ");
            char weaponKey = Char.ToUpper(Console.ReadKey().KeyChar);
            // could use some if/else statements to pick between the two characters
            // instead we will use a switch statement designed to do this
            switch (weaponKey)
            {
                case 'S':
                    sword.Roll = RollDice(3);
                    sword.Magic = (key == '1' || key == '3');
                    sword.Flaming = (key == '2' || key == '3');
                    Console.WriteLine($"\nRolled {sword.Roll} for {sword.Damage} HP \n");
                    break;
                case 'A':
                    arrow.Roll = RollDice(1);
                    arrow.Magic = (key == '1' || key == '3');
                    arrow.Flaming = (key == '2' || key == '3');
                    Console.WriteLine($"\nRolled {arrow.Roll} for {arrow.Damage} HP \n");
                    break;
                default:
                    return;
            }
        }
    }
    static int RollDice(int numberOfRolls)
    {
        int roll = 0;
        for (int i = 0; i < numberOfRolls; i++)
        {
            roll += random.Next(1, 7);
        }
        return roll;
    }
}


class ArrowDamage
{
    private const decimal BASE_MULTIPLIER = 0.35M;
    private const decimal MAGIC_MULTIPLIER = 2.5M;
    private const decimal FLAME_DAMAGE = 1.25M;

    public int roll;
    public bool flaming;
    public bool magic;

    public int Damage { get; private set; }

    public ArrowDamage(int startingRoll)
    {
        roll = startingRoll;
        CalculateDamage();
    }

    public int Roll
    {
        get { return roll; }
        set
        {
            roll = value;
            CalculateDamage();
        }
    }

    private void CalculateDamage()
    {
        decimal baseDamage = Roll * BASE_MULTIPLIER;
        if (Magic) baseDamage *= MAGIC_MULTIPLIER;
        if (Flaming) baseDamage += FLAME_DAMAGE;
        Damage = (int)Math.Ceiling(baseDamage);

        Debug.WriteLine($"CalculateDamage finished: {Damage} (roll: {Roll})");
    }
    public bool Magic
    {
        get { return magic; }
        set
        {
            magic = value;
            CalculateDamage();
        }
    }
    public bool Flaming
    {
        get { return flaming; }
        set
        {
            flaming = value;
            CalculateDamage();
        }
    }
}
