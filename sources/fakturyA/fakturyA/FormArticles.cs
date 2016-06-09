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
    public partial class FormArticles : Form
    {

        private int indeks=1;
        private bool czy_zamknac=false;
        // private bool editMode = true; // ustaw true kiedy zezwalasz na edytowanie artykułów
        public static List<Article> articlesList { get; set; } // weź to popraw STATYCZNE bo zabiję.

        public FormArticles()
        {
            InitializeComponent();
            //comboBox_max.SelectedIndex = 4;   
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
        private void GetAllrticles()
        {
            dataGridView1.Rows.Clear();
            DatabaseMySQL.LoadArticleList();
            if (articlesList.Count > 0)
            {
                int i = 0;
                foreach (Article a in articlesList)
                {
                    dataGridView1.Rows.Add();
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i];
                    row.Cells["Kod"].Value = a.Code;
                    row.Cells["Nazwa"].Value = a.Name;
                    row.Cells["JednostkaM"].Value = a.UnitMeasure;
                    row.Cells["CenaN"].Value = a.PriceNetto;
                    row.Cells["CenaB"].Value = a.PriceBrutto;
                    row.Cells["Vat"].Value = a.VATvalue;
                    i++;
                }
            }
        }
        private void FindInArticles(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var resultsArticles = from Article a in articlesList
                                  where (a.Code.Contains(Code_tb.Text)
                                  && a.Name.Contains(Name_tb.Text))

                                  select a;
            int i = 0;
            foreach (Article a in resultsArticles)
            {
                if (comboBox_max.Text != "Wszystko" && Convert.ToInt32(comboBox_max.Text) <= i)
                    break;
                i = dataGridView1.Rows.Add();

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i];
                row.Cells["Kod"].Value = a.Code;
                row.Cells["Nazwa"].Value = a.Name;
                row.Cells["JednostkaM"].Value = a.UnitMeasure;
                row.Cells["CenaN"].Value = a.PriceNetto;
                row.Cells["CenaB"].Value = a.PriceBrutto;
                row.Cells["Vat"].Value = a.VATvalue;

                i++;

            }
        }

        private void FormArticles_Load(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount==0)
            GetAllrticles();

            AddArticle.Hide();
        }
        private void editArticle_click(object sender, EventArgs e)
        {
            AddEditArticle wind =new  AddEditArticle();
            wind.Show();
        }
        private void RemoveArticle_click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseOnRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            if (mouseOnRow >= 0)
            {
                ContextMenu a = new ContextMenu();
                a.MenuItems.Add(new MenuItem(string.Format("Edytuj", dataGridView1.Rows[mouseOnRow].Cells["Kod"].Value), new EventHandler(this.editArticle_click)));
                a.MenuItems.Add(new MenuItem(string.Format("Usuń"), new EventHandler(this.RemoveArticle_click)));
                a.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }
       
        public void ShowWindowToAddNewArticle()
        {
            FormArticles a = new FormArticles();
            a.Show();
            a.AddArticle.Show();
            if(czy_zamknac)
            {
                a.Close();
            }
           // MessageBox.Show(articlesList[indeks].Name);
            MainProgram.AddedArticle = articlesList[indeks];
          //  return articlesList[indeks];
        }
       
        private void AddArticle_Click(object sender, EventArgs e)
        {
                   
                   

                   int selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
                   if (selectedCellCount > 0)
                   {

                       for (int i = 0; i < selectedCellCount; i++)
                       {
                           indeks = dataGridView1.SelectedCells[i].RowIndex;
                       }
                       DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[indeks];
                       int s = 0;
                       foreach (Article a in articlesList)
                       {
                           s++;
                           if (row.Cells["Kod"].Value == a.Code)
                           {
                               indeks = s -1;
                               break;
                           }
                       }
                    }
                   MessageBox.Show(Convert.ToString(indeks));
            AddArticleToInvoice addingArticle = new AddArticleToInvoice(indeks);
           
                   addingArticle.Show();


                   czy_zamknac = true;
        }
    }
}
