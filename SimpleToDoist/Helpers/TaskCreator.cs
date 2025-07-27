using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static SimpleToDoist.AppConstants;

namespace SimpleToDoist.TasksCreation
{
    public class TaskItem
    {
        // Properites
        private int _taskIndex;
        private string _taskName;
        private string _taskTitle;
        public string TaskDescription;
        private bool _taskCompletion;

        public Label taskLabel;
        public CheckBox taskCheckBox;

        // Properites Creation
        public int TaskIndex
        {
            get { return _taskIndex; }
            set
            {
                bool isNegative = value < 0;
                if (isNegative)
                {
                    MessageBox.Show($"Error index {_taskIndex} is negative");
                }

                _taskIndex = value;
            }
        }

        public string TaskName
        {
            get { return _taskName; }
            set
            {
                bool isEmpty = string.IsNullOrWhiteSpace(value);
                if (isEmpty)
                {
                    MessageBox.Show($"Error Task Name {_taskName} is empty");
                }
                _taskName = value;
            }
        }

        public string TaskTitle
        {
            get { return _taskTitle; }
            set
            {
                bool isEmpty = string.IsNullOrWhiteSpace(value);
                if (isEmpty)
                {
                    _taskTitle = null;
                    MessageBox.Show($"Error Task Name {_taskTitle} is empty");
                }
                _taskTitle = value.Trim();
            }
        }

        public bool TaskCompletion
        {
            get { return _taskCompletion; }
            set { _taskCompletion = value; }
        }

        public bool ChangeTaskCompletionStatus()
        {
            TaskCompletion = !TaskCompletion;
            return TaskCompletion;
        }

        // Setting TaskName
        public string CreateTaskName(string taskName)
        {
            bool isEmpty = string.IsNullOrWhiteSpace(taskName);
            if (isEmpty)
            {
                MessageBox.Show($"Error Task Name {taskName} is empty");
            }

            TaskName = taskName + TaskIndex.ToString();

            return TaskName;
        }

        // Constructor
        public TaskItem(int taskId)
        {
            TaskIndex = taskId;
            TaskName = CreateTaskName(newTaskName);
            TaskCompletion = false;
        }

        // Task swaping
        public void CopyFrom(TaskItem other)
        {
            this.TaskName = other.TaskName;
            this.TaskTitle = other.TaskTitle;
            this.TaskDescription = other.TaskDescription;
            this.TaskCompletion = other.TaskCompletion;

            this.taskLabel.Text = other.taskLabel.Text;
            this.taskCheckBox.Checked = other.taskCheckBox.Checked;
        }

        // Creating Task-Form Elements
        public void CreateTaskLabel()
        {
            Label newTaskLabel = new Label();

            newTaskLabel.Name = TaskName + newTaskLabelName;
            newTaskLabel.Text = (TaskIndex + 1).ToString() +
                numberDelimiter + TaskTitle;

            newTaskLabel.AutoEllipsis = true;
            newTaskLabel.AutoSize = false;
            newTaskLabel.TextAlign = ContentAlignment.MiddleLeft;

            newTaskLabel.Margin = new Padding(0, labelElementMargin, 0, labelElementMargin);
            newTaskLabel.Size = new Size(labelElementWidth, labelElementHeight);

            newTaskLabel.Tag = this;
            this.taskLabel = newTaskLabel;
        }

        public void UpdateTaskLabel()
        {
            Label currentLabel = this.taskLabel as Label;

            currentLabel.Tag = this;
            currentLabel.Text = (TaskIndex + 1).ToString() +
                numberDelimiter + TaskTitle;
        }

        public void CreateTaskCheckBox()
        {
            CheckBox newTaskCheckBox= new CheckBox();

            newTaskCheckBox.Name = TaskName + newTaskCheckBoxName;
            newTaskCheckBox.Text = null;
            newTaskCheckBox.Checked = TaskCompletion;

            newTaskCheckBox.Size = new Size(checkBoxElementSize, checkBoxElementSize);
            newTaskCheckBox.Margin = new Padding(0, checkBoxElementMargin, 0, checkBoxElementMargin);

            newTaskCheckBox.Tag = this;
            this.taskCheckBox = newTaskCheckBox;
        }

    }
}
