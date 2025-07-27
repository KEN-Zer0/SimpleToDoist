using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SimpleToDoist.AppConstants;
using SimpleToDoist.TasksCreation;

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
                if (TaskCounter < 0)
                {
                    Console.WriteLine("Error in tasks counting");
                    this.Close();

                    return _taskCounter;
                }

                if (TaskCounter == 0 && wasCalled)
                {
                    MessageBox.Show("You're done with your tasks!");
                    this.Close();
                }
                else if (TaskCounter > maxTaskItemElementsCount)
                {
                    tasksScrollBar.Visible = true;
                    tasksScrollBar.Enabled = true;
                    tasksScrollBar.Maximum = TaskCounter;
                }
                else if (TaskCounter <= maxTaskItemElementsCount)
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

                MessageBox.Show(TaskCounter.ToString());
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
        

        // Custom innitializations
        private void Innit_TasksPanel(int toDo_PannelHeight)
        {
            tasksLayoutPanel.Size = new Size(labelPanelWidth, toDo_PannelHeight);

            tasksLayoutPanel.HorizontalScroll.Maximum = 0;
            tasksLayoutPanel.HorizontalScroll.Visible = false;
            tasksLayoutPanel.VerticalScroll.Visible = false;
            tasksLayoutPanel.AutoScroll = false;
        }

        private void Innit_CheckBoxPanel(int toDo_PannelHeight)
        {
            checkBoxLayoutPanel.Size = new Size(checkBoxPanelWidth, toDo_PannelHeight);

            checkBoxLayoutPanel.HorizontalScroll.Maximum = 0;
            checkBoxLayoutPanel.HorizontalScroll.Visible = false;
            checkBoxLayoutPanel.VerticalScroll.Visible = false;
            checkBoxLayoutPanel.AutoScroll = false;
        }

        private void Innit_TaskScrollBar(int toDo_PannelHeight)
        {
            tasksScrollBar.Size = new Size(16, toDo_PannelHeight);
        }

        private int CheckElementSize()
        {
            int labelHeight = labelElementHeight + 2 * labelElementMargin;
            int checkBoxHeight = checkBoxElementSize + 2 * checkBoxElementMargin;

            bool isEqual = labelHeight == checkBoxHeight;
            if (isEqual)
                return labelHeight;
            else
                return -1;
        }

        private void Innit_ToDoList()
        {
            int elementHeight = CheckElementSize();
            int toDoListHeight = maxTaskItemElementsCount * elementHeight;

            Innit_TasksPanel(toDoListHeight);
            Innit_CheckBoxPanel(toDoListHeight);
            Innit_TaskScrollBar(toDoListHeight);
        }

        private void Test_Tasks1()
        {
            string zdanie = "jan,papaj,III";
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
            Innit_ToDoList();
            Test_Tasks1();
        }

        private void taskAddButton_Click(object sender, EventArgs e)
        {
            taskItemsList.Add(CreateNewTaskElement());
        }

        private void tasksScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Point scrollPoint = new Point(0, tasksScrollBar.Value);

            tasksLayoutPanel.AutoScrollPosition = scrollPoint;
            checkBoxLayoutPanel.AutoScrollPosition = scrollPoint;
        }
    }
}
