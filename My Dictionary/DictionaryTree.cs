using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Dictionary
{
    [Serializable]
    class DictionaryTree:ActiveDictionary
    {      

        private DictionaryItem _root;
        
        //Sets the properties of the root DictionaryItem
        public DictionaryTree(string Value)
        {
            if (Value != null)
            {
                _root = new DictionaryItem(false);
                _root.IsRoot = true;
                _root.RootName = Value;
            }
                
        }

        public DictionaryTree() { }

        //Adds DictionaryItems to the root dictionary
        public DictionaryTree(string Value, params DictionaryItem[] dictionaryItems):this(Value)
        {
            
            foreach(DictionaryItem DicItem in dictionaryItems)
            {
                if (DicItem.IsCategory)
                {
                    _root.AddDictionaryItem(DicItem);
                }
                else { throw new Exception("Cannot add non category item directly to the root."); }
            }
        }


        public DictionaryItem Root
        {
            get { return _root; }
        }

        public static void initializeDictionary(string DictionaryName)
        {
            Dictionary = new DictionaryTree(DictionaryName);
        }


        //Searches for a category and return s all the words in the category
        public static List<DictionaryItem> SearchReturnCategory(DictionaryItem Root, string Category)
        {
            List<DictionaryItem> ListOfWords = new List<DictionaryItem>();
            if (Root != null)
            {
                foreach (DictionaryItem DicItem in Root.DictionaryItems)
                {
                    if (DicItem.IsCategory && DicItem.CategoryName == Category)
                    {
                        ListOfWords = DicItem.DictionaryItems;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else { }

            return ListOfWords;
        }

        //Searches for a word in the dictoinary and returns it if the word is found
        public static DictionaryItem SearchReturnWord(DictionaryItem Root, string Word)
        {
            bool hasFoundWord = false;
            DictionaryItem WordFound = new DictionaryItem(false);
            if (Root != null)
            {
                //The assumption is that the word does not exist until found
                if (hasFoundWord == false)
                {
                    foreach (DictionaryItem DicItem in Root.DictionaryItems)
                    {

                        if (DicItem.IsCategory)
                        {
                            foreach (DictionaryItem childDicItem in DicItem.DictionaryItems)
                            {
                                if (childDicItem.WordName == Word)
                                {
                                    WordFound = childDicItem;
                                    hasFoundWord = true;
                                    break;
                                }
                                else
                                {
                                    
                                }
                            }
                        }
                        else { }
                    }

                }
                else { }

            }

            return WordFound;
        }

        public static bool HasCategory(string Category, DictionaryItem Root)
        {
            bool _hasCategory = false;
            try
            {
                foreach (DictionaryItem DicItem in Root.DictionaryItems)
                {
                    if (DicItem.IsCategory == true && DicItem.CategoryName == Category)
                    {
                        _hasCategory = true;
                        break;
                    }
                    else { _hasCategory = false; }
                }
            }
            catch (NullReferenceException)
            {
                _hasCategory = false;
            }

            return _hasCategory;
        }

        public static bool HasWord(string Word, DictionaryItem Root)
        {
            bool _hasWord = false;
        here:
            if (!_hasWord)
            {
                try
                {
                    foreach (DictionaryItem DicItem in Root.DictionaryItems)
                    {
                        foreach (DictionaryItem DicItemChild in DicItem.DictionaryItems)
                        {
                            if (DicItemChild.WordName == Word)
                            {
                                _hasWord = true;
                                goto here;

                            }
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    _hasWord = false;
                }

            }


            return _hasWord;
        }

        public static List<DictionaryItem> SearchReturnAllWords(DictionaryItem Root,string Word)
        {
            List<DictionaryItem> WordItems = new List<DictionaryItem>();
            

            try
            {
                var WordCollection = from d in (from d2 in Root.DictionaryItems where d2.IsCategory select d2)
                                     select d
                                into words
                                     from word in words.DictionaryItems
                                     where word.WordName.Contains(Word.Split('/')[1])
                                     select word;

                foreach (DictionaryItem d in WordCollection)
                {
                    WordItems.Add(d);                  
                   
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
           

           

            return WordItems;                                    
                                             
            
        }

        

    }
}
