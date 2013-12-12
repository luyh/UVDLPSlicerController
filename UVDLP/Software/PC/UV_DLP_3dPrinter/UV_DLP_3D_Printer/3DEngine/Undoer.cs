using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UV_DLP_3D_Printer;
using UV_DLP_3D_Printer.GUI.CustomGUI;

namespace Engine3D
{
    public class Undoer
    {
        protected enum eOperationType
        {
            Translate = 0,
            Scale,
            Rotate,
            AbsLocation,
            Add,
            Del
        }

        protected class UndoItem
        {
            public Object3d obj;
            public eOperationType opType;
            public double x, y, z;
        }

        List<UndoItem> m_undoItemList;
        ctlImageButton m_undoButt = null;

        public Undoer()
        {
            m_undoItemList = new List<UndoItem>();
        }

        protected void AddItem(eOperationType type, Object3d obj, double x, double y, double z)
        {
            if (obj == null)
                return;
            UndoItem item = new UndoItem();
            item.opType = type;
            item.obj = obj;
            item.x = x;
            item.y = y;
            item.z = z;
            m_undoItemList.Add(item);
            UpdateButton();
        }

        public void SaveTranslation(Object3d obj, double x, double y, double z)
        {
            if ((x == 0) && (y == 0) && (z == 0))
                return;
            AddItem(eOperationType.Translate, obj, -x, -y, -z);
        }

        public void SaveLocation(Object3d obj, double x, double y, double z)
        {
            if ((x == obj.m_center.x) && (y == obj.m_center.y) && (z == obj.m_center.z))
                return;
            AddItem(eOperationType.AbsLocation, obj, x, y, z);
        }

        public void SaveRotation(Object3d obj, double x, double y, double z)
        {
            if ((x == 0) && (y == 0) && (z == 0))
                return;
            AddItem(eOperationType.Rotate, obj, -x, -y, -z);
        }

        public void SaveScale(Object3d obj, double x, double y, double z)
        {
            if ((x == 1) && (y == 1) && (z == 1))
                return;
            if ((x != 0) && (y != 0) && (z != 0)) 
                AddItem(eOperationType.Scale, obj, 1/x, 1/y, 1/z);
        }

        public void SaveAddition(Object3d obj)
        {
            AddItem(eOperationType.Add, obj, 0, 0, 0);
        }

        public void SaveDelition(Object3d obj)
        {
            AddItem(eOperationType.Del, obj, 0, 0, 0);
        }

        public void Undo()
        {
            int count = m_undoItemList.Count;
            if (count == 0)
                return;

            UndoItem item = m_undoItemList[count - 1];
            m_undoItemList.RemoveAt(count - 1);
            switch (item.opType)
            {
                case eOperationType.Translate:
                    item.obj.Translate((float)item.x, (float)item.y, (float)item.z);
                    break;

                case eOperationType.Rotate:
                    item.obj.Rotate((float)item.x, (float)item.y, (float)item.z);
                    break;

                case eOperationType.Scale:
                    item.obj.Scale((float)item.x, (float)item.y, (float)item.z);
                    break;

                case eOperationType.AbsLocation:
                    item.obj.Translate((float)item.x - item.obj.m_center.x,
                        (float)item.y - item.obj.m_center.y, (float)item.z - item.obj.m_center.z);
                    break;

                case eOperationType.Add:
                    UVDLPApp.Instance().m_engine3d.RemoveObject(item.obj);
                    break;

                case eOperationType.Del:
                    UVDLPApp.Instance().m_engine3d.AddObject(item.obj);
                    break;

            }
            item.obj.Update();
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            UpdateButton();
        }

        public void AsociateButton(ctlImageButton butt)
        {
            m_undoButt = butt;
            m_undoButt.Click += new EventHandler(m_undoButt_Click);
            UpdateButton();
        }

        protected void UpdateButton()
        {
            if (m_undoButt == null)
                return;
            m_undoButt.Enabled = m_undoItemList.Count != 0;
        }

        void m_undoButt_Click(object sender, EventArgs e)
        {
            Undo();
        }

        public bool isEmpty()
        {
            return m_undoItemList.Count == 0;
        }


    }
}
