using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamageCalculatorFinal
{
    class WeaponDamage
    {
        public int Damage { get; protected set; }           // The Damage property's get accessor needs to be marked protected. That way the subclasses have access to update it, but no other class can set it. It's still protected from other classes accidentally setting it, so the subclasses will still be well-encapsulated.

        private int roll;
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();                          // The properties still call the CalculateDamage()-method, which keeps the Damage property updated. Even though the Properties are defined in the superclass, when they're inherited by a subclass they call the CalculateDamage()-method defined in that subclass. 
            }
        }

        private bool magic;
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();                          // The properties still call the CalculateDamage()-method, which keeps the Damage property updated. Even though the Properties are defined in the superclass, when they're inherited by a subclass they call the CalculateDamage()-method defined in that subclass.
            }
        }

        private bool flaming;
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();                          // The properties still call the CalculateDamage()-method, which keeps the Damage property updated. Even though the Properties are defined in the superclass, when they're inherited by a subclass they call the CalculateDamage()-method defined in that subclass.
            }
        }

        protected virtual void CalculateDamage()
        {
            Console.WriteLine("This text will never get printed");
            // This method is empty because the sub-classes overrides this method, so it will never be called. 
        }

        public WeaponDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }

    }
}
