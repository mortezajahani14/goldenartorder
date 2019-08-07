using System;
using System.Drawing;
using System.Windows.Forms;
using Telegram.Bot;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;

namespace Goldenart_Mng
{
    public partial class Form1 : Form
    {
        readonly string client_id2;
        public Form1(string client_id)
        {
            InitializeComponent();
            label12.BackColor = Color.Transparent;
            client_id2 = client_id;
            
    }

        Image img,img2,img3,img4;
        string imgadd, imgadd2, imgadd3, imgadd4;



        #region Var
        bool clas = true;
        double rate, ratesimp;
        int pardakht = 0, amount = 0, cost = 0, sympcost = 0, smscost = 0, id = 0;
        string  namela, lnamela, mobla, amountla, accla, nightla,errorla, smsla, names1 = "", names2 = "", names3 = "", names4 = "", namepic1 = "", namepic2 = "", namepic3 = "", namepic4 = "", simpla, datela, clientidla,vip,night,pardakhtsh , desssh,halghesh,tozihhalghesh,filedl,datesh,halghe;
        string strconn = "Server=144.76.189.82;Port=3306;Database=cp29196_Golddesign;UID=cp29196_ugolddesign;PASSWORD=sd0018658962;Convert Zero Datetime=true;Allow Zero Datetime=True;SslMode=None;CharSet=utf8;";

        #endregion





        public void refresh()
        {



          









            string sql = " SELECT *  FROM bot WHERE chatid='" + client_id2 + "' ";


            MySqlConnection conn = new MySqlConnection(strconn);
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {



                namela = reader.GetString("firstname");
                lnamela = reader.GetString("lastname");
                mobla = reader.GetString("mobile");
                amountla = reader.GetString("amont");
                amount =Convert.ToInt32( reader.GetString("amont"));
                accla = reader.GetString("vip");
                nightla = reader.GetString("night");
                smsla = reader.GetString("sms");
                simpla = reader.GetString("simp");
                datela = reader.GetString("date");
                clientidla = reader.GetString("chatid");





            }
            conn.Close();







            string sql2 = " SELECT *  FROM const WHERE name='cost' ";


            MySqlConnection conn2 = new MySqlConnection(strconn);
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);

            conn2.Open();

            MySqlDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {



                cost = Convert.ToInt32(reader2.GetString("amontwin"));
                sympcost = Convert.ToInt32(reader2.GetString("symp"));
                if (smsla == "1")
                {
                    smscost = Convert.ToInt32(reader2.GetString("sms"));
                }
                else
                {
                    smscost = 0;
                }
                




            }
            conn2.Close();






            name_la.Text = namela;
            lname_la.Text = lnamela;
            mob_la.Text = mobla;
            amount_la.Text = amountla;


            if (accla == "0")
            {
                acc_la.Text = "عادی";
            }
            else
            {
                acc_la.Text = "ویژه";
            }


            if (nightla == "0")
            {
                night_la.Text = "غیر فعال";
            }
            else
            {
                night_la.Text = "فعال";
            }


            if (smsla == "0")
            {
                sms_la.Text = "غیر فعال";
            }
            else
            {
                sms_la.Text = "فعال";
            }


            if (simpla == "0")
            {
                simp_la.Text = "غیر فعال";
            }
            else
            {
                simp_la.Text = "فعال";
            }

            DateTime d = DateTime.Parse(datela);

            PersianCalendar pc = new PersianCalendar();
            date_la.Text = string.Format("{0}/{1}/{2}   {3}:{4}:{5}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d), pc.GetHour(d), pc.GetMinute(d), pc.GetSecond(d));

            clientid_la.Text = clientidla;


         //  var dateNow = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time"));
         //
         //
         //
         //
         //  var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
         //                 dateNow.Hour, dateNow.Minute, dateNow.Second);
         //
         //
         //
         //
         //
         //
         //
         //
         //  string query = "UPDATE  bot SET date='" + date + "' WHERE chatid='" + client_id2 + "'";
         //
         //  //This is  MySqlConnection here i have created the object and pass my connection string.  
         //  MySqlConnection MyConn2 = new MySqlConnection(strconn);
         //  //This is command class which will handle the query and connection object.  
         //  MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
         //  MySqlDataReader MyReader2;
         //  MyConn2.Open();
         //  MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
         //
         //  while (MyReader2.Read())
         //  {
         //  }
         //  MyConn2.Close();
         //
         //


        }


