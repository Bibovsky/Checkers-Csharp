using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Che
{ 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (var pictureBox in Controls.OfType<PictureBox>())
                if (pictureBox.Tag == null)
                    pictureBox.AllowDrop = true;
        }
        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox picbox = (PictureBox)sender;
            picbox.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as PictureBox).Image != null)
                (sender as PictureBox).DoDragDrop((sender as PictureBox).Image, DragDropEffects.Copy);
            if ((sender as PictureBox).Tag == null)
                (sender as PictureBox).Image = null;
        }
    }
}
