using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parte005
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            string txt = check1.Text;
            bool status = check1.Checked;
            MessageBox.Show(txt + " " + status);
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            string txt = check2.Text;
            bool status = check2.Checked;
            MessageBox.Show(txt + " " + status);
        }

        private void check3_CheckedChanged(object sender, EventArgs e)
        {
            string txt = check3.Text;
            bool status = check3.Checked;
            MessageBox.Show(txt + " " + status);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string checados = "";

            if (check1.Checked)
            {
                checados += check1.Text + " - ";
            }

            if (check2.Checked)
            {
                checados += check2.Text + " - ";
            }

            if (check3.Checked)
            {
                checados += check3.Text;
            }

            MessageBox.Show(checados);
        }
    }
}
