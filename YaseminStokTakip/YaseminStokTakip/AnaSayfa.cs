using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YaseminStokTakip
{
    public partial class AnaSayfa : Form
    {
        OracleConnection con = new OracleConnection("DATA SOURCE=YASEMIN;PASSWORD=YSM232;USER ID=STOK");
        OracleDataAdapter adapt;
        int seciliSayiDegeri = 0;

        public AnaSayfa()
        {
            InitializeComponent();
            urunGruplariniGoruntule();
            urunleriListele();
            toplamUrunSayisi();
            sepettekiToplamUrunSayisi();
        }
        private void urunGruplariniGoruntule()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new OracleDataAdapter("select * from URUN_GRUPLARI", con);
            adapt.Fill(dt);
            CBUrunGruplari.DataSource = dt;
            CBUrunGruplari.DisplayMember = "TANIM";
            CBUrunGruplari.ValueMember = "ID";
            con.Close();
        }

        private void urunleriListele()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new OracleDataAdapter("select * from URUNLER U WHERE U.URUN_GRUP_ID = " + CBUrunGruplari.SelectedValue, con);
            adapt.Fill(dt);
            con.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // Dış Panel Özellikleri
                Panel p = new Panel();
                p.Height = 220;
                p.Width = 125;
                p.Padding = new Padding(10);
                p.BorderStyle = BorderStyle.FixedSingle;


                //Resim Ekleme İşlemleri

                Panel ustp = new Panel();
                ustp.Height = 150;
                ustp.Width = 110;
                ustp.Dock = DockStyle.Top;

                PictureBox pb = new PictureBox();
                pb.Height = 150;
                pb.Width = 110;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.ImageLocation = dt.Rows[i][6].ToString();
                ustp.Controls.Add(pb);

                p.Controls.Add(ustp);

                // Alt Panel İşlemleri Ürün Adedi ve Sepete Ekleme

                Panel altp = new Panel();
                altp.Height = 41;
                altp.Width = 110;
                altp.Dock = DockStyle.Bottom;

                Panel altUstP = new Panel();
                altUstP.Height = 20;
                altUstP.Width = 110;
                altUstP.Dock = DockStyle.Top;

                Label lbl = new Label();
                lbl.Text = dt.Rows[i][1].ToString();
                altUstP.Controls.Add(lbl);

                altp.Controls.Add(altUstP);

                Panel altAltP = new Panel();
                altAltP.Height = 21;
                altAltP.Width = 110;
                altAltP.Dock = DockStyle.Bottom;

                // Alt sol panel Ürün Adedi

                Panel altSolP = new Panel();
                altSolP.Width = 40;
                altSolP.Dock = DockStyle.Left;

                ComboBox cb = new ComboBox();
                cb.Dock = DockStyle.Fill;
                for (int k = 1; k < 11; k++)
                {
                    cb.Items.Add(k);
                }
                cb.SelectedIndex = 0;
                cb.Name = "cb_" + dt.Rows[i][0].ToString();
                cb.SelectedIndexChanged += new System.EventHandler(cmb_SelectedValueChanged);
                altSolP.Controls.Add(cb);

                altAltP.Controls.Add(altSolP);

                // Alt sağ panel Seç Butonu

                Panel altSagP = new Panel();
                altSagP.Width = 70;
                altSagP.Dock = DockStyle.Right;

                Button bt = new Button();
                bt.Text = "Ekle";
                bt.Name = dt.Rows[i][0].ToString();
                bt.Click += new EventHandler(button_Click);
                bt.Dock = DockStyle.Fill;
                altSagP.Controls.Add(bt);

                altAltP.Controls.Add(altSagP);

                altp.Controls.Add(altAltP);

                p.Controls.Add(altp);

                flowLayoutPanel1.Controls.Add(p);
            }
        }

        public void cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            seciliSayiDegeri = Convert.ToInt32(cb.SelectedItem.ToString());
        }

        public void button_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            string bName = bt.Name;
            string sayi = "0";

            OracleCommand cmd = new OracleCommand("insert into SEPET(URUN_ID,KULLANICI_ID,MIKTARI) values(:urun_id,:kullanici_id,:miktari)", con);
            con.Open();
            cmd.Parameters.Add(":urun_id", Convert.ToInt32(bName));
            cmd.Parameters.Add(":kullanici_id", Convert.ToInt32("6"));
            cmd.Parameters.Add(":miktari", Convert.ToInt32(seciliSayiDegeri));
            cmd.ExecuteNonQuery();
            con.Close();
            sepettekiToplamUrunSayisi();
            MessageBox.Show("Ürün sepetinize başarıyla eklendi !");
            

        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanicilar kullanicilar = new Kullanicilar();
            kullanicilar.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UrunGruplari urunGruplari = new UrunGruplari();
            urunGruplari.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Roller roller = new Roller();
            roller.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Urunler urunler = new Urunler();
            urunler.Show();
        }

        private void BTGoruntule_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            urunleriListele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sepet sepet = new Sepet();
            sepet.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Satis satis = new Satis();
            satis.Show();
        }

        private void BTUrunGruplariniYenile_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            urunGruplariniGoruntule();
            urunleriListele();
            toplamUrunSayisi();
            sepettekiToplamUrunSayisi();
        }

        private void toplamUrunSayisi()
        {
            con.Open();
            OracleCommand ora_cmd = new OracleCommand("TOPLAM_URUN_SAYISI", con);
            ora_cmd.BindByName = true;
            ora_cmd.CommandType = CommandType.StoredProcedure;
            ora_cmd.Parameters.Add("toplamSayi", OracleDbType.Int32).Direction = ParameterDirection.Output;
            ora_cmd.ExecuteNonQuery();

            int toplamUrunSayisi =  Convert.ToInt32(ora_cmd.Parameters["toplamSayi"].Value.ToString());
            LBLStoktakiToplamUrunSayisi.Text = toplamUrunSayisi.ToString();

            con.Close();

        }

        private void sepettekiToplamUrunSayisi()
        {
            con.Open();
            OracleCommand ora_cmd = new OracleCommand("SEPETTEKI_TOPLAM_URUN_SAYISI", con);
            ora_cmd.BindByName = true;
            ora_cmd.CommandType = CommandType.StoredProcedure;
            ora_cmd.Parameters.Add("sepettekiSayi", OracleDbType.Int32).Direction = ParameterDirection.Output;
            ora_cmd.ExecuteNonQuery();

            int sepettekiToplamUrunSayisi = 0;
            try
            {
                sepettekiToplamUrunSayisi = Convert.ToInt32(ora_cmd.Parameters["sepettekiSayi"].Value.ToString());
            }
            catch { }
            
            LBLSepettekiToplamUrunSayisi.Text = sepettekiToplamUrunSayisi.ToString();

            con.Close();

        }

        private void btSatinAl_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new OracleDataAdapter("select S.ID,S.URUN_ID,S.KULLANICI_ID, S.MIKTARI, U.TANIM, U.URUN_GRUP_ID, U.FIYAT, U.ACIKLAMA from SEPET S, URUNLER U WHERE S.URUN_ID = U.ID", con);
            adapt.Fill(dt);
            con.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OracleCommand cmd = new OracleCommand("insert into SATIS(URUN_ID,KULLANICI_ID,MIKTARI,TANIM,URUN_GRUP_ID,FIYAT,ACIKLAMA,TARIH) values(:urun_id,:kullanici_id,:miktari,:tanim,:urun_grup_id,:fiyat,:aciklama,:tarih)", con);
                con.Open();
                cmd.Parameters.Add(":urun_id", Convert.ToInt32(dt.Rows[i][1].ToString()));
                cmd.Parameters.Add(":kullanici_id", Convert.ToInt32(dt.Rows[i][2].ToString()));
                cmd.Parameters.Add(":miktari", Convert.ToInt32(dt.Rows[i][3].ToString()));
                cmd.Parameters.Add(":tanim", dt.Rows[i][4].ToString());
                cmd.Parameters.Add(":urun_grup_id", Convert.ToInt32(dt.Rows[i][5].ToString()));
                cmd.Parameters.Add(":fiyat", Convert.ToInt32(dt.Rows[i][6].ToString()));
                cmd.Parameters.Add(":aciklama", dt.Rows[i][7].ToString());
                cmd.Parameters.Add(":tarih", Convert.ToDateTime(DateTime.Now));

                cmd.ExecuteNonQuery();
                con.Close();
               
            }

            OracleCommand cmd1 = new OracleCommand("delete SEPET", con);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            sepettekiToplamUrunSayisi();
            toplamUrunSayisi();

            MessageBox.Show("Tüm ürünler satın alındı ve sepet boşaltıldı !");
        }
    }
}
