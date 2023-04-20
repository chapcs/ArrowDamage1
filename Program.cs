using System;
using System.Diagnostics;
using SwordDamage;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("\nS for sword, A for arrow, anything else to quit: ");
        char weaponKey = Char.ToUpper(Console.ReadKey().KeyChar);
        // could use some if/else statements to pick between the two characters
        // instead we will use a switch statement designed to do this
        switch (weaponKey)
        {
            case 'S':
                /* calculate sword damage */
                break;
            case 'A':
                /* calculate arrow damage */
                break;
            default:
                return;
        }
    }
    private static void Main(string[] args)
    {
        SwordDamage sword = new SwordDamage(RollDice());

        while (true)
        {
            Console.Write("0 for no abilities, 1 for magic, 2 for flaming, 3 for both; press any other key to quit: ");
            char keyChar = Console.ReadKey().KeyChar; // the boolean in this line determines whether to intercept the character, optional to display in console; KeyChar selects the character to be stored in keyChar; ReadKey() defaults to false

            if (keyChar == '0' || keyChar == '1' || keyChar == '2' || keyChar == '3')
            {
                sword.Roll = RollDice();
                sword.Magic = (keyChar == '1' || keyChar == '3');
                sword.Flaming = (keyChar == '2' || keyChar == '3');
                Console.WriteLine($"\nRolled {sword.Roll} for {sword.Damage} HP \n");
            }
            else
            {
                return;
            }
        }
    }
    static int RollDice()
    {
        return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
    }
}

namespace ArrowDamage1
{
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
}