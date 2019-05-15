using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace NDP_Proje
{
    class Altigen : Panel
    {
        public struct AltigenPoint
        {
            public Point start;
            public Point end;
        }

        public AltigenPoint altigenPoints;

        private readonly Control _cizimAlan;
        private Color _renk;

        Point[] _altigenNoktalari = new Point[12];
        
        public Altigen(Control cizimAlan, Color renk)
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
            e.Graphics.DrawLine(new Pen(Color.Black, 1), Width / 4, 1, 3 * (Width / 4), 1);//1
            e.Graphics.DrawLine(new Pen(Color.Black, 1), Width / 4, 0, 0, Height / 2);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), 3 * (Width / 4), 0, Width - 1, Height / 2);

            e.Graphics.DrawLine(new Pen(Color.Black, 1), Width / 4, Height - 1, 3 * (Width / 4), Height - 1);//1
            e.Graphics.DrawLine(new Pen(Color.Black, 1), Width / 4, Height, 0, Height / 2);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), 3 * (Width / 4), Height, Width - 1, Height / 2);            
        }

        public void Ekle()
        {
            _cizimAlan.Controls.Add(this);
        }

        public void MouseBasildi()
        {
            Location = _cizimAlan.PointToClient(Cursor.Position);
            altigenPoints.start = _cizimAlan.PointToClient(Cursor.Position);
        }

        public void MouseHareketEdiyor()
        {
            altigenPoints.end = _cizimAlan.PointToClient(Cursor.Position);
            Location = _cizimAlan.PointToClient(Cursor.Position);            
        }

        public void MouseBirakildi()
        {
            Size = new Size(altigenPoints.end.X - altigenPoints.start.X + 30, altigenPoints.end.Y - altigenPoints.start.Y + 30);
            Location = new Point(altigenPoints.start.X, altigenPoints.start.Y);
        }
    }
}
