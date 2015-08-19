using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace D1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bmp = pictureBox1.Image as Bitmap;

            using(var img = new ImagerBitmap(bmp))
            {
                for (int x = 0; x < img.Width; x++)
                    for (int y = 0; y < img.Height; y++)
                    {
                        var px = img.GetPixel(x, y);
                        var intensity = (int)(px.R*0.16 + px.B*0.6 + px.G*0.24);
                        Color newColor = Color.FromArgb(intensity, intensity, intensity);
                        img.SetPixel(x,y,newColor);
                    }

                pictureBox1.Image = img.Bitmap;
            }
        }

        private void gauss()
        {
            var bmp = pictureBox1.Image as Bitmap;

            using (var img = new ImagerBitmap(bmp))
            {
                int gaussWidth = 5;
                for (int x = gaussWidth; x < img.Width - 5; x++)
                    for (int y = gaussWidth; y < img.Height - 5; y++)
                    {
                        int R = 0, G = 0, B = 0, count = 0;

                        for (int x1 = x - gaussWidth; x1 <= x + gaussWidth; x1++)
                            for (int y1 = y - gaussWidth; y1 <= y + gaussWidth; y1++)
                            {
                                var c = img.GetPixel(x1, y1);
                                count++;
                                R += c.R;
                                G += c.G;
                                B += c.B;
                            }
                        img.SetPixel(x, y, Color.FromArgb(R / count, G / count, B / count));
                    }

                pictureBox1.Image = img.Bitmap;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(gauss).Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = origin.Clone() as Bitmap;
        }

        Bitmap origin;
        private void Form1_Load(object sender, EventArgs e)
        {
            origin = pictureBox1.Image.Clone() as Bitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var bmp = pictureBox1.Image as Bitmap;
            var dst = bmp.Clone() as Bitmap;

            using (var img = new ImagerBitmap(bmp))
            using (var imgDst = new ImagerBitmap(dst))
            {
                int gaussWidth = 1;
                for (int x = gaussWidth; x < img.Width - 5; x++)
                    for (int y = gaussWidth; y < img.Height - 5; y++)
                    {
                        List<MedianPixel> neibourghs = new List<MedianPixel>();

                        for (int x1 = x - gaussWidth; x1 <= x + gaussWidth; x1++)
                            for (int y1 = y - gaussWidth; y1 <= y + gaussWidth; y1++)
                            {
                                var c = img.GetPixel(x1, y1);
                                neibourghs.Add(new MedianPixel(c));
                            }

                        var newColor = neibourghs.OrderBy(n => n.Intensity).Skip(neibourghs.Count / 2).First().Color;

                        imgDst.SetPixel(x, y, newColor);
                    }

                pictureBox1.Image = imgDst.Bitmap;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var bmp = pictureBox1.Image as Bitmap;

            Random rnd = new Random();

            using (var img = new ImagerBitmap(bmp))
            {
                for (int x = 0; x < img.Width; x++)
                    for (int y = 0; y < img.Height; y++)
                    {
                        if (rnd.Next(6000) == 555)
                            img.SetPixel(x, y, Color.Red);
                        if (rnd.Next(6000) == 556)
                            img.SetPixel(x, y, Color.Blue);
                        if (rnd.Next(6000) == 557)
                            img.SetPixel(x, y, Color.Green);
                        if (rnd.Next(6000) == 556)
                            img.SetPixel(x, y, Color.Black);
                        if (rnd.Next(6000) == 557)
                            img.SetPixel(x, y, Color.White);
                    }

                pictureBox1.Image = img.Bitmap;
            }
        }
        static int cl(double a)
        {
            int aa = (int)a;
            if (aa <= 0)
                return 0;
            if (aa >= 255)
                return 255;
            return aa;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            var bmp = pictureBox1.Image as Bitmap;

            Random rnd = new Random();

            using (var img = new ImagerBitmap(bmp))
            {
                for (int x = 0; x < img.Width; x++)
                    for (int y = 0; y < img.Height; y++)
                    {
                        var px = img.GetPixel(x,y);
                        var S = ((px.R * 0.16 + px.G * 0.6 + px.B * 0.24)/128-1)*((float)trackBar1.Value/5)+1;
                        img.SetPixel(x, y, Color.FromArgb(cl(px.R*S),cl(px.G*S),cl(px.B*S)));
                        
                    }
                pictureBox1.Image = img.Bitmap;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Load Image", Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            origin = Image.FromFile(ofd.FileName) as Bitmap;
            pictureBox1.Image = origin.Clone() as Bitmap;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                origin = Clipboard.GetImage() as Bitmap;
                pictureBox1.Image = origin.Clone() as Bitmap;                
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pictureBox1.Image);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            bool ret = false;
            string filename = String.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp"))
                        {
                            origin = Image.FromFile(filename) as Bitmap;
                            pictureBox1.Image = origin.Clone() as Bitmap;
                        }
                    }
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

    }

    class MedianPixel
    {
        public MedianPixel(Color c)
        {
            Color = c;
            Intensity = (c.R + c.B + c.G) / 3.0;
        }
        public double Intensity { get; set; }
        public Color Color { get; set; }
    }
}
