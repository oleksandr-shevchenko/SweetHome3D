using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SweetHome3D.Furniture;
using System.IO;
namespace SweetHome3D
{
    public partial class ChangeTheFurniture : Form
    {
        String AddressOfTheImage;
        private Object CurrentFurniture;
        String direct;
        public ChangeTheFurniture(Object ob)
        {
            InitializeComponent();
            CurrentFurniture = ob;
        }        
        private void ChangeTheFurniture_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(0);
            listBox1.Items.Add(90);
            listBox1.Items.Add(180);
            listBox1.Items.Add(270);
            FurnitureObject ch = (FurnitureObject)CurrentFurniture;
            direct = ch.TypeName;
            textBoxName.Text = ch.Name;
            textBoxWidth.Text = ch.Width.ToString();
            textBoxDepth.Text = ch.Depth.ToString();
            textBoxHeight.Text = ch.Height.ToString();
            pictureBox1.Image = new Bitmap(ch.AddressOfTheImageTexture);
            AddressOfTheImage = ch.AddressOfTheImageTexture;
            switch(ch.Angle)
            {
                case 0:
                    listBox1.SelectedIndex = 0;
                    break;
                case 90:
                    listBox1.SelectedIndex = 1;
                    break;
                case 180:
                    listBox1.SelectedIndex = 2;
                    break;
                case 270:
                    listBox1.SelectedIndex = 3;
                    break;
            }
        }
        void Error()
        {
            MessageBox.Show("Не все поля заполнены!");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String Name;
            double Width;
            double Depth;
            double Height;
            if (textBoxName.Text != "" || textBoxName.Text != null)
                Name = textBoxName.Text;
            else
            {
                Error();
                return;
            }
            double result;
            if (Double.TryParse(textBoxWidth.Text, out result))
                Width = result;
            else
            {
                textBoxWidth.Text = "";
                return;
            }
            if (Double.TryParse(textBoxDepth.Text, out result))
                Depth = result;
            else
            {
                textBoxDepth.Text = "";
                return;
            }
            if (Double.TryParse(textBoxHeight.Text, out result))
            {
                Height = result;
            }
            else
            {
                textBoxHeight.Text = "";
                return;
            }
            if (AddressOfTheImage == null)
            {
                Error();
                return;
            }
            FurnitureObject ch = (FurnitureObject)CurrentFurniture;
            ch.Name = Name;
            ch.Width = Width;
            ch.Height = Height;
            ch.Depth = Depth;
            ch.AddressOfTheImageTexture = AddressOfTheImage;
            ch.Angle = (int)listBox1.Items[listBox1.SelectedIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Загрузка текстуры";
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.JPG)|*.bmp;*.jpg;*.JPG";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = Application.StartupPath + @"\" + direct;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo test = new FileInfo(openFileDialog.FileName);
                if (test.Extension != ".bmp" && test.Extension != ".jpg" && test.Extension != ".JPG")
                {
                    MessageBox.Show("Выбранный файл не корректный " + '\n' + "     Выбирете файл снова.");
                    return;
                }
                AddressOfTheImage= openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }
    }
}
