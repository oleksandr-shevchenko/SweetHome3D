using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;
using System.Drawing;
namespace SweetHome3D.Furniture
{
    [Serializable]
    public class Door :FurnitureObject
    {
        public Door()
        {
            Height = 220;
            Depth = 10;
            Width = 120;
            AddressOfTheImageTexture = @"Door\1.jpg";
            Name = "Дверь";
            TypeName = "Door";
        }
        
        public override void Draw()
        {
            Depth /= 2;
            Width /= 2;
            Gl.glPushMatrix();
            if (Angle == 0 || Angle == 180)
                Gl.glTranslated(Location.X - Width, 0, Location.Y - Depth);
            else
                Gl.glTranslated(Location.X - Depth, 0, Location.Y - Width);
            Gl.glRotated(Angle, 0, 1, 0);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
             Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
             Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
             Gl.glBindTexture(Gl.GL_TEXTURE_2D, Texture);
             Gl.glColor3d(1.0, 1.0, 1.0);
             Gl.glBegin(Gl.GL_QUADS);
             Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width, 0, Depth);
             Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width, Height,Depth);
             Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width, Height, Depth);
             Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width, 0, Depth);
             Gl.glEnd();
             Gl.glBegin(Gl.GL_QUADS);
             Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width, Height, Depth);
             Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width, Height, 0);
             Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width, Height, 0);
             Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width, Height, Depth);
             Gl.glEnd();
             Gl.glBegin(Gl.GL_QUADS);
             Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width, 0, Depth);
             Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width, Height, Depth);
             Gl.glTexCoord2d(1, 1); Gl.glVertex3d(Width, Height, 0);
             Gl.glTexCoord2d(1, 0); Gl.glVertex3d(Width, 0, 0);
             Gl.glEnd();
             Gl.glBegin(Gl.GL_QUADS);
             Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-Width, 0, Depth);
             Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-Width, Height, Depth);
             Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width, Height, 0);
             Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width, 0, 0);
             Gl.glEnd();

             Gl.glPopMatrix();
             Depth *= 2;
             Width *= 2;
        }

    }
}
