using SimpleToDoist.TasksCreation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using static SimpleToDoist.AppConstants;

namespace SimpleToDoist
{
    public class TaskSaving
    {
        private enum taskPropertiesOrder
        {
            Index = 0,
            Name,
            Title,
            Description,
            Completion,
            DueDate,
            Priority,
            Category,
            LabelColor
        }

        public static void SaveTasks(List<TaskItem> taskList)
        {
            string saveDirecotryPath = Path.Combine(Application.StartupPath, tasksSavingDirectory);
            if (!Directory.Exists(saveDirecotryPath))
            {
                Directory.CreateDirectory(saveDirecotryPath);
            }

            string fileSavingPath = Path.Combine(saveDirecotryPath, taskSavingPath);
            File.WriteAllText(fileSavingPath, "");

            if (!Directory.Exists(saveDirecotryPath) || !File.Exists(fileSavingPath)) return;

            foreach (TaskItem item in taskList)
            {
                string[] taskData = {
                    item.TaskIndex.ToString(),
                    item.TaskName,
                    item.TaskTitle,
                    item.TaskDescription,
                    item.TaskCompletion.ToString(),
                    item.TaskDueDate.ToString(),
                    item.TaskPriority.ToString(),
                    item.TaskCategory,
                    item.TaskLabelColor.ToArgb().ToString(),
                };

                foreach (string data in taskData)
                {
                    try
                    {
                        File.AppendAllText(fileSavingPath, data + ';');
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File savig error:\n" + ex.Message);
                    }
                }

                try
                {
                    File.AppendAllText(fileSavingPath, "\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File savig error:\n" + ex.Message);
                }
            }
        }

        public static List<TaskItem> ReadTasks()
        {
            string saveDirecotryPath = Path.Combine(Application.StartupPath, tasksSavingDirectory);
            string readingFrom = Path.Combine(saveDirecotryPath, taskSavingPath);
            //MessageBox.Show(readingFrom);

            List<TaskItem> taskList = new List<TaskItem>();

            foreach (string line in File.ReadAllLines(readingFrom))
            {
                if (line == null || line == "") break;

                string[] props = line.Split(';');

                int taskIndex = int.Parse(props[(int)taskPropertiesOrder.Index]);
                TaskItem item = new TaskItem(taskIndex);

                item.TaskName = props[(int)taskPropertiesOrder.Name];
                item.TaskTitle = props[(int)taskPropertiesOrder.Title];
                item.TaskDescription = props[(int)taskPropertiesOrder.Description];
                item.TaskCompletion = bool.Parse(props[(int)taskPropertiesOrder.Completion]);
                item.TaskDueDate = DateTime.Parse(props[(int)taskPropertiesOrder.DueDate]);
                item.TaskPriority = int.Parse(props[(int)taskPropertiesOrder.Priority]);
                item.TaskCategory = props[(int)taskPropertiesOrder.Category];
                item.TaskLabelColor = Color.FromArgb(int.Parse(props[(int)taskPropertiesOrder.LabelColor]));


                item.CreateTaskLabel();
                item.CreateTaskCheckBox();

                taskList.Add(item);
            }

            if(taskList.Count == 0) return null;
        
            return taskList;
        }
    }
}
