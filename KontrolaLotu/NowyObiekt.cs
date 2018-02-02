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
    public partial class NowyObiekt : Form
    {
        public NowyObiekt(MainForm owner)
        {
            InitializeComponent();
            this.owner = owner;
            radioButton1.Checked = true;
        }

        private MainForm owner;

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked && idTextBox.Text.Length == 0)
            {
                MessageBox.Show("Podaj nazwę obiektu!");
                return;
            }
            double x, y;
            if (!double.TryParse(xTextBox.Text, out x) || !double.TryParse(yTextBox.Text, out y))
            {
                MessageBox.Show("Nieprawidłowe współrzędne!");
                return;
            }
            Obiekt o;
            if (radioButton1.Checked)
            {
                o = new ObiektNaziemny(idTextBox.Text, x, y);
            }
            else
            {
                double wysokosc, predkosc, kierunek;
                if (!double.TryParse(wysokoscTextBox.Text, out wysokosc) || wysokosc <0)
                {
                    MessageBox.Show("Nieprawidłowa wartość wysokości!");
                    return;
                }
                if (!double.TryParse(predkoscTextBox.Text, out predkosc) || predkosc < 0)
                {
                    MessageBox.Show("Nieprawidłowa wartość prędkości!");
                    return;
                }
                if (!double.TryParse(kierunekTextBox.Text, out kierunek))
                {
                    MessageBox.Show("Nieprawdiłowy kierunek!");
                    return;
                }
                o = new Samolot((owner.NextId), x, y, wysokosc, predkosc, kierunek);
            }
            owner.DodajObiekt(o);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Height = radioButton1.Checked ? 207 : 259;
            //label6.Text = radioButton1.Checked ? "Nazwa:" : "Numer:";
            label6.Visible = idTextBox.Visible = radioButton1.Checked;
            //idTextBox.Enabled = radioButton1.Checked;
            //idTextBox.Text = radioButton1.Checked ? "" : owner.NextId.ToString();
            label3.Visible = label4.Visible = label5.Visible = wysokoscTextBox.Visible = predkoscTextBox.Visible = kierunekTextBox.Visible = radioButton2.Checked;
            if (radioButton2.Checked)
            {
                xTextBox.Location = new Point(xTextBox.Location.X, idTextBox.Location.Y);
                yTextBox.Location = new Point(yTextBox.Location.X, idTextBox.Location.Y + idTextBox.Height + 6);
            }
            else
            {
                xTextBox.Location = new Point(xTextBox.Location.X, idTextBox.Location.Y + idTextBox.Height + 6);
                yTextBox.Location = new Point(yTextBox.Location.X, xTextBox.Location.Y + xTextBox.Height + 6);
            }
            label1.Location = new Point(label1.Location.X, xTextBox.Location.Y + 3);
            label2.Location = new Point(label2.Location.X, yTextBox.Location.Y + 3);
        }
    }
}
