using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleErros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] num = { 10, 20, 30, 40, 50 };                   

            try
            {
                string res = "";
                for (int i = 0; i < 10; i++)
                {
                    res += num[i] + " ";
                }
                label1.Text = res;
            }
            catch (Exception ex)
            {
                label1.Text = "Erro !\n " + ex.Message;
            }
            finally
            {
                MessageBox.Show("Operação finalizada.");
            }
        }
    }
}
