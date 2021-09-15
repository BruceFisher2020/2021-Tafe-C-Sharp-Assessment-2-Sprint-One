
namespace AstronomicalProcessing
{
    partial class AstronomicalProcessingForm
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
            this.ListBoxMain = new System.Windows.Forms.ListBox();
            this.TextBoxMain = new System.Windows.Forms.TextBox();
            this.ButtonSort = new System.Windows.Forms.Button();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonAutoFill = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBoxMain
            // 
            this.ListBoxMain.FormattingEnabled = true;
            this.ListBoxMain.Location = new System.Drawing.Point(353, 71);
            this.ListBoxMain.Name = "ListBoxMain";
            this.ListBoxMain.Size = new System.Drawing.Size(240, 329);
            this.ListBoxMain.TabIndex = 0;
            this.ListBoxMain.SelectedIndexChanged += new System.EventHandler(this.ListBoxMain_SelectedIndexChanged);
            // 
            // TextBoxMain
            // 
            this.TextBoxMain.Location = new System.Drawing.Point(353, 45);
            this.TextBoxMain.Name = "TextBoxMain";
            this.TextBoxMain.Size = new System.Drawing.Size(240, 20);
            this.TextBoxMain.TabIndex = 1;
            // 
            // ButtonSort
            // 
            this.ButtonSort.Location = new System.Drawing.Point(116, 97);
            this.ButtonSort.Name = "ButtonSort";
            this.ButtonSort.Size = new System.Drawing.Size(75, 23);
            this.ButtonSort.TabIndex = 2;
            this.ButtonSort.Text = "Sort";
            this.ButtonSort.UseVisualStyleBackColor = true;
            this.ButtonSort.Click += new System.EventHandler(this.ButtonSort_Click);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(116, 149);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 3;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // ButtonAutoFill
            // 
            this.ButtonAutoFill.Location = new System.Drawing.Point(116, 195);
            this.ButtonAutoFill.Name = "ButtonAutoFill";
            this.ButtonAutoFill.Size = new System.Drawing.Size(75, 23);
            this.ButtonAutoFill.TabIndex = 4;
            this.ButtonAutoFill.Text = "AutoFill Data";
            this.ButtonAutoFill.UseVisualStyleBackColor = true;
            this.ButtonAutoFill.Click += new System.EventHandler(this.ButtonAutoFill_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(733, 97);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 5;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(733, 149);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 23);
            this.ButtonEdit.TabIndex = 6;
            this.ButtonEdit.Text = "Edit";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(733, 195);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelete.TabIndex = 7;
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // AstronomicalProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonAutoFill);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.ButtonSort);
            this.Controls.Add(this.TextBoxMain);
            this.Controls.Add(this.ListBoxMain);
            this.Name = "AstronomicalProcessingForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxMain;
        private System.Windows.Forms.TextBox TextBoxMain;
        private System.Windows.Forms.Button ButtonSort;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.Button ButtonAutoFill;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonDelete;
    }
}

