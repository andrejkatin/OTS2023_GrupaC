
namespace OTS2023_GrupaC.Models
{
    public class Player
    {
        public Location Location { get; set; }
        public int AmountOfNectar { get; set; }
        public int AmountOfHoneyJars { get; set; }
        public bool BeeCollected { get; set; }

        public Player()
        {
        }

        public Player(Location location)
        {
            Location = location;
        }


        public void MakeMove(Move move)
        {
            switch (move)
            {
                case Move.Up:
                    MoveUp();
                    break;
                case Move.Down:
                    MoveDown();
                    break;
                case Move.Left:
                    MoveLeft();
                    break;
                case Move.Right:
                    MoveRight();
                    break;
                case Move.Back:
                    MoveBack();
                    break;
                case Move.Forward:
                    MoveForward();
                    break;
                default:
                    break;
            }
        }

        public void MoveUp()
        {
            Location.Y--;
        }

        public void MoveDown()
        {
            Location.Y++;
        }

        public void MoveLeft()
        {
            Location.X--;
        }

        public void MoveRight()
        {
            Location.X++;
        }

        public void MoveBack()
        {
            Location.Z--;
        }

        public void MoveForward()
        {
            Location.Z++;
        }

        public Location GetLocationAfterMove(Move move)
        {
            int x = Location.X;
            int y = Location.Y;
            int z = Location.Z;
            switch (move)
            {
                case Move.Up:
                    return new Location(x, y - 1, z);
                case Move.Down:
                    return new Location(x, y + 1, z);
                case Move.Left:
                    return new Location(x - 1, y, z);
                case Move.Right:
                    return new Location(x + 1, y, z);
                case Move.Back:
                    return new Location(x, y, z - 1);
                case Move.Forward:
                    return new Location(x, y, z + 1);
                default:
                    return null;
            }
        }
    }
}
