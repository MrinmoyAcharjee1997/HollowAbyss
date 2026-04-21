using System;
using System.Collections.Generic;
using System.Text;

namespace HollowAbyssEngine
{
    internal static class GameUI
    {
        // Displays a single line of text instantly.
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Displays text without moving to a new line.
        public static void ShowInline(string message)
        {
            Console.Write(message);
        }

        // Adds a blank line for spacing.
        public static void NewLine()
        {
            Console.WriteLine();
        }

        // Clears the console window.
        public static void Clear()
        {
            Console.Clear();
        }

        // Waits for a single key press without requiring Enter.
        public static char GetSingleKeyInput(bool showPressedKey = true)
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char input = keyInfo.KeyChar;

            if (showPressedKey)
            {
                ShowMessage(input+"");
            }

            return input;
        }

        // Displays a numbered choice list and returns the selected key.
        public static char GetChoice(params string[] choices)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                ShowMessage($"{i + 1}. {choices[i]}");
            }

            ShowInline("Input: ");
            char input = GetSingleKeyInput();
            NewLine();

            return input;
        }

        // Pauses until the player presses any key.
        public static void WaitForAnyKey(string message = "Press any key to continue...")
        {
            ShowMessage(message);
            Console.ReadKey(true);
        }

        // Displays a formatted combat status line for one entity.
        public static void Status(Entity entity)
        {
            ShowMessage($"{entity.Name,-15} HP: {entity.HP,4}/{entity.MaxHP,-4} MP: {entity.Mana,4}/{entity.MaxMana,-4}");
        }

        // Displays the battle header at the start of a round.
        public static void ShowBattleHeader(Player player, NPC enemy, int round)
        {
            ShowMessage("---------------------------------------------------------------------");
            ShowMessage($"{player.Name} vs {enemy.Name} | ROUND : {round}");
            Status(player);
            Status(enemy);
            ShowMessage("---------------------------------------------------------------------");
        }
    }
}