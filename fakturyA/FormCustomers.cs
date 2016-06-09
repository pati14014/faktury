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
    public partial class FormCustomers : Form
    {
        private int SelectedConsumerID { get; set; } 


        public FormCustomers()
        {
            InitializeComponent();
        }

        public int ChooseConsumerWindow()
        {
            this.ShowDialog();
            return SelectedConsumerID; // przekaż na wyjście ID zaznaczonego rekordu. 
            // ktoś nie zaznaczył nic -> zwróć:  -1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedConsumerID = Convert.ToInt16(textBox1.Text);
            this.Close();
        }
    }
}
