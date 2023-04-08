using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Main method that calculates the the sword damage based off different params
/// </summary>
namespace SwordDamage
{
    class SwordDamage
    {
        public const int BASE_DAM = 3;
        public const int FLAME_DAM = 2;

        public int roll;
        public bool flaming;
        public bool magic;

        public int Damage { get; private set; }

        public SwordDamage(int startingRoll)
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
            decimal MagicMult = 1M;
            if (Magic) MagicMult = 1.75M;

            Damage = (int)(Roll * MagicMult) + BASE_DAM;
            if (Flaming) Damage += FLAME_DAM;
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
