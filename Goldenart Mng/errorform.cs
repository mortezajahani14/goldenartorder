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
    public partial class errorform : Form
    {
        string item;
        public errorform(string selectedItem)
        {
            InitializeComponent();
            item = selectedItem;
        }

        string strconn = "Server=144.76.189.82;Port=3306;Database=cp29196_Golddesign;UID=cp29196_ugolddesign;PASSWORD=sd0018658962;Convert Zero Datetime=true;Allow Zero Datetime=True;SslMode=None;CharSet=utf8;";


        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
                string query = "UPDATE  orderc SET  send='no' , error = '1',errordes='" + richTextBox1.Text + "' WHERE id='" + item + "'";

                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(strconn);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  

                while (MyReader2.Read())
                {
                }
                MyConn2.Close();

                this.Close();

           
           
        }
    }
}
