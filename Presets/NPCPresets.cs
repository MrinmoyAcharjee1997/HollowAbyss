using System;
using System.Collections.Generic;
using System.Text;

namespace HollowAbyssEngine.Presets
{
    internal static class NPCPresets
    {
        public static NPC CreateGoblin()
        {
            NPC goblin = new NPC(
                name: "Goblin",
                vit: 18,
                str: 22,
                dex: 16,
                intel: 8,
                fai: 6,
                luck: 12);

            goblin.KnownSpells.Add(Magic.Soulrend);
            goblin.KnownSpells.Add(Magic.Heal);

            return goblin;
        }

        public static NPC CreateBrute()
        {
            NPC brute = new NPC(
                name: "Brute",
                vit: 42,
                str: 38,
                dex: 10,
                intel: 4,
                fai: 4,
                luck: 8);

            brute.KnownSpells.Add(Magic.Soulrend);
            brute.KnownSpells.Add(Magic.Heal);

            return brute;
        }

        public static NPC CreateScout()
        {
            NPC scout = new NPC(
                name: "Scout",
                vit: 14,
                str: 16,
                dex: 34,
                intel: 10,
                fai: 6,
                luck: 22);

            scout.KnownSpells.Add(Magic.Soulrend);
            scout.KnownSpells.Add(Magic.Heal);

            return scout;
        }

        public static NPC CreateBandit()
        {
            NPC bandit = new NPC(
                name: "Bandit",
                vit: 20,
                str: 24,
                dex: 20,
                intel: 10,
                fai: 8,
                luck: 18);

            bandit.KnownSpells.Add(Magic.Soulrend);
            bandit.KnownSpells.Add(Magic.Heal);

            return bandit;
        }

        public static NPC CreateCultist()
        {
            NPC cultist = new NPC(
                name: "Cultist",
                vit: 12,
                str: 8,
                dex: 14,
                intel: 34,
                fai: 28,
                luck: 16);

            cultist.KnownSpells.Add(Magic.Soulrend);
            cultist.KnownSpells.Add(Magic.Heal);

            return cultist;
        }

        public static NPC CreateKnight()
        {
            NPC knight = new NPC(
               name: "Knight",
               vit: 36,
               str: 24,
               dex: 14,
               intel: 20,
               fai: 10,
               luck: 12);

            knight.KnownSpells.Add(Magic.Soulrend);
            knight.KnownSpells.Add(Magic.Heal);

            return knight;
        }

        public static NPC CreateAssassin()
        {
            NPC assassin = new NPC(
               name: "Assassin",
               vit: 12,
               str: 18,
               dex: 38,
               intel: 14,
               fai: 8,
               luck: 30);

            assassin.KnownSpells.Add(Magic.Soulrend);
            assassin.KnownSpells.Add(Magic.Heal);

            return assassin;
        }

        public static NPC CreateSlime()
        {
            NPC slime = new NPC(
                name: "Slime",
                vit: 30,
                str: 10,
                dex: 6,
                intel: 4,
                fai: 4,
                luck: 6);

            slime.KnownSpells.Add(Magic.Soulrend);
            slime.KnownSpells.Add(Magic.Heal);

            return slime;
        }

        public static NPC CreateSkeleton()
        {
            NPC skeleton = new NPC(
               name: "Skeleton",
               vit: 24,
               str: 22,
               dex: 18,
               intel: 8,
               fai: 4,
               luck: 10);

            skeleton.KnownSpells.Add(Magic.Soulrend);
            skeleton.KnownSpells.Add(Magic.Heal);

            return skeleton;
        }

        public static NPC CreateShaman()
        {
            NPC shaman = new NPC(
                name: "Shaman",
                vit: 16,
                str: 10,
                dex: 12,
                intel: 38,
                fai: 24,
                luck: 14);

            shaman.KnownSpells.Add(Magic.Soulrend);
            shaman.KnownSpells.Add(Magic.Heal);

            return shaman;
        }

        public static NPC CreateBeast()
        {
            NPC beast = new NPC(
                name: "Beast",
                vit: 28,
                str: 30,
                dex: 22,
                intel: 4,
                fai: 2,
                luck: 12);

            beast.KnownSpells.Add(Magic.Soulrend);
            beast.KnownSpells.Add(Magic.Heal);

            return beast;
        }

        public static NPC CreateEliteGuard()
        {
            NPC eliteGuard = new NPC(
                name: "Elite Guard",
                vit: 40,
                str: 28,
                dex: 20,
                intel: 18,
                fai: 12,
                luck: 16);

            eliteGuard.KnownSpells.Add(Magic.Soulrend);
            eliteGuard.KnownSpells.Add(Magic.Heal);

            return eliteGuard;
        }

    }
}
