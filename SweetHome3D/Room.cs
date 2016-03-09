using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SweetHome3D.Furniture;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;
namespace SweetHome3D
{
    [Serializable]
    public class Room
    {
        private String[] addressOfTheImageTexture;
        public String[] AddressOfTheImageTexture
        {
            get { return addressOfTheImageTexture; }
            set { addressOfTheImageTexture = value; }
        }
        private uint textureOfTheFloor;
        public uint TextureOfTheFloor
        {
            get { return textureOfTheFloor; }
            set { textureOfTheFloor = value; }
        }
        private uint textureOfTheWall;
        public uint TextureOfTheWall
        {
            get { return textureOfTheWall; }
            set { textureOfTheWall = value; }
        }
        private uint textureOfTheCeiling;
        public uint TextureOfTheCeiling
        {
            get { return textureOfTheCeiling; }
            set { textureOfTheCeiling = value; }
        }
        private List<FurnitureObject> listFurniture;
        public List<FurnitureObject> ListFurniture
        {
            get { return listFurniture; }
            set { listFurniture = value; }
        }
        string name;
        public string  Name
        {
            get { return name; }
            set { name = value; }
        }
        double widthX;
        public double WidthX
        {
            get { return widthX; }
            set { widthX = value; }
        }
        double lengthZ;
        public double LengthZ
        {
            get { return lengthZ; }
            set { lengthZ = value; }
        }
        double heightY;
        public double HeightY
        {
            get { return heightY; }
            set { heightY = value; }
        }
        [NonSerialized]
        private List<Control> listControlPanel;
        public List<Control> ListControlPanel
        {
            get { return listControlPanel; }
            set { listControlPanel = value; }
        }
        public Room()
        {
            listFurniture = new List<FurnitureObject>();
            listControlPanel = new List<Control>();
            addressOfTheImageTexture=new String[3];
        }
        private void DrawWall()
        {
            widthX /= 2;
            lengthZ /= 2;

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, TextureOfTheFloor);
            
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-WidthX, 0, -LengthZ);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-WidthX, 0, LengthZ);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(WidthX, 0, LengthZ);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(WidthX, 0, -LengthZ);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            //=======================================
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, TextureOfTheWall);
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-WidthX, 0, LengthZ);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-WidthX, heightY, LengthZ );
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-WidthX, heightY, -LengthZ);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-WidthX, 0, -LengthZ);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-WidthX, 0, LengthZ);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-WidthX, heightY, LengthZ);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(WidthX, heightY, LengthZ);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(WidthX, 0, LengthZ);
            Gl.glEnd();
            //-----------------------

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(WidthX, 0, -LengthZ);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(WidthX, heightY, -LengthZ);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(WidthX, heightY, LengthZ);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(WidthX, 0, LengthZ);
            Gl.glEnd();
            // 5-та сторона кубу
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-WidthX, 0, -LengthZ);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-WidthX, heightY, -LengthZ);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(WidthX, heightY, -LengthZ);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(WidthX, 0, -LengthZ);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            // ----------------------------
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, TextureOfTheCeiling);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-WidthX, heightY, -LengthZ);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-WidthX, heightY, LengthZ);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(WidthX, heightY, LengthZ);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(WidthX, heightY, -LengthZ);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            widthX *= 2;
            lengthZ *= 2;
        }
        public void DrawRoom()
        {
            DrawWall();
            foreach (FurnitureObject ob in listFurniture)
            {
                ob.Draw();
            }
        }
        public void TextureLoading()
        {
            this.TextureOfTheFloor = _3DViewOfTheRoom.TextureAdd(this.AddressOfTheImageTexture[0]);
            this.TextureOfTheWall = _3DViewOfTheRoom.TextureAdd(this.AddressOfTheImageTexture[1]);
            this.TextureOfTheCeiling =_3DViewOfTheRoom.TextureAdd(this.AddressOfTheImageTexture[2]);
            foreach (object o in this.ListFurniture)
            {
                        FurnitureObject c = (FurnitureObject)o;
                        c.Texture = _3DViewOfTheRoom.TextureAdd(c.AddressOfTheImageTexture);
            }
        }
    }
}
