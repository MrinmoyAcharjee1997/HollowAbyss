using System;
using System.Collections.Generic;
using System.Text;

namespace HollowAbyssEngine
{
    internal class NPC : Entity
    {
        public NPC(string name, int vit, int str, int dex, int intel, int fai, int luck)
            : base(name, EntityType.NPC, vit, str, dex, intel, fai, luck)
        {
            RecalculateStats();
        }
    }
}