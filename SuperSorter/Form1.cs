#region Usings
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
#endregion

namespace SuperSorter
{
    public partial class Form1 : Form
    {
        #region Variables
        private string FileContent = string.Empty;
        private string FilePath = string.Empty;
        private string Filename = string.Empty;

        private ToolTip FloatingPointNumbersInfo_ToolTip;

        private int[] Integers;
        private float[] Floats;
        private string[] Strings;

        private readonly Dictionary<bool, string> IsDataLoadedInfo = new Dictionary<bool, string>()
        {
            { true, "Data is currently loaded." },
            { false, "Data is not loaded yet." }
        };
        private bool IsDataLoadedFlag;

        /// <summary>
        /// <para>FullSetup:</para>
        /// <para>0 - selected separator</para>
        /// <para>1 - selected data type</para>
        /// <para>2 - selected sorting algorithm</para>
        /// </summary>
        private List<string> FullSetup;
        #endregion

        #region Initials
        public Form1()
        {
            InitializeComponent();

            UpdateStatusStrip();
            InitializeFullSetup_Stage1();
            InitializeComboBoxes();
            InitializeFullSetup_Stage2();
            InitializeFloatingPointNumbersInfo_ToolTip();
        }

        private void UpdateStatusStrip()
        {
            if (FileContent.Equals(string.Empty))
            {
                IsDataLoadedFlag = false;
                sort_button.Enabled = false;
            }
            else
            {
                IsDataLoadedFlag = true;
                sort_button.Enabled = true;
            }

            if (Filename.Equals(string.Empty))
                toolStripStatusLabel.Text = IsDataLoadedInfo[IsDataLoadedFlag];
            else
            {
                int numberOfItems = ProcessData();

                toolStripStatusLabel.Text = String.Format("{0} {1}{2}{3} {4} {5}",
                    IsDataLoadedInfo[IsDataLoadedFlag],
                    "File: \"", Filename, "\".",
                    "Number of items:", numberOfItems);
            }
        }

        private void InitializeFullSetup_Stage1()
        {
            FullSetup = new List<string>(3);
            for (int i = 0; i < 3; i++)
                FullSetup.Add(string.Empty);
        }

        private void InitializeComboBoxes()
        {
            separators_comboBox.SelectedIndex = 0;
            dataTypes_comboBox.SelectedIndex = 0;
            algorithms_comboBox.SelectedIndex = 0;
        }

        private void InitializeFullSetup_Stage2()
        {
            FullSetup[0] = separators_comboBox.Text;
            FullSetup[1] = dataTypes_comboBox.Text;
            FullSetup[2] = algorithms_comboBox.Text;
        }

        private void InitializeFloatingPointNumbersInfo_ToolTip()
        {
            FloatingPointNumbersInfo_ToolTip = new ToolTip();
            FloatingPointNumbersInfo_ToolTip.AutoPopDelay = 5000;
            FloatingPointNumbersInfo_ToolTip.InitialDelay = 100;
            FloatingPointNumbersInfo_ToolTip.ReshowDelay = 100;
            FloatingPointNumbersInfo_ToolTip.ShowAlways = true;
            FloatingPointNumbersInfo_ToolTip.SetToolTip(dataTypes_comboBox, "Floating Point Numbers should be in dots standard e.g. 2.55");
        }
        #endregion

        #region Data operations
        private int ProcessData()
        {
            string[] stringsArray;

            if (separators_comboBox.Text == "Semicolon")
                stringsArray = FileContent.Split(';');
            else if (separators_comboBox.Text == "Comma") 
                stringsArray = FileContent.Split(',');
            else if (separators_comboBox.Text == "New Line")
                stringsArray = FileContent.Split(
                    new[] { Environment.NewLine },
                    StringSplitOptions.None);
            else
                stringsArray = new string[0];

            stringsArray = stringsArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            int counter = 0;
            if (dataTypes_comboBox.Text == "Integers")
            {
                Integers = stringsArray.Select(int.Parse).ToArray();
                counter = Integers.Length;
            }
            else if (dataTypes_comboBox.Text == "Floating Point Numbers")
            {
                Floats = stringsArray.Select(float.Parse).ToArray();
                counter = Floats.Length;
            }
            else if (dataTypes_comboBox.Text == "Characters Strings")
            {
                Strings = new string[stringsArray.Length];
                Array.Copy(stringsArray, Strings, stringsArray.Length);
                counter = Strings.Count();
            }

            return counter;
        }

