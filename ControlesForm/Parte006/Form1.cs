using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parte006
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            checkList.Items.Add("Carro", true);
            checkList.Items.Add("Moto");
            checkList.Items.Add("Barco");
            checkList.Items.Add("Avião");

            int qtdItems = checkList.Items.Count;
            //MessageBox.Show("Quantidade items " + qtdItems);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checkList.Items.Clear();

            //checkList.Items.AddRange(new object[] { "Bike", "Mobilete", "Caminhão" });

            //bool res = checkList.Items.Contains("Moto");
            //if (res)
            //{
            //    MessageBox.Show("Contém");
            //}

            //checkList.Items.Remove("Moto");

            //checkList.Items.RemoveAt(2);

            //checkList.Items.Insert(1, "Cavalo");

            var items = checkList.CheckedItems;
            //var items = checkList.SelectedItems;
            foreach (var item in items)
            {
                MessageBox.Show(item.ToString());
            }
        }

        private void checkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = checkList.SelectedItem.ToString();
        }
    }
}
