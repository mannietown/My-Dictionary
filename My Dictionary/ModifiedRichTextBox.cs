using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



namespace My_Dictionary
{
    class ModifiedRichTextBox:RichTextBox
    {       

        public static ModifiedRichTextBox ModifiedRTB;
        private static int _cursorIndex = 0;//This stores the index of the current line

        private string _defaultText = "Category..." +
                Environment.NewLine + "Word..." +
                Environment.NewLine + "Definition...";

        private static bool _reset = false;
        public string DefaultText
        {
            get { return _defaultText; }
        }
       
   

        protected override void OnGotFocus(EventArgs e)
        {
            if(this.Text == DefaultText)
            {
                this.Text = string.Empty;
                return;
            }
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if(this.Text == string.Empty)
            {
                _reset = false;
                this.SelectionBullet = false;
                this.Text = DefaultText;
                return;
            }
            base.OnLostFocus(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!_reset)
            {
                if (CompareTextToDefaultText(this.Text))
                {
                    this.Text = "";
                    Presets(_cursorIndex, this);                    

                }
            }
            else { }
           
        }

    
        protected override void OnKeyUp(KeyEventArgs e)
        {            
            if (e.KeyData == Keys.Enter)
            {
                if (this.Text != string.Empty)
                {                    
                    Presets(_cursorIndex,this);
                }
                else
                {                    
                    e.Handled = true;
                }

            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                {                
                    if (this.Text != string.Empty)
                    {
                   
                    _cursorIndex += 1;
                        //When the definition has been entered
                        if (_cursorIndex == 3)
                        {
                            if (ActiveDictionary.Dictionary != null)
                            {
                                DictionaryItem Word = new DictionaryItem(false, true, this.Lines[0],
                                    new DictionaryItem(false)
                                    {
                                        CategoryName = Lines[0],
                                        WordName = Lines[2],
                                        WordDefinition = Lines[3]
                                    });
                            ActiveDictionary.Dictionary.Root.AddDictionaryItem(Word);
                        }
                            else
                            {
                                ActiveDictionary.Dictionary = new DictionaryTree("MyDictonary1");
                                DictionaryItem Word = new DictionaryItem(false, true, this.Lines[0],
                                    new DictionaryItem(false)
                                    {
                                        CategoryName = Lines[0],
                                        WordName = Lines[2],
                                        WordDefinition = Lines[3]
                                    });

                                ActiveDictionary.Dictionary.Root.AddDictionaryItem(Word);
                             }
                           

                        }


                    }

                }
              
                else
            {
                if(e.Modifiers == Keys.Control)
                {
                    Keys keydata = e.KeyData & e.KeyCode;
                    switch (keydata)
                    {
                        case Keys.M:
                        
                            bool goToBreak = false;

                            foreach (DictionaryItem category in ActiveDictionary.Dictionary.Root.DictionaryItems)
                            {
                                if (goToBreak == false)
                                {
                                    foreach (DictionaryItem word in category.DictionaryItems)
                                    {
                                        if (word.IsShowing)
                                        {
                                            word.CategoryName = Lines[0];
                                            word.WordName = Lines[2];
                                            word.WordDefinition = Lines[3];
                                            goToBreak = true;
                                            
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }                    
                                                      
                            break;
                    }
                }
            }          
        

            base.OnKeyDown(e);
        }

        //Compares the Text to the default text to see if the are equal
        private bool CompareTextToDefaultText(string Text)
        {
            string[] splitText = Text.Split('\n');
            string[] splitDefaultText = (from t in (DefaultText.Split('\r'))
                                                    select t).ToArray();
                                                   

            for(int i = 0; i < 3; i++)
            {
                if (splitDefaultText[i].Contains('\n'))
                {
                    splitDefaultText[i] = splitDefaultText[i].Split('\n')[1];
                }
            }

            if (splitText.SequenceEqual(splitDefaultText))
            {
                return true;
            }
            return false;
        }

        //Sets the fontstyle for the specific line
        public void Presets(int index,ModifiedRichTextBox modifiedRichTextBox)
        {
            switch (index)
            {
                case 0:
                    modifiedRichTextBox.SelectionStart = 0;
                    modifiedRichTextBox.SelectionFont = new Font(modifiedRichTextBox.SelectionFont, FontStyle.Underline);
             
                                    
                    break;                    
                case 1:
                    this.Text += Environment.NewLine;
                    modifiedRichTextBox.SelectionStart = modifiedRichTextBox.Text.Length;                    
                    modifiedRichTextBox.SelectionFont = new Font(modifiedRichTextBox.SelectionFont, FontStyle.Bold);
                    

                    break;
                case 2:                    
                    //this.Text += Environment.NewLine;
                    modifiedRichTextBox.SelectionStart = modifiedRichTextBox.Text.Length;
                    modifiedRichTextBox.SelectionFont = new Font(modifiedRichTextBox.SelectionFont, FontStyle.Italic);


                    break;
            }
        }       

        public string[] GetLines()
        {
            return this.Lines;
        }

        //Sets the rich textbox text and formatting to its default 
        public void Reset()
        {
            _reset = true;
            this.Text = "";
            this.SelectionBullet = false;            
            _cursorIndex = 0;
                        
        }

        //Prints the DictionaryItem and its properties
        public void PrintToScreen(DictionaryItem DicItem,ModifiedRichTextBox ModifiedRTB)
        {
            int _boldSelectionStart = 0;
            int _italicSelectionStart = 0;

            if(DicItem.WordName != null)
            {
                ModifiedRTB.Text = "";
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        //Category index
                        case 0:
                            ModifiedRTB.Text = DicItem.CategoryName;
                            ModifiedRTB.SelectionStart = 0;
                            ModifiedRTB.SelectionLength = DicItem.CategoryName.Length;
                            ModifiedRTB.SelectionFont = new Font(ModifiedRTB.SelectionFont, FontStyle.Underline);
                            
                            _boldSelectionStart = ModifiedRTB.Text.Length;
                            ModifiedRTB.Text += Environment.NewLine;


                            break;
                        //Word index
                        case 1:
                            ModifiedRTB.Text+= Environment.NewLine + DicItem.WordName;
                            ModifiedRTB.SelectionStart = _boldSelectionStart;
                            ModifiedRTB.SelectionLength = DicItem.WordName.Length+2;
                            ModifiedRTB.SelectionFont = new Font(ModifiedRTB.SelectionFont, FontStyle.Bold);
                            _italicSelectionStart = ModifiedRTB.Text.Length;
                            ModifiedRTB.Text += Environment.NewLine;
                            break;
                            //Definition index                            
                        case 2:
                            ModifiedRTB.Text += DicItem.WordDefinition;
                            ModifiedRTB.SelectionStart = _italicSelectionStart;
                            ModifiedRTB.SelectionLength = DicItem.WordDefinition.Length + 2;
                            ModifiedRTB.SelectionFont = new Font(ModifiedRTB.SelectionFont, FontStyle.Italic);

                            //Bolds the 2nd line again
                            ModifiedRTB.SelectionStart = _boldSelectionStart;
                            ModifiedRTB.SelectionLength = DicItem.WordName.Length+2;
                            ModifiedRTB.SelectionFont = new Font(ModifiedRTB.SelectionFont, FontStyle.Bold);

                            break;
                    }
                }
            }
            else
            {

            }
            
        }

        //Calls the search methods from the DictionaryTree class
        //The marked string is a combinaton of the string to search plus a tag which refers to a category or word search
        public object Search(string MarkedSearchString, DictionaryItem DicItem)
        {
            List<DictionaryItem> CategoryItem = new List<DictionaryItem>();
            DictionaryItem WordItem = new DictionaryItem();

            try
            {
                string StringToSearch = MarkedSearchString.Split('/')[1];
                string SearchCriteria = MarkedSearchString.Split('/')[0];

                if (SearchCriteria == "(C)")
                {
                    DictionaryItem dictionaryItem = new DictionaryItem();

                    return CategoryItem;
                }
                else if (SearchCriteria == "(W)")
                {
                   
                    
                    if(StringToSearch == DictionaryTree.SearchReturnWord(DicItem, StringToSearch).WordName)
                    {
                        WordItem = DictionaryTree.SearchReturnWord(DicItem, StringToSearch);
                    }
                    else
                    {
                        WordItem = null;
                    }
                    return WordItem;
                }
                else { return null; }

            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
                      
           
        }



    }
}
