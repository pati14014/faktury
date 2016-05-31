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
        private string[] SelectedArticleData;

        public FormArticles()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            MainProgram.ArticlesWindow = null; // powiadom program, że zamknęło się okno . 
        }


        public string[] ShowWindowToAddNewArticle()
        {
            this.ShowDialog();

            return SelectedArticleData; // zwróc prawdę, jeśli użytkownik dodał z powodzeniem rekord do tabeli. 
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            SelectedArticleData = new string[3] { textBox1.Text, textBox2.Text, textBox3.Text };

            this.Close(); 
        }

    }
}
