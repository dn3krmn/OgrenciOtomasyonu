using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciYonetimSistemi
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        CodeFirstContext context = new CodeFirstContext();
        private void Form7_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (textBox1 != null)
            {
                var ara = (from x in context.OgrenciDerss
                           join y in context.Ogrencis
                           on x.OgrenciNo equals y.OgrenciNo
                           join z in context.Derss
                           on x.DersID equals z.DersID
                           select new
                           {
                               x.Yil,
                               z.DersAdi,
                               y.OgrenciNo,
                               y.Ad,
                               y.Soyad,
                               x.Yariyil,
                               x.Vize,
                               x.Final,

                           }).Where(x => x.OgrenciNo.ToString() ==
                           textBox1.Text).ToList();
                foreach (var i in ara)
                {
                    ListViewItem item = new ListViewItem(i.Yil.ToString());
                    item.SubItems.Add(i.DersAdi);
                    item.SubItems.Add(i.OgrenciNo.ToString());
                    item.SubItems.Add(i.Ad);
                    item.SubItems.Add(i.Soyad);
                    item.SubItems.Add(i.Yariyil);
                    item.SubItems.Add(i.Vize.ToString());
                    item.SubItems.Add(i.Final.ToString());
                    listView1.Items.Add(item);
                }

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Öğrenci No İle Ara")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            if (textBox2 != null && comboBox1 != null)
            {
                var ara = (from x in context.OgrenciDerss
                           join z in context.Derss
                           on x.DersID equals z.DersID
                           select new
                           {
                               x.Yil,
                               z.DersAdi,
                               x.Yariyil
                           }).Where(x => x.Yariyil == comboBox1.Text).ToList();
                foreach (var i in ara)
                {
                    ListViewItem item = new ListViewItem(i.Yil.ToString());
                    item.SubItems.Add(i.DersAdi);
                    item.SubItems.Add(i.Yariyil);
                    listView2.Items.Add(item);
                }
            }
            
        }
    }
}
