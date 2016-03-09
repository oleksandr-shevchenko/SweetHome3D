using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;

namespace SweetHome3D
{
    public partial class _3DViewOfTheRoom : Form
    {
        private Room TheCurrentRoom;
        int width = 1, height = 1;
        float angleX, angleY;	     // Поточний кут повороту фігури
        float mouseX, mouseY;	     // Поточні координати
        float distZ = -10;		     // Відстань по осі Z до сцени
        float distX = 0;
        float distY = 130;
        float StopOrStart = 1;
        float angle = (float)0.0;		     // кут повороту фігури
        public _3DViewOfTheRoom(Room room)
        {
            InitializeComponent();
            AnT.InitializeContexts();
            TheCurrentRoom = room;
            OpenGl_Load();
        }
        private void _3DViewOfTheRoom_Load(object sender, EventArgs e)
        {
                
                RenderTimer.Start();
                TheCurrentRoom.TextureLoading();
                
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Draw();
        }
        public static uint TextureAdd(string url)
        {
            //индефекатор текстуры
            int imageId = 0;
            // текстурный объект
            uint mGlTextureObject = 0;
            // создаем изображение с индификатором imageId
            Il.ilGenImages(1, out imageId);
            // делаем изображение текущим
            Il.ilBindImage(imageId);
            // пробуем загрузить изображение
            if (Il.ilLoadImage(url))
            {
                // если загрузка прошла успешно
                // сохраняем размеры изображения
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                // определяем число бит на пиксель
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp) // в зависимости оп полученного результата
                {
                    // создаем текстуру используя режим GL_RGB или GL_RGBA
                    case 24:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
                // очищаем память
                Il.ilDeleteImages(1, ref imageId);
            }
            return mGlTextureObject;
        }
        private void OpenGl_Load()
        {
            // инициализация бибилиотеки glut 
            
            // установка цвета очистки экрана (RGBA) 
            Gl.glClearColor(255, 255, 255, 1);
            // установка порта вывода 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы 
            Gl.glLoadIdentity();
            // установка перспективы 
            Glu.gluPerspective(30, AnT.Width / AnT.Height, 1, 1500);
            // установка объектно-видовой матрицы 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // начальные настройки OpenGL 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            // активация таймера 
            RenderTimer.Start();
        }
        private void Draw()
        {
            angle -= (float)0.005 * StopOrStart; // збільшення кута повороту
            Gl.glViewport(0, 0, width, height); // задання області повороту
            // если текстура загружена
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            // установка порта вывода 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60, (float)(AnT.Width / AnT.Height), 1, 1500);
            // установка объектно-видовой матрицы 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // начальные настройки OpenGL 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            // очищение текущей матрицы 
            Gl.glLoadIdentity();
            // включаем режим текстурирования
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            // включаем режим текстурирования , указывая индификатор mGlTextureObject
            
            // сохраняем состояние матрицы
            Gl.glPushMatrix();
            if (angleX > 360)
                angleX = -360;
            else if (angleX < -360)
                angleX = 360;
            if (angleY > 360)
                angleY = -360;
            else if (angleY < -360)
                angleY = 360;
            Glu.gluLookAt(distX, distY, distZ, distX + Math.Sin(angleX * 3.14 / 180), distY + Math.Sin(angleY / 360), distZ + Math.Cos(angleX * 3.14 / 180), 0, 1, 0);
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glPushMatrix();
            //========================================
            TheCurrentRoom.DrawRoom();
            //========================================
            Gl.glPopMatrix();
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            // возвращаем матрицу
            Gl.glPopMatrix();
            // отключаем режим текстурирования
            Gl.glFlush();
            // Glut.glutSwapBuffers();
            // обновлеям элемент со сценой
            AnT.Invalidate();

        }
        private void AnT_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                    distX += (float)Math.Sin(angleX * 3.14 / 180) * 50;
                    distZ += (float)Math.Cos(angleX * 3.14 / 180) * 50;
                    break;
                case 's':
                    distX -= (float)Math.Sin(angleX * 3.14 / 180) * 50;
                    distZ -= (float)Math.Cos(angleX * 3.14 / 180) * 50;
                    break;
                case 'a':
                    distX += (float)Math.Cos(angleX * 3.14 / 180) * 50;
                    distZ -= (float)Math.Sin(angleX * 3.14 / 180) * 50;
                    break;
                case 'd':
                    distX -= (float)Math.Cos(angleX * 3.14 / 180) * 50;
                    distZ += (float)Math.Sin(angleX * 3.14 / 180) * 50;
                    break;
                case '=':
                    distY += 5;
                    break;
                case '-':
                    distY -= 5;
                    break;

            }
            if (distY < 130)
                distY = 130;
            if (distY > 210)
                distY = 210;

            if (distZ > (float)TheCurrentRoom.LengthZ / 2)
                distZ = (float)TheCurrentRoom.LengthZ / 2;
            
            if (distZ < -(float)TheCurrentRoom.LengthZ / 2)
                distZ = -(float)TheCurrentRoom.LengthZ / 2;
            
            if (distX > (float)TheCurrentRoom.WidthX/2)
                distX = (float)TheCurrentRoom.WidthX/2;
            
            if (distX < -(float)TheCurrentRoom.WidthX/2)
                distX = -(float)TheCurrentRoom.WidthX/2;
        }
        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                angleX += e.X - mouseX;
                angleY += e.Y - mouseY;
                mouseX = e.X;
                mouseY = e.Y;
            }
            else
            {
                mouseX = e.X;
                mouseY = e.Y;
            }
        }
        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            // индетефекатор текстурного объекта
            uint texObject;
            // генерируем текстурный объект
            Gl.glGenTextures(1, out texObject);
            // устанавливаем режим упаковки пикселей
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            // создаем привязку к только что созданной текстуре
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);
            // устанавливаем режим фильтрации и повторения текстуры
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
            // создаем RGB или RGBA текстуру
            switch (Format)
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }
            // возвращаем индетефекатор текстурного объекта
            return texObject;
        }
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }

       
       
    }
}
