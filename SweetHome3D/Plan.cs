using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetHome3D
{
    [Serializable]
    public class Plan
    {
        List<Room> listRoom;
        public List<Room> ListRoom
        {
            get { return listRoom; }
            set { listRoom = value; }
        }
       public Plan()
        {
            listRoom = new List<Room>();
        }
       public void DrawPlan(int Position)
       {
           listRoom[Position].DrawRoom();
       }
       
    }
}
