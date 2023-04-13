using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManipularNumeros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            #region TryParse
            //int num;
            ////bool res = int.TryParse("1985sdfsa", out num);

            //if (int.TryParse("1985", out num))
            //{
            //    lblResultado.Text = num.ToString();
            //}
            //else
            //{
            //    lblResultado.Text = "Erro na conversão";
            //}  
            #endregion

            #region ToString / Convert.ToString
            //double num = 120.5524;
            //lblResultado.Text = num.ToString("#.00");

            //int num = 254;
            //lblResultado.Text = num.ToString("X"); // Hex
            //lblResultado.Text = num.ToString("D"); // Dec
            //lblResultado.Text = num.ToString("X2"); // Hex min 2 digitos
            //lblResultado.Text = num.ToString("D2"); // Dec min 2 digitos
            //lblResultado.Text = num.ToString("C"); // Monetario

            //lblResultado.Text = Convert.ToString(num, 8);
            #endregion

            #region Classe Math
            double pi = Math.PI;
            double E = Math.E;
            double seno = Math.Sin(3);
            double conseno = Math.Cos(3);
            double potencia = Math.Pow(2, 10);
            double raizQuadrada = Math.Sqrt(49);
            double aredonda = Math.Round(158.20);
            double inteiro = Math.Truncate(32.57);
            double floor = Math.Floor(52.75);
            double ceil = Math.Ceiling(52.25);
            #endregion

            lblResultado.Text = ceil.ToString();
        }
    }
}
