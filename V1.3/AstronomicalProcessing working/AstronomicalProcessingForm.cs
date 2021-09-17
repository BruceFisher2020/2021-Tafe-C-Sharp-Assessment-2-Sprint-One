using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Original Code: Machyl 30017609, C Blunt, Sprint One
// Modified Code: Bruce Fisher P197681, C Blunt, Sprint One
// Date: 17/09/21
// Version: v1.3
// Astronomical Processing
// Program lists continuous data collected from the interaction of Neutrinos with Earth matter.
// The program will utilise simulated data and allows the user to add, edit, delete, sort and search the data.

namespace AstronomicalProcessing
{
    public partial class AstronomicalProcessingForm : Form
    {
        int?[] NeutrinoInteractions = new int?[24];
        int SelectedIndex = -1; // Set nothing selected from list box
        int NumberOfDataEntries = 0;
        String BLANK_ENTRY = "-";
        bool isSorted = false;

        #region Initialise Form Components
        public AstronomicalProcessingForm()
        {
            InitializeComponent();

            // Tool Tips for mouse cursor hovering over Buttons
            toolTip1.SetToolTip(ButtonAdd, "Add Data To List - from given input");
            toolTip1.SetToolTip(ButtonEdit, "Edit Data In List - from selection in list");
            toolTip1.SetToolTip(ButtonDelete, "Delete Data In List - from selection in list");
            toolTip1.SetToolTip(ButtonSort, "Sort Data - ascending order");
            toolTip1.SetToolTip(ButtonSearch, "Search Data - from given input");
            toolTip1.SetToolTip(ButtonAutoFill, "Pre-Fill List - random data");
            
        }
        #endregion
        #region Add Button
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            String inputText = TextBoxMain.Text;
            int inputInt;

            if (Int32.TryParse(inputText, out inputInt)) // Check for invalid input
            {
                if (NumberOfDataEntries < NeutrinoInteractions.Length)
                {
                    for (int i = 0; i < NeutrinoInteractions.Length; i++) //for looking for empty slots
                    {
                        if (!NeutrinoInteractions[i].HasValue)
                        {
                            NeutrinoInteractions[i] = inputInt;
                            NumberOfDataEntries++;
                            SelectedIndex = -1; // Set nothing selected from list box
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
        #endregion
        #region Edit Button
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (SelectedIndex == -1) // Check data is selected from list box
            {
                MessageBox.Show("Please select existing value");
                return;
            }
            String inputText = TextBoxMain.Text;
            int inputInt;

            if (Int32.TryParse(inputText, out inputInt)) // Check for invalid input
            {
                NeutrinoInteractions[SelectedIndex] = inputInt;
                UpdateDisplay();
                TextBoxMain.Clear();
                isSorted = false;
                return;
            }
            MessageBox.Show("Please enter an integer");
        }
        #endregion
        #region Delete Button
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (SelectedIndex == -1) // Check data is selected from list box
            {
                MessageBox.Show("Please select a value");
                return;
            }
            NeutrinoInteractions[SelectedIndex] = null;
            SelectedIndex = -1; // Set nothing selected from list box
            NumberOfDataEntries--;
            UpdateDisplay();
            TextBoxMain.Clear();
            isSorted = false;
        }
        #endregion
        #region Sort Button
        private void ButtonSort_Click(object sender, EventArgs e)
        {
            SortIntArray();
            UpdateDisplay();
        }
        #endregion
        #region Search Button
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
            if (!Int32.TryParse(searchText, out inputInt)) // Check for invalid input
            {
                MessageBox.Show("Error - Please enter an integer");
                return;
            }

            #region Binary Search
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
            #endregion
        }
        #endregion
        #region Auto Fill Button
        private void ButtonAutoFill_Click(object sender, EventArgs e)
        {
            AutofillData();
            UpdateDisplay();
        }
        #endregion
        #region Sort Button
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

            #region Bubble Sort
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
            #endregion

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
        #endregion
        #region Utilities
        #region AutoFillData
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
        #endregion
        #region UpdateDisplay List Box
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
        #endregion
        #region ListBoxMain Selected Index Changed
        //sets SelectedIndex on clicking listbox
        private void ListBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = ListBoxMain.SelectedItem.ToString();
            if (curItem == BLANK_ENTRY)
            {
                SelectedIndex = -1; // Set nothing selected from list box
                TextBoxMain.Text = "";
            }
            else
            {
                SelectedIndex = ListBoxMain.SelectedIndex;
                TextBoxMain.Text = curItem;
            }
        }
        #endregion
        #endregion
    }
}
