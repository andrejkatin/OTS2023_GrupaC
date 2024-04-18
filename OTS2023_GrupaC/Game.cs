using OTS2023_GrupaC.Exceptions;
using OTS2023_GrupaC.Models;

namespace OTS2023_GrupaC
{

    public enum Move
    {
        Up,
        Down,
        Left,
        Right,
        Back,
        Forward
    }

    public enum Achievement
    {
        Poor,
        Average,
        Good
    }

    public class Game
    {
        public Space Map { get; set; }
        public Player Player { get; set; }

        public Game(Location playerLocation, Location beeLocation)
        {
            Map = new Space();
            Map.InitializeMap();

            if (!ValidateLocationInsideMap(playerLocation) || !ValidateLocationInsideMap(beeLocation))
            {
                throw new LocationOutsideOfMapException("Locations must be valid!");
            }

            int itemX = beeLocation.X;
            int itemY = beeLocation.Y;
            int itemZ = beeLocation.Z;

            Map.Tiles[itemX, itemY, itemZ].Content = TileContent.Bee;
            Player = new Player(playerLocation);
        }

        public void MovePlayer(Move move)
        {
            Location playerPositionAfterMove = Player.GetLocationAfterMove(move);
            bool positionIsValid = ValidateLocation(playerPositionAfterMove);
            if (positionIsValid)
            {
                Player.MakeMove(move);
            }
        }

        public bool ValidateLocation(Location location)
        {
            int x = location.X;
            int y = location.Y;
            int z = location.Z;

            if (!ValidateLocationInsideMap(location))
            {
                return false;
            }
            if (Map.Tiles[x, y, z].Type.Equals(TileType.Hive))
            {
                return Player.BeeCollected;
            }
            else
            {
                return true;
            }
        }

        private bool ValidateLocationInsideMap(Location location)
        {
            int x = location.X;
            int y = location.Y;
            int z = location.Z;

            if (x < 0 || x >= Space.MapSize || y < 0 || y >= Space.MapSize)
            {
                return false;
            }
            if (Map.Tiles[x, y, z].Type.Equals(TileType.MapBarrier))
            {
                return false;
            }
            return true;
        }

        public void UpdatePlayer()
        {
            int x = Player.Location.X;
            int y = Player.Location.Y;
            int z = Player.Location.Z;

            if (Map.Tiles[x, y, z].Content.Equals(TileContent.Nectar))
            {
                Player.AmountOfNectar++;
            }
            else if (Map.Tiles[x, y, z].Content.Equals(TileContent.Bee))
            {
                Player.BeeCollected = true;
            }
            else if (Map.Tiles[x, y, z].Type.Equals(TileType.Hive))
            {
                Player.AmountOfHoneyJars += Player.AmountOfNectar;
                Player.AmountOfNectar = 0;
            }

            Map.EmptyTileOnLocation(Player.Location);
        }


        public Achievement CalculateAchievement()
        {
            if (Player.AmountOfHoneyJars > 11)
            {
                return Achievement.Good;
            }
            if (Player.AmountOfNectar >= 10 && Player.BeeCollected)
            {
                if (Player.AmountOfHoneyJars <= 5)
                {
                    return Achievement.Average;
                }
                else
                {
                    return Achievement.Good;
                }
            }
            return Achievement.Poor;
        }
    }
}
