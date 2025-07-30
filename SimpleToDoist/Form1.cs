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

            CreateTaskItem(newTaskItem);
            if (TaskCounter > 0) wasCalled = true;

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

            tasksLayoutPanel.Controls.Add(newTaskItem.TaskLabel);
            checkBoxLayoutPanel.Controls.Add(newTaskItem.TaskCheckBox);
            newTaskItem.TaskCheckBox.CheckedChanged += TaskCheckBox_CheckedChanged;

            TaskCounter++;
        }

        private void CheckTaskAmmount()
        {
            if (_taskCounter == 0 && wasCalled)
            {
                MessageBox.Show("You're done with your tasks!");
                this.Close();
            }
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
                if(e != null) CheckTaskAmmount();

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
                currentTask.TaskCheckBox.Tag = currentTask;
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

            lastTask.TaskCheckBox.Visible = false;
            lastTask.TaskLabel.Visible = false;

            checkBoxLayoutPanel.Controls.Remove(lastTask.TaskCheckBox);
            tasksLayoutPanel.Controls.Remove(lastTask.TaskLabel);

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
            this.ActiveControl = taskInputBox;

            FormTests();
        }

        private void taskInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool enterPressed = e.KeyCode == Keys.Enter;
            if (enterPressed)
            {
                taskAddButton_Click(null, null);
                e.SuppressKeyPress = true;

                taskInputBox.Clear();
            }
        }

        private void taskAddButton_Click(object sender, EventArgs e)
        {
            TaskItem newTaskItem = CreateNewTaskElement();
            if (newTaskItem == null) return;

            taskItemsList.Add(newTaskItem);
            taskInputBox.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TaskSaving.SaveTasks(taskItemsList);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            clearButton_Click(null, null);

            taskItemsList = TaskSaving.ReadTasks();
            if (taskItemsList == null) return;

            foreach (TaskItem taskItem in taskItemsList)
            {
                CreateTaskItem(taskItem);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (taskItemsList == null) return;
            for (int index = taskItemsList.Count - 1; index >= 0; index--)
            {
                DropTask(taskItemsList[index].TaskIndex);
            }
        }
    }
}
