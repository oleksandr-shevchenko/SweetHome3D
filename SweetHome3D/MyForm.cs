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
using System.Runtime.Serialization.Formatters.Binary;

namespace SweetHome3D
{   [Serializable]
    public partial class MyForm : Form
    {
    //Bitmap BmpImage;
        private List<uint> ListTexture;
        private List<String> AddressListOfImages;
        private Plan TheCurrentPlan;
        public MyForm()
        {
            AddressListOfImages = new List<String>();
            TheCurrentPlan = new Plan();
            InitializeComponent();
            ListTexture = new List<uint>();         
            Glut.glutInit(); 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE); 
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);
        }
        private void MyForm_Load(object sender, EventArgs e)
        {
            treeView_SetImageList();
        }     
        private void treeView_SetImageList()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add(Image.FromFile(@"Icon\close_folder.jpg"));
            imageList.Images.Add(Image.FromFile(@"Icon\open_folder.jpg"));

            imageList.Images.Add(new Bitmap(@"Icon\chair.jpg"));
            imageList.Images.Add(new Bitmap(@"Icon\sofa.jpg"));
            imageList.Images.Add(new Bitmap(@"Icon\ShelfForShoes.jpg"));
            imageList.Images.Add(new Bitmap(@"Icon\table.jpg"));
            imageList.Images.Add(new Bitmap(@"Icon\Door.jpg"));
            imageList.Images.Add(new Bitmap(@"Icon\Window.jpg"));
            treeView.ImageList = imageList;
            for (int i = 0; i < treeView.GetNodeCount(false); i++)
            {
                treeView.Nodes[i].ImageIndex = 0;
                treeView.Nodes[i].SelectedImageIndex = 0;
            }
            treeView.Nodes[0].Nodes[0].ImageIndex = 2;
            treeView.Nodes[0].Nodes[0].SelectedImageIndex =2;
            treeView.Nodes[0].Nodes[1].ImageIndex = 3;
            treeView.Nodes[0].Nodes[1].SelectedImageIndex = 3;
            treeView.Nodes[0].Nodes[2].ImageIndex = 4;
            treeView.Nodes[0].Nodes[2].SelectedImageIndex = 4;
            treeView.Nodes[0].Nodes[3].ImageIndex = 5;
            treeView.Nodes[0].Nodes[3].SelectedImageIndex = 5;
            treeView.Nodes[1].Nodes[0].ImageIndex = 6;
            treeView.Nodes[1].Nodes[0].SelectedImageIndex = 6;

            treeView.Nodes[1].Nodes[1].ImageIndex = 7;
            treeView.Nodes[1].Nodes[1].SelectedImageIndex = 7;
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void treeView_RootSetImage(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == 0)
            {
                e.Node.ImageIndex = 1;
                e.Node.SelectedImageIndex = 1;
            }
            else
            {
                e.Node.ImageIndex = 0;
                e.Node.SelectedImageIndex = 0;
            }
        }
        private void Close(object sender, EventArgs e)
        {
            Close();
        }
        public static void DrawPlan(PictureBox p)
        {
            Bitmap BmpImage = new Bitmap(p.Width, p.Height);
            using (Graphics graphics = Graphics.FromImage(BmpImage))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.Clear(Color.White);
                Pen pen = new Pen(Color.Gray, 1);
                for (int i = 0; i < p.Width; i += 10)
                    graphics.DrawLine(pen, new Point(i, 0), new Point(i, p.Height));
                for (int i = 0; i < p.Height; i += 10)
                    graphics.DrawLine(pen, new Point(0,i), new Point(p.Width,i));
            }
            p.Image = BmpImage;
        }     
        private void f(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                PictureBox q = (PictureBox)sender;
                
                if (q.Left > 0)
                    q.Left = q.Left + e.X - q.Size.Width / 2;
                if (q.Top > 0)
                    q.Top = q.Top + e.Y - q.Size.Height / 2;
                if (q.Left <= 0)
                    q.Left = 1;
                if (q.Top <= 0) 
                    q.Top = 1;

                for (int i = 0; i < TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListControlPanel.Count; i++)
                {
                    if (TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListControlPanel[i] == q)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        Object obj = TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListFurniture[i];
                            FurnitureObject furnitureObject = (FurnitureObject)obj;
                            int x=(int)(TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].WidthX/2);
                            int y = (int)(TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].LengthZ / 2);
                            furnitureObject.Location = new Point(x - q.Location.X  ,y - q.Location.Y);
                            break;
                    }

                }
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Room rr = new Room();
            AddRoomForm f = new AddRoomForm(rr,0);
            if (f.ShowDialog() == DialogResult.OK)
            { 
                this.TheCurrentPlan.ListRoom.Add(rr);
                int c=TheCurrentPlan.ListRoom.Count-1;
                PictureBox p = new PictureBox();
                
                p.Size = new Size((int)this.TheCurrentPlan.ListRoom[c].WidthX,(int)this.TheCurrentPlan.ListRoom[c].LengthZ);
                DrawPlan(p);
                p.BackColor = Color.White;
                p.Location = new Point(0,0);
                panel.Controls.Add(p);
                TheCurrentPlan.ListRoom[c].ListControlPanel.Add(p);
                listBoxRoom.Items.Add(rr.Name);
                listBoxRoom.SelectedIndex = listBoxRoom.Items.Count - 1;
            }
        }
        private void SaveThePlan(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Сохранение плана";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = "File";
            saveFileDialog.Filter = "Bin Document(*.bin)|*.bin|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                using (var fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                 //   System.Windows.Forms.Control;
                    BinaryFormatter bformatter = new BinaryFormatter();
                    bformatter.Serialize(fStream, this.TheCurrentPlan);
                    fStream.Close();

                }
            }
        }
        private void DownloadThePlan(object sender, EventArgs e)
        {
            string message = "Сохранить текущий план?";
            string caption = "Сохранение...";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult res=DialogResult.Abort;
            if(TheCurrentPlan.ListRoom.Count>0)
            res= MessageBox.Show(message, caption, buttons);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                SaveThePlan(new Object(), new EventArgs());
            }
            else if (res == DialogResult.Cancel)
                return;
            listBoxRoom.Items.Clear();
            panel.Controls.Clear();
            dataGridView1.Rows.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "BIN Document(*.bin)|*.bin|Все файлы (*.*)|*.*";
            openFileDialog.InitialDirectory="File";
            openFileDialog.RestoreDirectory=true;
            res=openFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo test = new FileInfo(openFileDialog.FileName);
                if (test.Extension != ".bin")
                {
                    MessageBox.Show("Выбранный файл не корректный " + '\n' + "     Выбирете файл снова.");
                    return;
                }
                using (var fStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    BinaryFormatter bformatter = new BinaryFormatter();
                    this.TheCurrentPlan = (Plan)bformatter.Deserialize(fStream);
                }
            }
            else
                return;
            foreach (Room room in TheCurrentPlan.ListRoom)
            {
                PictureBox p = new PictureBox();
                p.Size = new Size((int)room.WidthX, (int)room.LengthZ);
                DrawPlan(p);
                p.BackColor = Color.White;
                p.Location = new Point(0, 0);
                panel.Controls.Add(p);
                room.ListControlPanel = new List<Control>();
                room.ListControlPanel.Add(p);
                listBoxRoom.Items.Add(room.Name);
                listBoxRoom.SelectedIndex = listBoxRoom.Items.Count - 1;
                foreach (FurnitureObject obj in room.ListFurniture)
                {
                    Control t = panel.Controls[panel.Controls.Count - 1];
                    panel.Controls.RemoveAt(panel.Controls.Count - 1);
                    p = new PictureBox();
                    if(obj.Angle==0 || obj.Angle==180)
                    p.Size = new Size((int)obj.Width, (int)obj.Depth);
                    else
                        p.Size = new Size((int)obj.Depth, (int)obj.Width);
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.Image = new Bitmap(@"Icon\" + obj.TypeName + ".jpg");

                    p.Location = new Point((int)((room.WidthX / 2) - obj.Location.X), (int)((room.LengthZ / 2) - obj.Location.Y));
                    
                    
                    p.MouseMove += new System.Windows.Forms.MouseEventHandler(this.f);
                    p.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Furniture_MouseDoubleClick);
                    p.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picture_MouseClick);
                    panel.Controls.Add(p);
                    panel.Controls.Add(t);
                    
                    room.ListControlPanel.Clear();
                    foreach (Control con in panel.Controls)
                        room.ListControlPanel.Add(con);
                    obj.ControlObject = p.GetHashCode();
                   // dataGridView1.Rows.Add(new Bitmap(@"Icon\" + obj.TypeName + ".jpg"), obj.Name, obj.Width, obj.Depth, obj.Height, obj.Angle);
                }
            }

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string message = "Сохранить текущий план?";
            string caption = "Сохранение...";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult res=DialogResult.Cancel;
            if(TheCurrentPlan.ListRoom.Count>0)    
            res=MessageBox.Show(message, caption, buttons);
            if ( res== System.Windows.Forms.DialogResult.Yes)
            {
                SaveThePlan(new Object(), new EventArgs());
            }
            else 
                if (res == System.Windows.Forms.DialogResult.Cancel)
                return;
            listBoxRoom.Items.Clear();
            panel.Controls.Clear();
            dataGridView1.Rows.Clear();
            TheCurrentPlan = new Plan();
        }
        private void вид3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxRoom.SelectedIndex < 0)
                return;
            _3DViewOfTheRoom temp = new _3DViewOfTheRoom(this.TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex]);
            temp.Show();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listBoxRoom.Items.Count == 0)
                return;
            AddRoomForm f = new AddRoomForm(TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex],1);
            f.ShowDialog();
            
            
            //int x = (int)(TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].WidthX / 2);
            //int y = (int)(TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].LengthZ / 2);
            //foreach (FurnitureObject c in TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListFurniture)
            //     c.Location = new Point(x - TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListControlPanel[0].Location.X, y - TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListControlPanel[0].Location.Y);
        }
        private void listBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxRoom.SelectedIndex < 0)
                return;
            panel.Controls.Clear();
            foreach (Control con in TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListControlPanel)
                panel.Controls.Add(con);
            
            dataGridView1.Rows.Clear();
            foreach (Object obj in TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListFurniture)
            {
                FurnitureObject ob=(FurnitureObject)obj;
                dataGridView1.Rows.Add(new Bitmap(@"Icon\"+ob.TypeName+".jpg"), ob.Name, ob.Width, ob.Depth, ob.Height, ob.Angle);
            }
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }
        private void AddingFurniture(FurnitureObject obj)
        {
            Control t = panel.Controls[panel.Controls.Count - 1];
            panel.Controls.RemoveAt(panel.Controls.Count - 1);

            PictureBox p = new PictureBox();
            p.Size = new Size((int)obj.Width, (int)obj.Depth);
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Image = new Bitmap(@"Icon\" + obj.TypeName + ".jpg");
            p.Location = new Point((int)TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].WidthX / 2, (int)TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].LengthZ / 2);
            
            p.MouseMove += new System.Windows.Forms.MouseEventHandler(this.f);
            p.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Furniture_MouseDoubleClick);
            p.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picture_MouseClick);
            
            panel.Controls.Add(p);
            panel.Controls.Add(t);
            TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListControlPanel.Clear();
            foreach (Control con in panel.Controls)
                TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListControlPanel.Add(con);
            obj.ControlObject = p.GetHashCode();
            TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListFurniture.Add(obj);
            dataGridView1.Rows.Add(new Bitmap(@"Icon\" + obj.TypeName + ".jpg"), obj.Name, obj.Width, obj.Depth, obj.Height, obj.Angle);
 
        }
        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (listBoxRoom.Items.Count == 0)
                return;
            switch(e.Node.Name)
            {
                case "Chair":
                    FurnitureObject obj = new Chair();
                    AddingFurniture(obj);
                    break;
                case "Sofa":
                    obj = new Sofa();
                    AddingFurniture(obj);
                    break;
                case "ShelfForShoes" :
                    obj = new ShelfForShoes();
                    AddingFurniture(obj);
                    break;
                case "Table":
                    obj = new Table();
                    AddingFurniture(obj);
                    break;
                case "Door":
                    obj = new Door();
                    AddingFurniture(obj);
                    break;
                case "Window":
                    obj = new Window();
                    AddingFurniture(obj);
                    break;
            }   
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex>=0)
            dataGridView1.Rows[e.RowIndex].Selected = true;
           
        }
        private void Furniture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach(Object objec in TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListFurniture)
            {
                FurnitureObject  c = (FurnitureObject)objec;
                if (c.ControlObject == sender.GetHashCode())
                {
                    ChangeTheFurniture change = new ChangeTheFurniture(c);
                    if (change.ShowDialog() == DialogResult.OK)
                    {
                        int cur = 0;
                        foreach (Control control in TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListControlPanel)
                        {

                            if (control.GetHashCode() == c.ControlObject)
                            {
                                if (c.Angle == 0 || c.Angle == 180)
                                    control.Size = new Size((int)c.Width, (int)c.Depth);
                                else
                                    control.Size = new Size((int)c.Depth, (int)c.Width);
                                break;
                            }
                            cur++;

                        }
                        dataGridView1["Width", cur].Value = c.Width;
                        dataGridView1["Height", cur].Value = c.Height;
                        dataGridView1["Depth", cur].Value = c.Depth;
                        dataGridView1["Nam", cur].Value = c.Name;
                        dataGridView1["Angle", cur].Value = c.Angle;
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[cur].Selected = true;
                        return;
                    }
                }
            }
        }
        private void picture_MouseClick(object sender, MouseEventArgs e)
        {
            int cur = 0;
            if (TheCurrentPlan.ListRoom.Count <= 0)
                return;
            if (TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListFurniture.Count <= 0)
                return;
            foreach (Object objec in TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListFurniture)
            {
                FurnitureObject c = (FurnitureObject)objec;
                if (c.ControlObject == sender.GetHashCode())
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[cur].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[cur].Cells[0];
                    return;
                }
                cur++;
            }
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Delete)
            {
                if (TheCurrentPlan.ListRoom.Count <= 0)
                    return;
                string message = "Вы действительно хотите удалить?";
                string caption = "...";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult res  = MessageBox.Show(message, caption, buttons);
                if (res != DialogResult.Yes)
                    return;
                TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListFurniture.RemoveAt(dataGridView1.CurrentRow.Index);
                TheCurrentPlan.ListRoom[listBoxRoom.SelectedIndex].ListControlPanel.RemoveAt(dataGridView1.CurrentRow.Index);
                panel.Controls.RemoveAt(dataGridView1.CurrentRow.Index);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }
        private void listBoxRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TheCurrentPlan.ListRoom.Count <= 0)
                    return;
                string message = "Вы действительно хотите удалить комнату?";
                string caption = "...";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult res = MessageBox.Show(message, caption, buttons);
                if (res != DialogResult.Yes)
                    return;
                TheCurrentPlan.ListRoom.RemoveAt(listBoxRoom.SelectedIndex);
                panel.Controls.Clear();
                dataGridView1.Rows.Clear();
                listBoxRoom.Items.RemoveAt(listBoxRoom.SelectedIndex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
    }
}
