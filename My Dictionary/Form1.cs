using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace My_Dictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
           
            
        }

        #region Public controls
        public static Label StatusLabel;
        public static TextBox TextBoxSearch;
        #endregion

        #region Flags
        public static bool TypingInTextBox = false;
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            Clipboard.Clear();
            StatusLabel = this.label_Status;
            TextBoxSearch = textBox_Search;


            ModifiedRichTextBox.ModifiedRTB = modifiedRichTextBox1;       
            ModifiedRichTextBox MRTB = new ModifiedRichTextBox();
            modifiedRichTextBox1.Text = MRTB.DefaultText;

            FileIO.DeserializeDictionary();

            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModifiedRichTextBox MRTB = modifiedRichTextBox1;
            MRTB.Reset();
            modifiedRichTextBox1.Focus();
            textBox_Search.Focus();

            FileIO.SerializeDictionary();

        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            TypingInTextBox = true;
            System.Windows.Forms.TextBox textboxSearch = sender as System.Windows.Forms.TextBox;
            ModifiedRichTextBox ModifiedRTB = new ModifiedRichTextBox();

            try
            {
                try
                {
                    DictionaryItem DicObject = (DictionaryItem)ModifiedRTB.Search(textboxSearch.Text, ActiveDictionary.Dictionary.Root);
                    ModifiedRTB.PrintToScreen(DicObject, this.modifiedRichTextBox1);
                    
                }
                catch (NullReferenceException)
                {
                    ActiveDictionary.InitializeActiveSearchList(ActiveDictionary.Dictionary.Root, textBox_Search.Text);
                    //ModifiedRTB.PrintToScreen(ActiveDictionary.ActiveSearchList[0], this.modifiedRichTextBox1);
                }
                    
            }
            catch(InvalidCastException)
            {
                List<DictionaryItem> DicObject = (List<DictionaryItem>)ModifiedRTB.Search(textboxSearch.Text, ActiveDictionary.Dictionary.Root);
            }

            SearchStatus(this.label_Search, this.textBox_Search);
            TypingInTextBox = false;
            ActiveDictionary.ResetIndex();
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            ActiveDictionary.Incre();
            ModifiedRichTextBox ModRTB = new ModifiedRichTextBox();
            try
            {
                ModRTB.PrintToScreen(ActiveDictionary.ActiveSearchList[ActiveDictionary.listIndex], this.modifiedRichTextBox1);
            }
            catch (ArgumentOutOfRangeException) { }
            
            
        }

        private void button_decre_Click(object sender, EventArgs e)
        {
            ActiveDictionary.Decre();
            ModifiedRichTextBox ModRTB = new ModifiedRichTextBox();

            try
            {
                //index is -1 by default
                ModRTB.PrintToScreen(ActiveDictionary.ActiveSearchList[ActiveDictionary.listIndex], this.modifiedRichTextBox1);
            }
            catch (ArgumentOutOfRangeException) { }
            
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            
        }

        private void timer_Clipboard_Tick(object sender, EventArgs e)
        {
            if (DictionaryClipboard.HasContent())
            {
                DictionaryClipboard.SetClipboadText();
            }
            else
            {

            }
        }                

        private void Form1_Deactivate_1(object sender, EventArgs e)
        {
            timer_Clipboard.Start();
        }


        public void SearchStatus(Label label1,TextBox textbox1)
        {           

            if(DictionaryClipboard.HasContent() == true && !TypingInTextBox)
            {//if the ClipBoard has text, clear text box display the words found from the clipBoard
                textbox1.Text = "";
                label1.Text = "Searching... " + ActiveDictionary.ActiveSearchList.Count() + " Words found";
                
            }
            else if(TypingInTextBox)
            {
                if (textbox1.Text == "")
                {
                    label_Status.Text = "";
                }
                else
                {
                    label_Status.Text = "Searching... " + ActiveDictionary.ActiveSearchList.Count() + " Words found";
                }
            }
            
        }
      
    }
}
