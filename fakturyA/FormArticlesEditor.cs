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
    public partial class FormArticlesEditor : Form
    {
        private Article editArticle;
        private int i;
        public FormArticlesEditor()
        {
          
            InitializeComponent();
            
            FormArticleEditor_Button.Text = "Dodaj";
            editArticle = new Article();
        }
        public FormArticlesEditor(Article article)
        {
           
            InitializeComponent();
            
            FormArticleEditor_Button.Text="Zmień";
            editArticle = article;
            Code_TB.Text = article.Code;
            Code_TB.Enabled= false;
            PriceN_TB.Text = Convert.ToString(article.PriceNetto);
            Measure_CB.Text = article.UnitMeasure;
            Vat_CB.Text = Convert.ToString(article.VATvalue);
            Name_TB.Text = article.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(FormArticleEditor_Button.Text=="Dodaj")
            {
                editArticle.Code = Code_TB.Text;
                editArticle.Name = Name_TB.Text;
                editArticle.PriceNetto = Convert.ToDecimal(PriceN_TB.Text);
                editArticle.UnitMeasure = Measure_CB.Text;
                editArticle.VATvalue = Convert.ToDecimal(Vat_CB.Text);
                editArticle.Name = Name_TB.Text;
                editArticle.PriceBrutto = editArticle.PriceNetto +editArticle.VATvalue/100;
                FormArticles.articlesList.Add(editArticle);
                editArticle.GenerateQueryInsertArticles();
                MessageBox.Show(editArticle.Code + editArticle.Name);
                DatabaseMySQL.ExecuteQuery(editArticle.GenerateQueryInsertArticles());
                MainProgram.ArticlesWindow.AddRowsToDataGridView(editArticle);
                Close();
                
            }
            else
            {
               
                editArticle.Name = Name_TB.Text;
                editArticle.PriceNetto = Convert.ToDecimal(PriceN_TB.Text);
                editArticle.UnitMeasure = Measure_CB.Text;
                editArticle.VATvalue = Convert.ToDecimal(Vat_CB.Text);
                editArticle.Name = Name_TB.Text;
                editArticle.PriceBrutto = editArticle.PriceNetto + editArticle.VATvalue / 100;
                editArticle.GenerateQueryUpdateArticles();
                MessageBox.Show(editArticle.Code + editArticle.Name);
                DatabaseMySQL.ExecuteQuery(editArticle.GenerateQueryUpdateArticles());
                MainProgram.ArticlesWindow.ReplaceEditRowArticleInDataGrid(editArticle);
                //szukanie w articlelist po indexie
                // datagrid.view.rows[inex]
                Close();
                
            }
        }

        
        
    }
}
