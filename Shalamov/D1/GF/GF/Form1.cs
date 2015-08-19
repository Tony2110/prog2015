using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GF
{
    public partial class Form1 : Form
    {
        private List<Bitmap> BackUps;
        private int Index;
        private class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; set; }
            public int Y { get; set; }
            /// <summary>
            /// Возвращает дистанцию от используемой точки, до точки В
            /// </summary>
            public float GetDistance(Point B)
            {
                return (float)Math.Sqrt(Math.Pow(X - B.X, 2) + Math.Pow(Y - B.Y, 2));
            }
        }
        public Form1()
        {
            InitializeComponent();
            BackUps = new List<Bitmap>();
            Index = 0;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var F = new OpenFileDialog()
            {
                Title = "Открыть файл...",
                Filter = "JPG|*.jpg|PNG|*.png"
            };
            var R = F.ShowDialog(this);
            if (R != DialogResult.OK)
                return;
            pictureBox1.Image = Image.FromFile(F.FileName);
        }

        private void Ok_Vin_Click(object sender, EventArgs e)
        {
            BackUps.Add(pictureBox1.Image.Clone() as Bitmap);
            Index++;
            var IB = pictureBox1.Image as Bitmap;
            using (var img = new ImagerBitmap(IB))
            {
                var Center = new Point(img.Width / 2,img.Height / 2);
                for (int x = 0; x < img.Width; x++)
                    for (int y = 0; y < img.Height; y++)
                    {
                        var pix = img.GetPixel(x, y);
                        if (Center.GetDistance(new Point(x, y)) + Center.GetDistance(new Point(0, 0))/(10 - trackBar1.Value) > Center.GetDistance(new Point(0, 0)))
                        {
                            img.SetPixel(x, y, Color.Black);
                        }
                    }
                pictureBox1.Image = img.Bitmap;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackUps.Add(pictureBox1.Image.Clone() as Bitmap);
            Index++;
            var IB = pictureBox1.Image as Bitmap;
            using (var img = new ImagerBitmap(IB))
            {
                for (int x = 0; x < img.Width; x++)
                    for (int y = 0; y < img.Height; y++)
                    {
                        var pix = img.GetPixel(x, y);
                        var NewColor = Color.FromArgb((((pix.R + trackR.Value) > 255) ? 255 : pix.R + trackR.Value), (((pix.G + trackG.Value) > 255) ? 255 : pix.G + trackG.Value), (((pix.B + trackB.Value) > 255) ? 255 : pix.B + trackB.Value));
                        img.SetPixel(x, y, NewColor);
                    }
                pictureBox1.Image = img.Bitmap;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Index > 0)
            {
                pictureBox1.Image = BackUps[Index - 1];
                Index -= 1;
                BackUps.RemoveAt(BackUps.Count - 1);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var F = new SaveFileDialog()
            {
                Title = "Сохранение...",
                Filter = "PNG|*.png"
            };
            var r = F.ShowDialog();
            if(r != System.Windows.Forms.DialogResult.OK)
                return;
            pictureBox1.Image.Save(F.FileName, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
