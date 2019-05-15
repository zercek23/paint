using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace NDP_Proje
{    
    public partial class Form1 : Form
    {
        Kare kare;
        Daire daire;
        Ucgen ucgen;
        Altigen altigen;
        
        Color renk = Color.Transparent;

        bool basildi;
        bool kareDurum;
        bool daireDurum;
        bool ucgenDurum;
        bool altigenDurum;

        bool dosyaKayitDurum;
        string dosyaYolu;
        string dosyaAdi;

        public Form1()
        {
            InitializeComponent();
        }

        private void cizimAlanPanel_MouseDown(object sender, MouseEventArgs e)
        {
            basildi = true;

            if (basildi)
            {
                if (kareDurum)
                {
                   
                    kare = new Kare(cizimAlanPanel, renk);
                    kare.MouseBasildi();
                }
                if(daireDurum)
                {
                    daire = new Daire(cizimAlanPanel, renk);
                    daire.MouseBasildi();
                }
                if(ucgenDurum)
                {
                    ucgen = new Ucgen(cizimAlanPanel, renk);
                    ucgen.MouseBasildi();
                }
                if (altigenDurum)
                {
                    altigen = new Altigen(cizimAlanPanel, renk);
                    altigen.MouseBasildi();
                }
            }                
        }

        private void cizimAlanPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (basildi)
            {
                if (kareDurum)
                {
                    kare.MouseHareketEdiyor();
                }
                if (daireDurum)
                {
                    daire.MouseHareketEdiyor();
                }
                if (ucgenDurum)
                {
                    ucgen.MouseHareketEdiyor();
                }
                if (altigenDurum)
                {
                    altigen.MouseHareketEdiyor();
                }
            }                
        }

        private void cizimAlanPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (basildi)
            {
                if(kareDurum)
                {
                    kare.MouseBirakildi();
                    kare.Ekle();
                    KayitEt();
                }
                if (daireDurum)
                {
                    daire.MouseBirakildi();
                    daire.Ekle();
                    KayitEt();
                }
                if(ucgenDurum)
                {
                    ucgen.MouseBirakildi();
                    ucgen.Ekle();
                    KayitEt();
                }
                if (altigenDurum)
                {
                    altigen.MouseBirakildi();
                    altigen.Ekle();
                    KayitEt();
                }
            }
            basildi = false;
        }

        private void CizimSekilDegis(PictureBox picture)
        {
            karePictureBox.BackColor = Color.Transparent;
            dairePictureBox.BackColor = Color.Transparent;
            ucgenPictureBox.BackColor = Color.Transparent;
            altigenPictureBox.BackColor = Color.Transparent;
            secIslem.BackColor = Color.Transparent;

            picture.BackColor = Color.MediumPurple;
        }

        private void karePictureBox_Click(object sender, EventArgs e)
        {
            CizimSekilDegis(karePictureBox);

            kareDurum = true;
            daireDurum = false;
            ucgenDurum = false;
            altigenDurum = false;
        }

        private void dairePictureBox_Click(object sender, EventArgs e)
        {
            CizimSekilDegis(dairePictureBox);

            kareDurum = false;
            daireDurum = true;
            ucgenDurum = false;
            altigenDurum = false;
        }

        private void ucgenPictureBox_Click(object sender, EventArgs e)
        {
            CizimSekilDegis(ucgenPictureBox);

            daireDurum = false;
            kareDurum = false;
            ucgenDurum = true;
            altigenDurum = false;
        }

        private void altigenPictureBox_Click(object sender, EventArgs e)
        {
            CizimSekilDegis(altigenPictureBox);

            daireDurum = false;
            kareDurum = false;
            ucgenDurum = false;
            altigenDurum = true;
        }

        private void RenkDegis(PictureBox picture)
        {
            kirmizi.BackColor = Color.Transparent;
            mavi.BackColor = Color.Transparent;
            yesil.BackColor = Color.Transparent;
            turuncu.BackColor = Color.Transparent;
            siyah.BackColor = Color.Transparent;
            sari.BackColor = Color.Transparent; ;
            mor.BackColor = Color.Transparent;
            bordo.BackColor = Color.Transparent;
            beyaz.BackColor = Color.Transparent;

            picture.BackColor = Color.MediumPurple;
        }

        private void kirmizi_Click(object sender, EventArgs e)
        {
            renk = Color.Red;
            RenkDegis(kirmizi);
        }
        private void mavi_Click(object sender, EventArgs e)
        {
            renk = Color.Blue;   
            RenkDegis(mavi);
        }
        private void yesil_Click(object sender, EventArgs e)
        {
            renk = Color.Green;
            RenkDegis(yesil);
        }
        private void turuncu_Click(object sender, EventArgs e)
        {
            renk = Color.Orange;
            RenkDegis(turuncu);
        }
        private void siyah_Click(object sender, EventArgs e)
        {
            renk = Color.Black;
            RenkDegis(siyah);
        }
        private void sari_Click(object sender, EventArgs e)
        {
            renk = Color.Yellow;
            RenkDegis(sari);
        }
        private void mor_Click(object sender, EventArgs e)
        {
            renk = Color.Purple;
            RenkDegis(mor);
        }
        private void bordo_Click(object sender, EventArgs e)
        {
            renk = Color.Maroon;
            RenkDegis(bordo);
        }
        private void beyaz_Click(object sender, EventArgs e)
        {
            renk = Color.White;
            RenkDegis(beyaz);
        }

        private void secIslem_Click(object sender, EventArgs e)
        {
            CizimSekilDegis(secIslem);
            daireDurum = false;
            kareDurum = false;
            ucgenDurum = false;
            altigenDurum = false;
        }

        private void silIslem_Click(object sender, EventArgs e)
        {
            
        }

        private void KayitEt()
        {
            if(kareDurum)
            {
                FileStream fs = new FileStream("ilkkayit.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("kare " + kare.karePoints.start.ToString() +
                    " " + kare.karePoints.end.ToString() + " " + renk.ToString());

                sw.Close();
            }
            if (daireDurum)
            {
                FileStream fs = new FileStream("ilkkayit.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("daire " + daire.dairePoints.start.ToString() +
                    " " + daire.dairePoints.end.ToString() + " " + renk.ToString());

                sw.Close();
            }
            if (ucgenDurum)
            {
                FileStream fs = new FileStream("ilkkayit.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("ucgen " + ucgen.ucgenPoints.start.ToString() +
                    " " + ucgen.ucgenPoints.end.ToString() + " " + renk.ToString());

                sw.Close();
            }
            if (altigenDurum)
            {
                FileStream fs = new FileStream("ilkkayit.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("altigen " + altigen.altigenPoints.start.ToString() +
                    " " + altigen.altigenPoints.end.ToString() + " " + renk.ToString());

                sw.Close();
            }
        }

        private void KayitAc()
        {
            StreamReader sr = new StreamReader(dosyaAdi);

            string satir;
            

            while ((satir = sr.ReadLine()) != null)
            {
                //KARE
                int sayi1;

                sayi1 = satir.IndexOf("kare");
                if(sayi1==0)
                {
                    Point start;
                    Point end;

                    int start1;
                    int start2;
                    int start3;
                    start1 = satir.IndexOf('{');
                    start2 = satir.IndexOf(',');
                    start3 = satir.IndexOf('}');

                    int end1;
                    int end2;
                    int end3;
                    end1 = satir.LastIndexOf('{');
                    end2 = satir.LastIndexOf(',');
                    end3 = satir.LastIndexOf('}');

                    string startsatir = satir.Substring(start1, start3 - start1+1);
                    int startsatir2 = startsatir.IndexOf(',');
                    string startX = startsatir.Substring(3, startsatir2 - 3);
                    string startY = startsatir.Substring(startsatir2 + 3, startsatir.Length - (startsatir2 + 4));

                    string endsatir = satir.Substring(end1, end3 - end1 + 1);
                    int endsatir2 = endsatir.IndexOf(',');
                    string endX = endsatir.Substring(3, endsatir2 - 3);
                    string endY = endsatir.Substring(endsatir2 + 3, endsatir.Length - (endsatir2 + 4));

                    int renkRakam;
                    int renkRakam2;
                    string renk;
                    renkRakam = satir.IndexOf('[');
                    renkRakam2 = satir.IndexOf(']');
                    renk = satir.Substring(renkRakam + 1, satir.Length - renkRakam - 2);

                    

                    kare = new Kare(cizimAlanPanel, Color.AliceBlue);

                    start = new Point(Convert.ToInt32(startX),Convert.ToInt32(startY));

                    end = new Point(Convert.ToInt32(endX), Convert.ToInt32(endY));

                    kare.Location = new Point(start.X, start.Y);
                    kare.Size = new Size(end.X - start.X + 10, end.Y - start.Y + 10);
                    cizimAlanPanel.Controls.Add(kare);
                    Graphics g = kare.CreateGraphics();
                    g.DrawRectangle(new Pen(Color.Black, 2), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    if(renk == "Red")
                    {
                        g.FillRectangle(new SolidBrush(Color.Red), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if(renk == "Blue")
                    {
                        g.FillRectangle(new SolidBrush(Color.Blue), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Green")
                    {
                        g.FillRectangle(new SolidBrush(Color.Green), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Orange")
                    {
                        g.FillRectangle(new SolidBrush(Color.Orange), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Black")
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Yellow")
                    {
                        g.FillRectangle(new SolidBrush(Color.Yellow), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Purple")
                    {
                        g.FillRectangle(new SolidBrush(Color.Purple), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Maroon")
                    {
                        g.FillRectangle(new SolidBrush(Color.Maroon), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "White")
                    {
                        g.FillRectangle(new SolidBrush(Color.White), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                }
                //DAİRE
                int sayi2;

                sayi2 = satir.IndexOf("daire");
                if (sayi2 == 0)
                {
                    Point start;
                    Point end;

                    int start1;
                    int start2;
                    int start3;
                    start1 = satir.IndexOf('{');
                    start2 = satir.IndexOf(',');
                    start3 = satir.IndexOf('}');

                    int end1;
                    int end2;
                    int end3;
                    end1 = satir.LastIndexOf('{');
                    end2 = satir.LastIndexOf(',');
                    end3 = satir.LastIndexOf('}');

                    string startsatir = satir.Substring(start1, start3 - start1 + 1);
                    int startsatir2 = startsatir.IndexOf(',');
                    string startX = startsatir.Substring(3, startsatir2 - 3);
                    string startY = startsatir.Substring(startsatir2 + 3, startsatir.Length - (startsatir2 + 4));

                    string endsatir = satir.Substring(end1, end3 - end1 + 1);
                    int endsatir2 = endsatir.IndexOf(',');
                    string endX = endsatir.Substring(3, endsatir2 - 3);
                    string endY = endsatir.Substring(endsatir2 + 3, endsatir.Length - (endsatir2 + 4));

                    int renkRakam;
                    int renkRakam2;
                    string renk;
                    renkRakam = satir.IndexOf('[');
                    renkRakam2 = satir.IndexOf(']');
                    renk = satir.Substring(renkRakam + 1, satir.Length - renkRakam - 2);



                    daire = new Daire(cizimAlanPanel, Color.Transparent);

                    start = new Point(Convert.ToInt32(startX), Convert.ToInt32(startY));

                    end = new Point(Convert.ToInt32(endX), Convert.ToInt32(endY));

                    daire.Location = new Point(start.X, start.Y);
                    daire.Size = new Size(end.X - start.X + 10, end.Y - start.Y + 10);
                    cizimAlanPanel.Controls.Add(daire);

                    Graphics g = daire.CreateGraphics();
                    g.DrawEllipse(new Pen(Color.Black, 2), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                     
                    if (renk == "Red")
                    {
                        g.FillEllipse(new SolidBrush(Color.Red), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Blue")
                    {
                        g.FillEllipse(new SolidBrush(Color.Blue), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Green")
                    {
                        g.FillEllipse(new SolidBrush(Color.Green), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Orange")
                    {
                        g.FillEllipse(new SolidBrush(Color.Orange), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Black")
                    {
                        g.FillEllipse(new SolidBrush(Color.Black), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Yellow")
                    {
                        g.FillEllipse(new SolidBrush(Color.Yellow), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Purple")
                    {
                        g.FillEllipse(new SolidBrush(Color.Purple), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "Maroon")
                    {
                        g.FillEllipse(new SolidBrush(Color.Maroon), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                    else if (renk == "White")
                    {
                        g.FillEllipse(new SolidBrush(Color.White), 5, 5, end.X - start.X - 5, end.Y - start.Y - 5);
                    }
                }
                //UCGEN
                int sayi3;

                sayi3 = satir.IndexOf("ucgen");
                if (sayi3 == 0)
                {
                    Point start;
                    Point end;
                    Point[] _ucgenNoktalari = new Point[6];

                    int start1;
                    int start2;
                    int start3;
                    start1 = satir.IndexOf('{');
                    start2 = satir.IndexOf(',');
                    start3 = satir.IndexOf('}');

                    int end1;
                    int end2;
                    int end3;
                    end1 = satir.LastIndexOf('{');
                    end2 = satir.LastIndexOf(',');
                    end3 = satir.LastIndexOf('}');

                    string startsatir = satir.Substring(start1, start3 - start1 + 1);
                    int startsatir2 = startsatir.IndexOf(',');
                    string startX = startsatir.Substring(3, startsatir2 - 3);
                    string startY = startsatir.Substring(startsatir2 + 3, startsatir.Length - (startsatir2 + 4));

                    string endsatir = satir.Substring(end1, end3 - end1 + 1);
                    int endsatir2 = endsatir.IndexOf(',');
                    string endX = endsatir.Substring(3, endsatir2 - 3);
                    string endY = endsatir.Substring(endsatir2 + 3, endsatir.Length - (endsatir2 + 4));

                    int renkRakam;
                    int renkRakam2;
                    string renk;
                    renkRakam = satir.IndexOf('[');
                    renkRakam2 = satir.IndexOf(']');
                    renk = satir.Substring(renkRakam + 1, satir.Length - renkRakam - 2);




                    ucgen = new Ucgen(cizimAlanPanel, Color.Transparent);

                    start = new Point(Convert.ToInt32(startX), Convert.ToInt32(startY));

                    end = new Point(Convert.ToInt32(endX), Convert.ToInt32(endY));

                    ucgen.Location = new Point(start.X, start.Y);
                    ucgen.Size = new Size(end.X - start.X + 10, end.Y - start.Y + 10);
                    cizimAlanPanel.Controls.Add(ucgen);

                    _ucgenNoktalari[0] = new Point(ucgen.Width / 2, 1);
                    _ucgenNoktalari[1] = new Point(ucgen.Width, ucgen.Height - 1);
                    _ucgenNoktalari[2] = new Point(ucgen.Width / 2, 0);
                    _ucgenNoktalari[3] = new Point(1, ucgen.Height - 1);
                    _ucgenNoktalari[4] = new Point(1, ucgen.Height - 1);
                    _ucgenNoktalari[5] = new Point(ucgen.Width, ucgen.Height - 1);

                    Graphics g = ucgen.CreateGraphics();
                    g.DrawPolygon(new Pen(Color.Black, 2), _ucgenNoktalari);

                    if (renk == "Red")
                    {
                        g.FillPolygon(new SolidBrush(Color.Red), _ucgenNoktalari);
                    }
                    else if (renk == "Blue")
                    {
                        g.FillPolygon(new SolidBrush(Color.Blue), _ucgenNoktalari);
                    }
                    else if (renk == "Green")
                    {
                        g.FillPolygon(new SolidBrush(Color.Green), _ucgenNoktalari);
                    }
                    else if (renk == "Orange")
                    {
                        g.FillPolygon(new SolidBrush(Color.Orange), _ucgenNoktalari);
                    }
                    else if (renk == "Black")
                    {
                        g.FillPolygon(new SolidBrush(Color.Black), _ucgenNoktalari);
                    }
                    else if (renk == "Yellow")
                    {
                        g.FillPolygon(new SolidBrush(Color.Yellow), _ucgenNoktalari);
                    }
                    else if (renk == "Purple")
                    {
                        g.FillPolygon(new SolidBrush(Color.Purple), _ucgenNoktalari);
                    }
                    else if (renk == "Maroon")
                    {
                        g.FillPolygon(new SolidBrush(Color.Maroon), _ucgenNoktalari);
                    }
                    else if (renk == "White")
                    {
                        g.FillPolygon(new SolidBrush(Color.White), _ucgenNoktalari);
                    }
                }
                //ALTIGEN
                int sayi4;

                sayi4 = satir.IndexOf("altigen");
                if (sayi4 == 0)
                {
                    Point start;
                    Point end;

                    int start1;
                    int start2;
                    int start3;
                    start1 = satir.IndexOf('{');
                    start2 = satir.IndexOf(',');
                    start3 = satir.IndexOf('}');

                    int end1;
                    int end2;
                    int end3;
                    end1 = satir.LastIndexOf('{');
                    end2 = satir.LastIndexOf(',');
                    end3 = satir.LastIndexOf('}');

                    string startsatir = satir.Substring(start1, start3 - start1 + 1);
                    int startsatir2 = startsatir.IndexOf(',');
                    string startX = startsatir.Substring(3, startsatir2 - 3);
                    string startY = startsatir.Substring(startsatir2 + 3, startsatir.Length - (startsatir2 + 4));

                    string endsatir = satir.Substring(end1, end3 - end1 + 1);
                    int endsatir2 = endsatir.IndexOf(',');
                    string endX = endsatir.Substring(3, endsatir2 - 3);
                    string endY = endsatir.Substring(endsatir2 + 3, endsatir.Length - (endsatir2 + 4));


                    altigen = new Altigen(cizimAlanPanel, Color.Transparent);

                    start = new Point(Convert.ToInt32(startX), Convert.ToInt32(startY));

                    end = new Point(Convert.ToInt32(endX), Convert.ToInt32(endY));

                    altigen.Location = new Point(start.X, start.Y);
                    altigen.Size = new Size(end.X - start.X + 10, end.Y - start.Y + 10);
                    cizimAlanPanel.Controls.Add(altigen);

                    Graphics g = altigen.CreateGraphics();

                    g.DrawLine(new Pen(Color.Black, 1), altigen.Width / 4, 1, 3 * (altigen.Width / 4), 1);//1
                    g.DrawLine(new Pen(Color.Black, 1), altigen.Width / 4, 0, 0, altigen.Height / 2);
                    g.DrawLine(new Pen(Color.Black, 1), 3 * (altigen.Width / 4), 0, altigen.Width - 1, altigen.Height / 2);
                    
                    g.DrawLine(new Pen(Color.Black, 1), altigen.Width / 4, altigen.Height - 1, 3 * (altigen.Width / 4), altigen.Height - 1);//1
                    g.DrawLine(new Pen(Color.Black, 1), Width / 4, Height, 0, Height / 2);
                    g.DrawLine(new Pen(Color.Black, 1), 3 * (altigen.Width / 4), altigen.Height, altigen.Width - 1, altigen.Height / 2);
                }

            }
            sr.Close();
        }

        private void dosyaKayit_Click(object sender, EventArgs e)
        {
            dosyaKayitDurum = true;

            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            save.Filter = "Metin Dosyası |*.txt";
            save.InitialDirectory = "Debug";

            if (save.ShowDialog() == DialogResult.OK)
            {                
                StreamReader sr = new StreamReader("ilkkayit.txt");
                StreamWriter Kayit = new StreamWriter(save.FileName);

                string satir;
                while ((satir = sr.ReadLine()) != null)
                {
                    Kayit.WriteLine(satir);
                }

                Kayit.Close();
                sr.Close();
            }
        }

        private void dosyaAc_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            open.Filter = "Metin Dosyası |*.txt";
            open.InitialDirectory = "Debug";
            if (open.ShowDialog() == DialogResult.OK)
            {
                dosyaYolu = open.FileName;
                dosyaAdi = open.SafeFileName;
            }
            KayitAc();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.IO.File.Exists(@"ilkkayit.txt"))
            {
                System.IO.File.Delete(@"ilkkayit.txt");
            }
        }
    }
}