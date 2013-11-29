using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
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
        protected Color mErrColor;
        protected Color mValidColor;
        protected String mErrMsg;

        public int IntVal
        {
            get 
            {
                if (mErrMsg != null) throw new Exception(mErrMsg);
                return mIntVal; 
            }
            set { mIntVal = value; Text = mIntVal.ToString(); }
        }

        public float FloatVal
        {
            get {
                if (mErrMsg != null) throw new Exception(mErrMsg);
                return mFloatVal;
            }
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
        [Description("Text color when not valid"), Category("Data")]
        public Color ErrorColor
        {
            get { return mErrColor; }
            set { mErrColor = value; }
        }
        [Description("Text color when valid"), Category("Data")]
        public Color ValidColor
        {
            get { return mValidColor; }
            set { mValidColor = value; }
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
            mErrColor = Color.Red;
            mValidColor = Color.White;
            mErrMsg = null;
        }

        protected bool ValidateInt()
        {
            try
            {
                int newval = int.Parse(Text);
                if ((newval < mIntMin) || (newval > mIntMax))
                {
                    mErrMsg = "Integer number out of range (" + MinInt + " to " + mIntMax + ")";  
                    return false;
                }
                mIntVal = newval;
            }
            catch (Exception) 
            {
                mErrMsg = "Invalid integer number";
                return false;
            }
            mErrMsg = null;
            return true;
        }

        protected bool ValidateFloat()
        {
            try
            {
                float newval = float.Parse(Text);
                if ((newval < mFloatMin) || (newval > mFloatMax))
                {
                    mErrMsg = "Real number out of range (" + mFloatMin + " to " + mFloatMax + ")";
                    return false;
                }
                mFloatVal = newval;
            }
            catch (Exception) 
            {
                mErrMsg = "Invalid integer number";
                return false;
            }
            mErrMsg = null;
            return true;
        }

        protected void ValidateVal()
        {
            bool valOK = true;
            switch (mValType)
            {
                case EValueType.Int:
                    valOK = ValidateInt();
                    break;

                case EValueType.Float:
                    valOK = ValidateFloat();
                    break;
            }
            if (valOK)
                ForeColor = mValidColor;
            else
                ForeColor = mErrColor;
        }


        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            ValidateVal();
        }
    }
}
