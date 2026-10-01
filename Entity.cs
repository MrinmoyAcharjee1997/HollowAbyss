using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace HollowAbyssEngine
{
    abstract class Entity
    {
        // ===== Identity =====
        public string Name { get; protected set; }
        public enum EntityType {Player, NPC}
        public EntityType Type { get; protected set; }

        // ===== Attributes =====
        protected int VIT { get; set; }
        protected int STR { get; set; }
        protected int DEX { get; set; }
        protected int INT { get; set; }
        protected int FAI { get; set; }
        protected int LUCK { get; set; }

        // ===== Derived Stats =====
        public int HP { get; protected set; }
        public int MaxHP { get; protected set; }
        public int Mana { get; protected set; }
        public int MaxMana { get; protected set; }
        public int ATK { get; protected set; }
        public int MAG { get; protected set; }
        public int DEF { get; protected set; }
        public int Dexterity => DEX;

        // Resistance values are decimal percentages: 0.15 represents 15%.
        // Equipment, passives, and status effects can modify these later.
        public double PhysicalResistance { get; protected set; }
        public double MagicalResistance { get; protected set; }
        public double StatusResistance { get; protected set; }

        public double CritChance { get; protected set; }
        public double CritDamage { get; protected set; }
        public double Evasion { get; protected set; }
        public double Potency { get; protected set; }
        public double ItemDropRate { get; protected set; }

        // Spells this entity can cast.
        public List<Spell> KnownSpells { get; protected set; } = new List<Spell>();

        // Stance
        public bool IsBlocking { get; protected set; }


        protected Entity(string name, EntityType entityType, int vit, int str, int dex, int intel, int fai, int luck)
        {
            Name = name;
            Type = entityType;

            VIT = vit;
            STR = str;
            DEX = dex;
            INT = intel;
            FAI = fai;
            LUCK = luck;
        }

        protected void RecalculateStats()
        {
            // HP
            MaxHP = (10 * VIT) + (2 * STR) + (2 * DEX);
            HP = MaxHP;

            // Mana
            MaxMana = 10 * INT;
            Mana = MaxMana;

            // ATK
            ATK = (5 * STR) + (3 * DEX);

            // MAG
            MAG = 5 * INT;

            // DEF
            DEF = (2 * VIT) + (2 * STR);

            // Resistance
            // Physical resistance is reserved for gear, traits, and buffs.
            PhysicalResistance = 0;

            // Magical resistance represents an entity's innate warding. Gear
            // and magical effects can add to it later.
            MagicalResistance = (0.004 * FAI) + (0.0005 * INT);

            // Placeholder until the status-effect system is implemented.
            StatusResistance = 0;

            // Percent-based stats
            CritChance = (0.003 * DEX) + (0.007 * LUCK);
            CritDamage = 1.5 + (0.01 * DEX);

            Evasion = (0.008 * DEX) + (0.004 * LUCK);
            Potency = 1 + (0.05 * FAI);

            ItemDropRate = 0.01 * LUCK;
        }

        public void TakeDamage(int damage)
        {
            if (IsBlocking)
            {
                int blockValue = 30 + (DEF / 2);

                GameUI.ShowMessage($"{Name} blocks {blockValue} damage!");

                damage -= blockValue;

                if (damage < 0)
                {
                    damage = 0;
                }
            }

            TextEffects.TypeText($"{Name} takes {damage} damage.");

            HP -= damage;

            if (HP < 0)
            {
                HP = 0;
            }
        }


        public void Heal(int amount)
        {
            HP += amount;
            if (HP > MaxHP) HP = MaxHP;
        }

        public void UseMana(int amount)
        {
            Mana -= amount;
            if (Mana < 0) Mana = 0;
        }

        public bool HasEnoughMana(int amount)
        {
            return Mana >= amount;
        }

        public void StartBlock()
        {
            IsBlocking = true;
            TextEffects.TypeText($"{Name} raises their guard...");
        }

        public void EndBlock()
        {
            IsBlocking = false;
        }
    }
}
