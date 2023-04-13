using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parte007
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            combo.Items.Add("Carro");
            combo.Items.Add("Moto");
            combo.Items.Add("Barco");
            combo.Items.Add("Avião");

            combo.Items.AddRange(new object[] { "Cavalo", "Elevador", "Bike" });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(combo.Items.Count.ToString());

            //object item = combo.SelectedItem;
            //int indice = combo.SelectedIndex;
            //MessageBox.Show(indice + " " + item);

            //combo.Items.Clear();

            //combo.Items.Remove("Cavalo");

            //combo.Items.RemoveAt(1);

            //combo.Items.Insert(2, "Ovni");

            //MessageBox.Show(combo.Items.IndexOf("Barco").ToString());
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(combo.SelectedItem.ToString());
        }
    }
}
