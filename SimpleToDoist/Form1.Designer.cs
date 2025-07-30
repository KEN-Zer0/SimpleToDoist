using System.Drawing;
using System.Windows.Forms;

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
            this.mainContainerPanel = new System.Windows.Forms.Panel();
            this.innerPanel = new System.Windows.Forms.Panel();
            this.tasksLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.saveButton = new System.Windows.Forms.Button();
            this.mainContainerPanel.SuspendLayout();
            this.innerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskAddButton
            // 
            this.taskAddButton.Location = new System.Drawing.Point(51, 68);
            this.taskAddButton.Margin = new System.Windows.Forms.Padding(0);
            this.taskAddButton.Name = "taskAddButton";
            this.taskAddButton.Size = new System.Drawing.Size(78, 20);
            this.taskAddButton.TabIndex = 1;
            this.taskAddButton.Text = "Add Task";
            this.taskAddButton.UseVisualStyleBackColor = true;
            this.taskAddButton.Click += new System.EventHandler(this.taskAddButton_Click);
            // 
            // addNewLabel
            // 
            this.addNewLabel.AutoSize = true;
            this.addNewLabel.Location = new System.Drawing.Point(48, 49);
            this.addNewLabel.Name = "addNewLabel";
            this.addNewLabel.Size = new System.Drawing.Size(210, 13);
            this.addNewLabel.TabIndex = 1;
            this.addNewLabel.Text = "Create new Task for your simple ToDo List:";
            this.addNewLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // taskInputBox
            // 
            this.taskInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.taskInputBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.taskInputBox.Location = new System.Drawing.Point(132, 68);
            this.taskInputBox.Name = "taskInputBox";
            this.taskInputBox.Size = new System.Drawing.Size(227, 20);
            this.taskInputBox.TabIndex = 0;
            this.taskInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.taskInputBox_KeyDown);
            // 
            // mainContainerPanel
            // 
            this.mainContainerPanel.AutoScroll = true;
            this.mainContainerPanel.Controls.Add(this.innerPanel);
            this.mainContainerPanel.Location = new System.Drawing.Point(51, 91);
            this.mainContainerPanel.Name = "mainContainerPanel";
            this.mainContainerPanel.Size = new System.Drawing.Size(307, 160);
            this.mainContainerPanel.TabIndex = 3;
            // 
            // innerPanel
            // 
            this.innerPanel.AutoSize = true;
            this.innerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.innerPanel.Controls.Add(this.tasksLayoutPanel);
            this.innerPanel.Controls.Add(this.checkBoxLayoutPanel);
            this.innerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.innerPanel.Location = new System.Drawing.Point(0, 0);
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Size = new System.Drawing.Size(307, 3);
            this.innerPanel.TabIndex = 3;
            // 
            // tasksLayoutPanel
            // 
            this.tasksLayoutPanel.AutoSize = true;
            this.tasksLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tasksLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tasksLayoutPanel.Location = new System.Drawing.Point(22, 0);
            this.tasksLayoutPanel.Name = "tasksLayoutPanel";
            this.tasksLayoutPanel.Size = new System.Drawing.Size(0, 0);
            this.tasksLayoutPanel.TabIndex = 3;
            this.tasksLayoutPanel.WrapContents = false;
            // 
            // checkBoxLayoutPanel
            // 
            this.checkBoxLayoutPanel.AutoSize = true;
            this.checkBoxLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkBoxLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkBoxLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.checkBoxLayoutPanel.Name = "checkBoxLayoutPanel";
            this.checkBoxLayoutPanel.Size = new System.Drawing.Size(0, 0);
            this.checkBoxLayoutPanel.TabIndex = 4;
            this.checkBoxLayoutPanel.WrapContents = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(261, 46);
            this.saveButton.Margin = new System.Windows.Forms.Padding(0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(97, 19);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save Task List";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // simpleToDoist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(428, 323);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.mainContainerPanel);
            this.Controls.Add(this.taskInputBox);
            this.Controls.Add(this.addNewLabel);
            this.Controls.Add(this.taskAddButton);
            this.Name = "simpleToDoist";
            this.Text = "simpleToDoist";
            this.Load += new System.EventHandler(this.simpleToDoist_Load);
            this.mainContainerPanel.ResumeLayout(false);
            this.mainContainerPanel.PerformLayout();
            this.innerPanel.ResumeLayout(false);
            this.innerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button taskAddButton;
        private System.Windows.Forms.Label addNewLabel;
        private System.Windows.Forms.TextBox taskInputBox;
        private System.Windows.Forms.Panel mainContainerPanel;
        private System.Windows.Forms.Panel innerPanel;
        private System.Windows.Forms.FlowLayoutPanel tasksLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel checkBoxLayoutPanel;
        private Button saveButton;
    }
}

