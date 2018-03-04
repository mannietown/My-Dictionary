using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace My_Dictionary
{
    [Serializable]
    class DictionaryItem
    {
        bool _isCategory;
        bool _isRoot;
        bool _isShowing;
            
        string _wordName;
        string _wordDefinition;
        string _categoryName;
        string _rootName;

        List<DictionaryItem> _dictionaryItems = new List<DictionaryItem>();

        public FontStyle DefaultWordFontStyle
        {
            get { return FontStyle.Bold; }
        } 

        public FontStyle DefaultDefinitionFontStyle
        {
            get { return FontStyle.Italic; }
        }

        
        public FontStyle DefaultCategoryFontStyle
        {
            get { return FontStyle.Underline; }
        }
        public DictionaryItem(bool isCategory)
        {
            _isCategory = isCategory;
            if(_isCategory == false)
            {
                
            }
            else
            {
                _dictionaryItems = new List<DictionaryItem>();
            }
              

            
        }

        public DictionaryItem()
        {

        }
        
        //Adds dictonary items designating them as the root, category or just a word
        public DictionaryItem(bool isRoot,bool isCategory,string categoryName = "",params DictionaryItem [] dictionaryItems)
        {
            
            this._isRoot = isRoot;
            this._isCategory = isCategory;
            

            if (isCategory == true && categoryName != string.Empty)
            {
                this.RootName = ActiveDictionary.Dictionary.Root.RootName;
                _dictionaryItems = new List<DictionaryItem>();

                if (DictionaryTree.HasCategory(categoryName, ActiveDictionary.Dictionary.Root) == false)
                {
                    _categoryName = categoryName;
                    _wordName = null;
                    _wordDefinition = null;

                    foreach (DictionaryItem DicItem in dictionaryItems)
                    {
                        if (DicItem.IsCategory == false && DicItem.IsRoot == false)
                        {
                            if (!DictionaryTree.HasWord(DicItem.WordName, ActiveDictionary.Dictionary.Root))
                            {                                
                                _dictionaryItems.Add(DicItem);
                            }
                            else { continue; }

                        }

                    }
                }
                else
                {
                    //If the category already exists just add the word
                    foreach(DictionaryItem DicItem in ActiveDictionary.Dictionary.Root.DictionaryItems)
                    {
                        if (!DictionaryTree.HasWord(DicItem.WordName, ActiveDictionary.Dictionary.Root))
                        {
                            if (DicItem.CategoryName == categoryName)
                            {                                
                                DicItem.AddDictionaryItem(dictionaryItems[0]);
                                break;

                            }
                        }
                        else { continue; }
                        
                    }
                    return;
                }

            }else 
                if(isCategory == false && isRoot == false && categoryName!= "")
            {
                foreach (DictionaryItem DicItem in ActiveDictionary.Dictionary.Root.DictionaryItems)
                {
                    if (!DictionaryTree.HasWord(DicItem.WordName, ActiveDictionary.Dictionary.Root))
                    {
                        if (DicItem.CategoryName == categoryName)
                        {
                            DicItem.AddDictionaryItem(dictionaryItems[0]);
                            break;

                        }
                    }
                    else { continue; }

                }
            }



        }

        public bool IsShowing
        {
            get { return _isShowing; }
            set
            {
                _isShowing = value;
            }
        }
        public bool IsRoot
        {
            get { return _isRoot; }
            set { _isRoot = value; }
        }
        public string RootName
        {
            get { return _rootName; }
            set
            {
                _rootName = value;
            }
        }
        public string WordName
        {
            get { return _wordName; }
            set
            {
                if (value != null)
                    _wordName = value;
            }
        }

        public string WordDefinition
        {
            get { return _wordDefinition; }
            set
            {
                if (value != null)
                    _wordDefinition = value;
            }
        }

        public bool IsCategory
        {
            get { return _isCategory; }
            set
            {
                _isCategory = value;
            }
        }     
        
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {                
               this._categoryName = value;
            }
        }
        
        public int Count
        {
            get { return _dictionaryItems.Count; }
        }
                  
        public List<DictionaryItem> DictionaryItems
        {
            get { return _dictionaryItems; }
        }

        public void AddDictionaryItem(DictionaryItem DicItem)
        {
            //only categories can be added to the root
            if (DicItem != null && DicItem.IsCategory == true && this.IsRoot == true)
            {
                this._dictionaryItems.Add(DicItem);
            }//Only words can be added to categories
            else if(DicItem!= null && DicItem.IsCategory == false && this._isCategory == true)
            {
                this.DictionaryItems.Add(DicItem);
            }
                
        }

        

   
    }
}
