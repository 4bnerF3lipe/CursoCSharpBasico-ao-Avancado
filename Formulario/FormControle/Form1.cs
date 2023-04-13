using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormControle
{
    public partial class Form1 : Form
    {
        Label label1;
        Button btn1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1 = new Label();
            label1.Location = new Point(10, 10);
            label1.AutoSize = false;
            label1.Size = new Size(500, 100);
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Black;
            label1.Font = new Font("Arial", 28, FontStyle.Bold, GraphicsUnit.Point);
            label1.Text = "Minha Label no Código";

            btn1 = new Button();
            btn1.Location = new Point(250, 285);
            btn1.Size = new Size(200, 60);
            btn1.Text = "Botão Código";
            btn1.Font = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);

            btn1.Click += Btn1_Click;

            btn1.MouseEnter += Btn1_MouseEnter;

            this.Controls.Add(label1);
            this.Controls.Add(btn1);
        }

        private void Btn1_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Mouse sobre o botão";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            label1.Text = "Clicou no botão.";
        }
    }
}
