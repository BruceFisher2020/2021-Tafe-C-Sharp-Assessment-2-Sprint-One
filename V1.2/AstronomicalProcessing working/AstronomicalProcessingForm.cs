using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 15/09/21
// v1.2
// Original Code: Machyl 30017609
// Modified Code: Bruce Fisher P197681


namespace AstronomicalProcessing
{
    public partial class AstronomicalProcessingForm : Form
    {
        int?[] NeutrinoInteractions = new int?[24];
        int SelectedIndex = -1;
        int NumberOfDataEntries = 0;
        String BLANK_ENTRY = "-";
        bool isSorted = false;

        public AstronomicalProcessingForm()
        {
            InitializeComponent();

        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            String inputText = TextBoxMain.Text;
            int inputInt;

            if (Int32.TryParse(inputText, out inputInt))
            {
                if (NumberOfDataEntries < NeutrinoInteractions.Length)
                {
                    for (int i = 0; i < NeutrinoInteractions.Length; i++) //for looking for empty slots
                    {
                        if (!NeutrinoInteractions[i].HasValue)
                        {
                            NeutrinoInteractions[i] = inputInt;
                            NumberOfDataEntries++;
                            SelectedIndex = -1;
                            UpdateDisplay();
                            TextBoxMain.Clear();
                            isSorted = false;
                            return;
                        }
                    }
                    MessageBox.Show("Error - couldn't find null to fill in array");
                    return;
                }
                MessageBox.Show("Data already full, max: " + NeutrinoInteractions.Length);
                return;
            }
            MessageBox.Show("Please enter an integer");
        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (SelectedIndex == -1)
            {
                MessageBox.Show("Please select existing value");
                return;
            }
            String inputText = TextBoxMain.Text;
            int inputInt;
            if (Int32.TryParse(inputText, out inputInt))
            {
                NeutrinoInteractions[SelectedIndex] = inputInt;
                UpdateDisplay();
                TextBoxMain.Clear();
                isSorted = false;
                return;
            }
            MessageBox.Show("Please enter an integer");
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value");
                return;
            }
            NeutrinoInteractions[SelectedIndex] = null;
            SelectedIndex = -1;
            NumberOfDataEntries--;
            UpdateDisplay();
            TextBoxMain.Clear();
            isSorted = false;
        }
        private void ButtonSort_Click(object sender, EventArgs e)
        {
            SortIntArray();
            UpdateDisplay();
        }
        //not yet using binary search
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (!isSorted)
            {
                MessageBox.Show("Please sort data first");
                return;
            }

            String searchText = TextBoxMain.Text;
            if (searchText.Equals(""))
            {
                MessageBox.Show("Error - Text box empty");
                return;
            }

            int inputInt;
            if (!Int32.TryParse(searchText, out inputInt))
            {
                MessageBox.Show("Error - Please enter an integer");
                return;
            }

            int min = 0;
            int max = NeutrinoInteractions.Length - 1;
            int mid;

            while (min <= max)
            {
                mid = (min + max) / 2;
                if (NeutrinoInteractions[mid].HasValue && NeutrinoInteractions[mid].Value == inputInt)
                {
                    SelectedIndex = mid;
                    ListBoxMain.SetSelected(mid, true);
                    MessageBox.Show("Value found :)");
                    return;
                }
                else
                {
                    if (NeutrinoInteractions[mid].HasValue && NeutrinoInteractions[mid].Value > inputInt)
                    {
                        max = mid - 1;
                    }
                    else if (!NeutrinoInteractions[mid].HasValue || NeutrinoInteractions[mid].Value < inputInt) //assuming nulls where sorted to start of array
                    {
                        min = mid + 1;
                    }
                }
            }

        }
        private void ButtonAutoFill_Click(object sender, EventArgs e)
        {
            AutofillData();
            UpdateDisplay();
        }
        private void SortIntArray()
        {
            //setting nulls to -1 before sorting
            for (int i = 0; i < NeutrinoInteractions.Length; i++)
            {
                if (!NeutrinoInteractions[i].HasValue)
                {
                    NeutrinoInteractions[i] = -1;
                }
            }

            //bubble sort
            int int1, int2;
            for (int i = 0; i < NeutrinoInteractions.Length; i++)
            {
                for (int j = 0; j + 1 < NeutrinoInteractions.Length; j++)
                {
                    int1 = NeutrinoInteractions[j].Value;
                    int2 = NeutrinoInteractions[j + 1].Value;
                    if (int1 > int2)
                    {
                        NeutrinoInteractions[j] = int2;
                        NeutrinoInteractions[j + 1] = int1;
                    }
                }
            }

            //set -1 values back to null after sorting
            for (int i = 0; i < NeutrinoInteractions.Length; i++)
            {
                if (NeutrinoInteractions[i] == -1)
                {
                    NeutrinoInteractions[i] = null;
                }
            }

            isSorted = true;
        }
        //for generating random test data
        private void AutofillData()
        {
            Random rnd = new Random();
            for (int i = 0; i < NeutrinoInteractions.Length; i++) //for looking for empty slots
            {
                if (!NeutrinoInteractions[i].HasValue)
                {
                    NeutrinoInteractions[i] = rnd.Next(10, 100);
                    NumberOfDataEntries++;
                    continue;
                }
            }
            isSorted = false;
        }
        //fills in listbox with data from 'NeutrinoInteractions'
        private void UpdateDisplay()
        {
            ListBoxMain.Items.Clear();
            for (int i = 0; i < NeutrinoInteractions.Length; i++)
            {
                if (NeutrinoInteractions[i].HasValue)
                    ListBoxMain.Items.Add(NeutrinoInteractions[i]);
                else
                    ListBoxMain.Items.Add(BLANK_ENTRY);
            }
        }
        //sets SelectedIndex on clicking listbox
        private void ListBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = ListBoxMain.SelectedItem.ToString();
            if (curItem == BLANK_ENTRY)
            {
                SelectedIndex = -1;
                TextBoxMain.Text = "";
            }
            else
            {
                SelectedIndex = ListBoxMain.SelectedIndex;
                TextBoxMain.Text = curItem;
            }
        }








 
    }
}
