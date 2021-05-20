using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamageCalculatorFinal
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage(RollDice(3));                                                             // We create a new instance of the SwordDamage class. We specify how many dices should be rolled. The value of "total" then gets passed to the constructor, and the "startingRoll" gets set.
            ArrowDamage arrowDamage = new ArrowDamage(RollDice(1));                                                             // We create a new instance of the ArrowDamage class. We specify how many dices should be rolled. The value of "total" then gets passed to the constructor, and the "startingRoll" gets set. 

            while (true)
            {
                Console.WriteLine("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");       // The user first gets to choose if magic/flaming damage should get added. 
                char key = Console.ReadKey().KeyChar;

                if (key != '0' && key != '1' && key != '2' && key != '3') return;                                                   // If the user doesn't choose one of the options, the program quits. 

                Console.WriteLine("\nS for sword, A for arrow, anything else to quit: ");                                           // After the user has choosen if the weapon should be magic/flaming the user gets to choose which weapon to use. 
                char weaponKey = char.ToUpper(Console.ReadKey().KeyChar);

                switch (weaponKey)
                {
                    case 'S':                                                                                                       // If the user chooses 'S' for Sword, 3 dices gets rolled, magic/flaming damage gets applied (if chosen) then the final value of the Damage-field gets printed to console. 
                        swordDamage.Roll = RollDice(3);                                                                             // Anytime one of the Properties is set with a new value, the Property calls upon the CalculateDamage()-method. Depening on the weaponchoice, the overridden CalculateDamage()-method will be called. 
                        swordDamage.Magic = (key == '1' || key == '3');                                                             // So if the user presses 'S' for Sword, the overridden CalculateDamage()-method inside the SwordDamage-class will be used.
                        swordDamage.Flaming = (key == '2' || key == '3');
                        Console.WriteLine($"\nRolled {swordDamage.Roll} for {swordDamage.Damage} HP \n");
                        break;
                    case 'A':                                                                                                       // If the user chooses 'A' for Arrow, 1 dice gets rolled, magic/flaming damage gets applied (if chosen) then the final value of the Damage-field gets printed to console. 
                        arrowDamage.Roll = RollDice(1);                                                                             // Anytime one of the Properties is set with a new value, the Property calls upon the CalculateDamage()-method. Depening on the weaponchoice, the overridden CalculateDamage()-method will be called.
                        arrowDamage.Magic = (key == '1' || key == '3');                                                             // So if the user presses 'A' for Arrow, the overridden CalculateDamage()-method inside the ArrowDamage-class will be used.
                        arrowDamage.Flaming = (key == '2' || key == '3');
                        Console.WriteLine($"\nRolled {arrowDamage.Roll} for {arrowDamage.Damage} HP \n");
                        break;
                    default:
                        return;                                                                                                     // If the user doesn't choose one of the options, the program quits. 
                }

            }
        }

        /// <summary>
        /// The method rolls the specified amount of dices and returns the result of the dicerolls. 
        /// </summary>
        /// <param name="numberOfRolls">The number of dices to roll</param>
        /// <returns>The value of the dice/dices rolled</returns>
        private static int RollDice(int numberOfRolls)
        {                                                                                                                           // The method RollDice() takes the amount of dices to roll as a parameter. 
            int total = 0;

            for (int i = 0; i < numberOfRolls; i++)                                                                                 // The loop iterates as many times as the number of dices specified. 
            {
                total += random.Next(1, 7);                                                                                         // For every iteration of the loop a diceroll gets added to the variable "total". 
            }

            return total;                                                                                                           // The value of the variable "total" gets returned and stored in the Roll-field. 
        }

    }
}
