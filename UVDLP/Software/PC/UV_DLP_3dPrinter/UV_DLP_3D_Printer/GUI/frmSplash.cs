using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmSplash : Form
    {
        Timer m_timer;
        private int m_total = 0;
        int max = 100;
        public frmSplash()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            version.Parent = pictureBox1;
            version.BackColor = Color.Transparent;
            m_timer = new Timer();
            m_timer.Interval = 20;
            m_timer.Tick += new EventHandler(m_timer_Tick);
            m_timer.Start();
            version.Text = "Version " + Application.ProductVersion;
            Opacity = 0.0;
        }

        void m_timer_Tick(object sender, EventArgs e)
        {
            try
            {                
                if (m_total >= max)
                {
                    m_timer.Stop();
                    Close();
                    return;
                }
                
                if (m_total > (max - 5))
                {
                    this.Opacity -= .2;
                }

                if (m_total < 6)
                {
                    this.Opacity += .2;
                }
                m_total++;
                progressBar1.Value++;
                //throw new NotImplementedException();
                //move the progress bsar
            }
            catch (Exception ex) 
            {
                m_timer.Stop();
                DebugLogger.Instance().LogError(ex.Message);
                Close();
            }
        }
    }
}
