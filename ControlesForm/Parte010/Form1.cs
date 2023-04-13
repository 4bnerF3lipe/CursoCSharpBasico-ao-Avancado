using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parte010
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ListViewItem item1 = new ListViewItem("Gabriel");
            item1.SubItems.Add("12 98545-1542");
            item1.SubItems.Add("gabriel@mail.com");

            ListViewItem item2 = new ListViewItem("Logan");
            item2.SubItems.Add("12 45234-35454");
            item2.SubItems.Add("logan@mail.com");

            ListViewItem item3 = new ListViewItem("danny");
            item3.SubItems.Add("12 452454-1542");
            item3.SubItems.Add("danny@mail.com");

            ListViewItem item4 = new ListViewItem(new string[] { "Arthur", "13 3454-6545", "mail" });

            lista.Items.Add(item1);
            lista.Items.Add(item2);
            lista.Items.Add(item3);
            lista.Items.Add(item4);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lista.Items.Clear();
            //lista.Items.Remove(lista.SelectedItems[0]);
            //lista.Items.RemoveAt(1);
        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(lista.SelectedItems[0].Text);
        }
    }
}
