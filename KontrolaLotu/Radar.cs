using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KontrolaLotu
{
    class Radar
    {
        public Radar()
        {
            Obiekty = new List<Obiekt>();
            ostatniaAktualizacja = DateTime.Now;
        }

        public const int MIN_ODLEGLOSC = 100;
        public List<Obiekt> Obiekty { get; private set; }
        private DateTime ostatniaAktualizacja;

        public void DodajObiekt(Obiekt o)
        {
            Obiekty.Add(o);
        }

        public void UsunObiekt(Obiekt o)
        {
            Obiekty.Remove(o);
        }

        private double odleglosc(Obiekt o1, Obiekt o2)
        {
            double dx = o1.X - o2.X, dy = o1.Y - o2.Y;
            double h1 = 0, h2 = 0;
            if (o1 is Samolot) h1 = ((Samolot)o1).Wysokosc;
            if (o2 is Samolot) h2 = ((Samolot)o2).Wysokosc;
            double dh = h1 - h2;
            return Math.Sqrt(dx * dx + dy * dy + dh * dh);
        }

        public bool NiebezpiecznyDystans(Samolot s, Obiekt o)
        {
            if (s == o) return false;
            return odleglosc(s, o) <= MIN_ODLEGLOSC;
        }

        public bool Kolizja(Samolot s, Obiekt o)
        {
            if (s == o) return false;
            return odleglosc(s, o) <= 20;
        }

        public void Aktualizuj()
        {
            DateTime teraz = DateTime.Now;
            TimeSpan t = teraz - ostatniaAktualizacja;
            ostatniaAktualizacja = teraz;
            double czas = t.TotalSeconds;
            foreach (Samolot s in Obiekty.OfType<Samolot>())
            {
                s.Aktualizuj(czas);
            }            
        }

        public void ZapiszPlik()
        {
            SaveFileDialog dialog = new SaveFileDialog { Filter = "Mapa Kontroli Lotu (*.mkl)|*.mkl" };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            DialogResult result = MessageBox.Show("Czy dołączyć do pliku dane o samolotach?", "Kontrola Lotu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Cancel) return;
            bool zapiszSamoloty = result == DialogResult.Yes;
            string path = dialog.FileName;
            List<ObiektNaziemny> obiektyNaziemne = new List<ObiektNaziemny>();
            foreach (ObiektNaziemny on in Obiekty.OfType<ObiektNaziemny>()) obiektyNaziemne.Add(on);
            List<Samolot> samoloty = new List<Samolot>();
            int fileLength = 8 + obiektyNaziemne.Count * 20;
            if (zapiszSamoloty)
            {
                foreach (Samolot s in Obiekty.OfType<Samolot>()) samoloty.Add(s);
                fileLength += samoloty.Count * 60;
            }
            foreach (ObiektNaziemny on in obiektyNaziemne) fileLength += on.Nazwa.Length;
            byte[] file = new byte[fileLength];
            byte[] onLength = BitConverter.GetBytes(obiektyNaziemne.Count);
            try
            {
                Buffer.BlockCopy(onLength, 0, file, 0, 4);
                int pos = 4;
                foreach (ObiektNaziemny on in obiektyNaziemne)
                {
                    byte[] nazwaLength = BitConverter.GetBytes(on.Nazwa.Length);
                    Buffer.BlockCopy(nazwaLength, 0, file, pos, 4);
                    pos += 4;
                    byte[] nazwa = Encoding.Default.GetBytes(on.Nazwa);
                    Buffer.BlockCopy(nazwa, 0, file, pos, nazwa.Length);
                    pos += nazwa.Length;
                    byte[] x = BitConverter.GetBytes(on.X);
                    Buffer.BlockCopy(x, 0, file, pos, 8);
                    pos += 8;
                    byte[] y = BitConverter.GetBytes(on.Y);
                    Buffer.BlockCopy(y, 0, file, pos, 8);
                    pos += 8;
                }
                byte[] sLength = BitConverter.GetBytes(zapiszSamoloty ? samoloty.Count : 0);
                Buffer.BlockCopy(sLength, 0, file, pos, 4);
                pos += 4;
                if (zapiszSamoloty)
                {
                    foreach (Samolot s in samoloty)
                    {
                        byte[] nr = BitConverter.GetBytes(s.Numer);
                        Buffer.BlockCopy(nr, 0, file, pos, 4);
                        pos += 4;
                        byte[] x = BitConverter.GetBytes(s.X);
                        Buffer.BlockCopy(x, 0, file, pos, 8);
                        pos += 8;
                        byte[] y = BitConverter.GetBytes(s.Y);
                        Buffer.BlockCopy(y, 0, file, pos, 8);
                        pos += 8;
                        byte[] wysokosc = BitConverter.GetBytes(s.Wysokosc);
                        Buffer.BlockCopy(wysokosc, 0, file, pos, 8);
                        pos += 8;
                        byte[] predkosc = BitConverter.GetBytes(s.Predkosc);
                        Buffer.BlockCopy(predkosc, 0, file, pos, 8);
                        pos += 8;
                        byte[] kierunek = BitConverter.GetBytes(s.Kierunek);
                        Buffer.BlockCopy(kierunek, 0, file, pos, 8);
                        pos += 8;
                        byte[] wDocelowa = BitConverter.GetBytes(s.WysokoscDocelowa);
                        Buffer.BlockCopy(wDocelowa, 0, file, pos, 8);
                        pos += 8;
                        byte[] pDocelowa = BitConverter.GetBytes(s.PredkoscDocelowa);
                        Buffer.BlockCopy(pDocelowa, 0, file, pos, 8);
                        pos += 8;
                    }
                }
                System.IO.File.WriteAllBytes(path, file);
            }
            catch
            {
                MessageBox.Show("Nie udało się zapisać pliku!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public bool WczytajPlik()
        {
            OpenFileDialog dialog = new OpenFileDialog { Filter = "Mapa Kontroli Lotu (*.mkl)|*.mkl" };
            if (dialog.ShowDialog() != DialogResult.OK) return false;
            string path = dialog.FileName;
            byte[] file;
            try { file = System.IO.File.ReadAllBytes(path); }
            catch
            {
                MessageBox.Show("Nie udało się otworzyć pliku!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            List<Obiekt> noweObiekty = new List<Obiekt>();
            try
            {
                int onLength = BitConverter.ToInt32(file, 0);
                int pos = 4;
                for (int i = 0; i < onLength; i++)
                {
                    int nazwaLength = BitConverter.ToInt32(file, pos);
                    pos += 4;
                    string nazwa = Encoding.Default.GetString(file, pos, nazwaLength);
                    pos += nazwaLength;
                    double x = BitConverter.ToDouble(file, pos);
                    pos += 8;
                    double y = BitConverter.ToDouble(file, pos);
                    pos += 8;
                    noweObiekty.Add(new ObiektNaziemny(nazwa, x, y));
                }
                int sLength = BitConverter.ToInt32(file, pos);
                pos += 4;
                for (int i = 0; i < sLength; i++)
                {
                    int nr = BitConverter.ToInt32(file, pos);
                    pos += 4;
                    double x = BitConverter.ToDouble(file, pos);
                    pos += 8;
                    double y = BitConverter.ToDouble(file, pos);
                    pos += 8;
                    double wysokosc = BitConverter.ToDouble(file, pos);
                    pos += 8;
                    double predkosc = BitConverter.ToDouble(file, pos);
                    pos += 8;
                    double kierunek = BitConverter.ToDouble(file, pos);
                    pos += 8;
                    double wDocelowa = BitConverter.ToDouble(file, pos);
                    pos += 8;
                    double pDocelowa = BitConverter.ToDouble(file, pos);
                    pos += 8;
                    Samolot s = new Samolot(nr, x, y, wysokosc, predkosc, kierunek);
                    s.WysokoscDocelowa = wDocelowa;
                    s.PredkoscDocelowa = pDocelowa;
                    noweObiekty.Add(s);
                }
            }
            catch
            {
                MessageBox.Show("Niepoprawny format pliku!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            Obiekty.Clear();
            foreach (Obiekt o in noweObiekty) DodajObiekt(o);
            return true;
        }
    }
}
