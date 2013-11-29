using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public class ctlTextBox :TextBox
    {
        public enum EValueType
        {
            None,
            String,
            Int,
            Float
        }

        protected int mIntVal, mIntMin, mIntMax;
        protected float mFloatVal, mFloatMin, mFloatMax;
        protected EValueType mValType;

        public int IntVal
        {
            get { return mIntVal; }
            set { mIntVal = value; Text = mIntVal.ToString(); }
        }

        public float FloatVal
        {
            get { return mFloatVal; }
            set { mFloatVal = value; Text = mFloatVal.ToString(); }
        }


        // will apear in properties panel
        [Description("Auto input validation value type"), Category("Data")]
        public EValueType ValueType
        {
            get { return mValType; }
            set { mValType = value; ValidateVal(); }
        }
        [Description("Minimum valid integer"), Category("Data")]
        public int MinInt
        {
            get { return mIntMin; }
            set { mIntMin = value; ValidateVal(); }
        }
        [Description("Maximum valid integer"), Category("Data")]
        public int MaxInt
        {
            get { return mIntMax; }
            set { mIntMax = value; ValidateVal(); }
        }
        [Description("Minimum valid float"), Category("Data")]
        public float MinFloat
        {
            get { return mFloatMin; }
            set { mFloatMin = value; ValidateVal(); }
        }
        [Description("Maximum valid float"), Category("Data")]
        public float MaxFloat
        {
            get { return mFloatMax; }
            set { mFloatMax = value; ValidateVal(); }
        }


        public ctlTextBox()
        {
            mValType = EValueType.None;
            mIntVal = 0;
            mFloatVal = 0;
            mIntMax = int.MaxValue;
            mIntMin = int.MinValue;
            mFloatMax = float.MaxValue;
            mFloatMin = float.MinValue;
            AutoSize = false;
            Height = 28;
        }

        protected void ValidateInt()
        {
            try
            {
                int newval = int.Parse(Text);
                if (newval < mIntMin)
                    mIntVal = mIntMin;
                else if (newval > mIntMax)
                    mIntVal = mIntMax;
                else mIntVal = newval;
            }
            catch (Exception) { }
        }

        protected void ValidateFloat()
        {
            try
            {
                float newval = float.Parse(Text);
                if (newval < mFloatMin)
                    mFloatVal = mFloatMin;
                else if (newval > mFloatMax)
                    mFloatVal = mFloatMax;
                else mFloatVal = newval;
            }
            catch (Exception) { }
        }

        protected void ValidateVal()
        {
            switch (mValType)
            {
                case EValueType.Int:
                    ValidateInt();
                    break;

                case EValueType.Float:
                    ValidateFloat();
                    break;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            switch (mValType)
            {
                case EValueType.Int:
                    Text = mIntVal.ToString();
                    break;

                case EValueType.Float:
                    Text = mFloatVal.ToString();
                    break;
            }
            base.OnMouseLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            ValidateVal();
        }
    }
}
