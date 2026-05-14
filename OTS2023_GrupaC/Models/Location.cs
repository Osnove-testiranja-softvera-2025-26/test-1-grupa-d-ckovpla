

using System;

namespace OTS2026_GrupaD.Models
{
    public class playerLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public playerLocation()
        {

        }

        public playerLocation(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        override
        public bool Equals(Object obj)
        {
            return ((playerLocation)obj).X == X && ((playerLocation)obj).Y == Y && ((playerLocation)obj).Z == Z;
        }
    }
}
