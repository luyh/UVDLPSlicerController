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
            this.contextMenuSupport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdRemoveAllSupports = new System.Windows.Forms.ToolStripMenuItem();
            this.manipObject = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.treeScene = new System.Windows.Forms.TreeView();
            this.contextMenuObject.SuspendLayout();
            this.contextMenuSupport.SuspendLayout();
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
            // contextMenuSupport
            // 
            this.contextMenuSupport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdRemoveAllSupports});
            this.contextMenuSupport.Name = "contextMenuStrip2";
            this.contextMenuSupport.Size = new System.Drawing.Size(218, 28);
            // 
            // cmdRemoveAllSupports
            // 
            this.cmdRemoveAllSupports.Name = "cmdRemoveAllSupports";
            this.cmdRemoveAllSupports.Size = new System.Drawing.Size(217, 24);
            this.cmdRemoveAllSupports.Text = "Remove All Supports";
            this.cmdRemoveAllSupports.Click += new System.EventHandler(this.cmdRemoveAllSupports_Click);
            // 
            // manipObject
            // 
            this.manipObject.BackColor = System.Drawing.Color.Navy;
            this.manipObject.Controls.Add(this.lblTitle);
            this.manipObject.Controls.Add(this.treeScene);
            this.manipObject.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.manipObject.Location = new System.Drawing.Point(0, 0);
            this.manipObject.Name = "manipObject";
            this.manipObject.Size = new System.Drawing.Size(317, 321);
            this.manipObject.TabIndex = 21;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 17.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(304, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Scene Info";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeScene
            // 
            this.treeScene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeScene.BackColor = System.Drawing.Color.RoyalBlue;
            this.treeScene.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeScene.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeScene.ForeColor = System.Drawing.Color.White;
            this.treeScene.Location = new System.Drawing.Point(4, 34);
            this.treeScene.Name = "treeScene";
            this.treeScene.Size = new System.Drawing.Size(303, 256);
            this.treeScene.TabIndex = 1;
            this.treeScene.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeScene_NodeMouseClick);
            // 
            // ctlScene
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.manipObject);
            this.Name = "ctlScene";
            this.Size = new System.Drawing.Size(310, 321);
            this.contextMenuObject.ResumeLayout(false);
            this.contextMenuSupport.ResumeLayout(false);
            this.manipObject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel manipObject;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TreeView treeScene;
        private System.Windows.Forms.ContextMenuStrip contextMenuObject;
        private System.Windows.Forms.ToolStripMenuItem cmdRemoveObject;
        private System.Windows.Forms.ContextMenuStrip contextMenuSupport;
        private System.Windows.Forms.ToolStripMenuItem cmdRemoveAllSupports;

    }
}
