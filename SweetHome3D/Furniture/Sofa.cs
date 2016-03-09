﻿using System;
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
    public class Sofa : FurnitureObject
    {
        
        public Sofa()
        {
            Location = new Point(0, 0);
            Height = 100;
            Depth = 106;
            Width = 210;
            Angle = 0;
            Name = "Диван";
            TypeName = "Sofa";
            AddressOfTheImageTexture = @"Sofa\2.jpg";
          
        }
        [NonSerialized]
        Glu.GLUquadric QuadrObj;
        public override void Draw()
        {
            Width /= 2;
            Depth /= 2;
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
                Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, Texture);
            Gl.glPushMatrix();
            if(Angle == 0 || Angle == 180)
                Gl.glTranslated(Location.X - Width, 0, Location.Y - Depth + 5);
            else
                Gl.glTranslated(Location.X - Depth, 0, Location.Y - Width);
            Gl.glRotated(Angle, 0, 1, 0);
            Gl.glColor3d(0, 1, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0);  Gl.glVertex3d(Width-12, 5, Depth -15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, 5, -Depth+15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12, 5, -Depth+15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12, 5, Depth-15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, Height-80, Depth-15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height - 80, -Depth+15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12, Height - 80, -Depth+15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12, Height - 80, Depth-15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, 5, Depth-15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height - 80, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12, Height - 80, Depth - 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12, 5, Depth - 15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, 5, -Depth+15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height - 80, -Depth+15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12, Height - 80, -Depth+15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12, 5, -Depth+15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, 5, Depth-15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height - 80, Depth-15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(Width - 12, Height - 80, -Depth+15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(Width - 12, 5, -Depth+15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-Width + 12, 5, Depth-15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-Width + 12, Height - 80, Depth-15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12, Height - 80, -Depth+15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12, 5, -Depth+15);
            Gl.glEnd();
            Gl.glColor3d(0.85, 0.85, 0.85);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, 5, Depth - 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height - 40, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(Width - 12, Height - 40, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(Width - 12, 5, -Depth + 15);
            Gl.glEnd();
            ////glBegin(GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, Height - 40, Depth - 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 3, Height - 40, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(Width - 3, Height - 40, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(Width - 12, Height - 40, -Depth + 15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, 5, Depth - 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 10, 5, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(Width - 10, 5, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(Width - 12, 5, -Depth + 15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 10, 5, Depth - 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 3, Height - 40, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(Width - 3, Height - 40, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(Width - 10, 5, -Depth + 15);
            Gl.glEnd();
            
            
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, 5, Depth - 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height - 40, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(Width - 3, Height - 40, Depth - 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(Width - 10, 5, Depth - 15);
            Gl.glEnd();
            Gl.glColor3f(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, 5, -Depth + 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height - 40, -Depth + 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(Width - 3, Height - 40, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(Width - 10, 5, -Depth + 15);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-Width + 12, 5, Depth - 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-Width + 12, Height - 40, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12, Height - 40, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12, 5, -Depth + 15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-Width + 12, Height - 40, Depth - 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-Width + 12, Height - 40, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12, Height - 40, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12, Height - 40, -Depth + 15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-Width + 12, 5, Depth - 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-Width + 10, 5, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 10, 5, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 10, 5, -Depth + 15);
            Gl.glEnd();
            Gl.glColor3f(1, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-Width + 10, 5, Depth - 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-Width + 3, Height - 40, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 3, Height - 40, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 10, 5, -Depth + 15);
            Gl.glColor3f(0, 0, 0);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-Width + 12, 5, Depth - 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-Width + 12, Height - 40, Depth - 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 3, Height - 40, Depth - 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 10, 5, Depth - 15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-Width + 12, 5, -Depth + 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-Width + 12, Height - 40, -Depth + 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 3, Height - 40, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 10, 5, -Depth + 15);
            Gl.glEnd();
            Gl.glColor3d(0.9, 0.9, 0.9);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(-Width + 12, 5, -Depth + 30);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(-Width + 12, Height, -Depth + 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12, Height, -Depth);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12, 5, -Depth + 15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, 5, -Depth+30);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height, -Depth + 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(Width - 12, Height, -Depth);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(Width - 12, 5, -Depth + 15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, 5, -Depth + 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height, -Depth);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12,Height, -Depth);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12, 5, -Depth + 15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, 5, -Depth + 30);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height, -Depth + 15);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12, Height, -Depth + 15);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12, 5, -Depth + 30);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 12, Height, -Depth + 15);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 12, Height, -Depth);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 12,Height, -Depth);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 12,Height, -Depth + 15);
            Gl.glEnd();
            Gl.glColor3d(1.0, 1.0, 1.0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0, 0); Gl.glVertex3d(Width - 20, Height - 64, Depth - 31);
            Gl.glTexCoord2d(0, 1); Gl.glVertex3d(Width - 20, Height - 64, -Depth + 31);
            Gl.glTexCoord2d(1, 1); Gl.glVertex3d(-Width + 20,Height - 64, -Depth +31);
            Gl.glTexCoord2d(1, 0); Gl.glVertex3d(-Width + 20,Height - 64, Depth - 31);
            Gl.glEnd();

            
            Gl.glPushMatrix();
            Gl.glTranslated(Width - 4, Height - 40, -Depth + 15);
            QuadrObj =Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 8, 8, 2*Depth-30, 40, 2);
            
            Gl.glPopMatrix();
            
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 4, Height-40, -Depth + 15);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 8, 8, 2 * Depth - 30, 40, 2);
            Gl.glPopMatrix();
            
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 4, Height - 40, -Depth + 15 - 0.1);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluDisk(QuadrObj, 0, 8, 40, 2);
            Gl.glPopMatrix();
           
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 4, Height - 40, Depth - 15 + 0.1);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluDisk(QuadrObj, 0, 8, 40, 2);
            Gl.glPopMatrix();
            
            Gl.glPushMatrix();
            Gl.glTranslated(Width - 4, Height - 40, -Depth + 15 - 0.1);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluDisk(QuadrObj, 0, 8, 40, 2);
            Gl.glPopMatrix();
            
            Gl.glPushMatrix();
            Gl.glTranslated(Width - 4, Height - 40, Depth - 15 + 0.1);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluDisk(QuadrObj, 0, 8, 40, 2);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 12, Height, -Depth+7.5);
            Gl.glRotated(90, 0.0, 1.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 7.5, 7.5, 2*Width-22, 40, 2);
            Gl.glPopMatrix();
          
            Gl.glPushMatrix();
            Gl.glTranslated(Width - 12 +0.1, Height, -Depth+7.5);
            Gl.glRotated(90, 0.0, 1.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluDisk(QuadrObj, 0, 7.5, 40, 2);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 12 -0.1, Height, -Depth+7.5);
            Gl.glRotated(90, 0.0, 1.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluDisk(QuadrObj, 0, 7.5, 40, 2);
            Gl.glPopMatrix();
            Gl.glColor3d(0.0, 0.0, 1.0);
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 20, Height-72, -Depth+30);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 8, 8, Depth-9, 40, 2);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(Width - 20, Height-72, -Depth+30);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 8, 8, Depth-9, 40, 2);
            Gl.glPopMatrix();
            //=======
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 20, Height-72, -Depth+30);
            Gl.glRotated(90, 0.0, 1.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 8, 8, Width-20, 40, 2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, Height-72, -Depth+30);
            Gl.glRotated(90, 0.0, 1.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 8, 8, Width - 20, 40, 2);
            Gl.glPopMatrix();
            //==============
            Gl.glPushMatrix();
            //Gl.glTranslated(-width + 20, 28, 22);
            Gl.glTranslated(0, Height-72, Depth-30);
            Gl.glRotated(90, 0.0, 1.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 8, 8, Width-20, 40, 2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 20, Height-72, Depth-30);
            Gl.glRotated(90, 0.0, 1.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 8, 8, Width - 20, 40, 2);
            Gl.glPopMatrix();
            //====
            Gl.glPushMatrix();
            Gl.glTranslated(Width - 20, Height-72, Depth-30);
            Glut.glutSolidSphere(8, 40, 20);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 20, Height-72, -Depth+30);
            Glut.glutSolidSphere(8, 40, 20);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 20, Height-72, Depth-30);
            Glut.glutSolidSphere(8, 40, 20);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 20, Height-72, -Depth+30);
            Glut.glutSolidSphere(8, 40, 20);
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glColor3ub(78, 22, 9);
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 20, 5, Depth-23);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 6, 4, 5, 40, 2);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(-Width + 20, 5, -Depth+23);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 6, 4, 5, 40, 2);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(Width - 20, 5, Depth-23);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 6, 
               4, 5, 40, 2);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(Width - 20, 5, -Depth+23);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            QuadrObj = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(QuadrObj, Gl.GL_TRUE);
            Glu.gluCylinder(QuadrObj, 6, 4, 5, 40, 2);
            Gl.glPopMatrix();
            Gl.glRotated(90, 0, 1, 0);
            Gl.glPopMatrix();
            Width *= 2;
            Depth *= 2;
        }
    }
}