        public void smssend(string mobile, string id, string temp)
        {

            try
            {
                Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi("624E79452F76702B306F3757764A54505038346A743258556831444D67363158525650386E5451756967553D");
                var result = api.VerifyLookup(mobile, id, temp);
                //  foreach (var r in result)
                //  {
                //     Console.Write("r.Messageid.ToString()");
                // }
            }
            catch (Kavenegar.Exceptions.ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                Console.Write("Message : " + ex.Message);
            }
            catch (Kavenegar.Exceptions.HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                Console.Write("Message : " + ex.Message);
            }

        }
        public void smssenderror(string mobile, string id, string dess, string err, string temp)
        {

            try
            {
                Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi("624E79452F76702B306F3757764A54505038346A743258556831444D67363158525650386E5451756967553D");
                var result = api.VerifyLookup(mobile, id, dess, err, temp);
                //  foreach (var r in result)
                //  {
                //     Console.Write("r.Messageid.ToString()");
                // }
            }
            catch (Kavenegar.Exceptions.ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                Console.Write("Message : " + ex.Message);
            }
            catch (Kavenegar.Exceptions.HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                Console.Write("Message : " + ex.Message);
            }

        }




        private void Progresss1(object sender, UploadProgressChangedEventArgs e)
        {


            // the progress
            progressBar2.Value = e.ProgressPercentage;


            if (progressBar2.Value == 100)
            {
                progressBar2.Value = 0;
              
                pictureBox1.Image = null;
                img = null;
                
            }



        }

        private void Progresss2(object sender, UploadProgressChangedEventArgs e)
        {


            // the progress
            progressBar3.Value = e.ProgressPercentage;

            if (progressBar3.Value == 100)
            {
                progressBar3.Value = 0;

                pictureBox2.Image = null;
                img2 = null;

            }


        }

        private void Progresss3(object sender, UploadProgressChangedEventArgs e)
        {


            // the progress
            progressBar4.Value = e.ProgressPercentage;

            if (progressBar4.Value == 100)
            {
                progressBar4.Value = 0;

                pictureBox3.Image = null;
                img3 = null;

            }



        }

        private void Progresss4(object sender, UploadProgressChangedEventArgs e)
        {


            // the progress
            progressBar5.Value = e.ProgressPercentage;

            if (progressBar5.Value == 100)
            {
                progressBar5.Value = 0;

                pictureBox4.Image = null;
                img4 = null;

            }



        }





        #region Submit

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            progressBar2.Value = 0;
            label25.Visible = false;
            label23.Visible = false;
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "choose image(*.jpg;*png;*.gif)|*.jpg;*png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(opf.FileName);
                 imgadd = opf.FileName;
               
            
            
