using System;
using System.Collections.Generic;
using MinotaurLabyrinth.Monsters;

namespace MinotaurLabyrinth
{
    public static class LabyrinthCreator
    {
        private const int ScalingFactor = 16;

        private static readonly Dictionary<Size, (int rows, int cols)> _mapSizeDimensions = new()
        {
            { Size.Small, (4, 4) },
            { Size.Medium, (6, 6) },
            { Size.Large, (8, 8) },
        };

        public static (Map, Hero) InitializeMap(Size mapSize)
        {
            Map map = CreateMap(mapSize);
            ProceduralGenerator.Initialize(map);
            Location start = RandomizeMap(map);
            return (map, InitializePlayer(start));
        }

        private static Map CreateMap(Size mapSize)
        {
            if (!_mapSizeDimensions.TryGetValue(mapSize, out var dimensions))
            {
                throw new ArgumentException("Unknown map size");
            }

            return new Map(dimensions.rows, dimensions.cols);
        }

        private static Location RandomizeMap(Map map)
        {
            Location start = PlaceEntrance(map);
            PlaceRoom(map, RoomType.Sword, start);
            PlaceRoom(map, RoomType.Divine, start);
            AddRooms(RoomType.Pit, map);
            InitializeMonsters(map);
            return start;
        }

        private static void PlaceRoom(Map map, RoomType roomType, Location start)
        {
            Location roomLocation = ProceduralGenerator.GetRandomLocationNotAdjacentTo(start);
            map.SetRoomAtLocation(roomLocation, roomType);
        }

        private static Location PlaceEntrance(Map map)
        {
            Location start = ProceduralGenerator.GetRandomEdgeLocation(map);
            map.SetRoomAtLocation(start, RoomType.Entrance);
            return start;
        }

        private static void AddRooms(RoomType roomType, Map map, int multiplier = 1)
        {
            int numRooms = map.Rows * map.Columns * multiplier / ScalingFactor;
            for (int i = 0; i < numRooms; ++i)
            {
                map.SetRoomAtLocation(ProceduralGenerator.GetRandomLocation(), roomType);
            }
        }

        private static Hero InitializePlayer(Location start)
        {
            return new Hero(start);
        }

        private static void InitializeMonsters(Map map)
        {
            Location minotaurLocation = ProceduralGenerator.GetRandomLocation();
            Room room = map.GetRoomAtLocation(minotaurLocation);
            room.AddMonster(new Minotaur());

            Location mimicLocation = ProceduralGenerator.GetRandomLocation();
            Room room2 = map.GetRoomAtLocation(mimicLocation);
            room2.AddMonster(new Mimic());
        }
    }
}
