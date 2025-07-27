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

namespace SimpleToDoist
{
    public partial class simpleToDoist : Form
    {
        public simpleToDoist()
        {
            InitializeComponent();
        }

        private int _taskCounter = 0;
        private bool wasCalled = false;
        private int TaskCounter
        {
            get
            {
                if (_taskCounter < 0)
                {
                    Console.WriteLine("Error in tasks arithmetic");
                    this.Close();

                    return _taskCounter;
                }

                if (_taskCounter == 0 && wasCalled)
                {
                    MessageBox.Show("You're done with your tasks!");
                    this.Close();
                }
                else if (_taskCounter > maxTaskItemElementsCount)
                {
                    tasksScrollBar.Visible = true;
                    tasksScrollBar.Enabled = true;
                    tasksScrollBar.Maximum = _taskCounter;
                }
                else if (_taskCounter <= maxTaskItemElementsCount)
                {
                    tasksScrollBar.Visible = false;
                    tasksScrollBar.Enabled = false;
                    tasksScrollBar.Maximum = maxTaskItemElementsCount;
                    tasksScrollBar.Value = 1;
                }
                if (_taskCounter > 0) wasCalled = true;

                return _taskCounter;
            }

            set { _taskCounter = value; }
        }

        private List<TaskItem> taskItemsList = new List<TaskItem>();

        // Creating Tasks
        private TaskItem CreateTask()
        {
            TaskItem newTask = new TaskItem(TaskCounter);
            SetTaskTitle(newTask);
            return newTask;
        }

        // czy to jest zgodne z konwencja
        private void SetTaskTitle(TaskItem taskToSet)
        {
            string taskFetchedTitle = taskInputBox.Text;
            taskToSet.TaskTitle = taskFetchedTitle;
        }

        private TaskItem CreateNewTaskElement()
        {
            TaskItem newTaskItem = CreateTask();
            newTaskItem.CreateTaskLabel();
            newTaskItem.CreateTaskCheckBox();
            newTaskItem.taskCheckBox.CheckedChanged += TaskCheckBox_CheckedChanged;

            CreateTaskItem(newTaskItem);

            return newTaskItem;
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

                currentTask.CopyFrom(nextTask);
                currentTask.TaskIndex = i;
                currentTask.taskCheckBox.Tag = currentTask;
                currentTask.UpdateTaskLabel();
            }
            DeleteTaskInstance();
            TaskCounter--;
        }

        private void DeleteTaskInstance()
        {
            TaskItem lastTask = taskItemsList[TaskCounter - 1];

            lastTask.taskCheckBox.Visible = false;
            lastTask.taskLabel.Visible = false;

            checkBoxLayoutPanel.Controls.Remove(lastTask.taskCheckBox);
            tasksLayoutPanel.Controls.Remove(lastTask.taskLabel);

            taskItemsList.RemoveAt(TaskCounter - 1);
        }

        // Create task instance on form
        private void CreateTaskItem(TaskItem newTaskItem)
        {

            tasksLayoutPanel.Controls.Add(newTaskItem.taskLabel);
            checkBoxLayoutPanel.Controls.Add(newTaskItem.taskCheckBox);

            TaskCounter++;
        }

        private void Test_Tasks1()
        {
            string zdanie = "Testowy,task,utworzony,dla,testow";
            string[] slowa = zdanie.Split(',');

            foreach (string slowo in slowa)
            {
                taskInputBox.Text = slowo;

                taskItemsList.Add(CreateNewTaskElement());
            }
        }

        // *******************************
        // * MAIN FUNCTIONS
        // *******************************
        private void simpleToDoist_Load(object sender, EventArgs e)
        {
            FormInnits formProperites = new FormInnits();
            formProperites.ConnetFormObjects(tasksLayoutPanel,
                checkBoxLayoutPanel, tasksScrollBar);
            FormInnits.Innit_ToDoList(formProperites);

            Test_Tasks1();
        }

        private void taskAddButton_Click(object sender, EventArgs e)
        {
            taskItemsList.Add(CreateNewTaskElement());
            MessageBox.Show(TaskCounter.ToString());
        }

        private void tasksScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Point scrollPoint = new Point(0, tasksScrollBar.Value);

            tasksLayoutPanel.AutoScrollPosition = scrollPoint;
            checkBoxLayoutPanel.AutoScrollPosition = scrollPoint;
        }
    }
}
