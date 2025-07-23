namespace SimpleToDoist
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.taskAddButton = new System.Windows.Forms.Button();
            this.addNewLabel = new System.Windows.Forms.Label();
            this.taskInputBox = new System.Windows.Forms.TextBox();
            this.tasksLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // taskAddButton
            // 
            this.taskAddButton.Location = new System.Drawing.Point(194, 209);
            this.taskAddButton.Margin = new System.Windows.Forms.Padding(0);
            this.taskAddButton.Name = "taskAddButton";
            this.taskAddButton.Size = new System.Drawing.Size(78, 20);
            this.taskAddButton.TabIndex = 0;
            this.taskAddButton.Text = "Add Task";
            this.taskAddButton.UseVisualStyleBackColor = true;
            this.taskAddButton.Click += new System.EventHandler(this.taskAddButton_Click);
            // 
            // addNewLabel
            // 
            this.addNewLabel.AutoSize = true;
            this.addNewLabel.Location = new System.Drawing.Point(191, 193);
            this.addNewLabel.Name = "addNewLabel";
            this.addNewLabel.Size = new System.Drawing.Size(88, 13);
            this.addNewLabel.TabIndex = 1;
            this.addNewLabel.Text = "Create new Task";
            this.addNewLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // taskInputBox
            // 
            this.taskInputBox.Location = new System.Drawing.Point(275, 209);
            this.taskInputBox.Name = "taskInputBox";
            this.taskInputBox.Size = new System.Drawing.Size(227, 20);
            this.taskInputBox.TabIndex = 2;
            // 
            // tasksLayoutPanel
            // 
            this.tasksLayoutPanel.Location = new System.Drawing.Point(194, 238);
            this.tasksLayoutPanel.Name = "tasksLayoutPanel";
            this.tasksLayoutPanel.Size = new System.Drawing.Size(256, 100);
            this.tasksLayoutPanel.TabIndex = 3;
            // 
            // checkBoxLayoutPanel
            // 
            this.checkBoxLayoutPanel.Location = new System.Drawing.Point(456, 238);
            this.checkBoxLayoutPanel.Name = "checkBoxLayoutPanel";
            this.checkBoxLayoutPanel.Size = new System.Drawing.Size(46, 100);
            this.checkBoxLayoutPanel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxLayoutPanel);
            this.Controls.Add(this.tasksLayoutPanel);
            this.Controls.Add(this.taskInputBox);
            this.Controls.Add(this.addNewLabel);
            this.Controls.Add(this.taskAddButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button taskAddButton;
        private System.Windows.Forms.Label addNewLabel;
        private System.Windows.Forms.TextBox taskInputBox;
        private System.Windows.Forms.FlowLayoutPanel tasksLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel checkBoxLayoutPanel;
    }
}

