using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamageCalculatorFinal
{
    class SwordDamage : WeaponDamage
    {
        private const int BASE_DAMAGE = 3;                  // Since these constants aren't going to be used by any other class it makes sense to keep them private. 
        private const int FLAME_DAMAGE = 2;


        /// <summary>
        /// The constructor calculates damage based on default Magic and Flaming values and a starting 3d6 roll.
        /// </summary>
        /// <param name="startingRoll"></param>
        public SwordDamage(int startingRoll) : base(startingRoll) 
        {
            // All the constructor needs to do is use the base keyword to call the superclass's constructor, using its startingRoll parameter as the argument. 
        }


        /// <summary>
        /// Calculates the damage based on the current properties.
        /// </summary>
        protected override void CalculateDamage()
        {                                                   // All of the calculation is encapsulated inside the CalculateDamage method. It only depends on the get accessors for the Roll, Magic, and Flaming properties. 
            decimal magicMultiplier = 1M;

            if (Magic)
            {
                magicMultiplier = 1.75M;
            }

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;

            if (Flaming)
            {
                Damage += FLAME_DAMAGE;
            }
        }




    }
}
