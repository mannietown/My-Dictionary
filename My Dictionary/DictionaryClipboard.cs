using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace My_Dictionary
{
    class DictionaryClipboard
    {
        static string _clipboardText = "";
        static string[] _clipboardWords;
        static string _wordSearch = "";
        
        public static bool _wordFromClip = false;

        public DictionaryClipboard()
        {
           
        }

        //Checks if the clipboard has copied text
        public static bool HasContent()
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
                return true;
            return false;
        }
        //Sets the local variable _clipboardText
        public static void SetClipboadText()
        {
            if (HasContent())
            {
                if(_clipboardText == "")
                {
                    _clipboardText = Clipboard.GetText(TextDataFormat.Text);
                    SetClipboardWords();

                    //Searches dictionary for all highlighted words
                    Form1 form1 = new Form1();
                    foreach(string s in _clipboardWords)
                    {
                        if (DictionaryTree.HasWord(s, ActiveDictionary.Dictionary.Root))
                        {
                            ActiveDictionary.ActiveSearchList.Add(DictionaryTree.SearchReturnWord(ActiveDictionary.Dictionary.Root, s));
                        }
                        else { continue; }                        
                        
                    }

                    form1.SearchStatus(Form1.StatusLabel, Form1.TextBoxSearch);
                    ClearClipBoard();
                }
                else
                {
                    if(_wordSearch == "")
                    {
                        _wordSearch = Clipboard.GetText(TextDataFormat.Text);
                        DictionaryEntry DEntryForm = new DictionaryEntry();
                        DEntryForm.Show();                       
                    }
                }
            }
            else
            {

            }
        }
        public static void SetClipboardWords()
        {
            _clipboardWords = new string[_clipboardText.Split(' ', ',', '.', '/', '\\',':').Length];
            _clipboardWords = _clipboardText.Split(' ', ',', '.', '/', '\\');
            
        }

        //Searches the dictionary to find the highlighted word
        public DictionaryItem SearchWordObject()
        {
            try
            {
                //If the word is found, the flag that it came from the clipboard is true;
                _wordFromClip = true;
                return DictionaryTree.SearchReturnWord(ActiveDictionary.Dictionary.Root, _wordSearch);
            }
            catch (NullReferenceException)
            {
                return null;
            }
                 
        }

        public static string GetWordSearch()
        {
            return _wordSearch;
        }

        public static void ClearClipBoard()
        {
            Clipboard.Clear();
        }

        public static void ClearWordSearch()
        {
            _wordSearch = "";
        }

        public static void ClearClipText()
        {
            _clipboardText = "";
        }

    }
}
