using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                        var intensity = px.R + px.B + px.G;
                        intensity /= 3;
                        Color newColor = Color.FromArgb(intensity, intensity, intensity);
                        img.SetPixel(x,y,newColor);
                    }

                pictureBox1.Image = img.Bitmap;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var bmp = pictureBox1.Image as Bitmap;

            using (var img = new ImagerBitmap(bmp))
            {             
                int gaussWidth = 5;
                for (int x = gaussWidth; x < img.Width-5; x++)
                    for (int y = gaussWidth; y < img.Height-5; y++)
                    {
                        int R = 0, G = 0, B = 0, count = 0;

                        for (int x1 = x - gaussWidth; x1 <= x + gaussWidth;x1++ )
                            for (int y1 = y - gaussWidth; y1 <= y + gaussWidth; y1++)
                            {
                                var c = img.GetPixel(x1, y1);
                                count++;
                                R += c.R;
                                G += c.G;
                                B += c.B;
                            }
                        img.SetPixel(x, y, Color.FromArgb(R/count, G/count, B/count));
                    }

                pictureBox1.Image = img.Bitmap;
            }
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

        private void buttonNew_Click(object sender, EventArgs e)
        {
            var bmp = pictureBox1.Image as Bitmap;
            var dst = bmp.Clone() as Bitmap;
            using (var img = new ImagerBitmap(bmp))
            using (var imgDst = new ImagerBitmap(dst))
            {
                for (int x = 0; x < img.Width; x++)
                    for (int y = 0; y < img.Height; y++)
                    {
                        var px = img.GetPixel(x, y);
                        var sepia = (px.G + px.R+px.B)/3;
                        if (x < 7 || x > img.Width - 7 || y < 7 || y > img.Height-7)
                        {
                            imgDst.SetPixel(x, y, Color.DarkSeaGreen);
                        }
                        else
                        {
                            Color newColor = Color.FromArgb(25,sepia, sepia/2, sepia/6);
                            imgDst.SetPixel(x, y, newColor);
                        }
                        
                    }
                
                pictureBox1.Image = imgDst.Bitmap;
            }
        }

        private void New2_Click(object sender, EventArgs e)
        {
            int n = 0;
            var bmp = pictureBox1.Image as Bitmap;
            var dst = bmp.Clone() as Bitmap;
            using (var img = new ImagerBitmap(bmp))
            using (var imgDst = new ImagerBitmap(dst))
            {
                Random rand=new Random();
                for (int x = 3; x < imgDst.Width-3; x++)
                    for (int y = 3; y < imgDst.Height-3; y++)
                    {
                        var px = img.GetPixel(x, y);
                        if (rand.Next(200) == 100)
                        {
                            
                            
                                imgDst.SetPixel(x, y - 2, Color.White);
                                imgDst.SetPixel(x, y - 3, Color.White);
                                imgDst.SetPixel(x, y - 1, Color.White);
                                imgDst.SetPixel(x - 3, y, Color.White);
                                imgDst.SetPixel(x - 2, y, Color.White);
                                imgDst.SetPixel(x - 1, y, Color.White);
                                imgDst.SetPixel(x, y, Color.White);
                                imgDst.SetPixel(x + 1, y, Color.White);
                                imgDst.SetPixel(x + 2, y, Color.White);
                                imgDst.SetPixel(x + 3, y, Color.White);
                                imgDst.SetPixel(x, y + 1, Color.White);
                                imgDst.SetPixel(x, y + 2, Color.White);
                                imgDst.SetPixel(x, y + 3, Color.White);
                                imgDst.SetPixel(x+1, y+1, Color.White);
                                imgDst.SetPixel(x+2, y+2, Color.White);
                                imgDst.SetPixel(x-1, y-1, Color.White);
                                imgDst.SetPixel(x-2, y-2, Color.White);
                                imgDst.SetPixel(x-1, y+1, Color.White);
                                imgDst.SetPixel(x-2, y+2, Color.White);
                                imgDst.SetPixel(x+1, y-1, Color.White);
                                imgDst.SetPixel(x+2, y-2, Color.White);
                                x = x + 3;
                                y = y + 3;
                            
                        }
                    }

                pictureBox1.Image = imgDst.Bitmap;
            }
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
