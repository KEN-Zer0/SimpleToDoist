using SimpleToDoist.TasksCreation;
using System;
using System.Drawing;
using System.Windows.Forms;
using static SimpleToDoist.AppConstants;

namespace SimpleToDoist
{
    public partial class TaskCreator : Form
    {
        public TaskItem NewTask { get; set; }

        public TaskCreator(TaskItem NewTask)
        {
            this.NewTask = NewTask;

            InitializeComponent();
            this.categoryComboBox.SelectedIndex = 0;
            this.priorityScroll.Minimum = minTaskPriority;
            this.priorityScroll.Maximum = maxTaskPriority;
            this.StartPosition = FormStartPosition.CenterScreen;

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
            taskColorDialog.Color = Color.Red;
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

            DateTime dueDate = (DateTime)RoundDateTime(dueDateTimePicker.Value);
            NewTask.TaskDueDate = dueDate;
            NewTask.TaskPriority = priorityScroll.Value;
            NewTask.TaskCategory = categoryComboBox.Text;

            this.Close();
        }

        private DateTime? RoundDateTime(DateTime date)
        {
            if(date == null) return null;

            bool shouldRoundUp = date.Second >= 30;

            DateTime rounded = new DateTime(
                date.Year, date.Month, date.Day,
                date.Hour, date.Minute, 0);

            if (shouldRoundUp)
            {
                rounded = rounded.AddMinutes(1);
            }

            return rounded;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            NewTask = null;
            this.Close();
        }
    }
}
