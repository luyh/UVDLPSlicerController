using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace UV_DLP_3D_Printer.GUI
{
    public class ctlExpandPanel : System.Windows.Forms.FlowLayoutPanel
    {
        private const int STATE_CLOSED = 0;
        private const int STATE_OPEN = 1;
        private int state; // collapsed , 1= expanded
        //string title;
        Button cmdHeader;
        private Color m_opencolor = Color.Gray;
        private Color m_closecolor = Color.DarkGray;
        // this is called at runtime instantiation
        public ctlExpandPanel() 
        {
            InitializeComponent();
            BackColor = m_closecolor;

            cmdHeader = new Button();
            cmdHeader.Width = this.Width - 4;
            cmdHeader.BackColor = m_closecolor;
            cmdHeader.ForeColor = Color.White;
            cmdHeader.Height = 35;
            cmdHeader.Font = new System.Drawing.Font("Arial", 12);
            //cmdHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            cmdHeader.FlatStyle = FlatStyle.Flat;
            cmdHeader.FlatAppearance.BorderSize = 0;

            Controls.Add(cmdHeader);
            cmdHeader.Click += new System.EventHandler(cmdheader_Click);
            ctlExpandPanel_Resize(null, null);
            DoClose();
        }

        void ctlExpandPanel_Resize(object sender, EventArgs e)
        {            
            foreach (Control c in Controls)
            {
                c.Left = 4;
                c.Width = Width - 4;
            }
        }

        private int GetClosedHeight() 
        {
            return cmdHeader.Height + 5;
        }
        private int GetControlsHeight() 
        {
            int th = 0;
            foreach (Control c in Controls) 
            {
                th += c.Height;
            }
            th += th / 4;
            return th;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ctlExpandPanel
            // 
            this.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            //this.Margin = new System.Windows.Forms.Padding(8);
            
            this.ResumeLayout(false);

        }

        private void cmdheader_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case STATE_CLOSED:
                    DoOpen();
                    break;
                case STATE_OPEN:
                    DoClose();
                    break;
            }
        }

        private void DoOpen() 
        {
            state = STATE_OPEN;
            Height = GetControlsHeight();
            cmdHeader.Text = "-";
            cmdHeader.BackColor = m_opencolor;
        }
        private void DoClose() 
        {
            state = STATE_CLOSED;
            Height = GetClosedHeight();
            cmdHeader.Text = "+";
            cmdHeader.BackColor = m_closecolor;
        }

        private void ctlExpandPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
