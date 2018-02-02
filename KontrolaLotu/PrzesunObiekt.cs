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
    public partial class PrzesunObiekt : Form
    {
        public PrzesunObiekt(Obiekt o)
        {
            InitializeComponent();
            this.o = o;
            if (o is ObiektNaziemny)
            {
                Text = "Przesuń Obiekt Naziemny";
                label3.Text = "Nazwa: " + (o as ObiektNaziemny).Nazwa;
            }
            else
            {
                Text = "Przesuń Samolot";
                label3.Text = "Numer: " + (o as Samolot).Numer;
            }
            textBox1.Text = o.X.ToString("f2");
            textBox2.Text = o.Y.ToString("f2");
        }

        private Obiekt o;

        private void button1_Click(object sender, EventArgs e)
        {
            double x = 0, y = 0;
            if (!double.TryParse(textBox1.Text, out x) || !double.TryParse(textBox2.Text, out y))
            {
                MessageBox.Show("Nieprawidłowe współrzędne!");
                return;
            }
            o.UstawPozycje(x, y);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
