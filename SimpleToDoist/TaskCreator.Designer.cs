using System;
using System.Windows.Forms;

namespace SimpleToDoist
{
    partial class TaskCreator
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptioTextBox = new System.Windows.Forms.TextBox();
            this.dueDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dueDateLabel = new System.Windows.Forms.Label();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.priorityScroll = new System.Windows.Forms.HScrollBar();
            this.createButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.taskColorDialog = new System.Windows.Forms.ColorDialog();
            this.pickColorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.headerLabel.Location = new System.Drawing.Point(157, 42);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(242, 25);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Create your new task:";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.descriptionLabel.Location = new System.Drawing.Point(250, 85);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(100, 20);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "Description:";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.titleLabel.Location = new System.Drawing.Point(20, 83);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(46, 20);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Title:";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(72, 83);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(172, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // descriptioTextBox
            // 
            this.descriptioTextBox.Location = new System.Drawing.Point(356, 85);
            this.descriptioTextBox.Name = "descriptioTextBox";
            this.descriptioTextBox.Size = new System.Drawing.Size(169, 20);
            this.descriptioTextBox.TabIndex = 1;
            // 
            // dueDateTimePicker
            // 
            this.dueDateTimePicker.Checked = false;
            this.dueDateTimePicker.CustomFormat = "HH:mm dd.MM.yyyy";
            this.dueDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dueDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dueDateTimePicker.Location = new System.Drawing.Point(107, 109);
            this.dueDateTimePicker.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dueDateTimePicker.MinDate = new System.DateTime(2025, 7, 31, 0, 0, 0, 0);
            this.dueDateTimePicker.Name = "dueDateTimePicker";
            this.dueDateTimePicker.Size = new System.Drawing.Size(137, 21);
            this.dueDateTimePicker.TabIndex = 2;
            // 
            // dueDateLabel
            // 
            this.dueDateLabel.AutoSize = true;
            this.dueDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dueDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.dueDateLabel.Location = new System.Drawing.Point(20, 109);
            this.dueDateLabel.Margin = new System.Windows.Forms.Padding(3, 0, 2, 0);
            this.dueDateLabel.Name = "dueDateLabel";
            this.dueDateLabel.Size = new System.Drawing.Size(82, 20);
            this.dueDateLabel.TabIndex = 5;
            this.dueDateLabel.Text = "Due date:";
            this.dueDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.priorityLabel.Location = new System.Drawing.Point(250, 113);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(67, 20);
            this.priorityLabel.TabIndex = 6;
            this.priorityLabel.Text = "Priority:";
            this.priorityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // priorityScroll
            // 
            this.priorityScroll.LargeChange = 1;
            this.priorityScroll.Location = new System.Drawing.Point(356, 112);
            this.priorityScroll.Name = "priorityScroll";
            this.priorityScroll.Size = new System.Drawing.Size(169, 19);
            this.priorityScroll.TabIndex = 3;
            this.priorityScroll.TabStop = true;
            this.priorityScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.priorityScroll_Scroll);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(190, 178);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 6;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(275, 178);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.BackColor = System.Drawing.Color.Transparent;
            this.categoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.categoryLabel.Location = new System.Drawing.Point(20, 133);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(81, 20);
            this.categoryLabel.TabIndex = 10;
            this.categoryLabel.Text = "Category:";
            this.categoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Items.AddRange(new object[] {
            "Hobby",
            "Home",
            "Personal",
            "Work"});
            this.categoryComboBox.Location = new System.Drawing.Point(107, 136);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(137, 21);
            this.categoryComboBox.TabIndex = 4;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.colorLabel.Location = new System.Drawing.Point(250, 139);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(100, 20);
            this.colorLabel.TabIndex = 13;
            this.colorLabel.Text = "Label Color:";
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pickColorButton
            // 
            this.pickColorButton.Location = new System.Drawing.Point(356, 139);
            this.pickColorButton.Name = "pickColorButton";
            this.pickColorButton.Size = new System.Drawing.Size(169, 23);
            this.pickColorButton.TabIndex = 5;
            this.pickColorButton.Text = "Pick Color";
            this.pickColorButton.UseVisualStyleBackColor = true;
            this.pickColorButton.Click += new System.EventHandler(this.pickColorButton_Click);
            // 
            // TaskCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(552, 270);
            this.Controls.Add(this.pickColorButton);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.priorityScroll);
            this.Controls.Add(this.priorityLabel);
            this.Controls.Add(this.dueDateLabel);
            this.Controls.Add(this.dueDateTimePicker);
            this.Controls.Add(this.descriptioTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.headerLabel);
            this.Name = "TaskCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Creation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.DateTimePicker dueDateTimePicker;
        private System.Windows.Forms.Label dueDateLabel;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.HScrollBar priorityScroll;
        private System.Windows.Forms.TextBox descriptioTextBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.ColorDialog taskColorDialog;
        private System.Windows.Forms.Button pickColorButton;
    }
}