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

            // 4. DEF mitigation. Physical armor has diminishing returns and
            // cannot fully negate a successful hit by itself.
            damage = ApplyDefenseMitigation(damage, defender.DEF, 100);
            damage = ApplyResistance(damage, defender.PhysicalResistance);

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

            // 3. Magic bypasses physical armor and is reduced by the target's
            // innate and equipment-based magical resistance instead.
            damage = ApplyResistance(damage, defender.MagicalResistance);

            // 4. Apply
            defender.TakeDamage(damage);

            Thread.Sleep(1500);
        }

        private static int ApplyDefenseMitigation(int damage, int defense, int mitigationConstant)
        {
            double damageMultiplier = mitigationConstant / (double)(mitigationConstant + defense);
            return Math.Max(1, (int)Math.Round(damage * damageMultiplier));
        }

        private static int ApplyResistance(int damage, double resistance)
        {
            // Supports future vulnerabilities as well as resistance, while
            // protecting the combat system from accidental immunity stacks.
            double clampedResistance = Math.Clamp(resistance, -0.75, 0.75);
            return Math.Max(1, (int)Math.Round(damage * (1 - clampedResistance)));
        }
    }
}
