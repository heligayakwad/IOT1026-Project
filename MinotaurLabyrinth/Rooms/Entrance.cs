namespace MinotaurLabyrinth
{
    // Represents a divine room in the labyrinth.
    public class Divine : Room
    {
        static Divine()
        {
            RoomFactory.Instance.Register(RoomType.Divine, () => new Divine());
        }

        public override RoomType Type { get; } = RoomType.Divine;

        // Returns the display details of the divine room.
        public override DisplayDetails Display()
        {
            return new DisplayDetails($"[{Type.ToString()[0]}]", ConsoleColor.Yellow);
        }

        // Generates a random passive ability for the player.
        public static PassiveAbility GetRandomPassiveAbility()
        {
            int random = RandomNumberGenerator.Next(1, 5);
            return random switch
            {
                1 => PassiveAbility.IronWill,
                2 => PassiveAbility.DivineProtection,
                3 => PassiveAbility.Parry,
                4 => PassiveAbility.NullifyDeath
            };
        }

        // Displays the sense information for the divine room.
        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (heroDistance == 0)
            {
                if (hero.Passive != null)
                    ConsoleHelper.WriteLine("This is the divine room, but you've already picked up the ability!", ConsoleColor.Yellow);
                else
                    ConsoleHelper.WriteLine("You can sense a divine presence in the room!", ConsoleColor.Yellow);
                return true;
            }
            return false;
        }
    }
}
