using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoist.TasksCreation
{
    public class TaskCreator
    {
        public int taskIndex;
        public string taskName;
        public string taskTitle;
        public string taskDescription;
        public bool taskCompletion;
     

        public TaskCreator(int taskId, string newTaskName, 
            string newTaskTitle, string newTaskDescription)
        {
            taskIndex = taskId;
            taskName = newTaskName + taskId.ToString();
            taskTitle = newTaskTitle;
            taskDescription = newTaskDescription;
            taskCompletion = false;
        }

        
    }
}