            namepic1 = "_1";

               
            }
            pictureBox1.Image = img;
        }



        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void ListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label33.Visible = false;
            progressBar1.Value = 0;
            button2.Enabled = true;
            error_but.Enabled = true;

            string sql = " SELECT *  FROM orderc WHERE id='" + listBox1.SelectedItem + "' ";


            MySqlConnection conn = new MySqlConnection(strconn);
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {





                filedl = reader.GetString("file");
                pardakhtsh = reader.GetString("despay");
                desssh = reader.GetString("des");
                
                tozihhalghesh = reader.GetString("dhalghe");
                datesh = reader.GetString("date");
                errorla = reader.GetString("error");


                switch (reader.GetString("halghe"))
                {
                    case "1":
                        textBox2.Text = "حلقه شماره 1";
                        break;
                    case "2":
                        textBox2.Text = "حلقه شماره 2";
                        break;
                    case "3":
                        textBox2.Text = "حلقه شماره 3";
                        break;
                    case "4":
                        textBox2.Text = "پرچی شماره 1";
                        break;
                    case "5":
                        textBox2.Text = "پرچی شماره 2";
                        break;
                    case "6":
                        textBox2.Text = "بدون حلقه";
                        break;
                    case "7":
                        textBox2.Text = "حلقه چه خاص";
                        break;
                }


            }
            conn.Close();

            if (pardakhtsh == "موجودی")
            {
                label20.Text = "پرداخت از حساب";
            }
            else
            {
                label20.Text = "پرداخت از بانک";
            }
            if (errorla == "1")
            {
                error_but.Enabled = false;
            }

            textBox1.Text = desssh;
             
            textBox3.Text = tozihhalghesh;

            DateTime d = DateTime.Parse(datesh);

            PersianCalendar pc = new PersianCalendar();
            label22.Text = string.Format("{0}/{1}/{2}   {3}:{4}:{5}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d), pc.GetHour(d), pc.GetMinute(d), pc.GetSecond(d));

        }




        public void getlastid()
        {

            string sql = "SELECT * FROM orderc where clientid='" + clientidla + "' ORDER BY id DESC LIMIT 1";
            MySqlConnection conn = new MySqlConnection(strconn);
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                
               id =Convert.ToInt32( reader.GetString("id"));









            }
            conn.Close();
        }






        private void Progresss(object sender, UploadProgressChangedEventArgs e)
        {


            // the progress
            progressBar1.Value = e.ProgressPercentage;


            label12.Text = progressBar1.Value.ToString() + "%";


        }



        private void Button4_Click_1(object sender, EventArgs e)
        {

            if (bank_ra.Checked)
            {
                MessageBox.Show("در این نسخه امکان پرداخت بانکی وجود ندارد");
            }
            else
            {


                refresh();




                string sql = " SELECT *  FROM bot WHERE chatid='" + client_id2 + "' ";


                    MySqlConnection conn = new MySqlConnection(strconn);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    conn.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        vip = reader.GetString("vip");
                        night = reader.GetString("night");
                        rate = Convert.ToDouble( reader.GetString("rate"));
                        ratesimp = Convert.ToDouble(reader.GetString("ratesimp"));


                }
                    conn.Close();




                    var dateNow2 = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time"));




                    var date = new DateTime(dateNow2.Year, dateNow2.Month, dateNow2.Day,
                               dateNow2.Hour, dateNow2.Minute, dateNow2.Second);



                if (clas == true)
                {





                    MySqlCommand command;

                   



                    if (amount < (cost * rate))
                    {
                        MessageBox.Show("موجودی کافی نیست");
                    }
                    else
                    {



























                        







                        String insertQuery = "insert into orderc(type,class,blocktext,clientid,des,date,halghe,voice,photo,dhalghe,progress,file,Mac,User,errordes,status,pay,despay,Vip,Night) values(4,1,'',@clientid,@dess,@date,@halghe,'','','','','','','','','','yes','موجودی',@vip,@night)";

                        conn.Open();

                    command = new MySqlCommand(insertQuery, conn);

                          command.Parameters.Add("@clientid", MySqlDbType.Int16, 11);
                          command.Parameters.Add("@dess", MySqlDbType.VarChar, 128);
                           command.Parameters.Add("@date", MySqlDbType.DateTime);

                        command.Parameters.Add("@halghe", MySqlDbType.Int16, 11);
                    command.Parameters.Add("@dhalghe", MySqlDbType.VarChar, 128);
                    command.Parameters.Add("@vip", MySqlDbType.Int16, 11);
                    command.Parameters.Add("@night", MySqlDbType.Int16, 11);

                    command.Parameters["@clientid"].Value = client_id2;
                    command.Parameters["@dess"].Value = richTextBox1.Text;
                    command.Parameters["@date"].Value = date;
                       
                    command.Parameters["@halghe"].Value = halghe;
                    command.Parameters["@dhalghe"].Value = textBox8.Text;
                    command.Parameters["@vip"].Value = vip;
                    command.Parameters["@night"].Value = night;

                    if (command.ExecuteNonQuery() == 1)
                    {


                            getlastid();



                            if (pictureBox1.Image != null)
                            {
                                WebClient client = new WebClient();
                                client.Credentials = new NetworkCredential("cp29196", "Saiona123");
                                var uri = new System.Uri(@"ftp://144.76.189.82/public_html/Images/" + id + namepic1 + ".jpg", UriKind.Absolute);
                                client.UploadProgressChanged += new UploadProgressChangedEventHandler(Progresss1);
                                client.UploadFileAsync(uri, imgadd);
                            }

                            if (pictureBox2.Image != null)
                            {
                                WebClient client2 = new WebClient();
                                client2.Credentials = new NetworkCredential("cp29196", "Saiona123");
                                var uri2 = new System.Uri(@"ftp://144.76.189.82/public_html/Images/" + id + namepic2 + ".jpg", UriKind.Absolute);
                                client2.UploadProgressChanged += new UploadProgressChangedEventHandler(Progresss2);
                                client2.UploadFileAsync(uri2, imgadd2);
                            }

                            if (pictureBox3.Image != null)
                            {
                                WebClient client3 = new WebClient();
                                client3.Credentials = new NetworkCredential("cp29196", "Saiona123");
                                var uri3 = new System.Uri(@"ftp://144.76.189.82/public_html/Images/" + id + namepic3 + ".jpg", UriKind.Absolute);
                                client3.UploadProgressChanged += new UploadProgressChangedEventHandler(Progresss3);
                                client3.UploadFileAsync(uri3, imgadd3);
                            }

                            if (pictureBox4.Image != null)
                            {
                                WebClient client4 = new WebClient();
                                client4.Credentials = new NetworkCredential("cp29196", "Saiona123");
                                var uri4 = new System.Uri(@"ftp://144.76.189.82/public_html/Images/" + id + namepic4 + ".jpg", UriKind.Absolute);
                                client4.UploadProgressChanged += new UploadProgressChangedEventHandler(Progresss4);
                                client4.UploadFileAsync(uri4, imgadd4);
                            }


                            label23.Visible = true;



                    }

                    conn.Close();




                        if (pictureBox1.Image == null)
                        {
                            names1 = null;
                        }
                        else
                        {
                            names1 = (id + namepic1 + ".jpg");
                        }

                        if (pictureBox2.Image == null)
                        {
                            names2 = null;
                        }
                        else
                        {
                            names2 = (id + namepic2 + ".jpg");
                        }

                        if (pictureBox3.Image == null)
                        {
                            names3 = null;
                        }
                        else
                        {
                            names3 = (id + namepic3 + ".jpg");
                        }

                        if (pictureBox4.Image == null)
                        {
                            names4 = null;
                        }
                        else
                        {
                            names4 = (id + namepic4 + ".jpg");
                        }







                        string query2 = "UPDATE  orderc SET lphoto='" + names1 + "',lphoto2='" + names2 + "',lphoto3='" + names3 + "',lphoto4='" + names4 + "'  WHERE id='" + id + "'";

                        //This is  MySqlConnection here i have created the object and pass my connection string.  
                        MySqlConnection MyConn3 = new MySqlConnection(strconn);
                        //This is command class which will handle the query and connection object.  
                        MySqlCommand MyCommand3 = new MySqlCommand(query2, MyConn3);
                        MySqlDataReader MyReader3;
                        MyConn3.Open();
                        MyReader3 = MyCommand3.ExecuteReader();     // Here our query will be executed and data saved into the database.  

                        while (MyReader3.Read())
                        {
                        }
                        MyConn3.Close();







                        string query = "UPDATE  bot SET amont='" + (amount - ((cost*rate)+smscost)) + "' WHERE chatid='" + client_id2 + "'";

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

                        if (smsla == "1")
                        {

                           
                            smssend(mobla, id.ToString(), "order");
                        }


                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                        radioButton5.Checked = false;
                        radioButton6.Checked = false;
                        radioButton7.Checked = false;
                        textBox8.Text = "";
                        richTextBox1.Text = "";
                        
                        
                    }

                    

                }
                else
                {
                    MySqlCommand command;




                    if (amount < (sympcost * ratesimp))
                    {
                        MessageBox.Show("موجودی کافی نیست");
                    }
                    else
                    {


                        String insertQuery = "insert into orderc(type,class,blocktext,clientid,des,date,voice,photo,dhalghe,progress,file,Mac,User,errordes,status,pay,despay,Vip,Night) values(4,2,'',@clientid,@dess,@date,'','','','','','','','','','yes','موجودی',@vip,@night)";

                        conn.Open();

                        command = new MySqlCommand(insertQuery, conn);

                        command.Parameters.Add("@clientid", MySqlDbType.Int16, 11);
                        command.Parameters.Add("@dess", MySqlDbType.VarChar, 128);
                        command.Parameters.Add("@date", MySqlDbType.DateTime);

                        command.Parameters.Add("@vip", MySqlDbType.Int16, 11);
                        command.Parameters.Add("@night", MySqlDbType.Int16, 11);

                        command.Parameters["@clientid"].Value = client_id2;
                        command.Parameters["@dess"].Value = richTextBox1.Text;
                        command.Parameters["@date"].Value = date;

                        command.Parameters["@vip"].Value = vip;
                        command.Parameters["@night"].Value = night;

                        if (command.ExecuteNonQuery() == 1)
                        {
                            label23.Visible = true;
                        }

                        conn.Close();




                        string query = "UPDATE  bot SET amont='" + (amount - ((sympcost * ratesimp)+smscost)) + "' WHERE chatid='" + client_id2 + "'";

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



                         if (smsla == "1")
                        {

                           
                            smssend(mobla, id.ToString(), "order");
                        }


                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                        radioButton5.Checked = false;
                        radioButton6.Checked = false;
                        radioButton7.Checked = false;
                        textBox8.Text = "";
                        richTextBox1.Text = "";
                        pictureBox1.Image = null;
                        pictureBox2.Image = null;
                        pictureBox3.Image = null;
                        pictureBox4.Image = null;
                        img = null;
                        img2 = null;
                        img3 = null;
                        img4 = null;
                    }
                }


                refresh();



                 

            }

        }



        public void getorder()
        {




            listBox1.Items.Clear();
            listBox2.Items.Clear();

            string sql = "SELECT * FROM orderc where clientid='" + clientidla + "' and send='yes' Order By date DESC LIMIT 15";
            MySqlConnection conn = new MySqlConnection(strconn);
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                listBox1.Items.Add(reader.GetString("id"));









            }
            conn.Close();

        }




        public void geterrororder()
        {


            






            string sql = "SELECT * FROM orderc where clientid='" + clientidla + "' and send='no' and pay='yes' and block='1' Order By date DESC LIMIT 4";
            MySqlConnection conn = new MySqlConnection(strconn);
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                listBox2.Items.Add(reader.GetString("id"));









            }
            conn.Close();

        }




        private void Button1_Click_1(object sender, EventArgs e)
        {
            label33.Visible = false;
            filedl = "";
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            textBox4.Text = "";

            getorder();
            geterrororder();
        }

        private void Button5_Click_2(object sender, EventArgs e)
        {
            label33.Visible = false;
            progressBar1.Value = 0;
            button2.Enabled = false;
            error_but.Enabled = false;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            label20.Text = "";



            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            label22.Text = "";
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton6.Checked)
            {
                textBox8.Enabled = false;
                textBox8.Text = "";
            }
            else
            {
                textBox8.Enabled = true;
                
                    halghe = "7";
                label25.Visible = false;
                label23.Visible = false;

            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                halghe = "2";
                label25.Visible = false;
                label23.Visible = false;
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                halghe = "3";
                label23.Visible = false;
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                halghe = "4";
                label25.Visible = false;
                label23.Visible = false;
            }
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                halghe = "5";
                label25.Visible = false;
                label23.Visible = false;
            }
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                halghe = "6";
                label25.Visible = false;
                label23.Visible = false;
            }
        }

        private void SymbolBox1_Click(object sender, EventArgs e)
        {
            halghe h = new halghe();
            h.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label33.Visible = false;
            progressBar1.Value = 0;
            button2.Enabled = true;
            error_but.Enabled = true;

            string sql = " SELECT *  FROM orderc WHERE id='" + listBox2.SelectedItem + "' ";


            MySqlConnection conn = new MySqlConnection(strconn);
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {


                textBox4.Text = reader.GetString("blocktext");
                

            }
            conn.Close();
        }

        private void Error_but_Click(object sender, EventArgs e)
        {
            errorform er = new errorform( listBox1.SelectedItem.ToString());
            er.ShowDialog();
            getorder();
            geterrororder();

            button2.Enabled = false;
            error_but.Enabled = false;
           

            label20.Text = "";



            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            label22.Text = "";
        }

        private void SymbolBox2_Click(object sender, EventArgs e)
        {
            dessform d = new dessform();
            d.ShowDialog();
        }

        private void RadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                halghe = "1";
                
                
            }
        }



        private void Progresss(object sender, DownloadProgressChangedEventArgs e)
        {

            
            // the progress
            progressBar1.Value = e.ProgressPercentage;


            


        }




        private void Button2_Click_1(object sender, EventArgs e)
        {
            
            progressBar1.Value = 0;
            //System.Diagnostics.Process.Start(filedl);
            WebClient Client = new WebClient();
            var uri = new System.Uri(filedl, UriKind.Absolute);
            Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Progresss);
            Client.DownloadFileAsync(uri, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +@"\"+ listBox1.SelectedItem + ".zip" );
            label33.Visible = true;
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text =="")
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }
        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void SymbolBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://golden-art.ir/Pay/index.php?pay=" + client_id2);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            progressBar4.Value = 0;
            label25.Visible = false;
            label23.Visible = false;
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "choose image(*.jpg;*png;*.gif)|*.jpg;*png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                img3 = Image.FromFile(opf.FileName);
                imgadd3 = opf.FileName;


                
                namepic3 = "_3";


                
            }
            pictureBox3.Image = img3;
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            label25.Visible = false;
            label23.Visible = false;
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "choose image(*.jpg;*pmg;*.gif)|*.jpg;*pmg;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                img4 = Image.FromFile(opf.FileName);
                imgadd4 = opf.FileName;



                namepic4 = "_4";
            }



            pictureBox4.Image = img4;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode & Keys.F5) == Keys.F5)
            {

                refresh();
            }
        }

        private void SymbolBox4_Click(object sender, EventArgs e)
        {
            if (smsla == "0")
            {
                string query = "UPDATE  bot SET sms='1' WHERE chatid='" + client_id2 + "'";

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
                refresh();
            }
            else if(smsla == "1")
            {
                string query = "UPDATE  bot SET sms='0' WHERE chatid='" + client_id2 + "'";

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
                refresh();
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
 



            progressBar3.Value = 0;
            label25.Visible = false;
            label23.Visible = false;
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "choose image(*.jpg;*png;*.gif)|*.jpg;*png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                img2 = Image.FromFile(opf.FileName);
                imgadd2 = opf.FileName;


                
                namepic2 = "_2";


                
            }
            pictureBox2.Image = img2;
        }

        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            label25.Visible = false;
            label23.Visible = false;
            if (simpla == "1")
            {
                

                if (radioButton8.Checked)
                {
                    symbolBox1.Enabled = false;
                    pictureBox1.Enabled = false;
                    pictureBox2.Enabled = false;
                    pictureBox3.Enabled = false;
                    pictureBox4.Enabled = false;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    radioButton4.Enabled = false;
                    radioButton5.Enabled = false;
                    radioButton6.Enabled = false;
                    radioButton7.Enabled = false;
                    clas = false;
                    img = null;
                    img2 = null;
                    img3 = null;
                    img4 = null;
                    
                }
                else
                {
                    symbolBox1.Enabled = true;
                    pictureBox1.Enabled = true;
                    pictureBox2.Enabled = true;
                    pictureBox3.Enabled = true;
                    pictureBox4.Enabled = true;
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                    radioButton6.Enabled = true;
                    radioButton7.Enabled = true;
                    


                }
            }
            else
            {
                label25.Visible = true;
                label23.Visible = true;
            }
        }

        private void RadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            label25.Visible = false;
            label23.Visible = false;
            if (radioButton9.Checked)
            {
                clas = true;
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            refresh();
            label25.Visible = false;
            label23.Visible = false;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            textBox8.Text = "";
            richTextBox1.Text = "";
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            img = null;
            img2 = null;
            img3 = null;
            img4 = null;
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click_4(object sender, EventArgs e)
        {






        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refresh();
           



        }


        private void Button8_Click(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void Bank_ra_CheckedChanged(object sender, EventArgs e)
        {
            if (bank_ra.Checked)
            {
                pardakht = 2;
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (hesab_ra.Checked)
            {
                pardakht = 1;
            }
            
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            //  System.Diagnostics.Process.Start(dl);
        }

        private void Error_check_CheckedChanged(object sender, EventArgs e)
        {
            // if (error_check.Checked)
            //   {
            //   error_but.Enabled = true;
            //    error_txt.Enabled = true;

            //   bazpardakht_check.Enabled = true;
            //   bazpardakht_label.Enabled = true;

            //  }
            //   else
            //  {
            //   error_but.Enabled = false;
            //   error_txt.Enabled = false;
            //    error_txt.Text = "";
            //   bazpardakht_check.Enabled = false;
            //    bazpardakht_label.Enabled = false;
            //   bazpardakht_check.Checked = false;
            //  }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TopMost = false;
        }













        #endregion

        #region Voice

        private void Button5_Click(object sender, EventArgs e)
        {

            // Process.Start(voicefilepath);

        }
        #endregion




     
        private void Button3_Click(object sender, EventArgs e)
        {

           // OpenFileDialog openfiledialog = new OpenFileDialog();
            // if (classs == "1")
            //   {
            //     openfiledialog.Filter = "zip files (*.zip)|*.zip";
            // }
            // else if(classs == "2")
            //  { 
            // openfiledialog.Filter = "Image Files |*.JPG;*.PNG;*.GIF";
            //   }
            // if (openfiledialog.ShowDialog() == DialogResult.OK)
            //  {


        }
    }


}



