using SimpleToDoist.TasksCreation;
using System;
using System.Windows.Forms;

namespace SimpleToDoist
{
    public partial class TaskCreator : Form
    {
        public TaskItem NewTask { get; set; }

        public TaskCreator(TaskItem NewTask)
        {
            this.NewTask = NewTask;
            InitializeComponent();

            SetPriorityLabelValue();
        }

        private void priorityScroll_Scroll(object sender, ScrollEventArgs e)
        {
            SetPriorityLabelValue();
        }

        private void SetPriorityLabelValue()
        {
            priorityLabel.Text = "Priority: " + priorityScroll.Value.ToString();
        }

        private void pickColorButton_Click(object sender, EventArgs e)
        {
            taskColorDialog.ShowDialog();
            if (taskColorDialog.Color == null) return;

            if (NewTask == null) return;
            NewTask.TaskLabelColor = taskColorDialog.Color;
        }

        // Main Buttons
        private void createButton_Click(object sender, EventArgs e)
        {
            if (NewTask == null)
            {
                this.Close();
                return;
            }

            NewTask.TaskTitle = titleTextBox.Text;
            NewTask.TaskDescription = descriptioTextBox.Text;
            NewTask.TaskDueDate = dueDateTimePicker.Value;
            NewTask.TaskPriority = priorityScroll.Value;
            NewTask.TaskCategory = categoryComboBox.Text;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            NewTask = null;
            this.Close();
        }
    }
}
