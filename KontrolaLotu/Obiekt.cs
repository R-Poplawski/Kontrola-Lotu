using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KontrolaLotu
{
    public abstract class Obiekt
    {
        protected Obiekt(double x, double y)
        {
            UstawPozycje(x, y);
        }

        public double X { get; private set; }
        public double Y { get; private set; }

        public void UstawPozycje(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    class ObiektNaziemny : Obiekt
    {
        public string Nazwa { get; private set; }

        public override string ToString()
        {
            return Nazwa;
        }

        public ObiektNaziemny(string nazwa, double x, double y) : base(x, y)
        {
            Nazwa = nazwa;
        }
    }

    class Samolot : Obiekt
    {
        public Samolot(int nr, double x, double y, double wysokosc, double predkosc, double kierunek) : base(x, y)
        {
            Numer = nr;
            Wysokosc = wysokosc;
            Predkosc = predkosc;
            Kierunek = kierunek;
            WysokoscDocelowa = wysokosc;
            PredkoscDocelowa = predkosc;
        }

        public override string ToString()
        {
            return "Samolot " + Numer;
        }

        private double kierunek, wysokoscDocelowa, predkoscDocelowa;

        public int Numer { get; private set; }
        public double Wysokosc { get; private set; }
        public double Predkosc { get; private set; }
        public double Kierunek
        {
            get { return kierunek; }
            set
            {
                while (value < 0) value += 360;
                kierunek = value % 360;
            }
        }
        
        public double WysokoscDocelowa
        {
            get { return wysokoscDocelowa; }
            set
            {
                wysokoscDocelowa = value;
            }
        }
        public double PredkoscDocelowa
        {
            get { return predkoscDocelowa; }
            set
            {
                predkoscDocelowa = value;
            }
        }

        public void Aktualizuj(double czas)
        {
            double kierunek = this.kierunek * Math.PI / 180;
            UstawPozycje(X + Predkosc * czas * Math.Sin(kierunek), Y - Predkosc * czas * Math.Cos(kierunek));
            double dv = 10 * czas;
            if (Predkosc < PredkoscDocelowa)
            {
                if (PredkoscDocelowa - Predkosc < dv) Predkosc = PredkoscDocelowa;
                else Predkosc += dv;
            }
            else if (Predkosc > PredkoscDocelowa)
            {
                if (Predkosc - PredkoscDocelowa < dv) Predkosc = PredkoscDocelowa;
                else Predkosc -= dv;
            }
            double dh = 25 * czas;
            if (Wysokosc < WysokoscDocelowa)
            {
                if (WysokoscDocelowa - Wysokosc < dh) Wysokosc = WysokoscDocelowa;
                else Wysokosc += dh;
            }
            else if (Wysokosc > WysokoscDocelowa)
            {
                if (Wysokosc - WysokoscDocelowa < dh) Wysokosc = WysokoscDocelowa;
                else Wysokosc -= dh;
            }
        }
    }
}
