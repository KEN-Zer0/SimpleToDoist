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

        // tasks properites
        private int taskCounter = 1;
        const int maxTaskElementsCount = 6;
        
        // shared properites
        const int toDoElementMargin = 5;

        // checkBox properties
        const int checkBoxElementSize = 20;

        // Label properties
        const int labelElementWidth = 270;
        const int labelElementHeight = 15;

        private string getTaskDefinition()
        {
            bool isEmpty = taskInputBox.Text == "";
            if (isEmpty)
            {
                return null;
            }

            string taskDefinitionText =
                taskCounter.ToString() + ". " + // task num
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

            newLabel.Margin = new Padding(0, toDoElementMargin, 0, toDoElementMargin);
            newLabel.Size = new Size(labelElementWidth, labelElementHeight);

            return newLabel;
        }

        private CheckBox createCheckBox()
        {
            CheckBox newCheckBox = new CheckBox();

            newCheckBox.Name = "taskCheckBox_" + taskCounter.ToString();
            newCheckBox.Checked = false;
            newCheckBox.Text = "";

            newCheckBox.Size = new Size(checkBoxElementSize, checkBoxElementSize);
            newCheckBox.Margin = new Padding(0, 0, 0, toDoElementMargin);

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
            else if (taskCounter > maxTaskElementsCount)
            {
                tasksScrollBar.Visible = true;
                tasksScrollBar.Enabled = true;
                tasksScrollBar.Maximum = taskCounter;
            }
            else if (taskCounter <= maxTaskElementsCount)
            {
                tasksScrollBar.Visible = false;
                tasksScrollBar.Enabled = false;
                tasksScrollBar.Maximum = maxTaskElementsCount;
                tasksScrollBar.Value = 1;
            }

        }

        private void innitTasksPanel(int pannelHeight)
        {
            tasksLayoutPanel.Size = new Size(279, pannelHeight);
        }

        private void innitCheckBoxPanel(int pannelHeight)
        {
            checkBoxLayoutPanel.Size = new Size(21, pannelHeight);
        }

        private int checkElementSize()
        {
            int labelHeight = labelElementHeight + 2 * toDoElementMargin;
            int checkBoxHeight = checkBoxElementSize + 1 * toDoElementMargin;

            bool isEqual = labelHeight == checkBoxHeight;
            if(isEqual) return labelHeight;
            else return -1;
        }

        private void innitToDoList()
        {
            int elementHeight = 2;
            int toDoListHeight = maxTaskElementsCount * elementHeight;
            innitTasksPanel(toDoListHeight);
            innitCheckBoxPanel(toDoListHeight);
        }


        // Main Functions
        private void simpleToDoist_Load(object sender, EventArgs e)
        {
            innitToDoList();

            tasksLayoutPanel.HorizontalScroll.Maximum = 0;
            tasksLayoutPanel.HorizontalScroll.Visible = false;
            tasksLayoutPanel.VerticalScroll.Visible = false;
            tasksLayoutPanel.AutoScroll = false;

            checkBoxLayoutPanel.HorizontalScroll.Maximum = 0;
            checkBoxLayoutPanel.HorizontalScroll.Visible = false;
            checkBoxLayoutPanel.VerticalScroll.Visible = false;
            checkBoxLayoutPanel.AutoScroll = false;
        }

        private void taskAddButton_Click(object sender, EventArgs e)
        {
            createTaskItem();
            checkTasksAmount();
        }

        private void tasksScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Point scrollPoint = new Point(0, tasksScrollBar.Value);

            tasksLayoutPanel.AutoScrollPosition = scrollPoint;
            checkBoxLayoutPanel.AutoScrollPosition = scrollPoint;
        }

       
    }
}
