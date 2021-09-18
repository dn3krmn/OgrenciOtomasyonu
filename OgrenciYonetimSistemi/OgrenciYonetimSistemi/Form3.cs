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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        CodeFirstContext context = new CodeFirstContext();
        private void Form3_Load(object sender, EventArgs e)
        {
            Listele();
            var comboliste = context.Fakultes.ToList();
            comboBox1.DataSource = comboliste;
            comboBox1.DisplayMember = "FakulteAd";
            comboBox1.ValueMember = "FakulteID";
        }

        private void Listele()
        {
            listView1.Items.Clear();
            var liste = from x in context.Bolums
                        join y in context.Fakultes
                        on x.FakulteID equals y.FakulteID
                        select new
                        {
                            x.BolumID,
                            x.BolumAd,
                            y.FakulteAd
                        };
            foreach (var i in liste)
            {
                ListViewItem item = new ListViewItem(i.BolumID.ToString());
                item.SubItems.Add(i.BolumAd);
                item.SubItems.Add(i.FakulteAd);
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
            var ekle = new Bolum();
            ekle.BolumAd = textBox2.Text;
            ekle.FakulteID = fid;
            context.Bolums.Add(ekle);
            context.SaveChanges();
            MessageBox.Show("Bölüm bilgisi eklendi.",
                "Bölüm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListViewItem liste = listView1.SelectedItems[0];
            int id = int.Parse(liste.SubItems[0].Text);
            var sil = context.Bolums.FirstOrDefault
                (x => x.BolumID == id);
            context.Bolums.Remove(sil);
            context.SaveChanges();
            MessageBox.Show("Bölüm bilgisi silindi.",
                "Bölüm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var guncelle = context.Bolums.FirstOrDefault(x => x.BolumID == id);
            guncelle.BolumAd = textBox2.Text;
            guncelle.FakulteID = (int)comboBox1.SelectedValue;
            context.SaveChanges();
            MessageBox.Show("Bölüm bilgisi güncellendi.",
                "Bölüm", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
