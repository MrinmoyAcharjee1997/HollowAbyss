using System;
using System.Collections.Generic;
using System.Text;

namespace HollowAbyssEngine
{
    internal class NPC : Entity
    {
        // Encounter design data. Exact 0 and 100 are forced and guaranteed
        // escape outcomes respectively.
        public int EscapeBaseChance { get; }

        public NPC(string name, int vit, int str, int dex, int intel, int fai, int luck,
            int escapeBaseChance = 50)
            : base(name, EntityType.NPC, vit, str, dex, intel, fai, luck)
        {
            if (escapeBaseChance < 0 || escapeBaseChance > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(escapeBaseChance));
            }

            EscapeBaseChance = escapeBaseChance;
            RecalculateStats();
        }
    }
}
