using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMdi
{
    public partial class FormTres : Form
    {
        public FormTres(Form parent)
        {
            InitializeComponent();

            MdiParent = parent;
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            FormDois f = new FormDois(MdiParent);
            f.Show();
            Close();
        }
    }
}
