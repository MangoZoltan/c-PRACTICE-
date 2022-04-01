using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        List<Munkavallalo> munkavallalok = new List<Munkavallalo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //1. feladat fájlbeolvasás
            string[] sorok = File.ReadAllLines("munka.txt", Encoding.UTF8);

            foreach (var item in sorok)
            {
                string[] split = item.Split(';');
                string[] szul = split[2].Split('.');
                DateTime actualDate = new DateTime(int.Parse(szul[0]), int.Parse(szul[1]), int.Parse(szul[2]));

                Munkavallalo mv = new Munkavallalo(split[0], split[1], actualDate, split[3]);
                munkavallalok.Add(mv);
            }

            //2.feladat
            DateTime minDate1 = new DateTime(3000,01,01);
            string nev1 = "";
            string mk1 = "";
            foreach (var item in munkavallalok)
            {
                if (minDate1 > item.szul) {
                    minDate1 = item.szul;
                    nev1 = item.vezNev + " " + item.kerNev;
                    mk1 = item.munkakor;
                }
            }
            label1.Text = nev1 + " " + minDate1.ToString("yyyy-MM-dd") + " " + mk1;

            //3.feladat
            DateTime minDate2 = new DateTime(1000, 01, 01);
            string nev2 = "";
            string mk2 = "";
            foreach (var item in munkavallalok)
            {
                if (minDate2 < item.szul)
                {
                    minDate2 = item.szul;
                    nev2 = item.vezNev + " " + item.kerNev;
                    mk2 = item.munkakor;
                }
            }
            label2.Text = nev2 + " " + minDate2.ToString("yyyy-MM-dd") + " " + mk2;

            //5.feladat
            List<string> munkakorok = new List<string>();
            int actual = 0;
            int maxmk = 0;
            string maxmkn = "";

            foreach (var item in munkavallalok)
            {
                munkakorok.Add(item.munkakor);
            }

            munkakorok = munkakorok.Distinct().ToList();

            foreach (var item in munkakorok)
            {
                foreach (var item2 in munkavallalok)
                {
                    if (item == item2.munkakor)
                    {
                        actual++;
                    }
                }
                if (maxmk < actual) {
                    maxmk =actual;
                    maxmkn = item;
                }
                actual = 0;
            }
            label5.Text = maxmkn + " : " + maxmk;

            //6.feladat
            int atlag = 0;
            int osszeg = 0;
            int mvDB = 0;
            foreach (var item in munkavallalok)
            {
                osszeg += Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(item.szul.ToString("yyyy"));
                mvDB++;
            }
            atlag = osszeg / mvDB;
            StreamWriter sw = new StreamWriter("atlag_eletkor.txt", false,Encoding.UTF8);
            sw.WriteLine("A munkavállalók átlag életkora: " + atlag.ToString() + " év.");
            sw.Close();

            //7.feladat

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //4.feladat
            string betu1text = textBox1.Text;
            char betu1 = betu1text.ToCharArray()[0];
            label3.Text = "";
            foreach (var item in munkavallalok)
            {
                
                if (item.vezNev[0] == betu1)
                {
                    label3.Text += item.vezNev + "\n";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //5.feladat
            string betu1text = textBox2.Text;
            char betu1 = betu1text.ToCharArray()[0];
            label4.Text = "";
            foreach (var item in munkavallalok)
            {

                if (item.kerNev[0] == betu1)
                {
                    label4.Text += item.kerNev + "\n";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text="";
            int evCheck = int.Parse(textBox3.Text);
            foreach (var item in munkavallalok)
            {
                if (evCheck == int.Parse(item.szul.ToString("yyyy"))) {
                    label6.Text += item.vezNev + " " + item.kerNev+"\n";
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
