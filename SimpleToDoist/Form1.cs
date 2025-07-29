using SimpleToDoist.TasksCreation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SimpleToDoist.AppConstants;
using SimpleToDoist.MyTests;

namespace SimpleToDoist
{
    public partial class simpleToDoist : Form
    {
        public simpleToDoist()
        {
            InitializeComponent();
        }

        // Variables
        private int _taskCounter = 0;
        private bool wasCalled = false;
        private List<TaskItem> taskItemsList = new List<TaskItem>();

        // Properites
        private int TaskCounter
        {
            get
            {
                if (_taskCounter < 0)
                {
                    Console.WriteLine("Error in tasks arithmetic");
                    this.Close();
                }

                return _taskCounter;
            }
            set { _taskCounter = value; }
        }

        // Creating Tasks
        private TaskItem CreateNewTaskElement()
        {
            TaskItem newTaskItem = CreateTask();
            if (newTaskItem == null) return null;

            newTaskItem.CreateTaskLabel();
            newTaskItem.CreateTaskCheckBox();

            newTaskItem.taskCheckBox.CheckedChanged += TaskCheckBox_CheckedChanged;

            CreateTaskItem(newTaskItem);
            CheckTaskAmmount();

            return newTaskItem;
        }

        private TaskItem CreateTask()
        {
            TaskItem newTask = new TaskItem(TaskCounter);
            newTask.TaskTitle = taskInputBox.Text;

            bool isTaskValid = newTask.ValidateTaskParams();
            if (!isTaskValid) return null;

            return newTask;
        }

        // Create task instance on form
        private void CreateTaskItem(TaskItem newTaskItem)
        {

            tasksLayoutPanel.Controls.Add(newTaskItem.taskLabel);
            checkBoxLayoutPanel.Controls.Add(newTaskItem.taskCheckBox);

            TaskCounter++;
        }

        private void CheckTaskAmmount()
        {
            if (TaskCounter == 0 && wasCalled)
            {
                MessageBox.Show("You're done with your tasks!");
                this.Close();
            }
            
            if (TaskCounter > 0) wasCalled = true;
        }

        private void TaskCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clikedCheckBox = sender as CheckBox;
            if (clikedCheckBox == null) return;

            if (clikedCheckBox.Checked)
            {
                TaskItem connectedTask = clikedCheckBox.Tag as TaskItem;
                if (connectedTask == null) return;

                int clickedTaskIndex = connectedTask.TaskIndex;
                DropTask(clickedTaskIndex);

                Debug.WriteLine(TaskCounter.ToString());
            }
        }

        private void DropTask(int index)
        {
            for (int i = index; i < TaskCounter - 1; i++)
            {
                TaskItem currentTask = taskItemsList[i];
                TaskItem nextTask = taskItemsList[i + 1];

                currentTask.CopyForm(nextTask);
                currentTask.TaskIndex = i;
                currentTask.taskCheckBox.Tag = currentTask;
                currentTask.UpdateTaskLabel();
            }
            DeleteTaskInstance();
            TaskCounter--;
        }

        private void DeleteTaskInstance()
        {
            if (taskItemsList == null) return;
            TaskItem lastTask = taskItemsList[TaskCounter - 1];
            if(!lastTask.ValidateTaskParams()) return;

            lastTask.taskCheckBox.Visible = false;
            lastTask.taskLabel.Visible = false;

            checkBoxLayoutPanel.Controls.Remove(lastTask.taskCheckBox);
            tasksLayoutPanel.Controls.Remove(lastTask.taskLabel);

            lastTask = null;

            taskItemsList.RemoveAt(TaskCounter - 1);
        }

        // Tests
        private void FormTests()
        {
            Tests.Test_Tasks1(taskInputBox, taskItemsList, CreateNewTaskElement);

        }

        // *****************************
        //      * MAIN FUNCTIONS *
        // *****************************
        private void simpleToDoist_Load(object sender, EventArgs e)
        {
            FormInnits formProperites = new FormInnits();
            formProperites.LabelPanel = tasksLayoutPanel;
            formProperites.CheckBoxPanel = checkBoxLayoutPanel;

            FormInnits.Innit_ToDoList(formProperites);

            this.Controls.Add(formProperites.MainContainerPanel);
            //FormTests();
        }

        private void taskAddButton_Click(object sender, EventArgs e)
        {
            TaskItem newTaskItem = CreateNewTaskElement();
            if (newTaskItem == null) return;

            taskItemsList.Add(newTaskItem);
            //MessageBox.Show(TaskCounter.ToString());
        }
    }
}
