namespace My_Dictionary
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.button_AddNew = new System.Windows.Forms.Button();
            this.label_Search = new System.Windows.Forms.Label();
            this.button_decre = new System.Windows.Forms.Button();
            this.button_Incre = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.timer_Clipboard = new System.Windows.Forms.Timer(this.components);
            this.modifiedRichTextBox1 = new My_Dictionary.ModifiedRichTextBox();
            this.SuspendLayout();
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(164, 8);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(135, 20);
            this.textBox_Search.TabIndex = 1;
            this.textBox_Search.TextChanged += new System.EventHandler(this.textBox_Search_TextChanged);
            // 
            // button_AddNew
            // 
            this.button_AddNew.Location = new System.Drawing.Point(199, 208);
            this.button_AddNew.Name = "button_AddNew";
            this.button_AddNew.Size = new System.Drawing.Size(100, 23);
            this.button_AddNew.TabIndex = 3;
            this.button_AddNew.Text = "Add new Word";
            this.button_AddNew.UseVisualStyleBackColor = true;
            this.button_AddNew.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_Search
            // 
            this.label_Search.AutoSize = true;
            this.label_Search.Location = new System.Drawing.Point(117, 15);
            this.label_Search.Name = "label_Search";
            this.label_Search.Size = new System.Drawing.Size(41, 13);
            this.label_Search.TabIndex = 4;
            this.label_Search.Text = "Search";
            // 
            // button_decre
            // 
            this.button_decre.Location = new System.Drawing.Point(4, 34);
            this.button_decre.Name = "button_decre";
            this.button_decre.Size = new System.Drawing.Size(29, 23);
            this.button_decre.TabIndex = 5;
            this.button_decre.Text = "<--";
            this.button_decre.UseVisualStyleBackColor = true;
            this.button_decre.Click += new System.EventHandler(this.button_decre_Click);
            // 
            // button_Incre
            // 
            this.button_Incre.Location = new System.Drawing.Point(305, 34);
            this.button_Incre.Name = "button_Incre";
            this.button_Incre.Size = new System.Drawing.Size(29, 23);
            this.button_Incre.TabIndex = 6;
            this.button_Incre.Text = "-->";
            this.button_Incre.UseVisualStyleBackColor = true;
            this.button_Incre.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(39, 208);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(0, 13);
            this.label_Status.TabIndex = 7;
            // 
            // timer_Clipboard
            // 
            this.timer_Clipboard.Tick += new System.EventHandler(this.timer_Clipboard_Tick);
            // 
            // modifiedRichTextBox1
            // 
            this.modifiedRichTextBox1.Location = new System.Drawing.Point(39, 34);
            this.modifiedRichTextBox1.Name = "modifiedRichTextBox1";
            this.modifiedRichTextBox1.Size = new System.Drawing.Size(260, 168);
            this.modifiedRichTextBox1.TabIndex = 2;
            this.modifiedRichTextBox1.Text = "";
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 240);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.button_Incre);
            this.Controls.Add(this.button_decre);
            this.Controls.Add(this.label_Search);
            this.Controls.Add(this.button_AddNew);
            this.Controls.Add(this.modifiedRichTextBox1);
            this.Controls.Add(this.textBox_Search);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Search;
        private ModifiedRichTextBox modifiedRichTextBox1;
        private System.Windows.Forms.Button button_AddNew;
        private System.Windows.Forms.Label label_Search;
        private System.Windows.Forms.Button button_decre;
        private System.Windows.Forms.Button button_Incre;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Timer timer_Clipboard;
    }
}

