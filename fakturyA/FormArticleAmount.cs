using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fakturyA
{
    public partial class FormArticleAmount : Form
    {
         public int Amount { get; set; }
        public double Discount { get; set; }
        private int indeks;
        public FormArticleAmount(int indeks)
        {
            this.indeks=indeks;
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }


        }
        private void Add_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim().ToString();
            textBox2.Text = textBox2.Text.Trim().ToString();
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                //poprawić sprawdzanie co wpisali 
                // ideeexxxxx 
                FormArticles.articlesList[indeks].Amount = Convert.ToInt16(textBox2.Text);
                FormArticles.articlesList[indeks].Discount = Convert.ToDouble(textBox1.Text);
                MessageBox.Show(Convert.ToString(indeks + " " + FormArticles.articlesList[indeks].Amount + " " + Convert.ToString(FormArticles.articlesList[indeks].Discount)));
            }
            // MainProgram.AddArticletoInvoiceWindow.
            // MainProgram.AddArticletoInvoiceWindow.Close();
            MainProgram.InvoiceEditor.addArticleToInvoice(FormArticles.articlesList[indeks]);
            Close(); ;

        }
    }
}
