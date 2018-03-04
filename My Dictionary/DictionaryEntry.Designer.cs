namespace My_Dictionary
{
    partial class DictionaryEntry
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
            this.label_Definition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Definition = new System.Windows.Forms.TextBox();
            this.comboBox_Category = new System.Windows.Forms.ComboBox();
            this.button_AddWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Definition
            // 
            this.label_Definition.AutoSize = true;
            this.label_Definition.Location = new System.Drawing.Point(12, 39);
            this.label_Definition.Name = "label_Definition";
            this.label_Definition.Size = new System.Drawing.Size(51, 13);
            this.label_Definition.TabIndex = 9;
            this.label_Definition.Text = "Definition";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Category";
            // 
            // textBox_Definition
            // 
            this.textBox_Definition.Location = new System.Drawing.Point(71, 39);
            this.textBox_Definition.Multiline = true;
            this.textBox_Definition.Name = "textBox_Definition";
            this.textBox_Definition.Size = new System.Drawing.Size(248, 70);
            this.textBox_Definition.TabIndex = 7;
            // 
            // comboBox_Category
            // 
            this.comboBox_Category.FormattingEnabled = true;
            this.comboBox_Category.Location = new System.Drawing.Point(71, 12);
            this.comboBox_Category.Name = "comboBox_Category";
            this.comboBox_Category.Size = new System.Drawing.Size(248, 21);
            this.comboBox_Category.TabIndex = 6;
            // 
            // button_AddWord
            // 
            this.button_AddWord.Location = new System.Drawing.Point(244, 115);
            this.button_AddWord.Name = "button_AddWord";
            this.button_AddWord.Size = new System.Drawing.Size(75, 23);
            this.button_AddWord.TabIndex = 5;
            this.button_AddWord.Text = "Enter";
            this.button_AddWord.UseVisualStyleBackColor = true;
            this.button_AddWord.Click += new System.EventHandler(this.button_AddWord_Click_1);
            // 
            // DictionaryEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 149);
            this.Controls.Add(this.label_Definition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Definition);
            this.Controls.Add(this.comboBox_Category);
            this.Controls.Add(this.button_AddWord);
            this.Name = "DictionaryEntry";
            this.Text = "DictionaryEntry";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DictionaryEntry_FormClosed);
            this.Load += new System.EventHandler(this.DictionaryEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Definition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Definition;
        private System.Windows.Forms.ComboBox comboBox_Category;
        private System.Windows.Forms.Button button_AddWord;
    }
}