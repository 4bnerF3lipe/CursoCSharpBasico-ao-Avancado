using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arquivo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pasta = @"c:\curso\";
            string arquivo = "teste.txt";

            //bool res = File.Exists(pasta + arquivo);
            //label1.Text = res.ToString();

            //File.Delete(pasta + arquivo);

            //if (!File.Exists(pasta + arquivo))
            //{
            //    File.Create(pasta + arquivo).Close();
            //    label1.Text = "Criado";
            //}
            //else
            //{
            //    label1.Text = "Já existe";
            //}

            //if (File.Exists(pasta + arquivo))
            //{
            //    File.Copy(pasta + arquivo, pasta + "Copia.txt", true);
            //    label1.Text = "Copiado";
            //}
            //else
            //{
            //    label1.Text = "Arquivo não existe.";
            //}

            //File.Move(pasta + arquivo, pasta + "destino\\" + arquivo);

            File.WriteAllText(pasta + arquivo, "Teste de escrita de arquivo novo", Encoding.Default);

            label1.Text = File.ReadAllText(pasta + arquivo, Encoding.Default);

            //File.SetCreationTime(pasta + arquivo, DateTime.Now);
        }
    }
}

// File.Exists()
// Existe.Delete()
// File.Create()
// File.Move()
// File.Copy()
// File.WriteAllText()
// File.ReadAllText()
