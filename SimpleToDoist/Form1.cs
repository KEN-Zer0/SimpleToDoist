using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleToDoist
{
    public partial class simpleToDoist : Form
    {
        public simpleToDoist()
        {
            InitializeComponent();
        }

        private int taskCounter = 1;

        private string getTaskDefinition()
        {
            bool isEmpty = taskInputBox.Text == "";
            if (isEmpty)
            {
                return null;
            }

            string taskDefinitionText =
                taskCounter.ToString() + "# " + // task num
                taskInputBox.Text;              // task text

            return taskDefinitionText;
        }

        private Label createLabel()
        {
            string taskDefinitionText = getTaskDefinition();
            bool isInvalid = taskDefinitionText == null;
            if (isInvalid)
            {
                return null;
            }

            Label newLabel = new Label();
            newLabel.Name = "taskDefinition_" + taskCounter.ToString();
            newLabel.Text = getTaskDefinition();
            newLabel.AutoEllipsis = true;
            newLabel.AutoSize = false;
            newLabel.TextAlign = ContentAlignment.MiddleLeft;
            newLabel.Margin = new Padding(0, 5, 0, 5);
            newLabel.Size = new Size(270, 15);

            return newLabel;
        }

        private CheckBox createCheckBox()
        {
            CheckBox newCheckBox = new CheckBox();
            newCheckBox.Name = "taskCheckBox_" + taskCounter.ToString();
            newCheckBox.Checked = false;
            newCheckBox.Text = "";
            newCheckBox.Size = new Size(20, 20);
            newCheckBox.Margin = new Padding(0, 0, 0, 5);

            return newCheckBox;
        }

        private void createTaskItem()
        {
            Label taskLabel = createLabel();
            bool isNewLabelInvalid = taskLabel == null;
            if (isNewLabelInvalid)
            {
                return;
            }

            CheckBox taskCheckbox = createCheckBox();

            tasksLayoutPanel.Controls.Add(taskLabel);
            checkBoxLayoutPanel.Controls.Add(taskCheckbox);

            taskCounter++;
        }

        private void checkTasksAmount()
        {
            if (taskCounter < 0)
            {
                Console.WriteLine("Error in tasks counting");
                this.Close();

                return;
            }

            if (taskCounter == 0)
            {
                MessageBox.Show("You're done with your tasks!");
                this.Close();
            }
            else if (taskCounter > 6)
            {
                tasksScrollBar.Visible = true;
                tasksScrollBar.Enabled = true;
            }
            else if (taskCounter <= 6)
            {
                tasksScrollBar.Visible = false;
                tasksScrollBar.Enabled = false;
                tasksScrollBar.Value = 1;
            }

        }

        private void taskAddButton_Click(object sender, EventArgs e)
        {
            createTaskItem();
            checkTasksAmount();
        }

        private void tasksScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            tasksLayoutPanel.VerticalScroll.Value = tasksScrollBar.Value;
            checkBoxLayoutPanel.VerticalScroll.Value = tasksScrollBar.Value;
        }
    }
}
