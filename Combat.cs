using System;
using System.Collections.Generic;
using System.Text;

namespace HollowAbyssEngine
{
    internal static class Combat
    {
        // random seed for chance based interaction
        private static Random rng = new Random();

        // calculating physical damage
        public static void PhysicalAttack(Entity attacker, Entity defender)
        {
            TextEffects.TypeText($"{attacker.Name} attacks {defender.Name}");

            // 1. Evasion
            if (rng.NextDouble() < defender.Evasion)
            {
                TextEffects.TypeText("Attack missed!");
                return;
            }

            // 2. Base damage
            int damage = attacker.ATK;

            // 3. Crit 
            if (rng.NextDouble() < attacker.CritChance)
            {
                damage = (int)(damage * attacker.CritDamage);
                TextEffects.TypeText($"Critical Hit! {damage} damage dealt!");
            }

            // 4. DEF mitigation (LAST)
            damage -= defender.DEF;

            if (damage < 1)
                damage = 0;

            // 5. Apply damage
            defender.TakeDamage(damage);

            Thread.Sleep(1500);
        }

        // calculating magical damage
        public static void MagicAttack(Entity attacker, Entity defender, int baseDamage, double scalingMultiplier)
        {
            // 1. Evasion
            if (rng.NextDouble() < defender.Evasion)
            {
                TextEffects.TypeText("Spell missed!");
                return;
            }

            // 2. Base damage + spell scaling
            int scaledDamage = (int)((attacker.MAG * attacker.Potency) * scalingMultiplier);
            int damage = baseDamage + scaledDamage;

            // 3. DEF mitigation
            damage -= defender.DEF;

            if (damage < 1)
                damage = 0;

            // 4. Apply
            defender.TakeDamage(damage);

            Thread.Sleep(1500);
        }
    }
}