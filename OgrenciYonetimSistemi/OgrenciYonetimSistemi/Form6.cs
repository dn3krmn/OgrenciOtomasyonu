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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        CodeFirstContext context = new CodeFirstContext();
        private void Form6_Load(object sender, EventArgs e)
        {
            Listele();
            var comboliste = context.Derss.ToList();
            comboBox2.DataSource = comboliste;
            comboBox2.DisplayMember = "DersAdi";
            comboBox2.ValueMember = "DersID";
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.button5, "Derse Göre ARA");
        }

        private void Listele()
        {
            listView1.Items.Clear();
            var liste = from x in context.OgrenciDerss
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
                            
                        };
            foreach (var i in liste)
            {
                ListViewItem item = new ListViewItem(i.Yil.ToString());
                //item.SubItems.Add(i.Yil);
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


        void Temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int did = (int)comboBox2.SelectedValue;
            int numara = int.Parse(textBox3.Text);
            int vize = int.Parse(textBox4.Text);
            int final = int.Parse(textBox5.Text);
            var ekle = new OgrenciDers();
            ekle.Yil = textBox2.Text;
            ekle.DersID = did;
            ekle.Yariyil = comboBox1.Text;
            ekle.OgrenciNo = numara;
            ekle.Vize = vize;
            ekle.Final = final;      
            context.OgrenciDerss.Add(ekle);
            context.SaveChanges();
            MessageBox.Show("Öğrenci notu girildi.",
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListViewItem liste = listView1.SelectedItems[0];
            int id = int.Parse(liste.SubItems[2].Text);
            var sil = context.OgrenciDerss.FirstOrDefault
                (x => x.OgrenciNo == id);
            context.OgrenciDerss.Remove(sil);
            context.SaveChanges();
            MessageBox.Show("Öğrenci not bilgisi silindi.",
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox3.Text);
            int vize = int.Parse(textBox4.Text);
            int final = int.Parse(textBox5.Text);
            var guncelle = context.OgrenciDerss.FirstOrDefault(x => x.OgrenciNo == id);
            guncelle.Yil = textBox2.Text;
            guncelle.DersID = (int)comboBox2.SelectedValue;
            guncelle.Yariyil = comboBox1.Text;
            guncelle.OgrenciNo = id;
            guncelle.Vize = vize;
            guncelle.Final = final;
            context.SaveChanges();
            MessageBox.Show("Öğrenci not bilgisi güncellendi.",
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem secilen = listView1.SelectedItems[0];
            if (listView1.SelectedItems.Count > 0)
            {
                textBox2.Text = secilen.SubItems[0].Text;
                textBox3.Text = secilen.SubItems[2].Text;
                textBox4.Text = secilen.SubItems[6].Text;
                textBox5.Text = secilen.SubItems[7].Text;
                comboBox1.Text = secilen.SubItems[5].Text;
                comboBox2.Text = secilen.SubItems[1].Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Öğrenci No İle Ara";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void Form6_DoubleClick(object sender, EventArgs e)
        {
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (comboBox2 != null)
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

                           }).Where(x => x.DersAdi == comboBox2.Text).ToList();
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

    }
}
