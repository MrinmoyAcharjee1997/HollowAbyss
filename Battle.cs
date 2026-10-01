using System;
using System.Collections.Generic;
using System.Text;

namespace HollowAbyssEngine
{
    internal class Battle
    {
        private Player player;
        private NPC enemy;
        private int round;
        private bool escaped;
        private bool escapeLocked;

        // Shared RNG for enemy action selection.
        private static Random rng = new Random();

        public Battle(Player player, NPC enemy)
        {
            this.player = player;
            this.enemy = enemy;
            this.round = 1;
        }

        public void Run()
        {
            while (player.HP > 0 && enemy.HP > 0 && !escaped)
            {
                GameUI.Clear();
                GameUI.ShowBattleHeader(player, enemy, round);

                // Player acts first each round.
                TextEffects.TypeText("Your Turn...");
                PlayerTurn();

                if (escaped)
                {
                    break;
                }

                if (enemy.IsBlocking)
                {
                    enemy.EndBlock();
                }

                if (enemy.HP == 0)
                {
                    break;
                }

                // Enemy takes its turn after the player.
                TextEffects.TypeText("Enemy's Turn...");
                Thread.Sleep(2000);
                EnemyTurn();

                if (player.IsBlocking)
                {
                    player.EndBlock();
                }

                Thread.Sleep(3000);

                round++;
            }

            TextEffects.TypeText("");

            if (escaped)
            {
                TextEffects.TypeText($"{player.Name} escapes from {enemy.Name}.");
                ApplyEscapeLoss();
                GameUI.ShowMessage("---------------------------------------------------------------------");
            }
            else if (enemy.HP == 0)
            {
                TextEffects.TypeText($"{enemy.Name} perishes in battle!");
                TextEffects.TypeText($"Fight Concluded! {player.Name} wins!");
                GameUI.ShowMessage("---------------------------------------------------------------------");
                Thread.Sleep(5000);
            }
            else
            {
                TextEffects.TypeText($"{player.Name} perishes in battle!");
                TextEffects.TypeText($"Fight Concluded! {enemy.Name} wins!");
                GameUI.ShowMessage("---------------------------------------------------------------------");
                Thread.Sleep(5000);
            }
        }

        private void PlayerTurn()
        {
            bool validChoice = false;

            while (!validChoice)
            {
                GameUI.ShowMessage("Choose an action:");
                string escapeChoice = escapeLocked
                    ? "Escape (unavailable)"
                    : $"Escape ({GetEscapeChance()}%)";
                char input = GameUI.GetChoice("Physical Attack", "Cast Magic", "Block", "Parry (WIP)", "Use Item (WIP)", escapeChoice);

                GameUI.NewLine();

                switch (input)
                {
                    case '1':
                        Combat.PhysicalAttack(player, enemy);
                        validChoice = true;
                        break;

                    case '2':
                        validChoice = PlayerCastSpell();
                        break;

                    case '3':
                        PlayerBlock();
                        validChoice = true;
                        break;

                    case '6':
                        if (escapeLocked)
                        {
                            GameUI.ShowMessage("You have already failed to escape this battle.");
                            GameUI.Clear();
                        }
                        else
                        {
                            escaped = TryEscape();
                            escapeLocked = !escaped;
                            validChoice = true;
                        }
                        break;

                    default:
                        TextEffects.TypeText("Invalid action. Choose 1 or 2.");
                        Thread.Sleep(1500);
                        GameUI.Clear();
                        GameUI.ShowBattleHeader(player, enemy, round);
                        break;
                }
            }
        }

        private void EnemyTurn()
        {
            // Temporary enemy behavior:
            // randomly choose between physical and magic attack.
            EnemyChooseAction();
        }

        private void EnemyChooseAction()
        {
            bool lowHealth = enemy.HP <= (enemy.MaxHP / 4);
            bool canCastHeal = enemy.Mana >= Magic.Heal.ManaCost;

            // At low HP, enemy always tries to heal first.
            // If it cannot afford Heal, it blocks instead.
            if (lowHealth)
            {
                if (canCastHeal)
                {
                    Magic.CastSpell(Magic.Heal, enemy, enemy);
                }
                else
                {
                    EnemyBlock();
                }

                return;
            }

            // A healthy enemy should stay on the offensive. Defensive blocking
            // is reserved for the low-health fallback above.
            int choice = rng.Next(1, 3);

            switch (choice)
            {
                case 1:
                    Combat.PhysicalAttack(enemy, player);
                    break;

                case 2:
                    EnemyCastRandomSpell();
                    break;

                case 3:
                    EnemyBlock();
                    break;
            }
        }


