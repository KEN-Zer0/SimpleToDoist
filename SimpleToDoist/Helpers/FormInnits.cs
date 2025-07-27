using System.Drawing;
using System.Windows.Forms;
using static SimpleToDoist.AppConstants;

namespace SimpleToDoist
{
    public class FormInnits
    {
        private Panel _checkBoxPanel;
        private Panel _labelPanel;
        private VScrollBar _scrollBar;

        public Panel CheckBoxPanel
        {
            get { return _checkBoxPanel; }
            set
            {
                if (_checkBoxPanel == null) return;

                _checkBoxPanel = value;
            }
        }

        public Panel LabelPanel
        {
            get { return _labelPanel; }
            set
            {
                if (_labelPanel == null) return;

                _labelPanel = value;
            }
        }

        public VScrollBar ScrollBar
        {
            get { return _scrollBar; }
            set
            {
                if (_scrollBar == null) return;

                _scrollBar = value;
            }
        }

        // Custom innitializations
        private void Innit_TasksLabelPanel(int toDo_PannelHeight)
        {
            if(toDo_PannelHeight <= 0 || this.LabelPanel == null) return;
            this.LabelPanel.Size = new Size(labelPanelWidth, toDo_PannelHeight);

            this.LabelPanel.HorizontalScroll.Maximum = 0;
            this.LabelPanel.HorizontalScroll.Visible = false;
            this.LabelPanel.VerticalScroll.Visible = false;
            this.LabelPanel.AutoScroll = false;
        }

        private void Innit_TaskCheckBoxPanel(int toDo_PannelHeight)
        {
            if (toDo_PannelHeight <= 0 || this.CheckBoxPanel == null) return;
            this.CheckBoxPanel.Size = new Size(checkBoxPanelWidth, toDo_PannelHeight);

            this.CheckBoxPanel.HorizontalScroll.Maximum = 0;
            this.CheckBoxPanel.HorizontalScroll.Visible = false;
            this.CheckBoxPanel.VerticalScroll.Visible = false;
            this.CheckBoxPanel.AutoScroll = false;
        }

        private void Innit_TaskScrollBar(int toDo_PannelHeight)
        {
            if (toDo_PannelHeight <= 0 || this.ScrollBar == null) return;
            this.ScrollBar.Size = new Size(16, toDo_PannelHeight);
        }

        private static int CheckElementSize()
        {
            int labelHeight = labelElementHeight + 2 * labelElementMargin;
            int checkBoxHeight = checkBoxElementSize + 2 * checkBoxElementMargin;

            bool isEqual = labelHeight == checkBoxHeight;
            if (isEqual)
                return labelHeight;
            else
                return -1;
        }

        public void ConnetFormObjects(Panel labelPanel,
            Panel checkBoxPanel, VScrollBar scrollBar)
        {
            this.LabelPanel = labelPanel;
            this.CheckBoxPanel = checkBoxPanel;
            this.ScrollBar = scrollBar;
        }
        public static void Innit_ToDoList(FormInnits fromInnits)
        {
            int elementHeight = CheckElementSize();
            int toDoListHeight = maxTaskItemElementsCount * elementHeight;

            fromInnits.Innit_TasksLabelPanel(toDoListHeight);
            fromInnits.Innit_TaskCheckBoxPanel(toDoListHeight);
            fromInnits.Innit_TaskScrollBar(toDoListHeight);
        }
    }
}
