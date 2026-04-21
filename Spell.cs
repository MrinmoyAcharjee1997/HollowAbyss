using System;
using System.Collections.Generic;
using System.Text;

namespace HollowAbyssEngine
{
    internal class Spell
    {
        public string Name { get; private set; }
        public int ManaCost { get; private set; }

        public Spell(string name, int manaCost)
        {
            Name = name;
            ManaCost = manaCost;
        }
    }
}