        private void ArraysNotEqualDialog(string firstArrayName, string secondArrayName)
        {
            MessageBox.Show($"For some reason, an array sorted by {firstArrayName} is not the same as an array sorted by {secondArrayName}.",
                "Arrays are not equal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void SaveData<T>(T[] data)
        {
            DialogResult result = MessageBox.Show("Do you want to save sorted data (only new line separated format)?",
                "Saving data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files|*.txt|All files|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int len = data.Length;

                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                        for (int i = 0; i < len; i++)
                            if (i == (len - 1))
                                sw.Write(data[i]);
                            else
                                sw.WriteLine(data[i]);
                }
            }
        }
        #endregion

        #region Main Events
        private void loadData_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files|*.txt|All files|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = openFileDialog.FileName;
                    Filename = Path.GetFileName(FilePath);
                    Stream fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                        FileContent = reader.ReadToEnd();
                }
            }

            UpdateStatusStrip();
        }

        private void sort_button_Click(object sender, EventArgs e)
        {
            selectedSortingAlgorithmValue_label.Text = algorithms_comboBox.Text;

            string title = this.Text;
            this.Text = "Sorting, please wait...";

            if (FullSetup[1] == "Integers")
            {
                if (FullSetup[2] == "Insertion Sort")
                    CallInsertionSort(typeof(int));
                else if (FullSetup[2] == "Bubble Sort")
                    CallBubbleSort(typeof(int));
                else if (FullSetup[2] == "Quick Sort")
                    CallQuickSort(typeof(int));
                else if (FullSetup[2] == "Bogo Sort")
                    CallBogoSort(typeof(int));
                else if (FullSetup[2] == "All (except Bogo Sort)")
                {
                    selectedSortingAlgorithmValue_label.Text = "many";
                    CreateAllResultsForm(typeof(int), title);
                }
            }
            else if (FullSetup[1] == "Floating Point Numbers")
            {
                if (FullSetup[2] == "Insertion Sort")
                    CallInsertionSort(typeof(float));
                else if (FullSetup[2] == "Bubble Sort")
                    CallBubbleSort(typeof(float));
                else if (FullSetup[2] == "Quick Sort")
                    CallQuickSort(typeof(float));
                else if (FullSetup[2] == "Bogo Sort")
                    CallBogoSort(typeof(float));
                else if (FullSetup[2] == "All (except Bogo Sort)")
                {
                    selectedSortingAlgorithmValue_label.Text = "many";
                    CreateAllResultsForm(typeof(float), title);
                }
            }
            else if (FullSetup[1] == "Characters Strings")
            {
                if (FullSetup[2] == "Insertion Sort")
                    CallInsertionSort(typeof(string));
                else if (FullSetup[2] == "Bubble Sort")
                    CallBubbleSort(typeof(string));
                else if (FullSetup[2] == "Quick Sort")
                    CallQuickSort(typeof(string));
                else if (FullSetup[2] == "Bogo Sort")
                    CallBogoSort(typeof(string));
                else if (FullSetup[2] == "All (except Bogo Sort)")
                {
                    selectedSortingAlgorithmValue_label.Text = "many";
                    CreateAllResultsForm(typeof(string), title);
                }
            }
            else
                MessageBox.Show("Fatal error while sorting!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            this.Text = title;
        }

        private void separators_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FullSetup[0] = separators_comboBox.Text;
        }

        private void dataTypes_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FullSetup[1] = dataTypes_comboBox.Text;
        }

        private void algorithms_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FullSetup[2] = algorithms_comboBox.Text;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGeneratorForm();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cezary Pietruszyński Software Development 2021\nAll rights reserved",
                "Super Sorter",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        #endregion

        #region Call Algorithms
        private void CallInsertionSort(Type type)
        {
            dynamic sortingObject = null;

            if (type == typeof(int))
                sortingObject = new SortingAlgorithms.InsertionSort<int>(Integers);
            else if (type == typeof(float))
                sortingObject = new SortingAlgorithms.InsertionSort<float>(Floats);
            else if (type == typeof(string))
                sortingObject = new SortingAlgorithms.InsertionSort<string>(Strings);

            sortingObject.Sort();
            elapsedTimeValue_label.Text = string.Format("{0} {1}", sortingObject.SortingTime_ms, "ms");
            iterationsValue_label.Text = string.Format("{0}", sortingObject.Iterations);

            SaveData(sortingObject.SortedArray);
        }

        private void CallBubbleSort(Type type)
        {
            dynamic sortingObject = null;

            if (type == typeof(int))
                sortingObject = new SortingAlgorithms.BubbleSort<int>(Integers);
            else if (type == typeof(float))
                sortingObject = new SortingAlgorithms.BubbleSort<float>(Floats);
            else if (type == typeof(string))
                sortingObject = new SortingAlgorithms.BubbleSort<string>(Strings);

            sortingObject.Sort();
            elapsedTimeValue_label.Text = string.Format("{0} {1}", sortingObject.SortingTime_ms, "ms");
            iterationsValue_label.Text = string.Format("{0}", sortingObject.Iterations);

            SaveData(sortingObject.SortedArray);
        }

        private void CallQuickSort(Type type)
        {
            dynamic sortingObject = null;

            if (type == typeof(int))
                sortingObject = new SortingAlgorithms.QuickSort<int>(Integers);
            else if (type == typeof(float))
                sortingObject = new SortingAlgorithms.QuickSort<float>(Floats);
            else if (type == typeof(string))
                sortingObject = new SortingAlgorithms.QuickSort<string>(Strings);

            sortingObject.Sort();
            elapsedTimeValue_label.Text = string.Format("{0} {1}", sortingObject.SortingTime_ms, "ms");
            iterationsValue_label.Text = string.Format("{0}", sortingObject.Iterations);

            SaveData(sortingObject.SortedArray);
        }

        private void CallBogoSort(Type type)
        {
            dynamic sortingObject = null;

            if (type == typeof(int))
                sortingObject = new SortingAlgorithms.BogoSort<int>(Integers);
            else if (type == typeof(float))
                sortingObject = new SortingAlgorithms.BogoSort<float>(Floats);
            else if (type == typeof(string))
                sortingObject = new SortingAlgorithms.BogoSort<string>(Strings);

            sortingObject.Sort();
            elapsedTimeValue_label.Text = string.Format("{0} {1}", sortingObject.SortingTime_ms, "ms");
            iterationsValue_label.Text = string.Format("{0}", sortingObject.Iterations);

            SaveData(sortingObject.SortedArray);
        }

        private void CallAllSortingAlgorithms<T>(Type type, DataGridView all_results)
        {
            dynamic insertionSort = null;
            dynamic bubbleSort = null;
            dynamic quickSort = null;
            double allSortingTime = 0.0;
            ulong allIterations = 0;

            DataGridViewRow row = (DataGridViewRow)all_results.Rows[0].Clone();

            if (type == typeof(int))
            {
                insertionSort = new SortingAlgorithms.InsertionSort<int>(Integers);
                insertionSort.Sort();
                row.Cells[0].Value = "Insertion Sort";
                row.Cells[1].Value = insertionSort.SortingTime_ms;
                row.Cells[2].Value = insertionSort.Iterations;
                all_results.Rows.Add(row);

                row = (DataGridViewRow)all_results.Rows[1].Clone();
                bubbleSort = new SortingAlgorithms.BubbleSort<int>(Integers);
                bubbleSort.Sort();
                row.Cells[0].Value = "Bubble Sort";
                row.Cells[1].Value = bubbleSort.SortingTime_ms;
                row.Cells[2].Value = bubbleSort.Iterations;
                all_results.Rows.Add(row);

                row = (DataGridViewRow)all_results.Rows[2].Clone();
                quickSort = new SortingAlgorithms.QuickSort<int>(Integers);
                quickSort.Sort();
                row.Cells[0].Value = "Quick Sort";
                row.Cells[1].Value = quickSort.SortingTime_ms;
                row.Cells[2].Value = quickSort.Iterations;
                all_results.Rows.Add(row);
            }
            else if (type == typeof(float))
            {
                insertionSort = new SortingAlgorithms.InsertionSort<float>(Floats);
                insertionSort.Sort();
                row.Cells[0].Value = "Insertion Sort";
                row.Cells[1].Value = insertionSort.SortingTime_ms;
                row.Cells[2].Value = insertionSort.Iterations;
                all_results.Rows.Add(row);

                row = (DataGridViewRow)all_results.Rows[1].Clone();
                bubbleSort = new SortingAlgorithms.BubbleSort<float>(Floats);
                bubbleSort.Sort();
                row.Cells[0].Value = "Bubble Sort";
                row.Cells[1].Value = bubbleSort.SortingTime_ms;
                row.Cells[2].Value = bubbleSort.Iterations;
                all_results.Rows.Add(row);

                row = (DataGridViewRow)all_results.Rows[2].Clone();
                quickSort = new SortingAlgorithms.QuickSort<float>(Floats);
                quickSort.Sort();
                row.Cells[0].Value = "Quick Sort";
                row.Cells[1].Value = quickSort.SortingTime_ms;
                row.Cells[2].Value = quickSort.Iterations;
                all_results.Rows.Add(row);
            }
            else if (type == typeof(string))
            {
                insertionSort = new SortingAlgorithms.InsertionSort<string>(Strings);
                insertionSort.Sort();
                row.Cells[0].Value = "Insertion Sort";
                row.Cells[1].Value = insertionSort.SortingTime_ms;
                row.Cells[2].Value = insertionSort.Iterations;
                all_results.Rows.Add(row);

                row = (DataGridViewRow)all_results.Rows[1].Clone();
                bubbleSort = new SortingAlgorithms.BubbleSort<string>(Strings);
                bubbleSort.Sort();
                row.Cells[0].Value = "Bubble Sort";
                row.Cells[1].Value = bubbleSort.SortingTime_ms;
                row.Cells[2].Value = bubbleSort.Iterations;
                all_results.Rows.Add(row);

                row = (DataGridViewRow)all_results.Rows[2].Clone();
                quickSort = new SortingAlgorithms.QuickSort<string>(Strings);
                quickSort.Sort();
                row.Cells[0].Value = "Quick Sort";
                row.Cells[1].Value = quickSort.SortingTime_ms;
                row.Cells[2].Value = quickSort.Iterations;
                all_results.Rows.Add(row);
            }

            allSortingTime = insertionSort.SortingTime_ms +
                bubbleSort.SortingTime_ms +
                quickSort.SortingTime_ms;

            allIterations = insertionSort.Iterations +
                bubbleSort.Iterations +
                quickSort.Iterations;

            elapsedTimeValue_label.Text = string.Format("{0} {1}", allSortingTime, "ms");
            iterationsValue_label.Text = string.Format("{0}", allIterations);

            if (!Enumerable.SequenceEqual(insertionSort.SortedArray, bubbleSort.SortedArray))
                ArraysNotEqualDialog("Insertion Sort", "Bubble Sort");

            if (!Enumerable.SequenceEqual(insertionSort.SortedArray, quickSort.SortedArray))
                ArraysNotEqualDialog("Insertion Sort", "Quick Sort");

            if (!Enumerable.SequenceEqual(bubbleSort.SortedArray, quickSort.SortedArray))
                ArraysNotEqualDialog("Bubble Sort", "Quick Sort");
        }
        #endregion

        #region Generator Form
        private void CreateGeneratorForm()
        {
            Form form = new Form()
            {
                Text = "Generator",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MinimizeBox = false,
                MaximizeBox = false,
                Size = new Size(300, 200)
            };

            Label number_label = new Label()
            {
                Text = "Enter number of generated elements:",
                AutoSize = true,
                Location = new Point(10, 10)
            };

            NumericUpDown number_numericDropDown = new NumericUpDown()
            {
                Location = new Point(10, 30),
                Minimum = 2,
                Maximum = 1000000,
                Value = 1000
            };

            Label range_label = new Label()
            {
                Text = "Enter range:",
                AutoSize = true,
                Location = new Point(10, 60)
            };

            NumericUpDown minRange_numericDropDown = new NumericUpDown()
            {
                Location = new Point(10, 80),
                Minimum = -1000000,
                Maximum = 1000000,
                Value = 0
            };

            NumericUpDown maxRange_numericDropDown = new NumericUpDown()
            {
                Location = new Point(140, 80),
                Minimum = -1000000,
                Maximum = 1000000,
                Value = 1000
            };

            Button generate_button = new Button()
            {
                Text = "Generate",
                Location = new Point(10, 110)
            };

            form.Controls.Add(number_label);
            form.Controls.Add(number_numericDropDown);

            form.Controls.Add(range_label);
            form.Controls.Add(minRange_numericDropDown);
            form.Controls.Add(maxRange_numericDropDown);

            generate_button.Click += new EventHandler((sender, e) => generate_button_Click(sender, e,
                form,
                number_numericDropDown.Value,
                minRange_numericDropDown.Value,
                maxRange_numericDropDown.Value));

            form.Controls.Add(generate_button);

            form.ShowDialog();
        }

        private void generate_button_Click(object sender, EventArgs e, Form form, decimal noe, decimal min, decimal max)
        {
            if (min >= max)
            {
                MessageBox.Show("Minimum range value MUST be less than maximum range value.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                Random rnd = new Random();

                StreamWriter writetext;
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Text files|*.txt|All files|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FileName != "")
                        using (writetext = new StreamWriter(saveFileDialog.FileName))
                            for (int i = 0; i < Decimal.ToInt32(noe); i++)
                                if (i == (Decimal.ToInt32(noe) - 1))
                                    writetext.Write(rnd.Next(Decimal.ToInt32(min), Decimal.ToInt32(max)));
                                else
                                    writetext.WriteLine(rnd.Next(Decimal.ToInt32(min), Decimal.ToInt32(max)));
                    form.Close();
                }
            }
        }
        #endregion

        #region All results Form
        private void CreateAllResultsForm(Type type, string title)
        {
            Form form = new Form()
            {
                Text = "All results",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MinimizeBox = false,
                MaximizeBox = false,
                Size = new Size(300, 170)
            };

            DataGridView all_results = new DataGridView()
            {
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            };

            all_results.Columns[0].HeaderText = "Algorithm";
            all_results.Columns[1].HeaderText = "Time [ms]";
            all_results.Columns[2].HeaderText = "Iterations";

            CallAllSortingAlgorithms<Type>(type, all_results);

            this.Text = title;

            form.Controls.Add(all_results);

            form.ShowDialog();
        }
        #endregion
    }
}