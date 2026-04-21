using System;
using System.Collections.Generic;
using System.Text;
using static HollowAbyssEngine.Entity;

namespace HollowAbyssEngine
{
    internal class Program
    {
        internal int round = 1;
        static void Main(String[] args)
        {
            Console.WriteLine("Engine Initialized!");
            new Program().run();
            
        }

        public void run()
        {
            //These are preset player creation calls.
            Player P_Warrior     =   HollowAbyssEngine.Presets.PlayerPresets.CreateWarrior();
            Player P_Knight      =   HollowAbyssEngine.Presets.PlayerPresets.CreateKnight();
            Player P_Rogue       =   HollowAbyssEngine.Presets.PlayerPresets.CreateRogue();
            Player P_Ranger      =   HollowAbyssEngine.Presets.PlayerPresets.CreateRanger();
            Player P_Mage        =   HollowAbyssEngine.Presets.PlayerPresets.CreateMage();
            Player P_Cleric      =   HollowAbyssEngine.Presets.PlayerPresets.CreateCleric();
            Player P_Battlemage  =   HollowAbyssEngine.Presets.PlayerPresets.CreateBattlemage();
            Player P_Paladin     =   HollowAbyssEngine.Presets.PlayerPresets.CreatePaladin();
            Player P_Assassin    =   HollowAbyssEngine.Presets.PlayerPresets.CreateAssassin();
            Player P_Wretch      =   HollowAbyssEngine.Presets.PlayerPresets.CreateWretch();
            
            //These are preset enemy creation calls
            NPC E_Goblin       =   HollowAbyssEngine.Presets.NPCPresets.CreateGoblin();
            NPC E_Brute        =   HollowAbyssEngine.Presets.NPCPresets.CreateBrute();
            NPC E_Scout        =   HollowAbyssEngine.Presets.NPCPresets.CreateScout();
            NPC E_Bandit       =   HollowAbyssEngine.Presets.NPCPresets.CreateBandit();
            NPC E_Cultist      =   HollowAbyssEngine.Presets.NPCPresets.CreateCultist();
            NPC E_Knight       =   HollowAbyssEngine.Presets.NPCPresets.CreateKnight();
            NPC E_Assassin     =   HollowAbyssEngine.Presets.NPCPresets.CreateAssassin();
            NPC E_Slime        =   HollowAbyssEngine.Presets.NPCPresets.CreateSlime();
            NPC E_Skeleton     =   HollowAbyssEngine.Presets.NPCPresets.CreateSkeleton();
            NPC E_Shaman       =   HollowAbyssEngine.Presets.NPCPresets.CreateShaman();
            NPC E_Beast        =   HollowAbyssEngine.Presets.NPCPresets.CreateBeast();
            NPC E_EliteGuard   =   HollowAbyssEngine.Presets.NPCPresets.CreateEliteGuard();

            //Test case duo
            Player player = P_Knight;
            NPC enemy = E_Bandit;

            Battle battle = new Battle(player, enemy);
            battle.Run();
        }
    }
}