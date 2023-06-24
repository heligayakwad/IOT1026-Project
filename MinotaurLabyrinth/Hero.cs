namespace MinotaurLabyrinth
{
    // Represents the player in the game.
    public class Hero
    {
        // Creates a new player that starts at the given location.
        public Hero(Location start) => Location = start;

        // Contains all the commands that a player can access.
        public CommandList CommandList { get; } = new CommandList();

        // Represents the distance the player can sense danger.
        // Diagonally adjacent squares have a range of 2 from the player.
        public int SenseRange { get; } = 1;

        // The player's current location.
        public Location Location { get; set; }

        // Indicates whether the player is alive or not.
        public bool IsAlive { get; private set; } = true;

        // Indicates whether the player has won the game or not.
        public bool IsVictorious { get; set; }

        // Indicates whether the player currently has the catacomb map.
        public bool HasMap { get; set; } = true;

        // Indicates whether the player currently has the sword.
        public bool HasSword { get; set; }

        // Explains why a player died.
        public string CauseOfDeath { get; private set; } = "";

        // The player's health points.
        public int HealthPoints { get; private set; } = 5;

        // The player's passive ability.
        public PassiveAbility? Passive { get; set; } = null;

        /// <summary>
        /// Damages the player by the given amount.
        /// If the player has the Iron Will passive, they will survive a lethal attack.
        /// If the player has the Divine Protection passive, they will survive any attack.
        /// If the player has the Parry passive, they will have a 50% chance to parry the attack.
        /// </summary>
        /// <param name="attackAmount">The amount of damage inflicted by the attack.</param>
        /// <param name="monsterName">The name of the attacking monster.</param>
        public void Damage(int attackAmount, string monsterName)
        {
            Random random = new Random();

            if (Passive == PassiveAbility.Parry && random.Next(1, 3) == 1)
            {
                ConsoleHelper.WriteLine("You parry the attack!", ConsoleColor.Yellow);
                Passive = null;
                return;
            }

            if (Passive == PassiveAbility.DivineProtection)
            {
                ConsoleHelper.WriteLine("You are protected by divine forces!", ConsoleColor.Yellow);
                Passive = null;
                return;
            }

            if (HealthPoints <= attackAmount && Passive == PassiveAbility.IronWill)
            {
                ConsoleHelper.WriteLine("Your will to live is too strong, you survive a lethal attack!", ConsoleColor.Yellow);
                Passive = null;
                return;
            }

            HealthPoints -= attackAmount;

            if (HealthPoints <= 0)
            {
                Kill(monsterName);
            }

            ConsoleHelper.WriteLine($"{monsterName} hits you for {attackAmount} of damage!", ConsoleColor.Red);
        }

        // Kills the player and sets the cause of death.
        public void Kill(string cause)
        {
            IsAlive = false;
            CauseOfDeath = cause;
            ConsoleHelper.WriteLine("You have died!", ConsoleColor.Red);
        }
    }
}