        private Entity GetSpellTarget(Spell spell, Entity caster, Entity opponent)
        {
            switch (spell.Name)
            {
                case "Heal":
                    return caster;

                case "Soulrend":
                default:
                    return opponent;
            }
        }

        private bool PlayerCastSpell()
        {
            if (player.KnownSpells.Count == 0)
            {
                GameUI.ShowMessage($"{player.Name} does not know any spells.");
                return false;
            }

            GameUI.ShowMessage("Choose a spell:");

            for (int i = 0; i < player.KnownSpells.Count; i++)
            {
                Spell spell = player.KnownSpells[i];
                GameUI.ShowMessage($"{i + 1}. {spell.Name} ({spell.ManaCost} MP)");
            }

            GameUI.ShowInline("Your choice: ");
            char input = GameUI.GetSingleKeyInput();
            GameUI.NewLine();

            int spellIndex = (int)char.GetNumericValue(input) - 1;

            if (spellIndex < 0 || spellIndex >= player.KnownSpells.Count)
            {
                GameUI.ShowMessage("Invalid spell choice.");
                return false;
            }

            Spell selectedSpell = player.KnownSpells[spellIndex];

            if (player.Mana < selectedSpell.ManaCost)
            {
                GameUI.ShowMessage($"{player.Name} does not have enough mana to cast {selectedSpell.Name}.");
                return false;
            }

            Entity target = GetSpellTarget(selectedSpell, player, enemy);
            Magic.CastSpell(selectedSpell, player, target);

            return true;
        }

        private void EnemyCastRandomSpell()
        {
            bool fullHealth = enemy.HP == enemy.MaxHP;

            List<Spell> castableSpellsList = new List<Spell>();

            foreach (Spell spell in enemy.KnownSpells)
            {
                if (enemy.Mana >= spell.ManaCost &&
                    !(spell.Name == "Heal" && fullHealth))
                {
                    castableSpellsList.Add(spell);
                }
            }

            Spell[] castableSpells = castableSpellsList.ToArray();

            if (castableSpells.Length == 0)
            {
                GameUI.ShowMessage($"{enemy.Name} does not have a valid spell to cast.");
                Combat.PhysicalAttack(enemy, player);
                return;
            }

            Spell selectedSpell = castableSpells[rng.Next(castableSpells.Length)];
            Entity target = GetSpellTarget(selectedSpell, enemy, player);

            Magic.CastSpell(selectedSpell, enemy, target);
        }


        private void PlayerBlock()
        {
            player.StartBlock();
        }

        private void EnemyBlock()
        {
            enemy.StartBlock();
        }

        private int GetEscapeChance()
        {
            // Encounter difficulty establishes the base. Dexterity changes the
            // odds, while 0% and 100% remain authored, deterministic outcomes.
            if (enemy.EscapeBaseChance == 0 || enemy.EscapeBaseChance == 100)
            {
                return enemy.EscapeBaseChance;
            }

            int dexterityModifier = (player.Dexterity - enemy.Dexterity) * 2;
            return Math.Clamp(enemy.EscapeBaseChance + dexterityModifier, 5, 95);
        }

        private bool TryEscape()
        {
            int chance = GetEscapeChance();
            bool succeeded = rng.Next(100) < chance;

            TextEffects.TypeText(succeeded
                ? $"Escape succeeds ({chance}% chance)."
                : $"Escape fails ({chance}% chance)! {enemy.Name} can retaliate.");

            return succeeded;
        }

        private void ApplyEscapeLoss()
        {
            // TODO: Replace with a real loss when inventory and encounter
            // rewards exist (for example, forfeited rewards or dropped currency).
            GameUI.ShowMessage("You receive no rewards for escaping.");
        }
    }
}
