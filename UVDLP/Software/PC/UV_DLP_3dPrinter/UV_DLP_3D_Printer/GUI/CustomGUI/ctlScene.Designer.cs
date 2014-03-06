namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    partial class ctlScene
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuObject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdRemoveObject = new System.Windows.Forms.ToolStripMenuItem();
            this.manipObject = new System.Windows.Forms.FlowLayoutPanel();
            this.treeScene = new System.Windows.Forms.TreeView();
            this.ctlTitle1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlTitle();
            this.contextMenuObject.SuspendLayout();
            this.manipObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuObject
            // 
            this.contextMenuObject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdRemoveObject});
            this.contextMenuObject.Name = "contextMenuStrip1";
            this.contextMenuObject.Size = new System.Drawing.Size(181, 28);
            // 
            // cmdRemoveObject
            // 
            this.cmdRemoveObject.Name = "cmdRemoveObject";
            this.cmdRemoveObject.Size = new System.Drawing.Size(180, 24);
            this.cmdRemoveObject.Text = "Remove Object";
            this.cmdRemoveObject.Click += new System.EventHandler(this.cmdRemoveObject_Click);
            // 
            // manipObject
            // 
            this.manipObject.BackColor = System.Drawing.Color.Navy;
            this.manipObject.Controls.Add(this.ctlTitle1);
            this.manipObject.Controls.Add(this.treeScene);
            this.manipObject.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.manipObject.Location = new System.Drawing.Point(0, 0);
            this.manipObject.Name = "manipObject";
            this.manipObject.Size = new System.Drawing.Size(238, 318);
            this.manipObject.TabIndex = 21;
            // 
            // treeScene
            // 
            this.treeScene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeScene.BackColor = System.Drawing.Color.RoyalBlue;
            this.treeScene.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeScene.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeScene.ForeColor = System.Drawing.Color.White;
            this.treeScene.Location = new System.Drawing.Point(5, 54);
            this.treeScene.Name = "treeScene";
            this.treeScene.Size = new System.Drawing.Size(222, 256);
            this.treeScene.TabIndex = 1;
            this.treeScene.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeScene_NodeMouseClick);
            // 
            // ctlTitle1
            // 
            this.ctlTitle1.Checked = false;
            this.ctlTitle1.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.ctlTitle1.Gapx = 0;
            this.ctlTitle1.Gapy = 0;
            this.ctlTitle1.GLBackgroundImage = null;
            this.ctlTitle1.GLVisible = false;
            this.ctlTitle1.GuiAnchor = null;
            this.ctlTitle1.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttOinfo;
            this.ctlTitle1.Location = new System.Drawing.Point(3, 3);
            this.ctlTitle1.Name = "ctlTitle1";
            this.ctlTitle1.Size = new System.Drawing.Size(224, 45);
            this.ctlTitle1.StyleName = null;
            this.ctlTitle1.TabIndex = 2;
            this.ctlTitle1.Text = "Scene";
            this.ctlTitle1.Click += new System.EventHandler(this.ctlTitle1_Click);
            // 
            // ctlScene
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.manipObject);
            this.Name = "ctlScene";
            this.Size = new System.Drawing.Size(235, 52);
            this.contextMenuObject.ResumeLayout(false);
            this.manipObject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel manipObject;
        private System.Windows.Forms.TreeView treeScene;
        private System.Windows.Forms.ContextMenuStrip contextMenuObject;
        private System.Windows.Forms.ToolStripMenuItem cmdRemoveObject;
        private ctlTitle ctlTitle1;

    }
}
