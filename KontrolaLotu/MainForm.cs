using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KontrolaLotu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            NextId = 1;
            rozmiarEkranu = pictureBox1.Size;
            hScrollBar1.Maximum = maxX - minX;
            vScrollBar1.Maximum = maxY - minY;
            Skala = 100;
            drawTimer.Tick += (s, e) =>
            {
                radar.Aktualizuj();
                for (int i = 0; i < radar.Obiekty.Count; i++)
                {
                    Samolot samolot = radar.Obiekty[i] as Samolot;
                    if (samolot == null) continue;
                    if (samolot.X < minX || samolot.X > maxX || samolot.Y < minY || samolot.Y > maxY)
                    {
                        usunObiekt(samolot);
                        i--;
                    }
                }
                BeginInvoke((MethodInvoker)delegate { pictureBox1.Refresh(); });
            };
            propertyTimer.Tick += (s, e) =>
            {
                wyswietlDaneObiektu();
            };
            generator.Tick += (s, e) =>
            {
                if (rand.NextDouble() <= 0.4 && radar.Obiekty.OfType<Samolot>().Count() < 25) generujSamolot();
            };
            drawTimer.Start();
            propertyTimer.Start();
            generator.Start();
        }

        private Radar radar = new Radar();
        private Timer drawTimer = new Timer { Interval = 40 };
        private Timer propertyTimer = new Timer { Interval = 250 };
        private Timer generator = new Timer { Interval = 2000 };
        private Obiekt zaznaczonyObiekt;
        private Size rozmiarEkranu;
        private Random rand = new Random();
        private int skala = 100, minX = -2500, maxX = 2500, minY = -2500, maxY = 2500, xSr = 0, ySr = 0;
        private static int[] wartosciSkali = new int[] { 10, 25, 50, 75, 100, 150, 200, 300, 400 };

        public int Skala
        {
            get { return skala; }
            set
            {
                skala = value;
                skalaTextBox.Text = skala + "%";
                vScrollBar1.LargeChange = vScrollBar1.Maximum * 100 * pictureBox1.Height / skala / (maxY - minY);
                hScrollBar1.LargeChange = hScrollBar1.Maximum * 100 * pictureBox1.Width / skala / (maxX - minX);
                minusButton.Enabled = skala > wartosciSkali[0];
                plusButton.Enabled = skala < wartosciSkali[wartosciSkali.Length - 1];
                ustawSrodek(xSr, ySr);
            }
        }

        enum Dystans : int
        {
            Bezpieczny = 0,
            Niebezpieczny = 1,
            Kolizja = 2
        }

        
        public int NextId { get; private set; }

        public void DodajObiekt(Obiekt o, bool zaznacz = true)
        {
            Samolot s = o as Samolot;
            if (s != null)
            {
                NextId = s.Numer + 1;
            }
            radar.DodajObiekt(o);
            comboBox1.Items.Add(o);
            if (zaznacz) comboBox1.SelectedItem = o;
            button5.Enabled = true;
        }

        private void usunObiekt(Obiekt o)
        {
            radar.UsunObiekt(o);
            bool zmienWyswietlanyObiekt = comboBox1.SelectedItem == o;
            comboBox1.Items.Remove(o);
            if (!zmienWyswietlanyObiekt) return;
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            else
            {
                comboBox1.Text = "";
                zaznaczonyObiekt = null;
                wyswietlDaneObiektu();
                button1.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }
        }

        private void generujSamolot()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { generujSamolot(); });
                return;
            }
            int x = 0, y = 0;
            double kierunek = 0;
            switch (rand.Next() % 4)
            {
                case 0:
                    x = 0;
                    y = rand.Next() % rozmiarEkranu.Height;
                    kierunek = rand.NextDouble() * 180;
                    break;
                case 1:
                    x = pictureBox1.Width;
                    y = rand.Next() % rozmiarEkranu.Height;
                    kierunek = rand.NextDouble() * 180 + 180;
                    break;
                case 2:
                    x = rand.Next() % rozmiarEkranu.Width;
                    y = 0;
                    kierunek = rand.NextDouble() * 180 + 90;
                    break;
                case 3:
                    x = rand.Next() % rozmiarEkranu.Width;
                    y = pictureBox1.Height;
                    kierunek = rand.NextDouble() * 180 - 90;
                    break;
            }
            Point p = pozycjaBezwzgledna(x, y);
            if (p.X < minX) p.X = minX;
            if (p.X > maxX) p.X = maxX;
            if (p.Y < minY) p.Y = minY;
            if (p.Y > maxY) p.Y = maxY;
            Samolot s = new Samolot(NextId, p.X, p.Y, rand.NextDouble() * 1000 + 5, rand.NextDouble() * 45 + 5, kierunek);
            DodajObiekt(s, false);
        }

        private void ustawSrodek(int x, int y)
        {
            int h = (int)(hScrollBar1.Maximum * (x - minX - rozmiarEkranu.Width * 50.0 / Skala) / (maxX - minX));
            int v = (int)(vScrollBar1.Maximum * (y - minY - rozmiarEkranu.Height * 50.0 / Skala) / (maxY - minY));
            if (h < 0) h = 0;
            else if (h > hScrollBar1.Maximum) h = hScrollBar1.Maximum;
            if (v < 0) v = 0;
            else if (v > vScrollBar1.Maximum) v = vScrollBar1.Maximum;
            hScrollBar1.Value = h;
            vScrollBar1.Value = v;
            xSr = x;
            ySr = y;
        }

        private Point srodek()
        {
            return pozycjaBezwzgledna(rozmiarEkranu.Width / 2, rozmiarEkranu.Height / 2);
        }

        private Point pozycjaWzgledna(double x, double y)
        {
            return new Point((int)((x - minX - (maxX - minX) * hScrollBar1.Value / hScrollBar1.Maximum) * Skala / 100), (int)((y - minY - (maxY - minY) * vScrollBar1.Value / vScrollBar1.Maximum) * Skala / 100));
        }

        private Point pozycjaBezwzgledna(int x, int y)
        {
            return new Point(x * 100 / Skala + minX + (maxX - minX) * hScrollBar1.Value / hScrollBar1.Maximum, y * 100 / Skala + minY + (maxY - minY) * vScrollBar1.Value / vScrollBar1.Maximum);
        }

        private static Point[] obrocPunkty(Point[] punkty, Point srodek, double kierunek)
        {
            double rad = kierunek * Math.PI / 180;
            double sin = Math.Sin(rad);
            double cos = Math.Cos(rad);
            Point[] pkt = new Point[punkty.Length];
            for (int i = 0; i < punkty.Length; i++)
            {
                int x = (int)(cos * (punkty[i].X - srodek.X) - sin * (punkty[i].Y - srodek.Y) + srodek.X);
                int y = (int)(sin * (punkty[i].X - srodek.X) + cos * (punkty[i].Y - srodek.Y) + srodek.Y);
                pkt[i] = new Point(x, y);
            }
            return pkt;
        }

        private void rysujObiektNaziemny(ObiektNaziemny on, Dystans d, Graphics g)
        {
            const int a = 20;
            Point pw = pozycjaWzgledna(on.X, on.Y);
            int x = pw.X, y = pw.Y;
            Pen p = new Pen(d == Dystans.Bezpieczny ? Color.White : Color.Red);
            p.Width = 1;
            g.DrawRectangle(p, x - a / 2, y - a / 2, a, a);
            g.DrawLine(p, x - a / 2, y - a / 2, x + a / 2, y + a / 2);
            g.DrawLine(p, x - a / 2, y + a / 2, x + a / 2, y - a / 2);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(on.Nazwa, Font, d != Dystans.Kolizja ? Brushes.White : Brushes.Red, new Rectangle(x, y - a / 2 - 15, 0, 0), sf);
        }

        private void rysujSamolot(Samolot s, Dystans d, Graphics g)
        {
            const int a = 24;
            Point pw = pozycjaWzgledna(s.X, s.Y);
            int x = pw.X, y = pw.Y;
            Point[] pkt = new Point[]
            {
                new Point(x - a / 3, y + a / 2),
                new Point(x, y - a / 2),
                new Point(x + a / 3, y + a / 2),
                new Point(x, y + a / 6),
                new Point(x - a / 3, y + a / 2)
            };
            pkt = obrocPunkty(pkt, new Point(x, y), s.Kierunek);
            Pen p = new Pen(d == Dystans.Bezpieczny ? Color.Green : Color.Red);
            p.Width = 1;
            if (d == Dystans.Kolizja) g.FillPolygon(Brushes.DarkRed, pkt);
            g.DrawLines(p, pkt);
            int r = Radar.MIN_ODLEGLOSC * Skala / 100;
            g.DrawEllipse(d == Dystans.Bezpieczny ? Pens.Gray : Pens.DarkRed, x - r, y - r, 2 * r, 2 * r);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString("S-" + s.Numer, Font, d != Dystans.Kolizja ? Brushes.White : Brushes.Red, new Rectangle(x, y - a / 2 - 15, 0, 0), sf);
        }

        private void rysuj(Graphics g)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { rysuj(g); });
                return;
            }
            Dystans[] d = new Dystans[radar.Obiekty.Count];
            for (int i = 0; i < d.Length; i++) d[i] = Dystans.Bezpieczny;
            for (int i = 0; i < radar.Obiekty.Count; i++)
            {
                Samolot s = radar.Obiekty[i] as Samolot;
                if (s == null || d[i] == Dystans.Kolizja) continue;
                for (int j = 0; j < radar.Obiekty.Count; j++)
                {
                    if (radar.Kolizja(s, radar.Obiekty[j]))
                    {
                        d[i] = Dystans.Kolizja;
                        d[j] = Dystans.Kolizja;
                        break;
                    }
                    else if (radar.NiebezpiecznyDystans(s, radar.Obiekty[j]))
                    {
                        d[i] = Dystans.Niebezpieczny;
                        d[j] = Dystans.Niebezpieczny;
                    }
                }
            }
            g.Clear(Color.Black);
            for (int i = 0; i < radar.Obiekty.Count; i++)
            {
                if (radar.Obiekty[i] is ObiektNaziemny)
                {
                    ObiektNaziemny on = radar.Obiekty[i] as ObiektNaziemny;
                    rysujObiektNaziemny(on, d[i], g);
                }
                else if (radar.Obiekty[i] is Samolot)
                {
                    Samolot s = radar.Obiekty[i] as Samolot;
                    rysujSamolot(s, d[i], g);
                }
            }
            g.DrawLines(Pens.White, new Point[] { new Point(10, 40), new Point(5, 40), new Point(5, rozmiarEkranu.Height - 40), new Point(10, rozmiarEkranu.Height - 40) });
            g.DrawLine(Pens.White, 5, rozmiarEkranu.Height / 2, 10, rozmiarEkranu.Height / 2);
            g.DrawLines(Pens.White, new Point[] { new Point(40, 10), new Point(40, 5), new Point(rozmiarEkranu.Width - 40, 5), new Point(rozmiarEkranu.Width - 40, 10) });
            g.DrawLine(Pens.White, rozmiarEkranu.Width / 2, 5, rozmiarEkranu.Width / 2, 10);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            Point pb1 = pozycjaBezwzgledna(40, 40), pb2 = pozycjaBezwzgledna(rozmiarEkranu.Width / 2, rozmiarEkranu.Height / 2), pb3 = pozycjaBezwzgledna(rozmiarEkranu.Width - 40, rozmiarEkranu.Height - 40);
            g.DrawString(pb1.Y.ToString(), Font, Brushes.White, new Rectangle(12, 40, 0, 0), sf);
            g.DrawString(pb2.Y.ToString(), Font, Brushes.White, new Rectangle(12, rozmiarEkranu.Height / 2, 0, 0), sf);
            g.DrawString(pb3.Y.ToString(), Font, Brushes.White, new Rectangle(12, rozmiarEkranu.Height - 40, 0, 0), sf);
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Near;
            g.DrawString(pb1.X.ToString(), Font, Brushes.White, new Rectangle(40, 12, 0, 0), sf);
            g.DrawString(pb2.X.ToString(), Font, Brushes.White, new Rectangle(rozmiarEkranu.Width / 2, 12, 0, 0), sf);
            g.DrawString(pb3.X.ToString(), Font, Brushes.White, new Rectangle(rozmiarEkranu.Width - 40, 12, 0, 0), sf);
        }

        

        private void pokazDaneObiektuNaziemnego(bool pokaz)
        {
            xLabel.Visible = xTextBox.Visible = yLabel.Visible = yTextBox.Visible = pokaz;
        }

        private void pokazDaneSamolotu(bool pokaz)
        {
            wysokoscLabel.Visible = wysokoscTextBox.Visible = predkoscLabel.Visible = predkoscTextBox.Visible
                = kierunekLabel.Visible = kierunekTextBox.Visible = wysokoscDocelowaLabel.Visible = wysokoscDocelowaTextBox.Visible
                = predkoscDocelowaLabel.Visible = predkoscDocelowaTextBox.Visible = pokaz;
        }

        private void wyswietlDaneObiektu()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { wyswietlDaneObiektu(); });
                return;
            }
            if (zaznaczonyObiekt == null)
            {
                pokazDaneSamolotu(false);
                pokazDaneObiektuNaziemnego(false);
                comboBox1.Text = "";
                return;
            }
            pokazDaneObiektuNaziemnego(true);
            xTextBox.Text = zaznaczonyObiekt.X.ToString("f2");
            yTextBox.Text = zaznaczonyObiekt.Y.ToString("f2");
            Samolot s = zaznaczonyObiekt as Samolot;
            pokazDaneSamolotu(s != null);
            if (s == null) return;
            wysokoscTextBox.Text = s.Wysokosc.ToString("f2");
            predkoscTextBox.Text = s.Predkosc.ToString("f2");
            if (!kierunekTextBox.Focused) kierunekTextBox.Text = s.Kierunek.ToString("f2");
            if (!wysokoscDocelowaTextBox.Focused) wysokoscDocelowaTextBox.Text = s.WysokoscDocelowa.ToString("f2");
            if (!predkoscDocelowaTextBox.Focused) predkoscDocelowaTextBox.Text = s.PredkoscDocelowa.ToString("f2");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            rysuj(e.Graphics);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            zaznaczonyObiekt = comboBox1.SelectedItem as Obiekt;
            wyswietlDaneObiektu();
            button1.Enabled = button5.Enabled = button6.Enabled = zaznaczonyObiekt != null;
        }

        private void kierunekTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Samolot s = comboBox1.SelectedItem as Samolot;
                double kierunek;
                if (double.TryParse(kierunekTextBox.Text, out kierunek)) s.Kierunek = kierunek;
                kierunekTextBox.Text = s.Kierunek.ToString("f2");
            }
        }

        private void wysokoscDocelowaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Samolot s = comboBox1.SelectedItem as Samolot;
                double wys;
                if (double.TryParse(wysokoscDocelowaTextBox.Text, out wys) || wys < 0) s.WysokoscDocelowa = wys;
                wysokoscDocelowaTextBox.Text = s.WysokoscDocelowa.ToString("f2");
            }
        }

        private void predkoscDocelowaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Samolot s = comboBox1.SelectedItem as Samolot;
                double pr;
                if (double.TryParse(predkoscDocelowaTextBox.Text, out pr) || pr < 0) s.PredkoscDocelowa = pr;
                predkoscTextBox.Text = s.PredkoscDocelowa.ToString("f2");
            }
        }

        private void kierunekTextBox_Leave(object sender, EventArgs e)
        {
            Samolot s = zaznaczonyObiekt as Samolot;
            kierunekTextBox.Text = s != null ? s.Kierunek.ToString("f2") : "";
        }

        private void wysokoscDocelowaTextBox_Leave(object sender, EventArgs e)
        {
            Samolot s = zaznaczonyObiekt as Samolot;
            wysokoscDocelowaTextBox.Text = s != null ? s.WysokoscDocelowa.ToString("f2") : "";
        }

        private void predkoscDocelowaTextBox_Leave(object sender, EventArgs e)
        {
            Samolot s = zaznaczonyObiekt as Samolot;
            predkoscDocelowaTextBox.Text = s != null ? s.PredkoscDocelowa.ToString("f2") : "";
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && comboBox1.SelectedItem==null)
            {
                e.SuppressKeyPress = true;
                comboBox1.SelectedItem = zaznaczonyObiekt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usunObiekt(comboBox1.SelectedItem as Obiekt);
        }

        private void skalaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int s;
                string text = skalaTextBox.Text;
                text.Trim();
                if (text.Length > 0 && text[text.Length - 1] == '%') text = text.Substring(0, text.Length - 1);
                if (int.TryParse(text, out s))
                {
                    int min = wartosciSkali[0], max = wartosciSkali[wartosciSkali.Length - 1];
                    if (s < min) s = min;
                    else if (s > max) s = max;
                    Skala = s;
                }
                skalaTextBox.Text = Skala + "%";
            }
        }

        private void skalaTextBox_Leave(object sender, EventArgs e)
        {
            skalaTextBox.Text = Skala + "%";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new NowyObiekt(this).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!radar.WczytajPlik()) return;
            NextId = 1;
            comboBox1.Items.Clear();
            foreach (Obiekt o in radar.Obiekty)
            {
                Samolot s = o as Samolot;
                if (s != null) NextId = s.Numer + 1;
                comboBox1.Items.Add(o);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radar.Obiekty.Count > 0) radar.ZapiszPlik();
            else MessageBox.Show("Brak obiektów do zapisania!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            radar.Obiekty.Clear();
            comboBox1.Items.Clear();
            NextId = 1;
            zaznaczonyObiekt = null;
            wyswietlDaneObiektu();
            button1.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new PrzesunObiekt(comboBox1.SelectedItem as Obiekt).ShowDialog();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            if (pictureBox1.Width > 0 && pictureBox1.Height > 0) rozmiarEkranu = pictureBox1.Size;
            vScrollBar1.LargeChange = vScrollBar1.Maximum * 100 * rozmiarEkranu.Height / skala / (maxY - minY);
            hScrollBar1.LargeChange = hScrollBar1.Maximum * 100 * rozmiarEkranu.Width / skala / (maxX - minX);
            ustawSrodek(xSr, ySr);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            ySr = srodek().Y;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            xSr = srodek().X;
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wartosciSkali.Length; i++)
            {
                if (wartosciSkali[i] > Skala)
                {
                    Skala = wartosciSkali[i];
                    break;
                }
            }
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            for (int i = wartosciSkali.Length - 1; i >= 0; i--)
            {
                if (wartosciSkali[i] < Skala)
                {
                    Skala = wartosciSkali[i];
                    break;
                }
            }
        }
    }
}
