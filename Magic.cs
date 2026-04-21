using System;
using System.Collections.Generic;
using System.Text;

namespace HollowAbyssEngine
{
    internal static class Magic
    {
        public static readonly Spell Soulrend = new Spell("Soulrend", 12);
        public static readonly Spell Heal = new Spell("Heal", 10);

        public static void CastSpell(Spell spell, Entity caster, Entity target)
        {
            if (caster.Mana < spell.ManaCost)
            {
                GameUI.ShowMessage($"{caster.Name} does not have enough mana to cast {spell.Name}.");
                return;
            }

            caster.UseMana(spell.ManaCost);

            switch (spell.Name)
            {
                case "Soulrend":
                    CastSoulrend(caster, target);
                    break;

                case "Heal":
                    CastHeal(caster, target);
                    break;

                default:
                    GameUI.ShowMessage($"{spell.Name} has no effect implemented yet.");
                    break;
            }
        }

        private static void CastSoulrend(Entity caster, Entity target)
        {
            TextEffects.TypeText($"{caster.Name} casts Soulrend on {target.Name}...");
            Combat.MagicAttack(caster, target, 20, 0.35);
        }

        private static void CastHeal(Entity caster, Entity target)
        {
            int healAmount = 50 + (caster.MAG / 5) + (int)(caster.Potency * 10);

            TextEffects.TypeText($"{caster.Name} casts Heal...");
            target.Heal(healAmount);
            GameUI.ShowMessage($"{target.Name} recovers {healAmount} HP.");
        }
    }
}