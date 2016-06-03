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
    public partial class FormInvoiceEditor : Form
    {
        private List<string> productCodesOnInvoice = new List<string>();
        private List<string> deletedProductCodes = new List<string>();
        private Invoice editInvoice;

        private void AddNewInvoice_Load(object sender, EventArgs e)
        {
            dateTimePickerDateInvoice.MaxDate = DateTime.Now;
        }

        public FormInvoiceEditor() // konstruktor bezargumentowy, pozwala uruchomić edytor do utworzenia nowej faktury
        {
            InitializeComponent();
            editInvoice = new Invoice();
        }


        public FormInvoiceEditor(Invoice invoice) // konstruktor pozwalający uruchomić edytor w trybie edycji już istniejącej faktury
        {
            InitializeComponent();
            editInvoice = invoice;

            // odczytaj dane z istniejącej krotki (zapisanej w liście faktur) i wypisz do edytora
            textBoxInvoiceNumber.Text = invoice.Number;
            comboBoxPayMethod.Text = invoice.PaymentMethod;
            dateTimePickerDateInvoice.Text = invoice.InvoiceDate.ToString();
            dateTimePickerDateSale.Text = invoice.SellingDate.ToString();
            dateTimePickerDatePayment.Text = invoice.PaymentDate.ToString();
            textBoxAmountPaid.Text = invoice.AmountPaid.ToString();
            labelInvoiceValue.Text = invoice.InvoiceValue.ToString() + " zł";
            GetAndLoadCustomerDetails();
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // zmieniono termin płatności
            // podstawowa operacja to odpowiednio zmienić obiekt + przeliczyć datę na kalendarzu
            dateTimePickerDatePayment.Enabled = false;
            string selectedValue_DatePayment = (sender as ComboBox).Text;

            if (selectedValue_DatePayment == "7 dni")
                dateTimePickerDatePayment.Value = (Convert.ToDateTime(dateTimePickerDateSale.Value)).AddDays(7);
            else if (selectedValue_DatePayment == "14 dni")
                dateTimePickerDatePayment.Value = (Convert.ToDateTime(dateTimePickerDateSale.Value)).AddDays(14);
            else
            {
                dateTimePickerDatePayment.Value = DateTime.Now;
                dateTimePickerDatePayment.Enabled = true;
            }
        }


        private void buttonAddArticleToInvoice_Click(object sender, EventArgs e)
        {
            /// ======== TO DO -> potrzebny obiekt artykułu! ===============
            /// ============================================================
            /// ============================================================
            FormArticles addingArticleToInvoice_Window = new FormArticles();
            string[] addedArticleData = addingArticleToInvoice_Window.ShowWindowToAddNewArticle();

            if (addedArticleData == null) // no data receive
                return;

            string productCode = addedArticleData[0];
            string productAmount = addedArticleData[1];
            string productDiscount = addedArticleData[2];

            if (!productCodesOnInvoice.Contains(productCode))
            {
                MainProgram.Connection = DatabaseMySQL.Connect(MainProgram.DatabaseName);
                try
                {
                    DatabaseMySQL.OpenConnection(MainProgram.Connection);
                    string[] productData = DatabaseMySQL.GetArticleData(productCode);
                    string productName = productData[0];
                    string productPriceNetto = productData[1];
                    string productVAT = productData[2];

                    dataGridView1.Rows.Add(productCode, productName, productPriceNetto, productVAT, "*", productDiscount, productAmount, "szt.", "=", "=");
                    productCodesOnInvoice.Add(productCode);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    DatabaseMySQL.CloseConnection(MainProgram.Connection);
                }
            }
            else
            {
                MessageBox.Show("Ten produkt występuje już na fakturze i nie można go dodać ponownie.\nWybierz element na liście, a następnie dokonaj stosownych poprawek.");
            }

        }



        private void buttonSaveInvoice_Click(object sender, EventArgs e)
        {
            // Zapis lub uaktualnienie akturalnie otwartej faktury
            if (ValidateForm() == false)
                return;


            string query; 
            if (editInvoice.Number == null)
            {
                // zapis nowej faktury 
                editInvoice.Number = DatabaseMySQL.CreateNumberForNewInvoice();
                textBoxInvoiceNumber.Text = editInvoice.Number; // wypisz wygenerowany dla faktury numer 
                query = editInvoice.GenerateInsertQuery();
            }
            else
            {
                query = editInvoice.GenerateUpdateQuery(); // przygotowuje zapytanie UPDATE do bazy danych
            }


            int? returnValue = null;
            returnValue = DatabaseMySQL.ExecuteQuery(query);
           

            if (returnValue > 0)
                MessageBox.Show("Operacja wykonana pomyślnie (" + returnValue + ")");
            else
                MessageBox.Show("Wystąpił błąd.");

        }


        private void buttonChooseCustomer_Click(object sender, EventArgs e)
        {
            FormCustomers SelectCustomerID = new FormCustomers();
            editInvoice.CustomerID = SelectCustomerID.ChooseConsumerWindow();

            GetAndLoadCustomerDetails();
        }


        private void buttonRemoveArticleFromInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć?", "Potwierdź wybór", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                productCodesOnInvoice.Remove(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                deletedProductCodes.Add(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Nie zaznaczono nic do usunięcia.");
            }
        }


        private void GetAndLoadCustomerDetails()
        {
            if (editInvoice.CustomerID > 0)
            {

                labelCustomerName.Text = editInvoice.CustomerID.ToString();
                string[] consumerData = DatabaseMySQL.GetCustomerData(editInvoice.CustomerID);
                labelCustomerName.Text = consumerData[0];
                labelCustomerAdress.Text = consumerData[1];
                labelCustomerNIP.Text = consumerData[2];
            }
        }


        private void dateTimePickerDatePayment_ValueChanged(object sender, EventArgs e)
        {
            // to do 
            DateTime sellDate = Convert.ToDateTime(dateTimePickerDateSale.Value);
            DateTime paymentDate = Convert.ToDateTime(dateTimePickerDatePayment.Value);

            if (sellDate.AddDays(14) == paymentDate)
            {
                comboBoxSelectPaymentDate.SelectedIndex = 2;
            }
            else if (sellDate.AddDays(7) == paymentDate)
            {
                comboBoxSelectPaymentDate.SelectedIndex = 1;
            }
            else
            {
                comboBoxSelectPaymentDate.SelectedIndex = 3;
            }

            editInvoice.PaymentDate = dateTimePickerDatePayment.Value;

        }

        private void dateTimePickerDateInvoice_ValueChanged(object sender, EventArgs e)
        {
            editInvoice.InvoiceDate = dateTimePickerDateInvoice.Value;
        }

        private void dateTimePickerDateSale_ValueChanged(object sender, EventArgs e)
        {
            editInvoice.SellingDate = dateTimePickerDateSale.Value;
        }

        private void comboBoxPayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            editInvoice.PaymentMethod = comboBoxPayMethod.Text;
        }

        private void textBoxAmountPaid_TextChanged(object sender, EventArgs e)
        {
            //editInvoice.AmountPaid = textBoxAmountPaid.Text;    inaccessible
        }


        private bool ValidateForm()
        {
            if (editInvoice.CustomerID == -1)
            {
                errorProvider1.SetError(groupBox1, "Należy wybrać kontrahenta.");
                return false;
            }
            else
            {
                errorProvider1.SetError(groupBox1, "");
            }

            if (dataGridView1.Rows.Count == 0)
            {
                errorProvider1.SetError(dataGridView1, "Należy wybrać minimum 1 artykuł na fakturze.");
                return false;
            }
            else
            {
                errorProvider1.SetError(dataGridView1, "");
            }

            return true;
        }
    }
}
