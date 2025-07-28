using SimpleToDoist.TasksCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SimpleToDoist.MyTests
{
    public class Tests : simpleToDoist
    {
        public static void Test_Tasks1(TextBox textBox, List<TaskItem> list,
            Func<TaskItem> newTaskElement)
        {
            string zdanie = "Testowy,task,utworzony,dla,testow";
            string[] slowa = zdanie.Split(',');

            foreach (string slowo in slowa)
            {
                textBox.Text = slowo;

                list.Add(newTaskElement());
            }
        }
    }
}
