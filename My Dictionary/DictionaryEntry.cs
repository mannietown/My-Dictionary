using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Dictionary
{
    public partial class DictionaryEntry : Form
    {
        public DictionaryEntry()
        {
            InitializeComponent();
        }

        public static bool IsOn = false;
        private void DictionaryEntry_Load(object sender, EventArgs e)
        {
            IsOn = true;
            PopulateComboBox();
        }


        private void PopulateComboBox()
        {
            List<string> CategoryNames = new List<string>();
            foreach (DictionaryItem dItem in ActiveDictionary.Dictionary.Root.DictionaryItems)
            {
                CategoryNames.Add(dItem.CategoryName);
            }

            comboBox_Category.DataSource = CategoryNames;
        }

        private DictionaryItem WordItem()
        {
            DictionaryItem dItem = new DictionaryItem(false);
            dItem.WordName = DictionaryClipboard.GetWordSearch();
            dItem.CategoryName = comboBox_Category.Text;
            dItem.WordDefinition = textBox_Definition.Text;

            return dItem;
        }
        

        private void button_AddWord_Click_1(object sender, EventArgs e)
        {
            if (DictionaryTree.HasWord(WordItem().WordName, ActiveDictionary.Dictionary.Root))
            {
                //Error Provider Code
            }
            else
            {
                DictionaryItem DItem = new DictionaryItem(false, false, WordItem().CategoryName, WordItem());
                FileIO.SerializeDictionary();
                this.Close();
            }
           
        }

        private void DictionaryEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsOn = false;
        }
    }
}
