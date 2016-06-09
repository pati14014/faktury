using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace fakturyA
{
    public partial class FormInvoicesList : Form
    {
        public FormInvoicesList()
        {
            InitializeComponent();
            comboBoxMaximumResults.SelectedIndex = 2;
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            WriteAllInvoices();
        }

        private void WriteAllInvoices()
        {
            dataGridView1.Rows.Clear(); // wyczyść poprzednie dane nim załadujesz
            DatabaseMySQL.LoadInvoicesList();
                    
            if (MainProgram.InvoiceObjectsList.Count > 0) // jeśli tablica nie-pusta
            {    
                int i = 0;
                foreach (Invoice invoice in MainProgram.InvoiceObjectsList)
                {
                    dataGridView1.Rows.Add();
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i];

                    row.Cells["index"].Value = i;
                    row.Cells["NrFaktury"].Value = invoice.Number;
                    row.Cells["sprzedawca"].Value = invoice.EmployeeName;
                   // row.Cells["KlientNIP"].Value = invoice.CustomerNIP;
                    row.Cells["KlientName"].Value = invoice.CusotmerName;
                    row.Cells["WartoscFaktury"].Value = invoice.InvoiceValue;
                    row.Cells["DoZaplaty"].Value = invoice.AmountPaid;
                    row.Cells["DataWystawienia"].Value = invoice.InvoiceDate;
                    row.Cells["TerminPlatnosci"].Value = invoice.PaymentDate;
                    i++;
                }      
            }
        }

        private void FindInInvoices(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var ResultsInvoices = from Invoice invoice in MainProgram.InvoiceObjectsList
                                  where (invoice.Number.Contains(textBoxFindNumber.Text)
                                  && invoice.CusotmerName.Contains(textBoxFindCustomerName.Text))
                                  //&& invoice.CustomerNIP.ToString().Contains(textBoxFindNIP.Text))
                                  select invoice;

            foreach (Invoice invoice in ResultsInvoices)
            {
                int i = dataGridView1.Rows.Add();
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i];

                row.Cells["index"].Value = i;
                row.Cells["NrFaktury"].Value = invoice.Number;
                row.Cells["sprzedawca"].Value = invoice.EmployeeName;
               // row.Cells["KlientNIP"].Value = invoice.CustomerNIP;
                row.Cells["KlientName"].Value = invoice.CusotmerName;
                row.Cells["WartoscFaktury"].Value = invoice.InvoiceValue;
                row.Cells["DoZaplaty"].Value = invoice.AmountPaid;
                row.Cells["DataWystawienia"].Value = invoice.InvoiceDate;
                row.Cells["TerminPlatnosci"].Value = invoice.PaymentDate;
                i++;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            // context menu 
            int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            if (currentMouseOverRow >= 0)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem(string.Format("Edytuj fakturę nr {0}", dataGridView1.Rows[currentMouseOverRow].Cells["NrFaktury"].Value), new EventHandler(this.editInvoice_Click)));
                m.MenuItems.Add(new MenuItem(string.Format("Wyślij na e-mail kontrahenta")));
                m.MenuItems.Add(new MenuItem(string.Format("Usuń dokument"), new EventHandler(this.removeInvoice_Click)));
                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // nadpisujemy standardową metodę zamykania okna. Zamknięcie okna oznacza standardowo likwidację danego obiektu. 
            // My chcemy zamknąć okno, ale nie kasować go (bo użytkownik może np. ponownie je otworzyć).
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void editInvoice_Click(object sender, EventArgs e)
        {
            FormInvoiceEditor w = new FormInvoiceEditor(MainProgram.InvoiceObjectsList[dataGridView1.SelectedRows[0].Index]);
            w.ShowDialog();
        }

        private void removeInvoice_Click(object sender, EventArgs e)
        {
            string dialogText = String.Format("Próbujesz usunąć fakturę nr {0}.\n\nNie zaleca się usuwania wystawionych dokumentów.\nCzy mimo to chcesz usunąć?", MainProgram.InvoiceObjectsList[dataGridView1.SelectedRows[0].Index]);
            DialogResult result = MessageBox.Show(dialogText, "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(dataGridView1.SelectedRows[0].Index.ToString());
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }


        private void WriteInvoice(Invoice invoice)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
