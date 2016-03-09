using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SweetHome3D.Furniture
{
    [Serializable]
    public class FurnitureObject
    {
        private int angle;
        public int Angle
        {
            get { return angle; }
            set { angle = value; }
        }
        private uint texture;
        public uint Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        private String addressOfTheImageTexture;
        public String AddressOfTheImageTexture
        {
            get { return addressOfTheImageTexture; }
            set { addressOfTheImageTexture = value; }
        }
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        Point location;
        public Point Location
        {
            get { return location; }
            set { location = value; }
        }
        double width;
        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        double depth;
        public double Depth
        {
            get { return depth; }
            set { depth = value; }
        }
        double height;
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        int controlObject;
        public int ControlObject
        {
            get { return controlObject; }
            set { controlObject = value; }
        }
        String typeName;
        public String TypeName
        {
            get { return typeName; }
            set { typeName=value; }
        }
        public virtual void Draw(){}
    }
}
