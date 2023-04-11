

using System;

namespace OTS2023_GrupaC.Models
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location()
        {

        }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        override
        public bool Equals(Object obj)
        {
            return ((Location)obj).X == X && ((Location)obj).Y == Y;
        }
    }
}
