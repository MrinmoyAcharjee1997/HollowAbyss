using System;
using System.Collections.Generic;
using System.Text;

namespace HollowAbyssEngine.Presets
{
    internal static class PlayerPresets
    {
        public static Player CreateWarrior()
        {
            Player warrior = new Player(
                name: "Warrior",
                vit: 38,
                str: 34,
                dex: 18,
                intel: 8,
                fai: 10,
                luck: 12);

            warrior.KnownSpells.Add(Magic.Soulrend);
            warrior.KnownSpells.Add(Magic.Heal);

            return warrior;
        }

        public static Player CreateKnight()
        {
            Player knight = new Player(
                name: "Knight",
                vit: 42,
                str: 26,
                dex: 14,
                intel: 16,
                fai: 12,
                luck: 10);

            knight.KnownSpells.Add(Magic.Soulrend);
            knight.KnownSpells.Add(Magic.Heal);

            return knight;
        }

        public static Player CreateRogue()
        {
            Player rogue = new Player(
               name: "Rogue",
               vit: 18,
               str: 18,
               dex: 36,
               intel: 12,
               fai: 8,
               luck: 26);

            rogue.KnownSpells.Add(Magic.Soulrend);
            rogue.KnownSpells.Add(Magic.Heal);

            return rogue;
        }

        public static Player CreateRanger()
        {
            Player ranger = new Player(
                name: "Ranger",
                vit: 24,
                str: 22,
                dex: 30,
                intel: 10,
                fai: 8,
                luck: 18);

            ranger.KnownSpells.Add(Magic.Soulrend);
            ranger.KnownSpells.Add(Magic.Heal);

            return ranger;
        }

        public static Player CreateMage()
        {
            Player mage = new Player(
                name: "Mage",
                vit: 14,
                str: 6,
                dex: 12,
                intel: 40,
                fai: 22,
                luck: 12);

            mage.KnownSpells.Add(Magic.Soulrend);
            mage.KnownSpells.Add(Magic.Heal);

            return mage;
        }

        public static Player CreateCleric()
        {
            Player cleric = new Player(
                name: "Cleric",
                vit: 24,
                str: 12,
                dex: 10,
                intel: 22,
                fai: 36,
                luck: 14);

            cleric.KnownSpells.Add(Magic.Soulrend);
            cleric.KnownSpells.Add(Magic.Heal);

            return cleric;
        }

        public static Player CreateBattlemage()
        {
            Player battlemage = new Player(
                name: "Battlemage",
                vit: 24,
                str: 20,
                dex: 16,
                intel: 32,
                fai: 14,
                luck: 12);

            battlemage.KnownSpells.Add(Magic.Soulrend);
            battlemage.KnownSpells.Add(Magic.Heal);

            return battlemage;
        }

        public static Player CreatePaladin()
        {
            Player paladin = new Player(
                name: "Paladin",
                vit: 34,
                str: 24,
                dex: 12,
                intel: 14,
                fai: 28,
                luck: 10);

            paladin.KnownSpells.Add(Magic.Soulrend);
            paladin.KnownSpells.Add(Magic.Heal);

            return paladin;
        }

        public static Player CreateAssassin()
        {
            Player assassin = new Player(
                name: "Assassin",
                vit: 16,
                str: 20,
                dex: 40,
                intel: 10,
                fai: 6,
                luck: 28);

            assassin.KnownSpells.Add(Magic.Soulrend);
            assassin.KnownSpells.Add(Magic.Heal);

            return assassin;
        }

        public static Player CreateWretch()
        {
            Player wretch = new Player(
               name: "Wretch",
               vit: 1,
               str: 1,
               dex: 1,
               intel: 1,
               fai: 1,
               luck: 1);

            /*
            Bro doesnt know any spells KEKW

            wretch.KnownSpells.Add(Magic.Soulrend);
            wretch.KnownSpells.Add(Magic.Heal);
            */

            return wretch;
        }

    }
}
