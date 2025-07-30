using SimpleToDoist.TasksCreation;
using System;
using System.Collections.Generic;
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
            Label,
            CheckBox
        }

        public static void SaveTasks(List<TaskItem> taskList)
        {
            string saveDirecotryPath = Path.Combine(Application.StartupPath, tasksSavingDirectory);
            if (!Directory.Exists(saveDirecotryPath))
            {
                Directory.CreateDirectory(saveDirecotryPath);
            }

            string fileSavingPath = Path.Combine(saveDirecotryPath, taskSavingPath);
            if (!File.Exists(fileSavingPath))
            {
                File.Create(fileSavingPath);
            }

            if (!Directory.Exists(saveDirecotryPath) || !File.Exists(fileSavingPath)) return;

            // File clearing
            File.WriteAllText(fileSavingPath, "");

            foreach (TaskItem item in taskList)
            {
                string[] taskData = {
                    item.TaskIndex.ToString(),
                    item.TaskName,
                    item.TaskTitle,
                    item.TaskDescription,
                    item.TaskCompletion.ToString()
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

                string[] taskProperites = line.Split(';');

                int taskIndex = int.Parse(taskProperites[(int)taskPropertiesOrder.Index]);
                TaskItem item = new TaskItem(taskIndex);

                    item.TaskName = taskProperites[(int)taskPropertiesOrder.Name];
                    item.TaskTitle = taskProperites[(int)taskPropertiesOrder.Title];
                    item.TaskDescription = taskProperites[(int)taskPropertiesOrder.Description];
                    item.TaskCompletion = bool.Parse(taskProperites[(int)taskPropertiesOrder.Completion]);

                    item.CreateTaskLabel();
                    item.CreateTaskCheckBox();

                taskList.Add(item);
            }

            if(taskList.Count == 0) return null;
        
            return taskList;
        }
    }
}
