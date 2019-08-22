using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Goldenart_Mng
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }


        #region Var


        string client_id, mobile, sms;
        string strconn = "Server=golden-art.ir;Port=3306;Database=saiona_DB;UID=saiona_DB;PASSWORD=SAIONA!#@golden_art88348453;Convert Zero Datetime=true;Allow Zero Datetime=True;SslMode=None;CharSet=utf8;";

        #endregion





        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void SymbolBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string sql = " SELECT *  FROM bot WHERE chatid='" + user_txt.Text + "'  and password='" + pass_txt.Text + "'";


            MySqlConnection conn = new MySqlConnection(strconn);
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {


                client_id = reader.GetString("chatid");
                this.Hide();
                Form1 f = new Form1(client_id);
                f.Show();




            }
            conn.Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void User_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {




           


        }
            
    }
}
