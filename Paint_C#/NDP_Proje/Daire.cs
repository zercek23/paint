using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace NDP_Proje
{
    class Daire : Panel
    {
        public struct DairePoints
        {
            public Point start;
            public Point end;
        }

        public DairePoints dairePoints;

        private readonly Control _cizimAlan;
        private Color _renk;

        public Daire(Control cizimAlan, Color renk)
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
            e.Graphics.DrawEllipse(new Pen(Color.Black, 2), 2, 2, dairePoints.end.X - dairePoints.start.X - 5, dairePoints.end.Y - dairePoints.start.Y - 5);
            e.Graphics.FillEllipse(new SolidBrush(_renk), 2, 2, dairePoints.end.X - dairePoints.start.X - 5, dairePoints.end.Y - dairePoints.start.Y - 5);
        }

        public void MouseBasildi()
        {
            Location = _cizimAlan.PointToClient(Cursor.Position);
            dairePoints.start = _cizimAlan.PointToClient(Cursor.Position);
        }

        public void MouseHareketEdiyor()
        {
            dairePoints.end = _cizimAlan.PointToClient(Cursor.Position);

        }

        public void MouseBirakildi()
        {
            Size = new Size(dairePoints.end.X - dairePoints.start.X, dairePoints.end.Y - dairePoints.start.Y);
            Location = new Point(dairePoints.start.X, dairePoints.start.Y);            
        }
        public void Ekle()
        {
            _cizimAlan.Controls.Add(this);
        }
    }
}
