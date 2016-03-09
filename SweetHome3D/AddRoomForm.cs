using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SweetHome3D
{
    public partial class AddRoomForm : Form
    {
        private Room TheCurentRoom;
        bool add;
        private String[]AddressOfTheImage;
        public AddRoomForm(Room r,int chec)
        {
            InitializeComponent();
            TheCurentRoom = r;
            if (chec != 0)
            {
                textBoxName.Text = r.Name;
                textBoxLength.Text = r.LengthZ.ToString();
                textBoxWidth.Text = r.WidthX.ToString();
                textBoxHeight.Text = r.HeightY.ToString();
                pictureBox1.Image = new Bitmap(r.AddressOfTheImageTexture[0]);
                pictureBox2.Image = new Bitmap(r.AddressOfTheImageTexture[1]);
                pictureBox3.Image = new Bitmap(r.AddressOfTheImageTexture[2]);
                AddressOfTheImage = new String[3];
                for (int i = 0; i < 3; i++)
                    AddressOfTheImage[i] = r.AddressOfTheImageTexture[i];
                add = true;
            }
            else
                AddressOfTheImage = new String[3];
        }
        public AddRoomForm()
        {
            InitializeComponent();
            TheCurentRoom=new Room();
        }
        
        private void pictureBox_Click(object sender, EventArgs e)
        {
            int positionStr = 0; 
            PictureBox TheCurentPictureBox=new PictureBox ();
            uint TheCurentTexture;
            if (pictureBox1.GetHashCode() == sender.GetHashCode())
            {
                TheCurentPictureBox = pictureBox1;
                TheCurentTexture = TheCurentRoom.TextureOfTheFloor;
                positionStr = 0;
            }
            else if (pictureBox2.GetHashCode() == sender.GetHashCode())
            {
                TheCurentPictureBox = pictureBox2;
                TheCurentTexture = TheCurentRoom.TextureOfTheWall;
                positionStr = 1;
                
            }
            else if (pictureBox3.GetHashCode() == sender.GetHashCode())
            {
                TheCurentPictureBox = pictureBox3;
                TheCurentTexture = TheCurentRoom.TextureOfTheCeiling;
                positionStr = 2;   
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Загрузка текстуры";
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.JPG)|*.bmp;*.jpg;*.JPG";
            openFileDialog.InitialDirectory = Application.StartupPath;
            
            switch (positionStr)
            {
                case 0:
                    openFileDialog.InitialDirectory = Application.StartupPath + @"\Floor";
                    break;
                case 1:
                    openFileDialog.InitialDirectory = Application.StartupPath + @"\Wall";
                    break;
                case 2:
                    openFileDialog.InitialDirectory = Application.StartupPath + @"\Ceiling";
                    break;
            }
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo test = new FileInfo(openFileDialog.FileName);
                if (test.Extension != ".bmp" && test.Extension != ".jpg" && test.Extension != ".JPG")
                {
                    MessageBox.Show("Выбранный файл не корректный " + '\n' + "     Выбирете файл снова.");
                    return;
                }
                AddressOfTheImage[positionStr] = openFileDialog.FileName;
                TheCurentPictureBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        private void Error()
        {

 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" || textBoxName.Text != null)
                TheCurentRoom.Name = textBoxName.Text;
            else
            {
                Error();
                return;
            }
            double result;
            if (Double.TryParse(textBoxWidth.Text, out result))
            {
                TheCurentRoom.WidthX = result;
                if (add)
                {
                    Point pt = new Point((int)result, TheCurentRoom.ListControlPanel[TheCurentRoom.ListControlPanel.Count - 1].Size.Height);
                    TheCurentRoom.ListControlPanel[TheCurentRoom.ListControlPanel.Count - 1].Size = new Size(pt);
                    MyForm.DrawPlan((PictureBox)TheCurentRoom.ListControlPanel[TheCurentRoom.ListControlPanel.Count - 1]);
                }
            }
            else 
            {
                textBoxWidth.Text = "";
                return;
            }
            if (Double.TryParse(textBoxLength.Text, out result))
            {
                TheCurentRoom.LengthZ = result;
                if (add)
                {
                    Point pt = new Point(TheCurentRoom.ListControlPanel[TheCurentRoom.ListControlPanel.Count - 1].Size.Width, (int)result);
                    TheCurentRoom.ListControlPanel[TheCurentRoom.ListControlPanel.Count - 1].Size = new Size(pt);
                    MyForm.DrawPlan((PictureBox)TheCurentRoom.ListControlPanel[TheCurentRoom.ListControlPanel.Count - 1]);
                }
            }
            else
            {
                textBoxLength.Text = "";
                return;
            }
            if (Double.TryParse(textBoxHeight.Text, out result))
            {
                TheCurentRoom.HeightY = result;
            }
            else
            {
                textBoxHeight.Text = "";
                return;
            }
            foreach (String str in AddressOfTheImage)
            {
                if (str == null)
                {
                    Error();
                    return;
                }
            }
            for (int i = 0; i < 3;i++ )
                TheCurentRoom.AddressOfTheImageTexture[i] = AddressOfTheImage[i];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
