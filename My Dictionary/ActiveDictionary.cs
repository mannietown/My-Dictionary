using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;


namespace My_Dictionary
{
   [Serializable]
    class ActiveDictionary
    {
        
        internal static DictionaryTree Dictionary = new DictionaryTree();

        internal static List<DictionaryItem> ActiveSearchList = new List<DictionaryItem>(); 

        public static int listIndex = -1;

        public static void InitializeActiveSearchList(DictionaryItem DicItem,string Word)
        {           
            ActiveSearchList = DictionaryTree.SearchReturnAllWords(DicItem, Word);
        }

        //increments the list index by 1
        public static void Incre()
        {
            try
            {                
                if (listIndex == ActiveSearchList.Count() - 1)
                {
                    SystemSounds.Asterisk.Play();                    

                }
                else
                {
                    listIndex++;
                    SetIsShowing(listIndex);
                }
            }
            catch (NullReferenceException)
            {
                //Set isShowing of the last element in the list
                SetIsShowing(ActiveSearchList.Count() - 1);
            }
           
           
        }
        //decrements the list index by 1
        public static void Decre()
        {
            try
            {
                if (listIndex == 0)
                {
                    SystemSounds.Asterisk.Play();
                   
                }
                else
                {
                    listIndex--;
                    SetIsShowing(listIndex);
                }
            }
            catch (NullReferenceException)
            {
                //Set isShoowing to the first element in the list
                SetIsShowing(0);

            }
            
           
        }

        //Sets the listIndex back to it's default value
        public static void ResetIndex()
        {
            listIndex = -1;
        }
        
        //Sets the IsShowing property of the DictionaryItem to true if the object is being viewed
        public static void SetIsShowing(int index)
        {
            foreach(DictionaryItem category in Dictionary.Root.DictionaryItems)
            {
                foreach(DictionaryItem word in category.DictionaryItems)
                {
                    if(word.WordName == ActiveSearchList[index].WordName)
                    {
                        word.IsShowing = true;
                    }
                    else
                    {
                        word.IsShowing = false;
                    }
                }
            }
        }
              
    }

    class FileIO
    {
        static readonly string _fileName = "Dictionary1.txt";
        static readonly string _folderName = "My Dictionary"; 
        static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static readonly string filePath = Path.Combine(BaseDirectory, _folderName, _fileName);
        static readonly string folderPath = Path.Combine(BaseDirectory, _folderName);

        public static void SerializeDictionary()
        {
            if (Directory.Exists(folderPath))
            {
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(Path.Combine(BaseDirectory, _folderName, _fileName), FileMode.Open, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, ActiveDictionary.Dictionary);

                    }
                }
                else
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, ActiveDictionary.Dictionary);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(folderPath);
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(Path.Combine(BaseDirectory, _folderName, _fileName), FileMode.Open, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, ActiveDictionary.Dictionary);

                    }
                }
                else
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, ActiveDictionary.Dictionary);
                    }
                }
            }
            
            
           
        }

        public static void DeserializeDictionary()
        {
            if (Directory.Exists(folderPath))
            {
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(Path.Combine(BaseDirectory, _folderName, _fileName), FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        try
                        {
                            ActiveDictionary.Dictionary = (DictionaryTree)bf.Deserialize(fs);
                        }
                        catch (Exception)
                        {

                        }
                       
                    }
                }
                else
                {

                }
            }
            else { }
           
            
        }
    }
}
