namespace SimpleToDoist
{
    partial class simpleToDoist
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
            this.tasksScrollBar = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // taskAddButton
            // 
            this.taskAddButton.Location = new System.Drawing.Point(51, 68);
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
            this.addNewLabel.Location = new System.Drawing.Point(48, 52);
            this.addNewLabel.Name = "addNewLabel";
            this.addNewLabel.Size = new System.Drawing.Size(210, 13);
            this.addNewLabel.TabIndex = 1;
            this.addNewLabel.Text = "Create new Task for your simple ToDo List:";
            this.addNewLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // taskInputBox
            // 
            this.taskInputBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.taskInputBox.Location = new System.Drawing.Point(132, 68);
            this.taskInputBox.Name = "taskInputBox";
            this.taskInputBox.Size = new System.Drawing.Size(227, 20);
            this.taskInputBox.TabIndex = 2;
            // 
            // tasksLayoutPanel
            // 
            this.tasksLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tasksLayoutPanel.Location = new System.Drawing.Point(78, 97);
            this.tasksLayoutPanel.Name = "tasksLayoutPanel";
            this.tasksLayoutPanel.Size = new System.Drawing.Size(279, 160);
            this.tasksLayoutPanel.TabIndex = 3;
            this.tasksLayoutPanel.WrapContents = false;
            // 
            // checkBoxLayoutPanel
            // 
            this.checkBoxLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkBoxLayoutPanel.Location = new System.Drawing.Point(51, 97);
            this.checkBoxLayoutPanel.Name = "checkBoxLayoutPanel";
            this.checkBoxLayoutPanel.Size = new System.Drawing.Size(21, 160);
            this.checkBoxLayoutPanel.TabIndex = 4;
            this.checkBoxLayoutPanel.WrapContents = false;
            // 
            // tasksScrollBar
            // 
            this.tasksScrollBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tasksScrollBar.LargeChange = 5;
            this.tasksScrollBar.Location = new System.Drawing.Point(360, 97);
            this.tasksScrollBar.Minimum = 1;
            this.tasksScrollBar.Name = "tasksScrollBar";
            this.tasksScrollBar.Size = new System.Drawing.Size(16, 160);
            this.tasksScrollBar.TabIndex = 0;
            this.tasksScrollBar.Value = 1;
            this.tasksScrollBar.Visible = false;
            this.tasksScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tasksScrollBar_Scroll);
            // 
            // simpleToDoist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(428, 296);
            this.Controls.Add(this.tasksScrollBar);
            this.Controls.Add(this.checkBoxLayoutPanel);
            this.Controls.Add(this.tasksLayoutPanel);
            this.Controls.Add(this.taskInputBox);
            this.Controls.Add(this.addNewLabel);
            this.Controls.Add(this.taskAddButton);
            this.Name = "simpleToDoist";
            this.Text = "simpleToDoist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button taskAddButton;
        private System.Windows.Forms.Label addNewLabel;
        private System.Windows.Forms.TextBox taskInputBox;
        private System.Windows.Forms.FlowLayoutPanel tasksLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel checkBoxLayoutPanel;
        private System.Windows.Forms.VScrollBar tasksScrollBar;
    }
}

