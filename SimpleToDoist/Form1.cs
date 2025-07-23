using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleToDoist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int taskCounter = 1;

        private string getTaskDefinition()
        {
            bool isEmpty = taskInputBox.Text == "";
            if (isEmpty)
            {
                return null;
            }

            string taskDefinitionText =
                taskCounter.ToString() + "# " +
                taskInputBox.Text;
            
            return taskDefinitionText;
        }

        private Label createLabel()
        {
            Label newLabel = new Label();
            newLabel.Name = "taskDefinition_" + taskCounter.ToString();
            newLabel.Text = getTaskDefinition();

            return newLabel;
        }

        private CheckBox createCheckBox()
        {
            CheckBox newCheckBox = new CheckBox();
            newCheckBox.Name = "taskCheckBox_" + taskCounter.ToString();

            return newCheckBox;
        }

        private void createTask()
        {

        }

        private void taskAddButton_Click(object sender, EventArgs e)
        {


        }
    }
}
