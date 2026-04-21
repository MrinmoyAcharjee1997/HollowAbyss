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
            while (player.HP > 0 && enemy.HP > 0)
            {
                GameUI.Clear();
                GameUI.ShowBattleHeader(player, enemy, round);

                // Player acts first each round.
                TextEffects.TypeText("Your Turn...");
                PlayerTurn();

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

            if (enemy.HP == 0)
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
                char input = GameUI.GetChoice("Physical Attack", "Cast Magic", "Block", "Parry (WIP)", "Use Item (WIP)", "Escape (WIP)");

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

            // Normal behavior: randomly choose between
            // physical attack, spell cast, or block.
            int choice = rng.Next(1, 4);

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

            GameUI.ShowInline("Input: ");
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
    }
}
