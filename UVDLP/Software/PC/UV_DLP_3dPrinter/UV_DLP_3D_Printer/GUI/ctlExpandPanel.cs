using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace UV_DLP_3D_Printer.GUI
{
    public class ctlExpandPanel : System.Windows.Forms.FlowLayoutPanel
    {
        private const int STATE_CLOSED = 0;
        private const int STATE_OPEN = 1;
        private int state; // collapsed , 1= expanded
        Button cmdheader;
        public ctlExpandPanel() 
        {
            FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            cmdheader = new Button();
            cmdheader.Text = "+";
            cmdheader.Width = this.Width;
            cmdheader.Height = 25;
            cmdheader.Left = 0;
            cmdheader.Top = 0;
            cmdheader.Click += new EventHandler(cmdheader_Click);
            Controls.Add(cmdheader);
            state = STATE_CLOSED;
            
        }

        void cmdheader_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //expand or retract
            switch (state) 
            {
                case STATE_CLOSED:
                    state = STATE_OPEN;
                    this.Height = GetControlsHeight();
                    break;
                case STATE_OPEN:
                    state = STATE_CLOSED;
                    this.Height = cmdheader.Height;
                    break;
            }
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
    }
}
