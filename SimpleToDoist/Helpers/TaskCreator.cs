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
        public string taskName;
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

        public TaskCreator(int taskId, string newTaskName, 
            string newTaskTitle, string newTaskDescription)
        {
            TaskIndex = taskId;
            taskName = newTaskName + taskId.ToString();
            taskTitle = newTaskTitle;
            taskDescription = newTaskDescription;
            taskCompletion = false;
        }

        
    }
}
