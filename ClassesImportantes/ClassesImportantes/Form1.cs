using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassesImportantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMessageBox_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Ola meus amigos !!!");
            // MessageBox.Show("Mensagem a ser impressa", "Titulo da mensagem");

            //DialogResult res = MessageBox.Show("Texto da Mesnagem", "Titulo", MessageBoxButtons.OKCancel);

            //if (res == DialogResult.OK)
            //{
            //    lblResultado.Text = "Clicou em Ok";
            //}
            //else if (res == DialogResult.Cancel)
            //{
            //    lblResultado.Text = "Clicou em Cancelar";
            //}

            // MessageBox.Show("Mensagem", "Titulo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            MessageBox.Show("Mensagem", "Titulo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
        }

        private void btnAleatorio_Click(object sender, EventArgs e)
        {
            Random r = new Random(DateTime.Now.Millisecond);

            int valor = r.Next(100);
            double valor2 = r.NextDouble() * 100;

            lblResultado.Text = "Numero : " + valor2;
        }

        private void btnTimeSpan_Click(object sender, EventArgs e)
        {
            // lblResultado.Text = TimeSpan.FromTicks(1000000000).ToString();

            // lblResultado.Text = TimeSpan.TicksPerMinute.ToString();

            TimeSpan inicio = new TimeSpan(1, 0, 0);

            TimeSpan fim = new TimeSpan(3, 30, 0);

            //TimeSpan intervalo = fim - inicio;

            TimeSpan intervalo = fim.Subtract(inicio);

            lblResultado.Text = intervalo.ToString();
        }

        private void btnDateTime_Click(object sender, EventArgs e)
        {
            //lblResultado.Text = DateTime.Now.ToString();
            //lblResultado.Text = DateTime.Today.ToString();
            //lblResultado.Text = DateTime.DaysInMonth(2020,07).ToString();
            //lblResultado.Text = DateTime.IsLeapYear(2019).ToString();
            //lblResultado.Text = DateTime.Now.ToLongDateString();
            //lblResultado.Text = DateTime.Now.ToShortDateString();
            //lblResultado.Text = DateTime.Now.ToLongTimeString();
            //lblResultado.Text = DateTime.Now.ToShortTimeString();
            //lblResultado.Text = DateTime.Now.ToUniversalTime().ToString();
            //lblResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            DateTime data = new DateTime(1985, 01, 10, 14, 35, 30);

            //lblResultado.Text = data.AddYears(2).ToString();

            //TimeSpan tempo = new TimeSpan(5, 10, 5, 20);
            //lblResultado.Text = data.Add(tempo).ToString();

            lblResultado.Text = data.DayOfWeek.ToString();

            //lblResultado.Text = data.DayOfYear.ToString();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            Color vermelho = Color.Red;
            Color amarelo = Color.Yellow;

            //Color cor1 = Color.FromArgb(100, Color.DarkGreen);
            //Color cor1 = Color.FromArgb(255, 100, 50, 135);
            Color cor1 = Color.FromArgb(100, 50, 135);
            Color cor2 = Color.FromKnownColor(KnownColor.Control);
            Color cor3 = Color.FromName("DarkRed");

            lblResultado.BackColor = cor3;
            lblResultado.ForeColor = cor2;

            Color cor4 = lblResultado.BackColor;

            btnColor.BackColor = cor4;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            Font letra = new Font("Helvetica, Arial, sans-serif", 36, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Pixel);

            Font letra2 = new Font(FontFamily.GenericMonospace, 36, FontStyle.Regular, GraphicsUnit.Pixel);
            
            lblResultado.Text = "Bem vindo ao C#, Trabalho com fontes";

            lblResultado.Font = letra;
        }

        private void btnEnvironment_Click(object sender, EventArgs e)
        {
            string meusDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //Environment.CurrentDirectory = "C:\\";
            //string dirAtual = Environment.CurrentDirectory;
            //Environment.NewLine;
            //string varAmb = Environment.GetEnvironmentVariable("Path");

            //string[] discos = Environment.GetLogicalDrives();

            //foreach (string item in discos)
            //{
            //    lblResultado.Text += "\n" + item;
            //}

            string user = Environment.UserName;
            string dominio = Environment.UserDomainName;
            int cpu = Environment.ProcessorCount;
            
            lblResultado.Text = cpu.ToString();
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            //Application.Exit();

            string exec = Application.ExecutablePath;

            string pasta = Application.StartupPath;

            //Application.Restart();

            lblResultado.Text = pasta;
        }
    }
}
