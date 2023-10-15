
namespace SuperSorter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadData_button = new System.Windows.Forms.Button();
            this.statistics_groupBox = new System.Windows.Forms.GroupBox();
            this.iterationsValue_label = new System.Windows.Forms.Label();
            this.iterationsText_label = new System.Windows.Forms.Label();
            this.elapsedTimeValue_label = new System.Windows.Forms.Label();
            this.elapsedTimeText_label = new System.Windows.Forms.Label();
            this.selectedSortingAlgorithmValue_label = new System.Windows.Forms.Label();
            this.selectedSortingAlgorithmText_label = new System.Windows.Forms.Label();
            this.algorithms_comboBox = new System.Windows.Forms.ComboBox();
            this.sort_button = new System.Windows.Forms.Button();
            this.separators_comboBox = new System.Windows.Forms.ComboBox();
            this.dataTypes_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataType_label = new System.Windows.Forms.Label();
            this.separato_label = new System.Windows.Forms.Label();
            this.sorting_label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superSorterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.statistics_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 439);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // loadData_button
            // 
            this.loadData_button.Location = new System.Drawing.Point(9, 142);
            this.loadData_button.Name = "loadData_button";
            this.loadData_button.Size = new System.Drawing.Size(159, 23);
            this.loadData_button.TabIndex = 3;
            this.loadData_button.Text = "Load Data";
            this.loadData_button.UseVisualStyleBackColor = true;
            this.loadData_button.Click += new System.EventHandler(this.loadData_button_Click);
            // 
            // statistics_groupBox
            // 
            this.statistics_groupBox.Controls.Add(this.iterationsValue_label);
            this.statistics_groupBox.Controls.Add(this.iterationsText_label);
            this.statistics_groupBox.Controls.Add(this.elapsedTimeValue_label);
            this.statistics_groupBox.Controls.Add(this.elapsedTimeText_label);
            this.statistics_groupBox.Controls.Add(this.selectedSortingAlgorithmValue_label);
            this.statistics_groupBox.Controls.Add(this.selectedSortingAlgorithmText_label);
            this.statistics_groupBox.Location = new System.Drawing.Point(208, 27);
            this.statistics_groupBox.Name = "statistics_groupBox";
            this.statistics_groupBox.Size = new System.Drawing.Size(264, 186);
            this.statistics_groupBox.TabIndex = 5;
            this.statistics_groupBox.TabStop = false;
            this.statistics_groupBox.Text = "Statistics";
            // 
            // iterationsValue_label
            // 
            this.iterationsValue_label.AutoSize = true;
            this.iterationsValue_label.Location = new System.Drawing.Point(65, 86);
            this.iterationsValue_label.Name = "iterationsValue_label";
            this.iterationsValue_label.Size = new System.Drawing.Size(10, 13);
            this.iterationsValue_label.TabIndex = 5;
            this.iterationsValue_label.Text = "-";
            // 
            // iterationsText_label
            // 
            this.iterationsText_label.AutoSize = true;
            this.iterationsText_label.Location = new System.Drawing.Point(6, 86);
            this.iterationsText_label.Name = "iterationsText_label";
            this.iterationsText_label.Size = new System.Drawing.Size(53, 13);
            this.iterationsText_label.TabIndex = 4;
            this.iterationsText_label.Text = "Iterations:";
            // 
            // elapsedTimeValue_label
            // 
            this.elapsedTimeValue_label.AutoSize = true;
            this.elapsedTimeValue_label.Location = new System.Drawing.Point(82, 63);
            this.elapsedTimeValue_label.Name = "elapsedTimeValue_label";
            this.elapsedTimeValue_label.Size = new System.Drawing.Size(10, 13);
            this.elapsedTimeValue_label.TabIndex = 3;
            this.elapsedTimeValue_label.Text = "-";
            // 
            // elapsedTimeText_label
            // 
            this.elapsedTimeText_label.AutoSize = true;
            this.elapsedTimeText_label.Location = new System.Drawing.Point(6, 63);
            this.elapsedTimeText_label.Name = "elapsedTimeText_label";
            this.elapsedTimeText_label.Size = new System.Drawing.Size(70, 13);
            this.elapsedTimeText_label.TabIndex = 2;
            this.elapsedTimeText_label.Text = "Elapsed time:";
            // 
            // selectedSortingAlgorithmValue_label
            // 
            this.selectedSortingAlgorithmValue_label.AutoSize = true;
            this.selectedSortingAlgorithmValue_label.Location = new System.Drawing.Point(146, 40);
            this.selectedSortingAlgorithmValue_label.Name = "selectedSortingAlgorithmValue_label";
            this.selectedSortingAlgorithmValue_label.Size = new System.Drawing.Size(10, 13);
            this.selectedSortingAlgorithmValue_label.TabIndex = 1;
            this.selectedSortingAlgorithmValue_label.Text = "-";
            // 
            // selectedSortingAlgorithmText_label
            // 
            this.selectedSortingAlgorithmText_label.AutoSize = true;
            this.selectedSortingAlgorithmText_label.Location = new System.Drawing.Point(6, 40);
            this.selectedSortingAlgorithmText_label.Name = "selectedSortingAlgorithmText_label";
            this.selectedSortingAlgorithmText_label.Size = new System.Drawing.Size(134, 13);
            this.selectedSortingAlgorithmText_label.TabIndex = 0;
            this.selectedSortingAlgorithmText_label.Text = "Selected Sorting Algorithm:";
            // 
            // algorithms_comboBox
            // 
            this.algorithms_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algorithms_comboBox.FormattingEnabled = true;
            this.algorithms_comboBox.Items.AddRange(new object[] {
            "Insertion Sort",
            "Bubble Sort",
            "Quick Sort",
            "Bogo Sort",
            "All (except Bogo Sort)"});
            this.algorithms_comboBox.Location = new System.Drawing.Point(21, 245);
            this.algorithms_comboBox.Name = "algorithms_comboBox";
            this.algorithms_comboBox.Size = new System.Drawing.Size(159, 21);
            this.algorithms_comboBox.TabIndex = 6;
            this.algorithms_comboBox.SelectedIndexChanged += new System.EventHandler(this.algorithms_comboBox_SelectedIndexChanged);
            // 
            // sort_button
            // 
            this.sort_button.Location = new System.Drawing.Point(21, 289);
            this.sort_button.Name = "sort_button";
            this.sort_button.Size = new System.Drawing.Size(160, 23);
            this.sort_button.TabIndex = 7;
            this.sort_button.Text = "Sort";
            this.sort_button.UseVisualStyleBackColor = true;
            this.sort_button.Click += new System.EventHandler(this.sort_button_Click);
            // 
            // separators_comboBox
            // 
            this.separators_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.separators_comboBox.FormattingEnabled = true;
            this.separators_comboBox.Items.AddRange(new object[] {
            "Semicolon",
            "Comma",
            "New Line"});
            this.separators_comboBox.Location = new System.Drawing.Point(9, 41);
            this.separators_comboBox.Name = "separators_comboBox";
            this.separators_comboBox.Size = new System.Drawing.Size(159, 21);
            this.separators_comboBox.TabIndex = 8;
            this.separators_comboBox.SelectedIndexChanged += new System.EventHandler(this.separators_comboBox_SelectedIndexChanged);
            // 
            // dataTypes_comboBox
            // 
            this.dataTypes_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataTypes_comboBox.FormattingEnabled = true;
            this.dataTypes_comboBox.Items.AddRange(new object[] {
            "Integers",
            "Floating Point Numbers",
            "Characters Strings"});
            this.dataTypes_comboBox.Location = new System.Drawing.Point(9, 98);
            this.dataTypes_comboBox.Name = "dataTypes_comboBox";
            this.dataTypes_comboBox.Size = new System.Drawing.Size(159, 21);
            this.dataTypes_comboBox.TabIndex = 9;
            this.dataTypes_comboBox.SelectedIndexChanged += new System.EventHandler(this.dataTypes_comboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataType_label);
            this.groupBox1.Controls.Add(this.dataTypes_comboBox);
            this.groupBox1.Controls.Add(this.separato_label);
            this.groupBox1.Controls.Add(this.separators_comboBox);
            this.groupBox1.Controls.Add(this.loadData_button);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 186);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // dataType_label
            // 
            this.dataType_label.AutoSize = true;
            this.dataType_label.Location = new System.Drawing.Point(6, 82);
            this.dataType_label.Name = "dataType_label";
            this.dataType_label.Size = new System.Drawing.Size(60, 13);
            this.dataType_label.TabIndex = 12;
            this.dataType_label.Text = "Data Type:";
            // 
            // separato_label
            // 
            this.separato_label.AutoSize = true;
            this.separato_label.Location = new System.Drawing.Point(6, 25);
            this.separato_label.Name = "separato_label";
            this.separato_label.Size = new System.Drawing.Size(56, 13);
            this.separato_label.TabIndex = 11;
            this.separato_label.Text = "Separator:";
            // 
            // sorting_label
            // 
            this.sorting_label.AutoSize = true;
            this.sorting_label.Location = new System.Drawing.Point(18, 229);
            this.sorting_label.Name = "sorting_label";
            this.sorting_label.Size = new System.Drawing.Size(70, 13);
            this.sorting_label.TabIndex = 11;
            this.sorting_label.Text = "Sorting Type:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.applicationToolStripMenuItem,
            this.superSorterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
            this.generateToolStripMenuItem.Text = "Generate data (new line separated integers)";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // superSorterToolStripMenuItem
            // 
            this.superSorterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.superSorterToolStripMenuItem.Name = "superSorterToolStripMenuItem";
            this.superSorterToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.superSorterToolStripMenuItem.Text = "Super Sorter";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.sorting_label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sort_button);
            this.Controls.Add(this.algorithms_comboBox);
            this.Controls.Add(this.statistics_groupBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Form1";
            this.Text = "Super Sorter";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.statistics_groupBox.ResumeLayout(false);
            this.statistics_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button loadData_button;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.GroupBox statistics_groupBox;
        private System.Windows.Forms.Label iterationsValue_label;
        private System.Windows.Forms.Label iterationsText_label;
        private System.Windows.Forms.Label elapsedTimeValue_label;
        private System.Windows.Forms.Label elapsedTimeText_label;
        private System.Windows.Forms.Label selectedSortingAlgorithmValue_label;
        private System.Windows.Forms.Label selectedSortingAlgorithmText_label;
        private System.Windows.Forms.ComboBox algorithms_comboBox;
        private System.Windows.Forms.Button sort_button;
        private System.Windows.Forms.ComboBox separators_comboBox;
        private System.Windows.Forms.ComboBox dataTypes_comboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label dataType_label;
        private System.Windows.Forms.Label separato_label;
        private System.Windows.Forms.Label sorting_label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superSorterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
    }
}

