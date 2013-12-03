using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlNumber : UserControl
    {
        int mBorderWidth;
        int mGap;
        bool mIsFloat;
        float mIncrement;

        [Description("Called when value is changed"), Category("CatAction")]
        public event EventHandler ValueChanged;

        // will apear in properties panel
        [DefaultValue(int.MinValue)]
        [Description("Minimum valid integer"), Category("Data")]
        public int MinInt
        {
            get { return textData.MinInt; }
            set { textData.MinInt = value;}
        }
        [DefaultValue(int.MaxValue)]
        [Description("Maximum valid integer"), Category("Data")]
        public int MaxInt
        {
            get { return textData.MaxInt; }
            set { textData.MaxInt = value; }
        }
        [DefaultValue(float.MinValue)]
        [Description("Minimum valid float"), Category("Data")]
        public float MinFloat
        {
            get { return textData.MinFloat; }
            set { textData.MinFloat = value;}
        }
        [DefaultValue(float.MaxValue)]
        [Description("Maximum valid float"), Category("Data")]
        public float MaxFloat
        {
            get { return textData.MaxFloat; }
            set { textData.MaxFloat = value; }
        }
        [Description("Text color when not valid"), Category("Data")]
        public Color ErrorColor
        {
            get { return textData.ErrorColor; }
            set { textData.ErrorColor = value; }
        }
        [Description("Text color when valid"), Category("Data")]
        public Color ValidColor
        {
            get { return textData.ValidColor; }
            set { textData.ValidColor = value; }
        }

        // true if entered number is valid
        public bool Valid
        {
            get { return textData.Valid; }
        }

        /*[Description("Get thr text box element"), Category("Data")]
        public ctlTextBox TextBox
        {
            get { return textData; }
        }*/

        [Description("Text box font"), Category("Data")]
        public Font TextFont
        {
            get { return textData.Font; }
            set { textData.Font = value; }
        }

        [DefaultValue(1)]
        [Description("Indicates the amount of increment/decrement when buttons are pressesd"), Category("Data")]
        public float Increment
        {
            get { return mIncrement; }
            set { mIncrement = value; }
        }

        [DefaultValue(2)]
        [Description("Width of border"), Category("Data")]
        public int BorderWidth
        {
            get { return mBorderWidth; }
            set { mBorderWidth = value; Invalidate(); }
        }

        [DefaultValue(1)]
        [Description("Horizontal gap between buttons and text"), Category("Data")]
        public int Gap
        {
            get { return mGap; }
            set { mGap = value; Invalidate(); }
        }

        [DefaultValue(false)]
        [Description("Indicates if the number is an integer or float"), Category("Data")]
        public bool IsFloat
        {
            get { return mIsFloat; }
            set { 
                mIsFloat = value;
                textData.ValueType = value ? ctlTextBox.EValueType.Float : ctlTextBox.EValueType.Int;
            }
        }

        [DefaultValue(0)]
        [Description("Set/Get current integer value"), Category("Data")]
        public int IntVal
        {
            get { return textData.IntVal; }
            set { textData.IntVal = value; }
        }

        [DefaultValue(0)]
        [Description("Set/Get current float value"), Category("Data")]
        public float FloatVal
        {
            get { return textData.FloatVal; }
            set { textData.FloatVal = value; }
        }

        [Description("Background color of inner buttons"), Category("Data")]
        public Color ButtonsColor
        {
            get { return buttMinus.BackColor; }
            set {
                buttMinus.BackColor = value;
                buttPlus.BackColor = value;
                textData.BackColor = value;
            }
        }

        public ctlNumber()
        {
            InitializeComponent();
            mBorderWidth = 2;
            mGap = 1;
            PlaceElements();
            mIsFloat = false;
            textData.ValueType = ctlTextBox.EValueType.Int;
            mIncrement = 1;
            PlaceElements();
        }

        protected void PlaceElements()
        {
            int w = Width;
            int h = Height;
            if ((w / h) < 3)
            {
                h = w / 3; 
            }
            int bs= h - 2 * mBorderWidth;
            buttMinus.Location = new Point(mBorderWidth, mBorderWidth);
            buttMinus.Width = buttMinus.Height = bs;
            buttPlus.Location = new Point(Width - bs - mBorderWidth, mBorderWidth);
            buttPlus.Width = buttPlus.Height = bs;
            textData.Location = new Point(bs + mBorderWidth + mGap, mBorderWidth);
            textData.Width = Width - 2 * (bs + mBorderWidth + mGap);
            textData.Height = bs;
        }

        private void ctlNumber_Resize(object sender, EventArgs e)
        {
            PlaceElements();
        }


        private void AdjustValue(float val)
        {
            if (mIsFloat)
            {
                float newfloat = textData.FloatVal + val;
                if (newfloat > textData.MaxFloat)
                    textData.FloatVal = textData.MaxFloat;
                else
                    textData.FloatVal = newfloat;
            }
            else
            {
                int newint = textData.IntVal + (int)Math.Round(val);
                if (newint > textData.MaxInt)
                    textData.IntVal = textData.MaxInt;
                else
                    textData.IntVal = newint;
            }
        }

        private void buttPlus_Click(object sender, EventArgs e)
        {
            AdjustValue(mIncrement);
        }

        private void buttMinus_Click(object sender, EventArgs e)
        {
            AdjustValue(-mIncrement);
        }

        private void textData_TextChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
    }
}
