namespace fakturyA
{
    partial class FormArticlesEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Code_TB = new System.Windows.Forms.TextBox();
            this.PriceN_TB = new System.Windows.Forms.TextBox();
            this.Name_TB = new System.Windows.Forms.TextBox();
            this.Vat_CB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Measure_CB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FormArticleEditor_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kod";
            // 
            // Code_TB
            // 
            this.Code_TB.Location = new System.Drawing.Point(127, 24);
            this.Code_TB.Name = "Code_TB";
            this.Code_TB.Size = new System.Drawing.Size(100, 20);
            this.Code_TB.TabIndex = 1;
            // 
            // PriceN_TB
            // 
            this.PriceN_TB.Location = new System.Drawing.Point(127, 172);
            this.PriceN_TB.Name = "PriceN_TB";
            this.PriceN_TB.Size = new System.Drawing.Size(100, 20);
            this.PriceN_TB.TabIndex = 2;
            // 
            // Name_TB
            // 
            this.Name_TB.Location = new System.Drawing.Point(127, 60);
            this.Name_TB.Name = "Name_TB";
            this.Name_TB.Size = new System.Drawing.Size(100, 20);
            this.Name_TB.TabIndex = 5;
            // 
            // Vat_CB
            // 
            this.Vat_CB.FormattingEnabled = true;
            this.Vat_CB.Items.AddRange(new object[] {
            "23,00",
            "8,00",
            "5,00"});
            this.Vat_CB.Location = new System.Drawing.Point(127, 137);
            this.Vat_CB.Name = "Vat_CB";
            this.Vat_CB.Size = new System.Drawing.Size(100, 21);
            this.Vat_CB.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nazwa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Jednostka Miary";
            // 
            // Measure_CB
            // 
            this.Measure_CB.FormattingEnabled = true;
            this.Measure_CB.Items.AddRange(new object[] {
            "usluga",
            "sztuka",
            "opakowanie",
            "m2",
            "kg",
            "litr",
            "m"});
            this.Measure_CB.Location = new System.Drawing.Point(127, 97);
            this.Measure_CB.Name = "Measure_CB";
            this.Measure_CB.Size = new System.Drawing.Size(100, 21);
            this.Measure_CB.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(74, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Vat ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cena Netto";
            // 
            // FormArticleEditor_Button
            // 
            this.FormArticleEditor_Button.Location = new System.Drawing.Point(259, 205);
            this.FormArticleEditor_Button.Name = "FormArticleEditor_Button";
            this.FormArticleEditor_Button.Size = new System.Drawing.Size(75, 23);
            this.FormArticleEditor_Button.TabIndex = 12;
            this.FormArticleEditor_Button.Text = "button1";
            this.FormArticleEditor_Button.UseVisualStyleBackColor = true;
            this.FormArticleEditor_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormArticlesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 326);
            this.Controls.Add(this.FormArticleEditor_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Measure_CB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Vat_CB);
            this.Controls.Add(this.Name_TB);
            this.Controls.Add(this.PriceN_TB);
            this.Controls.Add(this.Code_TB);
            this.Controls.Add(this.label1);
            this.Name = "FormArticlesEditor";
            this.Text = "FormArticlesEditor";
           // this.Load += new System.EventHandler(this.FormArticlesEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Code_TB;
        private System.Windows.Forms.TextBox PriceN_TB;
        private System.Windows.Forms.TextBox Name_TB;
        private System.Windows.Forms.ComboBox Vat_CB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Measure_CB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button FormArticleEditor_Button;

    }
}