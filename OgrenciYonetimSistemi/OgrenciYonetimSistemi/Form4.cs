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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        CodeFirstContext context = new CodeFirstContext();

        private void Form4_Load(object sender, EventArgs e)
        {
            Listele();
            var comboliste = context.Bolums.ToList();
            comboBox1.DataSource = comboliste;
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.ValueMember = "BolumID";
        }
        private void Listele()
        {
            listView1.Items.Clear();
            var liste = from x in context.Derss
                        join y in context.Bolums
                        on x.BolumID equals y.BolumID
                        select new
                        {
                            x.DersID,
                            x.DersAdi,
                            y.BolumAd
                        };
            foreach (var i in liste)
            {
                ListViewItem item = new ListViewItem(i.DersID.ToString());
                item.SubItems.Add(i.DersAdi);
                item.SubItems.Add(i.BolumAd);
                listView1.Items.Add(item);
            }
        }


        void Temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fid = (int)comboBox1.SelectedValue;
            var ekle = new Ders();
            ekle.DersAdi = textBox2.Text;
            ekle.BolumID = fid;
            context.Derss.Add(ekle);
            context.SaveChanges();
            MessageBox.Show("Ders bilgisi eklendi.",
                "Ders", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListViewItem liste = listView1.SelectedItems[0];
            int id = int.Parse(liste.SubItems[0].Text);
            var sil = context.Derss.FirstOrDefault
                (x => x.DersID == id);
            context.Derss.Remove(sil);
            context.SaveChanges();
            MessageBox.Show("Ders bilgisi silindi.",
                "Ders", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var guncelle = context.Derss.FirstOrDefault(x => x.DersID == id);
            guncelle.DersAdi = textBox2.Text;
            guncelle.BolumID = (int)comboBox1.SelectedValue;
            context.SaveChanges();
            MessageBox.Show("Ders bilgisi güncellendi.",
                "Ders", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem secilen = listView1.SelectedItems[0];
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = secilen.SubItems[0].Text;
                textBox2.Text = secilen.SubItems[1].Text;
                comboBox1.Text = secilen.SubItems[2].Text;
            }
        }
    }
}
