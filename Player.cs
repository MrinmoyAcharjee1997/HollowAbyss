using System;
using System.Collections.Generic;
using System.Text;

namespace HollowAbyssEngine
{
    internal class Player : Entity
    {
        public Player(string name, int vit, int str, int dex, int intel, int fai, int luck)
            : base(name, EntityType.Player, vit, str, dex, intel, fai, luck)
        {
            RecalculateStats();
        }
    }
}