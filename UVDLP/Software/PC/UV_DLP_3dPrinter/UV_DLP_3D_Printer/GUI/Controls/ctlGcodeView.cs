using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlGcodeView : UserControl
    {
        public ctlGcodeView()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return txtGCode.Text;
            }
            set
            {
                txtGCode.Text = value;
            }
        }

        private void buttConfig_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "GCode Files(*.gcode)|*.gcode|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    UVDLPApp.Instance().LoadGCode(openFileDialog1.FileName);
                    // txtGCode.Text = UVDLPApp.Instance().m_gcode.RawGCode;
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        private void ctlImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // get the gcode from the textbox, save it...
                    UVDLPApp.Instance().m_gcode.RawGCode = txtGCode.Text;
                    UVDLPApp.Instance().SaveGCode(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

    }
}
