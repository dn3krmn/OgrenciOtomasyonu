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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        CodeFirstContext context = new CodeFirstContext();
        private void Form2_Load(object sender, EventArgs e)
        {
            Listele();
        }
        private void Listele()
        {
            listView1.Items.Clear();
            var liste = context.Fakultes.ToList();
            for (int i = 0; i < liste.Count; i++)
            {
                ListViewItem item = new ListViewItem(
                    liste[i].FakulteID.ToString());
                item.SubItems.Add(liste[i].FakulteAd);
                listView1.Items.Add(item);
            }
        }
        //işlem bitince textboxları temizlemek için
        void Temizle()
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var ekle = new Fakulte();
            ekle.FakulteAd = textBox2.Text;
            context.Fakultes.Add(ekle);
            context.SaveChanges();
            MessageBox.Show("Fakülte bilgisi eklendi.",
                "Fakülte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            Listele();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ListViewItem liste = listView1.SelectedItems[0];
            int id = int.Parse(liste.SubItems[0].Text);
            var sil = context.Fakultes.FirstOrDefault
                (x => x.FakulteID == id);
            context.Fakultes.Remove(sil);
            context.SaveChanges();
            MessageBox.Show("Fakülte bilgisi silindi.",
                "Fakülte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var guncelle = context.Fakultes.FirstOrDefault(x => x.FakulteID == id);
            guncelle.FakulteAd = textBox2.Text;
            context.SaveChanges();
            MessageBox.Show("Fakülte bilgisi güncellendi.",
                "Fakülte", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }
    }
}
