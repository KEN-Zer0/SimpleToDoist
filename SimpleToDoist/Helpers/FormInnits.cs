using System.Drawing;
using System.Windows.Forms;
using static SimpleToDoist.AppConstants;

namespace SimpleToDoist
{
    public class FormInnits
    {
        private Panel _mainContainerPanel;
        private Panel _innerPannel;
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

        public Panel MainContainerPanel
        {
            get { return _mainContainerPanel; }
            set
            {
                if (_mainContainerPanel == null) return;

                _mainContainerPanel = value;
            }
        }

        public Panel InnerPannel
        {
            get { return _innerPannel; }
            set
            {
                if (_innerPannel == null) return;

                _innerPannel = value;
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
        private void Innit_MainContainerPanel()
        {
            MainContainerPanel = new Panel();
            if (_mainContainerPanel == null) return;

            MainContainerPanel.Dock = DockStyle.Fill;
            MainContainerPanel.AutoScroll = true;
            MainContainerPanel.AutoSize = true;
            MainContainerPanel.Visible = true;
            MainContainerPanel.BackColor = Color.FromArgb(255,0,0);

        }

        private void Innit_InnerPannel()
        {
            InnerPannel = new Panel();
            if (_innerPannel ==null) return;

            InnerPannel.Dock = DockStyle.Top;
            InnerPannel.AutoSize = true;
            InnerPannel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            InnerPannel.BackColor = Color.Transparent;

            if(_mainContainerPanel ==null) return;
            MainContainerPanel.Controls.Add(InnerPannel);
        }

        private void Innit_TasksLabelPanel(int toDo_PannelHeight)
        {
            if (toDo_PannelHeight <= 0 || this.LabelPanel == null) return;
            this.LabelPanel.Size = new Size(labelPanelWidth, toDo_PannelHeight);

            this.LabelPanel.Size = new Size(286, 190);
            this.LabelPanel.HorizontalScroll.Maximum = 0;
            this.LabelPanel.HorizontalScroll.Visible = false;
            this.LabelPanel.VerticalScroll.Visible = false;
            this.LabelPanel.AutoScroll = false;

            if(_innerPannel == null) return;
            _innerPannel.Controls.Add(this.LabelPanel);
        }

        private void Innit_TaskCheckBoxPanel(int toDo_PannelHeight)
        {
            if (toDo_PannelHeight <= 0 || this.CheckBoxPanel == null) return;
            this.CheckBoxPanel.Size = new Size(checkBoxPanelWidth, toDo_PannelHeight);

            this.CheckBoxPanel.HorizontalScroll.Maximum = 0;
            this.CheckBoxPanel.HorizontalScroll.Visible = false;
            this.CheckBoxPanel.VerticalScroll.Visible = false;
            this.CheckBoxPanel.AutoScroll = false;

            if (_innerPannel == null) return;
            _innerPannel.Controls.Add(this.CheckBoxPanel);
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
            Panel checkBoxPanel)
        {
            this.LabelPanel = labelPanel;
            this.CheckBoxPanel = checkBoxPanel;
        }
        public static void Innit_ToDoList(FormInnits formInnits)
        {
            int elementHeight = CheckElementSize();
            int toDoListHeight = maxTaskItemElementsCount * elementHeight;

            formInnits.Innit_MainContainerPanel();
            formInnits.Innit_InnerPannel();
            formInnits.Innit_TasksLabelPanel(toDoListHeight);
            formInnits.Innit_TaskCheckBoxPanel(toDoListHeight);
            //formInnits.Innit_TaskScrollBar(toDoListHeight);
        }
    }
}
