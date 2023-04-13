using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imprimir
{
    public partial class Form1 : Form
    {
        int x;
        int y;
        int largura;
        int altura;
        int num_linhas;
        int pagina;
        int num_paginas;

        public Form1()
        {
            InitializeComponent();
            pagina = 0;
            num_paginas = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            largura = printDocument1.DefaultPageSettings.Bounds.Width;
            altura = printDocument1.DefaultPageSettings.Bounds.Height;
            x = 50;
            y = 50;
            num_linhas = 0;

            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() != DialogResult.Cancel)
            {
                largura = printDocument1.DefaultPageSettings.Bounds.Width;
                altura = printDocument1.DefaultPageSettings.Bounds.Height;
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                printDocument1.Print();
            }            
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            #region Parte 1

            //string texto = "Trabalhando com impressão.";
            //Font letra = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Point);
            //Brush pincel = new SolidBrush(Color.Black);
            //Point pontoInicial = new Point(100, 50);

            //// Desenhar o documetno para ser impresso
            //e.Graphics.DrawString(texto, letra, pincel, pontoInicial);
            //e.Graphics.DrawString("Gabriel Artigas", letra, Brushes.Red, new Point(100, 150));
            //e.Graphics.FillRectangle(Brushes.Green, new Rectangle(100, 220, 400, 100));

            #endregion

            #region Parte 2

            //int x = printDocument1.DefaultPageSettings.Bounds.X;
            //int y = printDocument1.DefaultPageSettings.Bounds.Y;
            //int largura = printDocument1.DefaultPageSettings.Bounds.Width;
            //int altura = printDocument1.DefaultPageSettings.Bounds.Height;

            //string titulo = "Titulo da Página";
            //Font letraTitulo = new Font("Verdana", 24, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            //Brush pincelTitulo = new SolidBrush(Color.Red);
            //Rectangle areaTitulo = new Rectangle(x + 50, y + 100, largura - 100, 100);
            //StringFormat formatoTitulo = new StringFormat();
            //formatoTitulo.Alignment = StringAlignment.Center;
            //formatoTitulo.LineAlignment = StringAlignment.Center;

            //string texto = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Repudiandae sed dolore veritatis odit excepturi incidunt ullam dolorem temporibus itaque quis illum ea sint, voluptatibus, et esse neque velit perferendis vero.";
            //Font letra = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Point);
            //Brush pincel = new SolidBrush(Color.Black);
            //Rectangle areaTexto = new Rectangle(x + 50, y + 200, largura - 100, altura - 400);

            //// Desenhar o documetno para ser impresso
            //e.Graphics.DrawString(titulo, letraTitulo, pincelTitulo, areaTitulo, formatoTitulo);
            //e.Graphics.DrawString(texto, letra, pincel, areaTexto);
            ////e.Graphics.DrawRectangle(new Pen(Color.Red, 5), areaTitulo);
            ////e.Graphics.DrawRectangle(new Pen(Color.Red, 5), areaTexto);

            #endregion

            #region Parte 3

            List<string> linhas = new List<string>()
            {
                "1. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "2. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "3. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "4. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "5. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "6. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "7. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "8. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "9. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "10. Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                "1. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "2. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "3. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "4. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "5. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "6. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "7. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "8. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "9. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "20. Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                "1. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "2. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "3. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "4. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "5. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "6. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "7. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "8. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "9. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "30. Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                "1. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "2. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "3. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "4. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "5. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "6. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "7. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "8. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "9. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "40. Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                "1. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "2. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "3. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "4. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "5. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "6. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "7. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "8. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "9. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "50. Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                "1. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "2. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "3. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "4. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "5. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "6. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "7. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "8. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "9. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "60. Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                "1. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "2. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "3. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "4. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "5. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "6. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "7. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "8. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "9. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "70. Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                "1. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "2. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "3. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "4. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "5. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "6. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "7. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "8. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "9. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "80. Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                "1. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "2. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "3. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "4. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "5. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "6. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "7. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "8. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "9. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "90. Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                "1. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "2. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "3. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "4. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "5. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "6. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "7. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "8. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "9. Lorem, ipsum dolor sit amet consectetur adipisicing elit. ",
                "100. Lorem, ipsum dolor sit amet consectetur adipisicing elit."
            };

            string titulo = "Titulo da Página";
            Font letraTitulo = new Font("Verdana", 24, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            Brush pincelTitulo = new SolidBrush(Color.Red);
            Rectangle areaTitulo = new Rectangle(x, y, largura - 100, 100);
            StringFormat formatoTitulo = new StringFormat();
            formatoTitulo.Alignment = StringAlignment.Center;
            formatoTitulo.LineAlignment = StringAlignment.Center;

            //// Desenhar o documetno para ser impresso
            Font letra = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Point);
            Brush pincel = new SolidBrush(Color.Black);

            while (num_linhas < linhas.Count)
            {
                if (num_linhas == 0)
                {
                    e.Graphics.DrawString(titulo, letraTitulo, pincelTitulo, areaTitulo, formatoTitulo);
                    y += 150;
                }

                e.Graphics.DrawString(linhas[num_linhas], letra, pincel, new Point(x, y));
                y += 30;
                num_linhas++;

                if (y >= altura - 50)
                {
                    // Mudar de Pagina
                    y = 50;
                    e.HasMorePages = true;
                    num_paginas++;
                    break;
                }
            }

            #endregion
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            largura = printDocument1.DefaultPageSettings.Bounds.Width;
            altura = printDocument1.DefaultPageSettings.Bounds.Height;
            x = 50;
            y = 50;
            num_linhas = 0;

            printPreviewControl1.Document = printDocument1;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (pagina > 0)
            {
                printPreviewControl1.StartPage = --pagina;
            }
        }

        private void btnProxima_Click(object sender, EventArgs e)
        {
            if (pagina < num_paginas)
            {
                printPreviewControl1.StartPage = ++pagina;
            }
        }

        private void btnVisualizarPadrao_Click(object sender, EventArgs e)
        {
            largura = printDocument1.DefaultPageSettings.Bounds.Width;
            altura = printDocument1.DefaultPageSettings.Bounds.Height;
            x = 50;
            y = 50;
            num_linhas = 0;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
