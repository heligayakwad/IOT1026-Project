using System;
using System.Collections.Generic;

namespace MinotaurLabyrinth
{
    /// <summary>
    /// A static class that provides methods to create and initialize a labyrinth map with various features, such as an entrance, sword, traps, and monsters.
    /// </summary>
    public static class LabyrinthCreator
    {
        const int ScalingFactor = 16;
        static readonly Dictionary<Size, (int rows, int cols)> _mapSizeDimensions = new()
        {
            { Size.Small, (4, 4) },
            { Size.Medium, (6, 6) },
            { Size.Large, (8, 8) },
        };

        /// <summary>
        /// Initializes the labyrinth map with the specified size, and creates a new Hero at the entrance location.
        /// </summary>
        /// <param name="mapSize">The Size of the map to be created (Small, Medium, or Large).</param>
        /// <returns>A tuple containing the initialized Map and the Hero placed at the entrance location.</returns>
        public static (Map, Hero) InitializeMap(Size mapSize)
        {
            Map map = CreateMap(mapSize);
            ProceduralGenerator.Initialize(map);
            Location start = RandomizeMap(map);
            return (map, InitializePlayer(start));
        }

        
    }
}
