using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleToDoist.TasksCreation
{
    public class TaskCreator
    {
        private int _taskIndex;
        private string _taskName;
        public string taskTitle;
        public string taskDescription;
        public bool taskCompletion;
     
        public int TaskIndex
        {
            get { return _taskIndex; }
            set 
            {
                if (value < 0) 
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

        public TaskCreator(int taskId, string newTaskName, 
            string newTaskTitle, string newTaskDescription)
        {
            TaskIndex = taskId;
            _taskName = newTaskName + taskId.ToString();
            taskTitle = newTaskTitle;
            taskDescription = newTaskDescription;
            taskCompletion = false;
        }

        
    }
}
