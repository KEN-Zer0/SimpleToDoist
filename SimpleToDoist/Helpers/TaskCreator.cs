using System;
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

        public DateTime TaskDueDate {  get; set; }
        public TimeSpan TaskRemainingTime;
        
        public void UpdateRemainingTime()
        {
            TaskRemainingTime = TaskDueDate - DateTime.Now;
        }

        private byte _taskPriority;
        public int TaskPriority 
        { 
            get { return _taskPriority; } 
            set
            {
                if(value < minTaskPriority || value > maxTaskPriority) return;
                _taskPriority = (byte)value;
            }
        }
        public string TaskCategory { get; set; }
        public Color TaskLabelColor { get; set; }

        private bool _taskCompletion;

        public Label TaskLabel;
        public CheckBox TaskCheckBox;

        // Properites Creation
        public int TaskIndex
        {
            get { return _taskIndex; }
            set
            {
                bool isNegative = value < 0;
                if (isNegative)
                {
                    // move to main code to not-stop test taking
                    //MessageBox.Show($"Error index {_taskIndex} is negative"); 
                    return;
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
                    // move to main code to not-stop test taking
                    //MessageBox.Show($"Error Task Name is empty", "Info", MessageBoxButtons.OK, MessageBoxIcon.None); 
                    _taskName = "";

                    return;
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
                    _taskTitle = "";
                    // move to main code to not-stop test taking
                    //MessageBox.Show($"Error Task Name is empty");
                    return;
                }
                _taskTitle = value.Trim();
            }
        }

        public ToolTip TaskLabelToolTip { get; set; }

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

        // Constructor
        public TaskItem(int taskId)
        {
            if (taskId < 0)
            {
                _taskIndex = -1;
                _taskName = "";
                return;
            }

            TaskIndex = taskId;
            TaskName = newTaskName + TaskIndex.ToString();
            TaskCompletion = false;
        }

        public bool ValidateTaskParams()
        {
            bool isIndexInvalid = TaskIndex < 0;
            bool isNameInvalid = string.IsNullOrWhiteSpace(TaskName);
            bool isTitleInvalid = string.IsNullOrWhiteSpace(TaskTitle);

            if (isIndexInvalid || isNameInvalid || isTitleInvalid) 
                return false;

            return true;
        }

        // Task moving
        public void CopyTaskPropertiesFrom(TaskItem other)
        {
            this.TaskName = other.TaskName;
            this.TaskTitle = other.TaskTitle;
            this.TaskDescription = other.TaskDescription;
            this.TaskCompletion = other.TaskCompletion;
            
            this.TaskDueDate = other.TaskDueDate;


            this.TaskLabel.Text = other.TaskLabel.Text;
            this.TaskLabelToolTip = other.TaskLabelToolTip;
            this.TaskCheckBox.Checked = other.TaskCheckBox.Checked;
        }

        // Creating Task-Form Elements
        public void CreateTaskLabel()
        {
            Label newTaskLabel = new Label();

            newTaskLabel.Name = TaskName + newTaskLabelName;
            newTaskLabel.Text = SetTaskLabel_Text();

            newTaskLabel.AutoEllipsis = true;
            newTaskLabel.AutoSize = false;
            newTaskLabel.TextAlign = ContentAlignment.MiddleLeft;

            newTaskLabel.Margin = new Padding(0, labelElementMargin, 0, labelElementMargin);
            newTaskLabel.Size = new Size(labelElementWidth, labelElementHeight);

            CreateTaskLabelEvents(newTaskLabel);

            newTaskLabel.Tag = this;
            this.TaskLabel = newTaskLabel;

            TaskLabelToolTip = CreateToolTip_TaskLabel();
        }

        private void CreateTaskLabelEvents(Label label)
        {
            label.Click += (s, e) =>
            {
                UpdateRemainingTime();

                string msg = TaskCategory + "\n\n" + 
                SetToolTipText() + "\n\n" +
                "Due to: " + TaskDueDate.ToString(@"HH\:mm") + "\n" +
                "Time left: " + TaskRemainingTime.ToString(@"HH\:mm\:ss");
                MessageBox.Show(msg, "Task Description");
            };

            label.MouseEnter += (s, e) =>
            {
                if(TaskLabelColor != null)
                {
                    label.BackColor = TaskLabelColor;
                } 
                else
                {
                    label.BackColor = Color.FromArgb(50, 255, 255, 255);
                }
            };

            label.MouseLeave += (s, e) =>
            {
                label.BackColor = Color.Transparent;
            };
        }

        private ToolTip CreateToolTip_TaskLabel()
        {
            ToolTip toolTip = new ToolTip();

            if (TaskLabel == null) return null;

            string toolTipText = SetToolTipText();
            if (toolTipText == null) return null;
            toolTip.SetToolTip(TaskLabel, toolTipText);

            toolTip.Active = true;
            toolTip.AutoPopDelay = 30000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            return toolTip;
        }

        private string SetToolTipText()
        {
            if(TaskDescription == null) return null;
            string toolTipText = "Description:\n" + TaskDescription;

            return toolTipText;
        }

        public void UpdateTaskLabel()
        {
            Label currentLabel = TaskLabel;

            currentLabel.Tag = this;
            currentLabel.Text = SetTaskLabel_Text();
        }

        private string SetTaskLabel_Text()
        {
            return (TaskIndex + 1).ToString() +
                numberDelimiter + ' ' + TaskTitle;
        }

        public void CreateTaskCheckBox()
        {
            CheckBox newTaskCheckBox = new CheckBox();

            newTaskCheckBox.Name = TaskName + newTaskCheckBoxName;
            newTaskCheckBox.Text = null;
            newTaskCheckBox.Checked = TaskCompletion;

            newTaskCheckBox.Size = new Size(checkBoxElementSize, checkBoxElementSize);
            newTaskCheckBox.Margin = new Padding(0, checkBoxElementMargin, 0, checkBoxElementMargin);

            newTaskCheckBox.Tag = this;
            this.TaskCheckBox = newTaskCheckBox;
        }

    }
}
