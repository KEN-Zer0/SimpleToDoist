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
        
        private int taskCounter = 1;
        private List<TaskItem> taskItemsList = new List<TaskItem>();

        // Creating Tasks
        private TaskItem CreateTask()
        {
            TaskItem newTask = new TaskItem(taskCounter);
            SetTaskTitle(newTask);
            return newTask;
        }

        // czy to jest zgodne z konwencja
        private void SetTaskTitle(TaskItem taskToSet)
        {
            string taskFetchedTitle = taskInputBox.Text;
            taskToSet.TaskTitle = taskFetchedTitle;
        }

        private TaskItem CreateTaskItemElemnts()
        {
            TaskItem newTaskItem = CreateTask();
            newTaskItem.CreateTaskLabel();
            newTaskItem.CreateTaskCheckBox();

            CreateTaskItem(newTaskItem);
        
            return newTaskItem;
        }

        // Create task instance on form
        private void CreateTaskItem(TaskItem newTaskItem)
        {
            
            tasksLayoutPanel.Controls.Add(newTaskItem.taskLabel);
            checkBoxLayoutPanel.Controls.Add(newTaskItem.taskCheckBox);

            taskCounter++;
        }

        // Tasks counting
        private void CheckTasksAmount()
        {
            if (taskCounter < 0)
            {
                Console.WriteLine("Error in tasks counting");
                this.Close();

                return;
            }

            if (taskCounter == 0)
            {
                MessageBox.Show("You're done with your tasks!");
                this.Close();
            }
            else if (taskCounter > maxTaskItemElementsCount)
            {
                tasksScrollBar.Visible = true;
                tasksScrollBar.Enabled = true;
                tasksScrollBar.Maximum = taskCounter;
            }
            else if (taskCounter <= maxTaskItemElementsCount)
            {
                tasksScrollBar.Visible = false;
                tasksScrollBar.Enabled = false;
                tasksScrollBar.Maximum = maxTaskItemElementsCount;
                tasksScrollBar.Value = 1;
            }

        }

        // Custom innitializations
        private void InnitTasksPanel(int toDo_PannelHeight)
        {
            tasksLayoutPanel.Size = new Size(labelPanelWidth, toDo_PannelHeight);

            tasksLayoutPanel.HorizontalScroll.Maximum = 0;
            tasksLayoutPanel.HorizontalScroll.Visible = false;
            tasksLayoutPanel.VerticalScroll.Visible = false;
            tasksLayoutPanel.AutoScroll = false;
        }

        private void InnitCheckBoxPanel(int toDo_PannelHeight)
        {
            checkBoxLayoutPanel.Size = new Size(checkBoxPanelWidth, toDo_PannelHeight);

            checkBoxLayoutPanel.HorizontalScroll.Maximum = 0;
            checkBoxLayoutPanel.HorizontalScroll.Visible = false;
            checkBoxLayoutPanel.VerticalScroll.Visible = false;
            checkBoxLayoutPanel.AutoScroll = false;
        }

        private void InnitTaskScrollBar(int toDo_PannelHeight)
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

        private void InnitToDoList()
        {
            int elementHeight = CheckElementSize();
            int toDoListHeight = maxTaskItemElementsCount * elementHeight;

            InnitTasksPanel(toDoListHeight);
            InnitCheckBoxPanel(toDoListHeight);
            InnitTaskScrollBar(toDoListHeight);
        }


        // *******************************
        // * MAIN FUNCTIONS
        // *******************************
        private void simpleToDoist_Load(object sender, EventArgs e)
        {
            InnitToDoList();
        }

        private void taskAddButton_Click(object sender, EventArgs e)
        {
            taskItemsList.Add(CreateTaskItemElemnts());
            CheckTasksAmount();
        }

        private void tasksScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Point scrollPoint = new Point(0, tasksScrollBar.Value);

            tasksLayoutPanel.AutoScrollPosition = scrollPoint;
            checkBoxLayoutPanel.AutoScrollPosition = scrollPoint;
        }


    }
}
