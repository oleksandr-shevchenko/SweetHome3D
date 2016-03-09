using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetHome3D
{
    class Location
    {
        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private int distanceFromTheFloor;
        public int DistanceFromTheFloor
        {
            get { return distanceFromTheFloor; }
            set { distanceFromTheFloor = value; }
        }
    }
}
