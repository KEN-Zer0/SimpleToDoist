using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleToDoist.TasksCreation
{
    public class TaskItem
    {
        private int _taskIndex;
        private string _taskName;
        private string _taskTitle;
        public string taskDescription;
        private bool _taskCompletion;

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
                _taskTitle = value;
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

        //public TaskItem(int taskId, string newTaskTitle,
        //    string newTaskName = "taskItem_",
        //    string newTaskDescription = "")
        public TaskItem(int taskId,
            string newTaskName = "taskItem_",
            string newTaskDescription = "")
        {
            TaskIndex = taskId;
            TaskName = CreateTaskName(newTaskName);
            //TaskTitle = "";
            taskDescription = newTaskDescription;
            TaskCompletion = false;
        }
    }
}
