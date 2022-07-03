using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoruntuIslemeFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = false;
        }

        int Syc = 0;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(Syc == 0)
                {
                    openFileDialog1.DefaultExt = ".jpg";
                    openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                    openFileDialog1.ShowDialog();
                    String ResminYolu = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(ResminYolu);

                    var Result = ResminYolu.Substring(24);

                    tabControl2.Visible = true;

                    tabControl2.TabPages[Syc].Text = Result;
                }
                else
                {
                    openFileDialog1.DefaultExt = ".jpg";
                    openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                    openFileDialog1.ShowDialog();
                    String ResminYolu = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(ResminYolu);

                    var Result = ResminYolu.Substring(24);

                    tabControl2.TabPages.Add(Result);

                }

                Syc++;
            }
            catch { }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox2.Image;
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
        }



        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;

            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.TabPages.RemoveAt(i);
            }
            if(tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, Gray);

            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı. Fonksiyonla gelmedi.
            int ResimYuksekligi = GirisResmi.Height;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur.
            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;

                    double X = Convert.ToDouble(textBox1.Text);
                    double Y = Convert.ToDouble(textBox2.Text);
                    double Z = Convert.ToDouble(textBox3.Text);

                    GriDeger = Convert.ToInt16(R * X + G * Y + B * Z);
                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;

        }

        private void blackWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;

            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                tabControl1.TabPages.RemoveAt(i);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, BW);


            if (checkBox17.Checked)
            {
                int R = 0, G = 0, B = 0;
                Color OkunanRenk, DonusenRenk;
                Bitmap GirisResmi, CikisResmi;
                GirisResmi = new Bitmap(pictureBox1.Image);
                int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur.

                int MinEsikleme = 0;
                int MaxEsikleme = Convert.ToInt16(textBox4.Text);

                //int EsiklemeDegeri = Convert.ToInt32(textBox1.Text);
                for (int x = 0; x < ResimGenisligi; x++)
                {
                    for (int y = 0; y < ResimYuksekligi; y++)
                    {
                        OkunanRenk = GirisResmi.GetPixel(x, y);
                        if ((MinEsikleme <= OkunanRenk.R) && (OkunanRenk.R <= MaxEsikleme))
                            R = 255;
                        else
                            R = 0;
                        if ((MinEsikleme <= OkunanRenk.G) && (OkunanRenk.G <= MaxEsikleme))
                            G = 255;
                        else
                            G = 0;
                        if ((MinEsikleme <= OkunanRenk.B) && (OkunanRenk.B <= MaxEsikleme))
                            B = 255;
                        else
                            B = 0;
                        DonusenRenk = Color.FromArgb(R, G, B);
                        CikisResmi.SetPixel(x, y, DonusenRenk);
                    }
                }
                pictureBox2.Image = CikisResmi;
            }
            else if (checkBox18.Checked)
            {
                int R = 0, G = 0, B = 0;
                Color OkunanRenk, DonusenRenk;
                Bitmap GirisResmi, CikisResmi;
                GirisResmi = new Bitmap(pictureBox1.Image);
                int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur.

                int MinEsikleme = Convert.ToInt16(textBox5.Text);
                int MaxEsikleme = Convert.ToInt16(textBox6.Text);

                //int EsiklemeDegeri = Convert.ToInt32(textBox1.Text);
                for (int x = 0; x < ResimGenisligi; x++)
                {
                    for (int y = 0; y < ResimYuksekligi; y++)
                    {
                        OkunanRenk = GirisResmi.GetPixel(x, y);
                        if ((MinEsikleme <= OkunanRenk.R) && (OkunanRenk.R <= MaxEsikleme))
                            R = 255;
                        else
                            R = 0;
                        if ((MinEsikleme <= OkunanRenk.G) && (OkunanRenk.G <= MaxEsikleme))
                            G = 255;
                        else
                            G = 0;
                        if ((MinEsikleme <= OkunanRenk.B) && (OkunanRenk.B <= MaxEsikleme))
                            B = 255;
                        else
                            B = 0;
                        DonusenRenk = Color.FromArgb(R, G, B);
                        CikisResmi.SetPixel(x, y, DonusenRenk);
                    }
                }
                pictureBox2.Image = CikisResmi;
            }

        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                tabControl1.TabPages.RemoveAt(i);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            for(int i = 0; i < ResimGenisligi; i++)
            {
                for(int j = 0; j < ResimYuksekligi; j++)
                {
                    CikisResmi.SetPixel(i,j,Color.FromArgb( 255 - GirisResmi.GetPixel(i,j).R , 255 - GirisResmi.GetPixel(i, j).G , 255 - GirisResmi.GetPixel(i, j).B));
                }
            }

            pictureBox2.Image = CikisResmi;
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;

            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                tabControl1.TabPages.RemoveAt(i);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, Brightness);

            if(checkBox19.Checked)
            {
                int R = 0, G = 0, B = 0;
                Bitmap GirisResmi, CikisResmi;
                GirisResmi = new Bitmap(pictureBox1.Image);
                int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

                for (int i = 0; i < ResimGenisligi; i++)
                {
                    for (int j = 0; j < ResimYuksekligi; j++)
                    {
                        R = GirisResmi.GetPixel(i, j).R;
                        G = GirisResmi.GetPixel(i, j).G;
                        B = GirisResmi.GetPixel(i, j).B;

                        R = R + Convert.ToInt16(textBox7.Text);
                        G = G + Convert.ToInt16(textBox8.Text);
                        B = B + Convert.ToInt16(textBox9.Text);

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;

                        CikisResmi.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                }

                pictureBox2.Image = CikisResmi;
            }
            else if(checkBox20.Checked)
            {
                int R = 0, G = 0, B = 0;
                Bitmap GirisResmi, CikisResmi;
                GirisResmi = new Bitmap(pictureBox1.Image);
                int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

                for (int i = 0; i < ResimGenisligi; i++)
                {
                    for (int j = 0; j < ResimYuksekligi; j++)
                    {
                        R = GirisResmi.GetPixel(i, j).R;
                        G = GirisResmi.GetPixel(i, j).G;
                        B = GirisResmi.GetPixel(i, j).B;

                        R = R - Convert.ToInt16(textBox12.Text);
                        G = G - Convert.ToInt16(textBox11.Text);
                        B = B - Convert.ToInt16(textBox10.Text);

                        if (R < 0) R = 0;
                        if (G < 0) G = 0;
                        if (B < 0) B = 0;

                        CikisResmi.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                }

                pictureBox2.Image = CikisResmi;
            }
           
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, Constrast);

            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor.
            int X1 = Convert.ToInt16(textBox16.Text);
            int X2 = Convert.ToInt16(textBox15.Text);
            int Y1 = Convert.ToInt16(textBox13.Text);
            int Y2 = Convert.ToInt16(textBox14.Text);
            int i = 0, j = 0; //Çıkış resminin x ve y si olacak.
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    int Gri = (R + G + B) / 3;
                    //*********** Kontras Formülü***************
                    int X = Gri;
                    int Y = ((((X - X1) * Y2 - Y1)) / (X2 - X1)) + Y1;
                    if (Y > 255) Y = 255;
                    if (Y < 0) Y = 0;
                    DonusenRenk = Color.FromArgb(Y, Y, Y);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            
            pictureBox2.Image = CikisResmi;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Point PicPoint = PointToScreen(new Point(pictureBox2.Bounds.Left, pictureBox1.Bounds.Top));
            Point CurPoint = Cursor.Position;

            textBox16.Text = Math.Abs(PicPoint.X - CurPoint.X).ToString();
            textBox15.Text = Math.Abs(PicPoint.Y - CurPoint.Y).ToString();

            Graphics CizimAlani;
            Pen Kalem = new Pen(System.Drawing.Color.Red, 1);
            CizimAlani = pictureBox2.CreateGraphics();

            CizimAlani.DrawRectangle( Kalem , Math.Abs(PicPoint.X - CurPoint.X) , Math.Abs(PicPoint.Y - CurPoint.Y) , 2 , 2);
        }

        private void redChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            for (int i = 0; i < ResimGenisligi; i++)
            {
                for (int j = 0; j < ResimYuksekligi; j++)
                {
                    R = GirisResmi.GetPixel(i, j).R;

                    CikisResmi.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }

            pictureBox2.Image = CikisResmi;
        }

        private void greenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            for (int i = 0; i < ResimGenisligi; i++)
            {
                for (int j = 0; j < ResimYuksekligi; j++)
                {
                    G = GirisResmi.GetPixel(i, j).G;

                    CikisResmi.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }

            pictureBox2.Image = CikisResmi;
        }

        private void blueChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            for (int i = 0; i < ResimGenisligi; i++)
            {
                for (int j = 0; j < ResimYuksekligi; j++)
                {
                    B = GirisResmi.GetPixel(i, j).B;

                    CikisResmi.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }

            pictureBox2.Image = CikisResmi;
        }

        List<Point> NoktalarDizisi = new List<Point>();
        bool Drm = false;
        int Sayac = 0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point PicBox = PointToScreen(new Point(pictureBox1.Bounds.Left, pictureBox1.Bounds.Top));
            Point Mouse = Cursor.Position;

            Point Sonuc = new Point();
            Sonuc.X = Math.Abs(PicBox.X - Mouse.X + tabControl2.Location.X);
            Sonuc.Y = Math.Abs(PicBox.Y - Mouse.Y + tabControl2.Location.Y + 20);

            NoktalarDizisi.Add(Sonuc);

            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Red, 2);
            CizimAlani = pictureBox1.CreateGraphics();
            CizimAlani.DrawRectangle(Kalem1, NoktalarDizisi.First().X, NoktalarDizisi.First().Y, 2, 2);

            if (Drm)
            {
                if (((Sonuc.X - 15 < NoktalarDizisi.First().X) && (Sonuc.Y + 15 > NoktalarDizisi.First().Y)) && ((Sonuc.Y - 15 < NoktalarDizisi.First().Y) && (Sonuc.Y + 15 > NoktalarDizisi.First().Y)))
                {
                    NoktalarDizisi.Insert(NoktalarDizisi.Count, NoktalarDizisi.Last());
                }

                CizimAlani = pictureBox1.CreateGraphics();
                CizimAlani.DrawLine(Kalem1, NoktalarDizisi.ElementAt(Sayac - 1).X, NoktalarDizisi.ElementAt(Sayac - 1).Y, NoktalarDizisi.ElementAt(Sayac).X, NoktalarDizisi.ElementAt(Sayac).Y);

            }

            Sayac++;
            Drm = true;
        }

        private void corpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;

            CikisResmi = new Bitmap(ResimGenisligi,ResimYuksekligi);

            for (int i = 0; i < ResimGenisligi; i++)
            {
                for (int j = 0; j < ResimYuksekligi; j++)
                {
                    if (InsideOutside(i, j) == true)
                    {
                        CikisResmi.SetPixel(i, j, GirisResmi.GetPixel(i, j));
                    }
                    else
                    {
                        CikisResmi.SetPixel(i, j, Color.FromArgb(0,0,0));
                    }
                }
            }

            pictureBox2.Image = CikisResmi;
        }

        public bool InsideOutside(float X, float Y)
        {
            int EnBuyukNokta = NoktalarDizisi.Count - 1;
            float TotalAci = AciBul(NoktalarDizisi[EnBuyukNokta].X, NoktalarDizisi[EnBuyukNokta].Y, X, Y, NoktalarDizisi[0].X, NoktalarDizisi[0].Y);

            for (int i = 0; i < EnBuyukNokta; i++)
            {
                TotalAci += AciBul(NoktalarDizisi[i].X, NoktalarDizisi[i].Y, X, Y, NoktalarDizisi[i + 1].X, NoktalarDizisi[i + 1].Y);
            }

            return (Math.Abs(TotalAci) > 0.000001);
        }

        public static float AciBul(float Bir, float Iki, float Uc, float Dort, float Bes, float Alti)
        {

            float Noktalar = Noktaciklar(Bir, Iki, Uc, Dort, Bes, Alti);

            float KarsitNoktalar = KarsitNoktalarUzunlugu(Bir, Iki, Uc, Dort, Bes, Alti);

            return (float)Math.Atan2(KarsitNoktalar, Noktalar);
        }

        public static float KarsitNoktalarUzunlugu(float Bir, float Iki, float Uc, float Dort, float Bes, float Alti)
        {
            float First = Bir - Uc;
            float Second = Iki - Dort;
            float Third = Bes - Uc;
            float Forth = Alti - Dort;

            return (First * Forth - Second * Third);
        }

        private static float Noktaciklar(float Bir, float Iki, float Uc, float Dort, float Bes, float Alti)
        {
            float First = Bir - Uc;
            float Second = Iki - Dort;
            float Third = Bes - Uc;
            float Forth = Alti - Dort;

            return (First * Third + Second * Forth);
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, Move);

            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            double x2 = 0, y2 = 0;
            //Taşıma mesafelerini atıyor.
            int Tx = Convert.ToInt16(textBox18.Text);
            int Ty = Convert.ToInt16(textBox17.Text);
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);
                    x2 = x1 + Tx;
                    y2 = y1 + Ty;
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                    {
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                    }
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, Mirror);

            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            double Aci = Convert.ToDouble(textBox19.Text);
            double RadyanAci = Aci * 2 * Math.PI / 360;
            double x2 = 0, y2 = 0;
            //Resim merkezini buluyor. Resim merkezi etrafında döndürecek.
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYuksekligi / 2;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);
                    //----A-Orta dikey eksen etrafında aynalama ----------------
                    //x2 = Convert.ToInt16(-x1 + 2 * x0);
                    //y2 = Convert.ToInt16(y1);
                    //----B-Orta yatay eksen etrafında aynalama ----------------
                    //x2 = Convert.ToInt16(x1);
                    //y2 = Convert.ToInt16(-y1 + 2 *y0);

                    //----C-Ortadan geçen 45 açılı çizgi etrafında aynalama----------
                    double Delta = (x1 - x0) * Math.Sin(RadyanAci) - (y1 - y0) * Math.Cos(RadyanAci);
                    x2 = Convert.ToInt16(x1 + 2 * Delta * (-Math.Sin(RadyanAci)));
                    y2 = Convert.ToInt16(y1 + 2 * Delta * (Math.Cos(RadyanAci)));
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, Rotation);

            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int Aci = Convert.ToInt16(textBox20.Text);
            double RadyanAci = Aci * 2 * Math.PI / 360;
            double x2 = 0, y2 = 0;
            //Resim merkezini buluyor. Resim merkezi etrafında döndürecek.
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYuksekligi / 2;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);
                    //Döndürme Formülleri
                    x2 = Math.Cos(RadyanAci) * (x1 - x0) - Math.Sin(RadyanAci) * (y1 - y0) + x0;
                    y2 = Math.Sin(RadyanAci) * (x1 - x0) + Math.Cos(RadyanAci) * (y1 - y0) + y0;
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            pictureBox2.Image = CikisResmi;

        }

        private void bendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, Bending);

            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            //Taşıma mesafelerini atıyor.
            double EgmeKatsayisi = Convert.ToInt16( textBox21.Text );
            double x2 = 0, y2 = 0;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);
                    // +X ekseni yönünde
                    //x2 = x1 + EgmeKatsayisi * y1;
                    //y2 = y1;
                    // -X ekseni yönünde
                    //x2 = x1 - EgmeKatsayisi * y1;
                    //y2 = y1;
                    // +Y ekseni yönünde
                    //x2 = x1;
                    //y2 = EgmeKatsayisi * x1 + y1;
                    // -Y ekseni yönünde
                    x2 = x1;
                    y2 = -EgmeKatsayisi * x1 + y1;

                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, Scaling);

            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            int R = 0, G = 0, B = 0;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resminin boyutları
            int x2 = 0, y2 = 0; //Çıkış resminin x ve y si olacak.
            int KucultmeKatsayisi = Convert.ToInt16( textBox22.Text );
            for (int x1 = 0; x1 < ResimGenisligi; x1 = x1 + KucultmeKatsayisi)
            {
                y2 = 0;
                for (int y1 = 0; y1 < ResimYuksekligi; y1 = y1 + KucultmeKatsayisi)
                {
                    //x ve y de ilerlerken her atlanan pikselleri okuyacak ve ortalama değerini alacak.
                    R = 0; G = 0; B = 0;
                    try //resim sınırının dışına çıkaldığında hata vermesin diye
                    {
                        for (int i = 0; i < KucultmeKatsayisi; i++)
                        {
                            for (int j = 0; j < KucultmeKatsayisi; j++)
                            {
                                OkunanRenk = GirisResmi.GetPixel(x1 + i, y1 + j);
                                R = R + OkunanRenk.R;
                                G = G + OkunanRenk.G;
                                B = B + OkunanRenk.B;
                            }
                        }
                    }
                    catch { }
                    //Renk kanallarının ortalamasını alıyor
                    R = R / (KucultmeKatsayisi * KucultmeKatsayisi);
                    G = G / (KucultmeKatsayisi * KucultmeKatsayisi);
                    B = B / (KucultmeKatsayisi * KucultmeKatsayisi);
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x2, y2, DonusenRenk);
                    y2++;
                }
                x2++;
            }
            pictureBox2.Image = CikisResmi;
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, Blur);

            if (checkBox21.Checked)
            {
                OrtalamaFiltresi();
            }
            else if (checkBox22.Checked)
            {
                OrtancaFiltresi();
            }
            else if (checkBox23.Checked)
            {
                GaussFiltresi();
            }
        }

        public void OrtalamaFiltresi()
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3; //şablon boyutu 3 den büyük tek rakam olmalıdır (3,5,7 gibi). 
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;

            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0; toplamG = 0; toplamB = 0;
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R; toplamG = toplamG + OkunanRenk.G; toplamB = toplamB + OkunanRenk.B;
                        }
                    }
                    ortalamaR = toplamR / (SablonBoyutu * SablonBoyutu);
                    ortalamaG = toplamG / (SablonBoyutu * SablonBoyutu);
                    ortalamaB = toplamB / (SablonBoyutu * SablonBoyutu);
                    CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        public void OrtancaFiltresi()
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3; //şablon boyutu 3 den büyük tek rakam olmalıdır (3,5,7 gibi). 
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int[] R = new int[ElemanSayisi];
            int[] G = new int[ElemanSayisi];
            int[] B = new int[ElemanSayisi];
            int[] Gri = new int[ElemanSayisi];
            int x, y, i, j;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                { //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor. 
                    int k = 0;
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            R[k] = OkunanRenk.R;
                            G[k] = OkunanRenk.G;
                            B[k] = OkunanRenk.B;
                            Gri[k] = Convert.ToInt16(R[k] * 0.299 + G[k] * 0.587 + B[k] * 0.114); //Gri ton formülü
                            k++;
                        }
                    }
                    //Gri tona göre sıralama yapıyor. Aynı anda üç rengide değiştiriyor. 
                    int GeciciSayi = 0;
                    for (i = 0; i < ElemanSayisi; i++)
                    {
                        for (j = i + 1; j < ElemanSayisi; j++)
                        {
                            if (Gri[j] < Gri[i])
                            {
                                GeciciSayi = Gri[i];
                                Gri[i] = Gri[j];
                                Gri[j] = GeciciSayi;
                                GeciciSayi = R[i];
                                R[i] = R[j];
                                R[j] = GeciciSayi;
                                GeciciSayi = G[i];
                                G[i] = G[j];
                                G[j] = GeciciSayi;
                                GeciciSayi = B[i];
                                B[i] = B[j];
                                B[j] = GeciciSayi;
                            }
                        }
                    }
                    //Sıralama sonrası ortadaki değeri çıkış resminin piksel değeri olarak atıyor. 
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R[(ElemanSayisi - 1) / 2], G[(ElemanSayisi - 1) / 2], B[(ElemanSayisi - 1) / 2]));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        public void GaussFiltresi()
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 5; //Çekirdek matrisin boyutu 
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            int[] Matris = { 1, 4, 7, 4, 1, 4, 20, 33, 20, 4, 7, 33, 55, 33, 7, 4, 20, 33, 20, 4, 1, 4, 7, 4, 1 };
            int MatrisToplami = 1 + 4 + 7 + 4 + 1 + 4 + 20 + 33 + 20 + 4 + 7 + 33 + 55 + 33 + 7 + 4 + 20 + 33 + 20 + 4 + 1 + 4 + 7 + 4 + 1;

            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor. 
                    int k = 0; //matris içindeki elemanları sırayla okurken kullanılacak. 
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);

                            toplamR = toplamR + OkunanRenk.R * Matris[k];
                            toplamG = toplamG + OkunanRenk.G * Matris[k];
                            toplamB = toplamB + OkunanRenk.B * Matris[k];
                            k++;
                        }

                        ortalamaR = toplamR / MatrisToplami;
                        ortalamaG = toplamG / MatrisToplami;
                        ortalamaB = toplamB / MatrisToplami;

                        CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));

                    }
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void sharpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, Sharpenning);

            if (checkBox24.Checked)
            {
                KenarNetlestirme();
            }
            else if (checkBox25.Checked)
            {
                KonvolusyonNetlestirme();
            }
            else if (checkBox26.Checked)
            {
                NormallestimeNetlestirme();
            }
        }

        public void KenarNetlestirme()
        {
            Bitmap OrjinalResim = new Bitmap(pictureBox1.Image);
            Bitmap BulanikResim = BtmpMeanFiltresi(); //Bitmap BulanikResim = GaussFiltresi();
            Bitmap KenarGoruntusu = OrjianalResimdenBulanikResmiCikarma(OrjinalResim, BulanikResim);
            Bitmap NetlesmisResim = KenarGoruntusuIleOrjinalResmiBirlestir(OrjinalResim, KenarGoruntusu);
            pictureBox2.Image = NetlesmisResim;
        }

        public Bitmap OrjianalResimdenBulanikResmiCikarma(Bitmap OrjinalResim, Bitmap BulanikResim)
        {
            Color OkunanRenk1, OkunanRenk2, DonusenRenk; Bitmap CikisResmi;
            int ResimGenisligi = OrjinalResim.Width; int ResimYuksekligi = OrjinalResim.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int R, G, B; double Olcekleme = 2; //Keskin kenaları daha iyi görmek için değerini artırıyoruz. 
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk1 = OrjinalResim.GetPixel(x, y);
                    OkunanRenk2 = BulanikResim.GetPixel(x, y);
                    R = Convert.ToInt16(Olcekleme * Math.Abs(OkunanRenk1.R - OkunanRenk2.R));
                    G = Convert.ToInt16(Olcekleme * Math.Abs(OkunanRenk1.G - OkunanRenk2.G));
                    B = Convert.ToInt16(Olcekleme * Math.Abs(OkunanRenk1.B - OkunanRenk2.B));
                    //=============================================================== 
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak. (Dikkat: Normalizasyon yapılmamıştır. ) 
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0; if (G < 0) G = 0; if (B < 0) B = 0;
                    //================================================================ 
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            return CikisResmi;
        }

        public Bitmap KenarGoruntusuIleOrjinalResmiBirlestir(Bitmap OrjinalResim, Bitmap KenarGoruntusu)
        {
            Color OkunanRenk1, OkunanRenk2, DonusenRenk; Bitmap CikisResmi;
            int ResimGenisligi = OrjinalResim.Width; int ResimYuksekligi = OrjinalResim.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int R, G, B;

            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk1 = OrjinalResim.GetPixel(x, y); OkunanRenk2 = KenarGoruntusu.GetPixel(x, y);
                    R = OkunanRenk1.R + OkunanRenk2.R;
                    G = OkunanRenk1.G + OkunanRenk2.G;
                    B = OkunanRenk1.B + OkunanRenk2.B;
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    DonusenRenk = Color.FromArgb(R, G, B); CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            return CikisResmi;
        }

        public void KonvolusyonNetlestirme()
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB;
            int R, G, B;
            int[] Matris = { 0, -2, 0, -2, 11, -2, 0, -2, 0 };
            int MatrisToplami = 0 + -2 + 0 + -2 + 11 + -2 + 0 + -2 + 0;

            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek. 
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor. 
                    int k = 0;
                    //matris içindeki elemanları sırayla okurken kullanılacak. 
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R * Matris[k];
                            toplamG = toplamG + OkunanRenk.G * Matris[k];
                            toplamB = toplamB + OkunanRenk.B * Matris[k];
                            k++;
                        }
                    }
                    R = toplamR / MatrisToplami; G = toplamG / MatrisToplami; B = toplamB / MatrisToplami;
                    //=========================================================== //Renkler sınırların dışına çıktıysa, sınır değer alınacak. 
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    //===========================================================
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        public void NormallestimeNetlestirme()
        {

            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB;
            int R, G, B;
            int[] Matris = { 0, -2, 0, -2, 11, -2, 0, -2, 0 };
            int MatrisToplami = 3;
            int EnBuyukR = 0;
            int EnBuyukG = 0;
            int EnBuyukB = 0;
            int EnKucukR = 0;
            int EnKucukG = 0;
            int EnKucukB = 0;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek.
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0; //matris içindeki elemanları sırayla okurken kullanılacak.
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R * Matris[k];
                            toplamG = toplamG + OkunanRenk.G * Matris[k];
                            toplamB = toplamB + OkunanRenk.B * Matris[k];
                            k++;
                        }
                    }
                    R = toplamR / MatrisToplami;
                    G = toplamG / MatrisToplami;
                    B = toplamB / MatrisToplami;
                    //===========================================================
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (R > 255)
                    {
                        if (EnBuyukR < R)
                            EnBuyukR = R;
                        //R = 255;
                    }
                    if (G > 255)
                    {
                        if (EnBuyukG < G)
                            EnBuyukG = G;
                        //G = 255;
                    }
                    if (B > 255)
                    {
                        if (EnBuyukB < B)
                            EnBuyukB = B;
                        //B = 255;
                    }
                    //------------------------
                    if (R < 0)
                    {
                        if (EnKucukR > R)
                            EnKucukR = R;
                        //R = 0;
                    }
                    if (G < 0)
                    {
                        if (EnKucukG > G)
                            EnKucukG = G;
                        //G = 0;
                    }
                    if (B < 0)
                    {
                        if (EnKucukB > B)
                            EnKucukB = B;
                        //B = 0;
                    }
                }
            }

            int EnBuyuk = 0, EnKucuk = 0;
            if (EnBuyukR > EnBuyuk)
                EnBuyuk = EnBuyukR;
            if (EnBuyukG > EnBuyuk)
                EnBuyuk = EnBuyukG;
            if (EnBuyukB > EnBuyuk)
                EnBuyuk = EnBuyukB;
            if (EnKucukR > EnKucuk)
                EnKucuk = EnKucukR;
            if (EnKucukG > EnKucuk)
                EnKucuk = EnKucukG;
            if (EnKucukB > EnKucuk)
                EnKucuk = EnKucukB;
            Bitmap NormallesmisNetResim = ResmiNormallestir(GirisResmi, SablonBoyutu, ResimGenisligi, ResimYuksekligi, EnBuyuk, EnKucuk);
            pictureBox2.Image = NormallesmisNetResim;

        }

        public Bitmap ResmiNormallestir(Bitmap GirisResmi, int SablonBoyutu, int ResimGenisligi, int ResimYuksekligi, int EnBuyuk, int EnKucuk)
        {
            int toplamR = 0;
            int toplamG = 0;
            int toplamB = 0;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int x, y, i, j;
            int R, G, B;
            int[] Matris = { 0, -2, 0, -2, 11, -2, 0, -2, 0 };
            int MatrisToplami = 3;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek.
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0; //matris içindeki elemanları sırayla okurken kullanılacak.
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            Color OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R * Matris[k];
                            toplamG = toplamG + OkunanRenk.G * Matris[k];
                            toplamB = toplamB + OkunanRenk.B * Matris[k];
                            k++;
                        }
                    }
                    R = toplamR / MatrisToplami;
                    G = toplamG / MatrisToplami;
                    B = toplamB / MatrisToplami;
                    //NORMALİZASYON------------------------
                    int YeniR = (255 * (R - EnKucuk)) / (EnBuyuk - EnKucuk);
                    int YeniG = (255 * (G - EnKucuk)) / (EnBuyuk - EnKucuk);
                    int YeniB = (255 * (B - EnKucuk)) / (EnBuyuk - EnKucuk);

                    if (YeniR > 255) YeniR = 255;
                    if (YeniG > 255) YeniG = 255;
                    if (YeniB > 255) YeniB = 255;
                    if (YeniR < 0) YeniR = 0;
                    if (YeniG < 0) YeniG = 0;
                    if (YeniB < 0) YeniB = 0;
                    //===========================================================
                    CikisResmi.SetPixel(x, y, Color.FromArgb(YeniR, YeniG, YeniB));
                }
            }
            return CikisResmi;
        }

        public Bitmap BtmpMeanFiltresi()
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3; //şablon boyutu 3 den büyük tek rakam olmalıdır (3,5,7 gibi). 
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;

            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0; toplamG = 0; toplamB = 0;
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R; toplamG = toplamG + OkunanRenk.G; toplamB = toplamB + OkunanRenk.B;
                        }
                    }
                    ortalamaR = toplamR / (SablonBoyutu * SablonBoyutu);
                    ortalamaG = toplamG / (SablonBoyutu * SablonBoyutu);
                    ortalamaB = toplamB / (SablonBoyutu * SablonBoyutu);
                    CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                }
            }
            return CikisResmi;
        }

        private void edgeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, EdgeDetection);

            if (checkBox27.Checked)
            {
                SobelEdge();
            }
            else if (checkBox28.Checked)
            {
                PrewitEdge();
            }
            else if (checkBox29.Checked)
            {
                RobertCross();
            }
        }

        public void SobelEdge()
        {
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y;

            Color Renk;
            int P1, P2, P3, P4, P5, P6, P7, P8, P9;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) 
                {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    Renk = GirisResmi.GetPixel(x - 1, y - 1);
                    P1 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y - 1);
                    P2 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y - 1);
                    P3 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x - 1, y);
                    P4 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y);
                    P5 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y);
                    P6 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x - 1, y + 1);
                    P7 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y + 1);
                    P8 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y + 1);
                    P9 = (Renk.R + Renk.G + Renk.B) / 3;
                    //Hesaplamayı yapan Sobel Temsili matrisi ve formülü.
                    int Gx = Math.Abs(-P1 + P3 - 2 * P4 + 2 * P6 - P7 + P9); //Dikey çizgiler
                    int Gy = Math.Abs(P1 + 2 * P2 + P3 - P7 - 2 * P8 - P9); //Yatay Çizgiler
                    int SobelDegeri = 0;
                    //SobelDegeri = Gx;
                    //SobelDegeri = Gy;
                    //SobelDegeri = Gx + Gy; //1. Formül
                    SobelDegeri = Convert.ToInt16(Math.Sqrt(Gx * Gx + Gy * Gy)); //2.Formül

                    if (SobelDegeri > 255) SobelDegeri = 255;
                    //Eşikleme: örnek olarak 100 değeri kullanılmıştır.
                    //if (SobelDegeri > 100)
                    // SobelDegeri = 255;
                    //else
                    // SobelDegeri = 0;
                    CikisResmi.SetPixel(x, y, Color.FromArgb(SobelDegeri, SobelDegeri, SobelDegeri));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        public void PrewitEdge()
        {
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y;
            Color Renk;
            int P1, P2, P3, P4, P5, P6, P7, P8, P9;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) 
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    Renk = GirisResmi.GetPixel(x - 1, y - 1);
                    P1 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y - 1);
                    P2 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y - 1);
                    P3 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x - 1, y);
                    P4 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y);
                    P5 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y);
                    P6 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x - 1, y + 1);
                    P7 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y + 1);
                    P8 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y + 1);
                    P9 = (Renk.R + Renk.G + Renk.B) / 3;
                    int Gx = Math.Abs(-P1 + P3 - P4 + P6 - P7 + P9); //Dikey çizgileri Bulur
                    int Gy = Math.Abs(P1 + P2 + P3 - P7 - P8 - P9); //Yatay Çizgileri Bulur.
                    int PrewittDegeri = 0;
                    PrewittDegeri = Gx;
                    PrewittDegeri = Gy;
                    PrewittDegeri = Gx + Gy; //1. Formül
                                             //PrewittDegeri = Convert.ToInt16(Math.Sqrt(Gx * Gx + Gy * Gy)); //2.Formül
                                             //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (PrewittDegeri > 255) PrewittDegeri = 255;
                    //Eşikleme: Örnek olarak 100 değeri kullanıldı.
                    //if (PrewittDegeri > 100)
                    //PrewittDegeri = 255;
                    //else
                    //PrewittDegeri = 0;
                    CikisResmi.SetPixel(x, y, Color.FromArgb(PrewittDegeri, PrewittDegeri, PrewittDegeri));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        public void RobertCross()
        {
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int x, y;
            Color Renk;
            int P1, P2, P3, P4;
            for (x = 0; x < ResimGenisligi - 1; x++) 
 {
                for (y = 0; y < ResimYuksekligi - 1; y++)
                {
                    Renk = GirisResmi.GetPixel(x, y);
                    P1 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y);
                    P2 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y + 1);
                    P3 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y + 1);
                    P4 = (Renk.R + Renk.G + Renk.B) / 3;
                    int Gx = Math.Abs(P1 - P4); //45 derece açı ile duran çizgileri bulur.
                    int Gy = Math.Abs(P2 - P3); //135 derece açı ile duran çizgileri bulur.
                    int RobertCrossDegeri = 0;
                    RobertCrossDegeri = Gx;
                    RobertCrossDegeri = Gy;
                    RobertCrossDegeri = Gx + Gy; //1. Formül
                                                 //RobertCrossDegeri = Convert.ToInt16(Math.Sqrt(Gx * Gx + Gy * Gy)); //2.Formül
                                                 //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (RobertCrossDegeri > 255) RobertCrossDegeri = 255; 
                     //Eşikleme
                     //if (RobertCrossDegeri > 50)
                     // RobertCrossDegeri = 255;
                     //else
                     // RobertCrossDegeri = 0;
                     CikisResmi.SetPixel(x, y, Color.FromArgb(RobertCrossDegeri, RobertCrossDegeri,
                    RobertCrossDegeri));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        int[,] EtiketNumarasi;

        private void findingObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi, CikisResmi;
            int KomsularinEnKucukEtiketDegeri = 0;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int PikselSayisi = ResimGenisligi * ResimYuksekligi;

            int i, j, x, y, EtiketNo = 0;
            EtiketNumarasi = new int[ResimGenisligi, ResimYuksekligi]; //Resmin her pikselinin etiket numarası tutulacak.
                                                                       //Tüm piksellerin Etiket numarasını başlangıçta 0 olarak atayacak. Siyah ve beyaz farketmez. Zaten ileride beyaz olanlara numara verilecek.
            for (i = 0; i < ResimGenisligi; i++)
            {
                for (j = 0; j < ResimYuksekligi; j++)
                {
                    EtiketNumarasi[i, j] = 0;
                }
            }
            int IlkDeger = 0, SonDeger = 0;
            bool DegisimVar = false; //Etiket numaralarında değişim olmayana kadar dönmesi için sonsuz döngüyü kontrol edecek.
            do //etiket numaralarında değişim kalmayana kadar dönecek.
            {
                DegisimVar = false;
                //------------------------- Resmi tarıyor ----------------------------
                for (j = 1; j < ResimYuksekligi - 1; j++) //Resmin 1 piksel içerisinden başlayıp, bitirecek. Çünkü çekirdek şablon en dış kenardan başlamalı.
                {
                    for (i = 1; i < ResimGenisligi - 1; i++)
                    {
                        //Resim siyah beyaz olduğu için tek kanala bakmak yeterli olacak. Sıradaki piksel beyaz ise işlem yap. Beyaz olduğu 255 yerine 128 kullanarak yapıldı.
                        if (GirisResmi.GetPixel(i, j).R > 128)
                        {
                            //işlem öncesi ele alınan pikselin etiket değerini okuyacak. İşlemler bittikten sonra bu değer değişirse, sonsuz döngü için işlem yapılmış demektir.
                            IlkDeger = EtiketNumarasi[i, j];
                            //Komşular arasında en küçük etiket numarasını bulacak.
                            KomsularinEnKucukEtiketDegeri = 0;
                            for (y = -1; y <= 1; y++) //Çekirdek şablon 3x3 lük bir matris. Dolayısı ile i,j nin -1 den başlayıp +1 ne kadar yer kaplar.
                            {
                                for (x = -1; x <= 1; x++)
                                {
                                    if (EtiketNumarasi[i + x, j + y] != 0 && KomsularinEnKucukEtiketDegeri == 0) //hücrenin etiketi varsa ve daha hiç en küçük atanmadı ise ilk okuduğu bu değeri en küçük olarak atayacak.
                                    {
                                        KomsularinEnKucukEtiketDegeri = EtiketNumarasi[i + x, j + y];
                                    }
                                    else if (EtiketNumarasi[i + x, j + y] < KomsularinEnKucukEtiketDegeri && EtiketNumarasi[i + x, j + y] != 0 && KomsularinEnKucukEtiketDegeri != 0) //En küçük değer ve okunan hücreye etiket atanmışsa, içindeki değer en küçük değerden küçük ise o zaman en küçük o hücrenin değeri olmalıdır.
                                    {
                                        KomsularinEnKucukEtiketDegeri = EtiketNumarasi[i + x, j + y];
                                    }
                                }
                            }
                            if (KomsularinEnKucukEtiketDegeri != 0) //Beyaz komşu buldu ve içlerinde en küçük etiket değerine sahip numara da var. O zaman orta piksele o numarayı ata.
                            {
                                EtiketNumarasi[i, j] = KomsularinEnKucukEtiketDegeri;
                            }
                            else if (KomsularinEnKucukEtiketDegeri == 0) //Komşuların hiç birinde etiket numarası yoksa o zaman yeni bir numara ata
                            {
                                EtiketNo = EtiketNo + 1;
                                EtiketNumarasi[i, j] = EtiketNo;
                            }
                            SonDeger = EtiketNumarasi[i, j]; //İşlem öncesi ve işlem sonrası değerler aynı ise ve butün piksellerde hep aynı olursa artık değişim yok demektir.
                            if (IlkDeger != SonDeger)
                                DegisimVar = true;
                        }
                    }
                }
            } while (DegisimVar == true); // Etiket numarlarında değişik kalmayana kadar dön.
                                          // Etiket değerine bağlı resmi renklendirecek-----------------------
                                          // Pikseller üzerine yazılmış numaraları diziye atıyor. Array boyutu resimdeki piksel sayısınca oluyor.
            int[] DiziEtiket = new int[PikselSayisi];
            x = 0;
            for (i = 1; i < ResimGenisligi - 1; i++)
            {
                for (j = 1; j < ResimYuksekligi - 1; j++)
                {
                    x++;
                    DiziEtiket[x] = EtiketNumarasi[i, j];
                }
            }
            //Dizideki etiket numaralarını sıralıyor. Hazır fonksiyon kullanıyor.
            Array.Sort(DiziEtiket);
            //Tekrar eden etiket numaraarını çıkarıyor. Hazır fonksiyon kullanıyor. Tekil numaraları diziye atıyor.
            int[] TekrarsizEtiketNumaralari = DiziEtiket.Distinct().ToArray();
            //DİKKAT BURADA RenkDizisi ihtiyaç değil gibi. Renk adedi direk Tekrarsız numaralardan alınabilir.
            int[] RenkDizisi = new int[TekrarsizEtiketNumaralari.Length]; //Tekil numaralar aynı boyutta renk dizisini oluşturuyor.
            for (y = 0; y < TekrarsizEtiketNumaralari.Length; y++)
            {
                RenkDizisi[y] = TekrarsizEtiketNumaralari[y]; //sıradaki ilk renge, ait olacağı etiketin kaç numara olacağını atıyor.
            }
            int RenkSayisi = RenkDizisi.Length; //kaç tane numara varsa o kadar renk var demektir.
            Color[] Renkler = new Color[RenkSayisi];
            Random Rastgele = new Random();
            int Kirmizi, Yesil, Mavi;
            for (int r = 0; r < RenkSayisi; r++) //sonraki renkler.
            {
                Kirmizi = Rastgele.Next(5, 25) * 10; //Açık renkler elde etmek ve 10 katları şeklinde olmasını sağlıyor. yani 150-250 arasındaki sayıları atıyor.
                Yesil = Rastgele.Next(5, 25) * 10;
                Mavi = Rastgele.Next(5, 25) * 10;
                Renkler[r] = Color.FromArgb(Kirmizi, Yesil, Mavi); //Renkler dizisi Color tipinde renkleri tutan bir dizidir.
            }
            //Color[] Renkler= { Color.Black, Color.Blue, Color.Red, Color.Orange, Color.LightPink, Color.LightYellow, Color.LimeGreen, Color.MediumPurple, Color.Olive, Color.Magenta, Color.Maroon, Color.AliceBlue, Color.AntiqueWhite, Color.Aqua, Color.LightBlue, Color.Azure, Color.White };
            for (i = 1; i < ResimGenisligi - 1; i++) //Resmin 1 piksel içerisinden başlayıp, bitirecek. Çünkü çekirdek şablon en dış kenardan başlamalı.
            {
                for (j = 1; j < ResimYuksekligi - 1; j++)
                {
                    int RenkSiraNo = Array.IndexOf(RenkDizisi, EtiketNumarasi[i, j]); //Dikkat: önemli bir komut. Dizinin değerinden sıra numarasını alıyor. int[] array = { 2, 3, 5, 7, 11, 13 }; int index = Array.IndexOf(array, 11); // returns 4
                    if (GirisResmi.GetPixel(i, j).R < 128) //Eğer bu pikselin rengi siyah ise aynı pikselin CikisResmi resmide siyah yapılacak.
                    {
                        CikisResmi.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        CikisResmi.SetPixel(i, j, Renkler[RenkSiraNo]);
                    }
                }
            }

            pictureBox2.Image = CikisResmi;
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı. İçerisine görüntü yüklendi.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur. Tanımlaması globalde yapıldı.

            for (int x = 0; x < ResimGenisligi - 1; x++)
            {
                for (int y = 0; y < ResimYuksekligi - 1; y++)
                {

                    if (GirisResmi.GetPixel(x, y).R == 255 || GirisResmi.GetPixel(x, y + 1).R == 255 || GirisResmi.GetPixel(x + 1, y).R == 255 || GirisResmi.GetPixel(x + 1, y + 1).R == 255)
                    {
                        CikisResmi.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        CikisResmi.SetPixel(x, y + 1, Color.FromArgb(255, 255, 255));
                        CikisResmi.SetPixel(x + 1, y, Color.FromArgb(255, 255, 255));
                        CikisResmi.SetPixel(x + 1, y + 1, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        CikisResmi.SetPixel(x, y, GirisResmi.GetPixel(x, y));
                    }
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void spreadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı. İçerisine görüntü yüklendi.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur. Tanımlaması globalde yapıldı.

            for (int x = 0; x < ResimGenisligi - 1; x++)
            {
                for (int y = 0; y < ResimYuksekligi - 1; y++)
                {

                    if (GirisResmi.GetPixel(x, y).R == 0 || GirisResmi.GetPixel(x, y + 1).R == 0 || GirisResmi.GetPixel(x + 1, y).R == 0 || GirisResmi.GetPixel(x + 1, y + 1).R == 0)
                    {
                        CikisResmi.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        CikisResmi.SetPixel(x, y + 1, Color.FromArgb(0, 0, 0));
                        CikisResmi.SetPixel(x + 1, y, Color.FromArgb(0, 0, 0));
                        CikisResmi.SetPixel(x + 1, y + 1, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        CikisResmi.SetPixel(x, y, GirisResmi.GetPixel(x, y));
                    }
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void sumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, SumAndSubs);

            if(checkBox30.Checked)
            {
                Bitmap GirisResmi, CikisResmi, GirisResmi2;
                GirisResmi = new Bitmap(pictureBox1.Image);
                GirisResmi2 = new Bitmap(pictureBox2.Image);
                int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı. İçerisine görüntü yüklendi.
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur. Tanımlaması globalde yapıldı.

                int R = 0, G = 0, B = 0;

                for (int i = 0; i < ResimGenisligi; i++)
                {
                    for (int j = 0; j < ResimYuksekligi; j++)
                    {
                        R = GirisResmi.GetPixel(i, j).R + GirisResmi2.GetPixel(i, j).R;
                        G = GirisResmi.GetPixel(i, j).G + GirisResmi2.GetPixel(i, j).G;
                        B = GirisResmi.GetPixel(i, j).B + GirisResmi2.GetPixel(i, j).B;

                        if (R < 0) R = 0;
                        else if (R > 255) R = 255;

                        if (G < 0) G = 0;
                        else if (G > 255) G = 255;

                        if (B < 0) B = 0;
                        else if (B > 255) B = 255;

                        CikisResmi.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                }
                pictureBox2.Image = CikisResmi;
            }
            else if(checkBox31.Checked)
            {
                Bitmap Resim1, Resim2, CikisResmi;
                Resim1 = new Bitmap(pictureBox1.Image);
                Resim2 = new Bitmap(pictureBox2.Image);
                int ResimGenisligi = Resim1.Width;
                int ResimYuksekligi = Resim1.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                Color Renk1, Renk2;
                int x, y;
                int R = 0, G = 0, B = 0;
                int EnBuyukDeger = 0, EnKucukDeger = 0;
                for (x = 0; x < ResimGenisligi; x++) 
                    {
                    for (y = 0; y < ResimYuksekligi; y++)
                    {
                        Renk1 = Resim1.GetPixel(x, y);
                        Renk2 = Resim2.GetPixel(x, y);
                        ////İki resmi direk toplama
                        R = Renk1.R + Renk2.R;
                        G = Renk1.G + Renk2.G;
                        B = Renk1.B + Renk2.B;
                        
                    if (R > EnBuyukDeger)
                            EnBuyukDeger = R;
                        if (G > EnBuyukDeger)
                            EnBuyukDeger = G;
                        if (B > EnBuyukDeger)
                            EnBuyukDeger = B;
                        if (R < EnKucukDeger)
                            EnKucukDeger = R;
                        if (G < EnKucukDeger)
                            EnKucukDeger = G;
                        if (B < EnKucukDeger)
                            EnKucukDeger = G;
                    }
                }

                pictureBox2.Image = Normalizasyon(Resim1, Resim2, EnBuyukDeger, EnKucukDeger);
            }
        }

        public Bitmap Normalizasyon(Bitmap Resim1, Bitmap Resim2, int EnBuyukDeger, int EnKucukDeger)
        {
            Bitmap CikisResmi;
            int ResimGenisligi = Resim1.Width;
            int ResimYuksekligi = Resim1.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            Color Renk1, Renk2;
            int x, y;
            int R = 0, G = 0, B = 0;
            int UstSinir = 0, AltSinir = 0;
            if (EnBuyukDeger > 255)
                UstSinir = 255;
            else
                UstSinir = EnBuyukDeger;
            if (EnKucukDeger < 0)
                AltSinir = 0;
            else
            AltSinir = EnKucukDeger;
            for (x = 0; x < ResimGenisligi; x++) 
 {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    Renk1 = Resim1.GetPixel(x, y);
                    Renk2 = Resim2.GetPixel(x, y);
                    ////İki resmi direk toplama
                    R = Renk1.R + Renk2.R;
                    G = Renk1.G + Renk2.G;
                    B = Renk1.B + Renk2.B;

                    int NormalDegerR = (((UstSinir - AltSinir) * (R - EnKucukDeger)) / (EnBuyukDeger -
                   EnKucukDeger)) + AltSinir;
                    int NormalDegerG = (((UstSinir - AltSinir) * (G - EnKucukDeger)) / (EnBuyukDeger -
                   EnKucukDeger)) + AltSinir;
                    int NormalDegerB = (((UstSinir - AltSinir) * (B - EnKucukDeger)) / (EnBuyukDeger -
                   EnKucukDeger)) + AltSinir;
                    CikisResmi.SetPixel(x, y, Color.FromArgb(NormalDegerR, NormalDegerG, NormalDegerB));
                }
            }
            return CikisResmi;

        }

        private void substractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tabControl1.TabCount; x++)
            {
                tabControl1.TabPages.RemoveAt(x);
            }
            if (tabControl1.TabPages.Count != 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

            tabControl1.TabPages.Insert(0, SumAndSubs);

            if(checkBox30.Checked)
            {
                Bitmap GirisResmi, CikisResmi, GirisResmi2;
                GirisResmi = new Bitmap(pictureBox1.Image);
                GirisResmi2 = new Bitmap(pictureBox2.Image);
                int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı. İçerisine görüntü yüklendi.
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur. Tanımlaması globalde yapıldı.

                int R = 0, G = 0, B = 0;

                for (int i = 0; i < ResimGenisligi; i++)
                {
                    for (int j = 0; j < ResimYuksekligi; j++)
                    {
                        R = GirisResmi.GetPixel(i, j).R - GirisResmi2.GetPixel(i, j).R;
                        G = GirisResmi.GetPixel(i, j).G - GirisResmi2.GetPixel(i, j).G;
                        B = GirisResmi.GetPixel(i, j).B - GirisResmi2.GetPixel(i, j).B;

                        if (R < 0) R = 0;
                        else if (R > 255) R = 255;

                        if (G < 0) G = 0;
                        else if (G > 255) G = 255;

                        if (B < 0) B = 0;
                        else if (B > 255) B = 255;

                        CikisResmi.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                }
                pictureBox2.Image = CikisResmi;
            }
            else if(checkBox31.Checked)
            {
                Bitmap Resim1, Resim2, CikisResmi;
                Resim1 = new Bitmap(pictureBox1.Image);
                Resim2 = new Bitmap(pictureBox2.Image);
                int ResimGenisligi = Resim1.Width;
                int ResimYuksekligi = Resim1.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                Color Renk1, Renk2;
                int x, y;
                int R = 0, G = 0, B = 0;
                int EnBuyukDeger = 0, EnKucukDeger = 0;
                for (x = 0; x < ResimGenisligi; x++)
                {
                    for (y = 0; y < ResimYuksekligi; y++)
                    {
                        Renk1 = Resim1.GetPixel(x, y);
                        Renk2 = Resim2.GetPixel(x, y);
                        ////İki resmi direk toplama
                        R = Renk1.R - Renk2.R;
                        G = Renk1.G - Renk2.G;
                        B = Renk1.B - Renk2.B;

                        if (R > EnBuyukDeger)
                            EnBuyukDeger = R;
                        if (G > EnBuyukDeger)
                            EnBuyukDeger = G;
                        if (B > EnBuyukDeger)
                            EnBuyukDeger = B;
                        if (R < EnKucukDeger)
                            EnKucukDeger = R;
                        if (G < EnKucukDeger)
                            EnKucukDeger = G;
                        if (B < EnKucukDeger)
                            EnKucukDeger = G;
                    }
                }

                pictureBox2.Image = Normalizasyon(Resim1, Resim2, EnBuyukDeger, EnKucukDeger);
            }
        }

        private void andToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Resim1, Resim2, CikisResmi;
            Resim1 = new Bitmap(pictureBox1.Image);
            Resim2 = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = Resim1.Width;
            int ResimYuksekligi = Resim1.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            Color Renk1, Renk2;
            int x, y;
            int R = 0, G = 0, B = 0;
            for (x = 0; x < ResimGenisligi; x++) 
 {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    Renk1 = Resim1.GetPixel(x, y);
                    Renk2 = Resim2.GetPixel(x, y);
                    string binarySayi1 = Convert.ToString(Renk1.R, 2).PadLeft(8, '0');
                    string binarySayi2 = Convert.ToString(Renk2.R, 2).PadLeft(8, '0');
                    string Bit1 = null, Bit2 = null, StringIkiliSayi = null;
                    for (int i = 0; i < 8; i++)
                    {
                        Bit1 = binarySayi1.Substring(i, 1);
                        Bit2 = binarySayi2.Substring(i, 1);
                        ////AND İŞLEMİ
                        if (Bit1 == "0" && Bit2 == "0") StringIkiliSayi = StringIkiliSayi + "0";
                        else if (Bit1 == "1" && Bit2 == "1") StringIkiliSayi = StringIkiliSayi + "1";
                        else StringIkiliSayi = StringIkiliSayi + "0";
                    }
                    R = Convert.ToInt32(StringIkiliSayi, 2); //İkili sayıyı tam sayıya dönüştürüyor.
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R, R, R)); //Gri resim
                }
            }
            pictureBox2.Image = CikisResmi;

        }

        private void nandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Resim1, Resim2, CikisResmi;
            Resim1 = new Bitmap(pictureBox1.Image);
            Resim2 = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = Resim1.Width;
            int ResimYuksekligi = Resim1.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            Color Renk1, Renk2;
            int x, y;
            int R = 0, G = 0, B = 0;
            for (x = 0; x < ResimGenisligi; x++)
            {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    Renk1 = Resim1.GetPixel(x, y);
                    Renk2 = Resim2.GetPixel(x, y);
                    string binarySayi1 = Convert.ToString(Renk1.R, 2).PadLeft(8, '0');
                    string binarySayi2 = Convert.ToString(Renk2.R, 2).PadLeft(8, '0');
                    string Bit1 = null, Bit2 = null, StringIkiliSayi = null;
                    for (int i = 0; i < 8; i++)
                    {
                        Bit1 = binarySayi1.Substring(i, 1);
                        Bit2 = binarySayi2.Substring(i, 1);
                        if (Bit1 == "0" && Bit2 == "0") StringIkiliSayi = StringIkiliSayi + "1";
                        else if (Bit1 == "1" && Bit2 == "1") StringIkiliSayi = StringIkiliSayi + "0";
                        else StringIkiliSayi = StringIkiliSayi + "1";
                    }
                    R = Convert.ToInt32(StringIkiliSayi, 2); //İkili sayıyı tam sayıya dönüştürüyor.
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R, R, R)); //Gri resim
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void orToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Resim1, Resim2, CikisResmi;
            Resim1 = new Bitmap(pictureBox1.Image);
            Resim2 = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = Resim1.Width;
            int ResimYuksekligi = Resim1.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            Color Renk1, Renk2;
            int x, y;
            int R = 0, G = 0, B = 0;
            for (x = 0; x < ResimGenisligi; x++)
            {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    Renk1 = Resim1.GetPixel(x, y);
                    Renk2 = Resim2.GetPixel(x, y);
                    string binarySayi1 = Convert.ToString(Renk1.R, 2).PadLeft(8, '0');
                    string binarySayi2 = Convert.ToString(Renk2.R, 2).PadLeft(8, '0');
                    string Bit1 = null, Bit2 = null, StringIkiliSayi = null;
                    for (int i = 0; i < 8; i++)
                    {
                        Bit1 = binarySayi1.Substring(i, 1);
                        Bit2 = binarySayi2.Substring(i, 1);
                        ////AND İŞLEMİ
                        if (Bit1 == "0" || Bit2 == "0") StringIkiliSayi = StringIkiliSayi + "0";
                        else if (Bit1 == "1" || Bit2 == "1") StringIkiliSayi = StringIkiliSayi + "1";
                        else StringIkiliSayi = StringIkiliSayi + "0";
                    }
                    R = Convert.ToInt32(StringIkiliSayi, 2); //İkili sayıyı tam sayıya dönüştürüyor.
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R, R, R)); //Gri resim
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void nORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Resim1, Resim2, CikisResmi;
            Resim1 = new Bitmap(pictureBox1.Image);
            Resim2 = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = Resim1.Width;
            int ResimYuksekligi = Resim1.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            Color Renk1, Renk2;
            int x, y;
            int R = 0, G = 0, B = 0;
            for (x = 0; x < ResimGenisligi; x++)
            {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    Renk1 = Resim1.GetPixel(x, y);
                    Renk2 = Resim2.GetPixel(x, y);
                    string binarySayi1 = Convert.ToString(Renk1.R, 2).PadLeft(8, '0');
                    string binarySayi2 = Convert.ToString(Renk2.R, 2).PadLeft(8, '0');
                    string Bit1 = null, Bit2 = null, StringIkiliSayi = null;
                    for (int i = 0; i < 8; i++)
                    {
                        Bit1 = binarySayi1.Substring(i, 1);
                        Bit2 = binarySayi2.Substring(i, 1);
                        if (Bit1 == "0" || Bit2 == "0") StringIkiliSayi = StringIkiliSayi + "0";
                        else if (Bit1 == "1" || Bit2 == "1") StringIkiliSayi = StringIkiliSayi + "1";
                        else StringIkiliSayi = StringIkiliSayi + "0";
                    }
                    R = Convert.ToInt32(StringIkiliSayi, 2); //İkili sayıyı tam sayıya dönüştürüyor.
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R, R, R)); //Gri resim
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void xORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Resim1, Resim2, CikisResmi;
            Resim1 = new Bitmap(pictureBox1.Image);
            Resim2 = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = Resim1.Width;
            int ResimYuksekligi = Resim1.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            Color Renk1, Renk2;
            int x, y;
            int R = 0, G = 0, B = 0;
            for (x = 0; x < ResimGenisligi; x++)
            {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    Renk1 = Resim1.GetPixel(x, y);
                    Renk2 = Resim2.GetPixel(x, y);
                    string binarySayi1 = Convert.ToString(Renk1.R, 2).PadLeft(8, '0');
                    string binarySayi2 = Convert.ToString(Renk2.R, 2).PadLeft(8, '0');
                    string Bit1 = null, Bit2 = null, StringIkiliSayi = null;
                    for (int i = 0; i < 8; i++)
                    {
                        Bit1 = binarySayi1.Substring(i, 1);
                        Bit2 = binarySayi2.Substring(i, 1);
                        ////AND İŞLEMİ
                        if (Bit1 == "0" ^ Bit2 == "0") StringIkiliSayi = StringIkiliSayi + "0";
                        else if (Bit1 == "1" ^ Bit2 == "1") StringIkiliSayi = StringIkiliSayi + "1";
                        else StringIkiliSayi = StringIkiliSayi + "0";
                    }
                    R = Convert.ToInt32(StringIkiliSayi, 2); //İkili sayıyı tam sayıya dönüştürüyor.
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R, R, R)); //Gri resim
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void subsBackGroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi, CikisResmi;

            GirisResmi = new Bitmap( pictureBox1.Image );
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;

            CikisResmi = new Bitmap(pictureBox2.Image);

            for(int i = 0; i < ResimGenisligi; i++)
            {
                for(int j = 0; j < ResimYuksekligi; j++)
                {
                    if( (GirisResmi.GetPixel(i, j).R == CikisResmi.GetPixel(i, j).R) && (GirisResmi.GetPixel(i, j).G == CikisResmi.GetPixel(i, j).G) && (GirisResmi.GetPixel(i, j).B == CikisResmi.GetPixel(i, j).B) )
                    {
                        CikisResmi.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }

            pictureBox2.Image = CikisResmi;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            Color OkunanRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi; //Histogram için giriş resmi gri-ton olmalıdır.
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            int i = 0; //piksel sayısı tutulacak.
            for (int x = 0; x < GirisResmi.Width; x++)
            {
                for (int y = 0; y < GirisResmi.Height; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3;
                    DiziPiksel.Add(OrtalamaRenk); //Resimdeki tüm noktaları diziye atıyor.
                }
            }
            int[] DiziPikselSayilari = new int[256];
            for (int r = 0; r < 255; r++) //256 tane renk tonu için dönecek.
            {
                int PikselSayisi = 0;
                for (int s = 0; s < DiziPiksel.Count; s++) //resimdeki piksel sayısınca dönecek.
                {
                    if (r == Convert.ToInt16(DiziPiksel[s]))
                        PikselSayisi++;
                }
                DiziPikselSayilari[r] = PikselSayisi;
            }
            //Değerleri listbox'a ekliyor.
            int RenkMaksPikselSayisi = 0; //Grafikte y eksenini ölçeklerken kullanılacak.
            for (int k = 0; k <= 255; k++)
            {
                //Maksimum piksel sayısını bulmaya çalışıyor.
                if (DiziPikselSayilari[k] > RenkMaksPikselSayisi)
                {
                    RenkMaksPikselSayisi = DiziPikselSayilari[k];
                }
            }
            //Grafiği çiziyor.
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Yellow, 1);
            Pen Kalem2 = new Pen(System.Drawing.Color.Red, 1);
            CizimAlani = pictureBox2.CreateGraphics();
            pictureBox2.Refresh();
            int GrafikYuksekligi = 1000;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi;
            double OlcekX = 1.6;
            for (int x = 0; x <= 255; x++)
            {
                CizimAlani.DrawLine(Kalem1, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX),
               (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
                //Dikey kırmızı çizgiler.
                if (x % 50 == 0)
                    CizimAlani.DrawLine(Kalem2, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX), 0);
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
