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
    public partial class Giris : Form
    {
        OracleConnection con = new OracleConnection("DATA SOURCE=YASEMIN;PASSWORD=YSM232;USER ID=STOK");
        OracleCommand cmd;
        OracleDataAdapter adapt;
        public Giris()
        {
            InitializeComponent();
        }

        private void BTGiris_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new OracleDataAdapter("select * from KULLANICILAR K WHERE K.KULLANICI_ADI = '" + TBKullaniciAdi.Text.Trim() + "' AND K.SIFRE = '" + TBParola.Text.Trim() + "'", con);
            adapt.Fill(dt);
            con.Close();

            if(dt.Rows.Count > 0)
            {
                AnaSayfa anaSayfa = new AnaSayfa();
                anaSayfa.Show();
                this.Hide();
            }
            else
            {
                LBLUyari.Text = "Kullanıcı adı veya parola yanlış !";
            }
        }
    }
}
