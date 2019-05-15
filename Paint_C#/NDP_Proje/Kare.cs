using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.IO;


namespace NDP_Proje
{
    class Kare : Panel
    {
        public struct KarePoint
        {
            public Point start;
            public Point end;
        }

        public KarePoint karePoints;

        private readonly Control _cizimAlan;
        private Color _renk;

        public Kare(Control cizimAlan, Color renk)
        {
            _cizimAlan = cizimAlan;
            _renk = renk;

            Width = 0;
            Height = 0;
            BackColor = Color.Transparent;

            Paint += Cizildi;
        }

        private void Cizildi(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black, 2), 5, 5, karePoints.end.X - karePoints.start.X - 5, karePoints.end.Y - karePoints.start.Y - 5);
            e.Graphics.FillRectangle(new SolidBrush(_renk), 5, 5, karePoints.end.X - karePoints.start.X - 5, karePoints.end.Y - karePoints.start.Y - 5);
        }

        public void MouseBasildi()
        {
            Location = _cizimAlan.PointToClient(Cursor.Position);
            karePoints.start = _cizimAlan.PointToClient(Cursor.Position);            
        }

        public void MouseHareketEdiyor()
        {
            karePoints.end = _cizimAlan.PointToClient(Cursor.Position);
        }

        public void MouseBirakildi()
        {
            Size = new Size(karePoints.end.X - karePoints.start.X+10, karePoints.end.Y - karePoints.start.Y+10);            
            Location = new Point(karePoints.start.X, karePoints.start.Y);
        }

        public void Ekle()
        {
            _cizimAlan.Controls.Add(this);
        }
    }
}
