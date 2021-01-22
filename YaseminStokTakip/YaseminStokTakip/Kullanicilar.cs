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
    public partial class Kullanicilar : Form
    {
        OracleConnection con = new OracleConnection("DATA SOURCE=YASEMIN;PASSWORD=YSM232;USER ID=STOK");
        OracleCommand cmd;
        OracleDataAdapter adapt;
        int ID = 0;

        public Kullanicilar()
        {
            InitializeComponent();
            DisplayData();
            rolleriGoruntule();
        }

        private void rolleriGoruntule()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new OracleDataAdapter("select * from ROLLER", con);
            adapt.Fill(dt);
            CBRol.DataSource = dt;
            CBRol.DisplayMember = "KULLANICI_TURU";
            CBRol.ValueMember = "ID";
            con.Close();
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if (TBTC.Text != "" && TBAdi.Text != "" && TBSoyadi.Text != "" && DPTarih.Text != "" && TBMail.Text != "" && TBCepTel.Text != "" && TBKullaniciAdi.Text != "" && TBSifre.Text != "")
            {
                cmd = new OracleCommand("insert into KULLANICILAR(ADI,DOGUM_TARIHI,KULLANICI_ADI,MAIL,ROL_ID,SIFRE,SOYADI,TC_KIMLIK_NO,CEP_TEL) values(:adi,:dogum_tarihi,:kullanici_adi,:mail,:rol_id,:sifre,:soyadi,:tc_kimlik_no,:cep_tel)", con);
                con.Open();
                cmd.Parameters.Add(":adi", TBAdi.Text);
                cmd.Parameters.Add(":dogum_tarihi", DPTarih.Value);
                cmd.Parameters.Add(":kullanici_adi", TBKullaniciAdi.Text);
                cmd.Parameters.Add(":mail", TBMail.Text);
                cmd.Parameters.Add(":rol_id", Convert.ToInt32(CBRol.SelectedValue));
                cmd.Parameters.Add(":sifre", TBSifre.Text);
                cmd.Parameters.Add(":soyadi", TBSoyadi.Text);
                cmd.Parameters.Add(":tc_kimlik_no", TBTC.Text);
                cmd.Parameters.Add(":cep_tel", TBCepTel.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt başarıyla tamamlandı !");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz !");
            }
        }

        private void ClearData()
        {
            TBTC.Text = "";
            TBAdi.Text = "";
            TBSoyadi.Text = "";
            DPTarih.Value = DateTime.Now;
            TBMail.Text = "";
            TBCepTel.Text = "";
            TBKullaniciAdi.Text = "";
            TBSifre.Text = "";
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new OracleDataAdapter("select k.*, r.KULLANICI_TURU from KULLANICILAR K INNER JOIN ROLLER R ON k.rol_id = r.id", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            satirlariGizle();
        }

        private void satirlariGizle()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[9].Visible = false;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TBTC.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TBAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TBSoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            CBRol.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TBKullaniciAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TBSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            DPTarih.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            TBMail.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            TBCepTel.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
        }



        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (TBTC.Text != "" && TBAdi.Text != "" && TBSoyadi.Text != "" && DPTarih.Text != "" && TBMail.Text != "" && TBCepTel.Text != "" && TBKullaniciAdi.Text != "" && TBSifre.Text != "")
            {
                cmd = new OracleCommand("update KULLANICILAR set ADI=:adi,DOGUM_TARIHI=:dogum_tarihi,KULLANICI_ADI=:kullanici_adi,MAIL=:mail,ROL_ID=:rol_id,SIFRE=:sifre,SOYADI=:soyadi,TC_KIMLIK_NO=:tc_kimlik_no,CEP_TEL=:cep_tel where ID=:id", con);
                con.Open();
                
                cmd.Parameters.Add(":adi", TBAdi.Text);
                cmd.Parameters.Add(":dogum_tarihi", DPTarih.Value);
                cmd.Parameters.Add(":kullanici_adi", TBKullaniciAdi.Text);
                cmd.Parameters.Add(":mail", TBMail.Text);
                cmd.Parameters.Add(":rol_id", Convert.ToInt32(CBRol.SelectedValue));
                cmd.Parameters.Add(":sifre", TBSifre.Text);
                cmd.Parameters.Add(":soyadi", TBSoyadi.Text);
                cmd.Parameters.Add(":tc_kimlik_no", TBTC.Text);
                cmd.Parameters.Add(":cep_tel", TBCepTel.Text);
                cmd.Parameters.Add(":id", ID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt başarıyla güncellendi !");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek kaydı seçiniz !");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new OracleCommand("delete KULLANICILAR where ID=:id", con);
                con.Open();
                cmd.Parameters.Add(":id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt başarıyla silindi !");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kaydı seçiniz !");
            }
        }

        private void BTIptal_Click(object sender, EventArgs e)
        {
            ClearData();
            ID = 0;
        }

        private void Search()
        {
            string sorgu = "select k.*, r.KULLANICI_TURU from KULLANICILAR K INNER JOIN ROLLER R ON k.rol_id = r.id";

            con.Open();
            DataTable dt = new DataTable();
            

            if (TBTC.Text != "")
            {
                    sorgu += " AND K.TC_KIMLIK_NO LIKE '%" + TBTC.Text + "%'";
            }
            if (TBAdi.Text != "")
            {
                    sorgu += " AND K.ADI LIKE '%" + TBAdi.Text + "%'";
            }
            if (TBSoyadi.Text != "")
            {
                    sorgu += " AND K.SOYADI LIKE '%" + TBSoyadi.Text + "%'";
            }
            if (TBCepTel.Text != "")
            {
                    sorgu += " AND K.CEP_TEL LIKE '%" + TBCepTel.Text + "%'";
            }


            adapt = new OracleDataAdapter(sorgu, con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void TBLAra_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
