
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

        public Location GetLocationAfterMove(Move move)
        {
            int x = Location.X;
            int y = Location.Y;
            switch (move)
            {
                case Move.Up:
                    return new Location(x, y - 1);
                case Move.Down:
                    return new Location(x, y + 1);
                case Move.Left:
                    return new Location(x - 1, y);
                case Move.Right:
                    return new Location(x + 1, y);
                default:
                    return null;
            }
        }
    }
}
