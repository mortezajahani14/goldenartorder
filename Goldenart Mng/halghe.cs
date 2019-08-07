using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Goldenart_Mng
{
    public partial class halghe : Form
    {
        public halghe()
        {
            InitializeComponent();
        }

        private void Halghe_MouseDown(object sender, MouseEventArgs e)
        {
            
                this.Close();
            
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void Halghe_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
