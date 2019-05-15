using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.IO;

namespace NDP_Proje
{
    class Ucgen : Panel
    {
        public struct UcgenPoint
        {
            public Point start;
            public Point end;
        }

        public UcgenPoint ucgenPoints;

        private readonly Control _cizimAlan;
        private Color _renk;

        Point[] _ucgenNoktalari = new Point[6];

        public Ucgen(Control cizimAlan, Color renk)
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
            _ucgenNoktalari[0] = new Point(Width / 2, 1);
            _ucgenNoktalari[1] = new Point(Width, Height - 1);
            _ucgenNoktalari[2] = new Point(Width / 2, 0);
            _ucgenNoktalari[3] = new Point(1, Height - 1);
            _ucgenNoktalari[4] = new Point(1, Height - 1);
            _ucgenNoktalari[5] = new Point(Width, Height - 1);

            e.Graphics.DrawPolygon(new Pen(Color.Black, 2), _ucgenNoktalari);
            e.Graphics.FillPolygon(new SolidBrush(_renk), _ucgenNoktalari);
        }        

        public void MouseBasildi()
        {
            Location = _cizimAlan.PointToClient(Cursor.Position);
            ucgenPoints.start = _cizimAlan.PointToClient(Cursor.Position);
        }

        public void MouseHareketEdiyor()
        {
            ucgenPoints.end = _cizimAlan.PointToClient(Cursor.Position);
            Location = _cizimAlan.PointToClient(Cursor.Position);           
        }

        public void MouseBirakildi()
        {
            Size = new Size(ucgenPoints.end.X - ucgenPoints.start.X + 30, ucgenPoints.end.Y - ucgenPoints.start.Y + 30);
            Location = new Point(ucgenPoints.start.X, ucgenPoints.start.Y);
        }

        public void Ekle()
        {
            _cizimAlan.Controls.Add(this);
        }
    }
}
