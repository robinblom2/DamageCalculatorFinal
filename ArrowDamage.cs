using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamageCalculatorFinal
{
    class ArrowDamage : WeaponDamage
    {

        private const decimal BASE_MULTIPLIER = 0.35M;                  // Since these constants aren't going to be used by any other class it makes sense to keep them private. 
        private const decimal MAGIC_MULTIPLIER = 2.5M;
        private const decimal FLAME_DAMAGE = 1.25M;


        /// <summary>
        /// The constructor calculates damage based on default Magic and Flaming values and a starting 3d6 roll.
        /// </summary>
        /// <param name="startingRoll"></param>
        public ArrowDamage(int startingRoll) : base(startingRoll)
        {
            // All the constructor needs to do is use the base keyword to call the superclass's constructor, using its startingRoll parameter as the argument.
        }


        /// <summary>
        /// Calculates the damage based on the current properties.
        /// </summary>
        protected override void CalculateDamage()
        {                                                                   // All of the calculation is encapsulated inside the CalculateDamage method. It only depends on the get accessors for the Roll, Magic, and Flaming properties. 

            decimal baseDamage = Roll * BASE_MULTIPLIER;                    // First calculate the base damage of an arrow attack. 

            if (Magic)
            {
                baseDamage *= MAGIC_MULTIPLIER;                             // If magic, then multiply the magic multiplier with the base damage. 
            }
            if (Flaming)
            {
                Damage += (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);     // If flaming, then add flame damage to the base damage, and round the result up. The method returns a decimal, so we need to cast it to an int and then add the result to the damage-field. 
            }
            else
            {
                Damage = (int)Math.Ceiling(baseDamage);                     // Else if no magic damage or flaming damage was added, just round the base damage up, cast it to an int and then add the result to the damage-field. 
            }

        }




    }

}

