namespace TidyMyFolder
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvTargetDirectory = new System.Windows.Forms.TreeView();
            this.tbSelectedFolder = new System.Windows.Forms.TextBox();
            this.btSearchSimilar = new System.Windows.Forms.Button();
            this.tvDestinationDirectory = new System.Windows.Forms.TreeView();
            this.clbSearchResult = new System.Windows.Forms.CheckedListBox();
            this.btMoveFolder = new System.Windows.Forms.Button();
            this.btRefreshTargetNode = new System.Windows.Forms.Button();
            this.btRefreshDestination = new System.Windows.Forms.Button();
            this.btMoveFromTargetToDest = new System.Windows.Forms.Button();
            this.btOpenFolder = new System.Windows.Forms.Button();
            this.btOpenDestFolder = new System.Windows.Forms.Button();
            this.cmsTreeViewControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btOpenSearchFolder = new System.Windows.Forms.Button();
            this.btTargetFolderDelete = new System.Windows.Forms.Button();
            this.cmsTreeViewControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvTargetDirectory
            // 
            this.tvTargetDirectory.FullRowSelect = true;
            this.tvTargetDirectory.Location = new System.Drawing.Point(14, 14);
            this.tvTargetDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tvTargetDirectory.Name = "tvTargetDirectory";
            this.tvTargetDirectory.Size = new System.Drawing.Size(436, 560);
            this.tvTargetDirectory.TabIndex = 0;
            this.tvTargetDirectory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTargetDirectory_AfterSelect);
            this.tvTargetDirectory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDestinationDirectory_NodeMouseClick);
            this.tvTargetDirectory.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvTargetDirectory_BeforeSelect);
            // 
            // tbSelectedFolder
            // 
            this.tbSelectedFolder.Location = new System.Drawing.Point(457, 362);
            this.tbSelectedFolder.Name = "tbSelectedFolder";
            this.tbSelectedFolder.Size = new System.Drawing.Size(253, 23);
            this.tbSelectedFolder.TabIndex = 1;
            // 
            // btSearchSimilar
            // 
            this.btSearchSimilar.Location = new System.Drawing.Point(716, 361);
            this.btSearchSimilar.Name = "btSearchSimilar";
            this.btSearchSimilar.Size = new System.Drawing.Size(75, 23);
            this.btSearchSimilar.TabIndex = 2;
            this.btSearchSimilar.Text = "search";
            this.btSearchSimilar.UseVisualStyleBackColor = true;
            this.btSearchSimilar.Click += new System.EventHandler(this.btSearchSimilar_Click);
            // 
            // tvDestinationDirectory
            // 
            this.tvDestinationDirectory.Location = new System.Drawing.Point(457, 14);
            this.tvDestinationDirectory.Name = "tvDestinationDirectory";
            this.tvDestinationDirectory.Size = new System.Drawing.Size(496, 315);
            this.tvDestinationDirectory.TabIndex = 3;
            this.tvDestinationDirectory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTargetDirectory_AfterSelect);
            this.tvDestinationDirectory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDestinationDirectory_NodeMouseClick);
            this.tvDestinationDirectory.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvTargetDirectory_BeforeSelect);
            // 
            // clbSearchResult
            // 
            this.clbSearchResult.CheckOnClick = true;
            this.clbSearchResult.FormattingEnabled = true;
            this.clbSearchResult.HorizontalScrollbar = true;
            this.clbSearchResult.Location = new System.Drawing.Point(457, 390);
            this.clbSearchResult.Name = "clbSearchResult";
            this.clbSearchResult.Size = new System.Drawing.Size(496, 184);
            this.clbSearchResult.TabIndex = 4;
            // 
            // btMoveFolder
            // 
            this.btMoveFolder.Location = new System.Drawing.Point(797, 361);
            this.btMoveFolder.Name = "btMoveFolder";
            this.btMoveFolder.Size = new System.Drawing.Size(75, 23);
            this.btMoveFolder.TabIndex = 5;
            this.btMoveFolder.Text = "move";
            this.btMoveFolder.UseVisualStyleBackColor = true;
            this.btMoveFolder.Click += new System.EventHandler(this.btMoveFolder_Click);
            // 
            // btRefreshTargetNode
            // 
            this.btRefreshTargetNode.Location = new System.Drawing.Point(12, 580);
            this.btRefreshTargetNode.Name = "btRefreshTargetNode";
            this.btRefreshTargetNode.Size = new System.Drawing.Size(75, 23);
            this.btRefreshTargetNode.TabIndex = 6;
            this.btRefreshTargetNode.Text = "refresh";
            this.btRefreshTargetNode.UseVisualStyleBackColor = true;
            this.btRefreshTargetNode.Click += new System.EventHandler(this.btRefreshDestination_Click);
            // 
            // btRefreshDestination
            // 
            this.btRefreshDestination.Location = new System.Drawing.Point(457, 335);
            this.btRefreshDestination.Name = "btRefreshDestination";
            this.btRefreshDestination.Size = new System.Drawing.Size(75, 23);
            this.btRefreshDestination.TabIndex = 7;
            this.btRefreshDestination.Text = "refresh";
            this.btRefreshDestination.UseVisualStyleBackColor = true;
            this.btRefreshDestination.Click += new System.EventHandler(this.btRefreshDestination_Click);
            // 
            // btMoveFromTargetToDest
            // 
            this.btMoveFromTargetToDest.Location = new System.Drawing.Point(538, 335);
            this.btMoveFromTargetToDest.Name = "btMoveFromTargetToDest";
            this.btMoveFromTargetToDest.Size = new System.Drawing.Size(75, 23);
            this.btMoveFromTargetToDest.TabIndex = 8;
            this.btMoveFromTargetToDest.Text = "move";
            this.btMoveFromTargetToDest.UseVisualStyleBackColor = true;
            this.btMoveFromTargetToDest.Click += new System.EventHandler(this.btMoveFolder_Click);
            // 
            // btOpenFolder
            // 
            this.btOpenFolder.Location = new System.Drawing.Point(93, 580);
            this.btOpenFolder.Name = "btOpenFolder";
            this.btOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.btOpenFolder.TabIndex = 9;
            this.btOpenFolder.Text = "open";
            this.btOpenFolder.UseVisualStyleBackColor = true;
            this.btOpenFolder.Click += new System.EventHandler(this.btOpenFolder_Click);
            // 
            // btOpenDestFolder
            // 
            this.btOpenDestFolder.Location = new System.Drawing.Point(619, 335);
            this.btOpenDestFolder.Name = "btOpenDestFolder";
            this.btOpenDestFolder.Size = new System.Drawing.Size(75, 23);
            this.btOpenDestFolder.TabIndex = 10;
            this.btOpenDestFolder.Text = "open";
            this.btOpenDestFolder.UseVisualStyleBackColor = true;
            this.btOpenDestFolder.Click += new System.EventHandler(this.btOpenFolder_Click);
            // 
            // cmsTreeViewControl
            // 
            this.cmsTreeViewControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.cmsTreeViewControl.Name = "cmsTreeViewControl";
            this.cmsTreeViewControl.Size = new System.Drawing.Size(111, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.openToolStripMenuItem.Text = "open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.refreshToolStripMenuItem.Text = "refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // btOpenSearchFolder
            // 
            this.btOpenSearchFolder.Location = new System.Drawing.Point(878, 361);
            this.btOpenSearchFolder.Name = "btOpenSearchFolder";
            this.btOpenSearchFolder.Size = new System.Drawing.Size(75, 23);
            this.btOpenSearchFolder.TabIndex = 11;
            this.btOpenSearchFolder.Text = "open";
            this.btOpenSearchFolder.UseVisualStyleBackColor = true;
            this.btOpenSearchFolder.Click += new System.EventHandler(this.btOpenSearchFolder_Click);
            // 
            // btTargetFolderDelete
            // 
            this.btTargetFolderDelete.Location = new System.Drawing.Point(375, 580);
            this.btTargetFolderDelete.Name = "btTargetFolderDelete";
            this.btTargetFolderDelete.Size = new System.Drawing.Size(75, 23);
            this.btTargetFolderDelete.TabIndex = 12;
            this.btTargetFolderDelete.Text = "delete";
            this.btTargetFolderDelete.UseVisualStyleBackColor = true;
            this.btTargetFolderDelete.Click += new System.EventHandler(this.btTargetFolderDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 609);
            this.Controls.Add(this.btTargetFolderDelete);
            this.Controls.Add(this.btOpenFolder);
            this.Controls.Add(this.btRefreshTargetNode);
            this.Controls.Add(this.btOpenSearchFolder);
            this.Controls.Add(this.btOpenDestFolder);
            this.Controls.Add(this.clbSearchResult);
            this.Controls.Add(this.btMoveFromTargetToDest);
            this.Controls.Add(this.tvDestinationDirectory);
            this.Controls.Add(this.tvTargetDirectory);
            this.Controls.Add(this.tbSelectedFolder);
            this.Controls.Add(this.btRefreshDestination);
            this.Controls.Add(this.btMoveFolder);
            this.Controls.Add(this.btSearchSimilar);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.cmsTreeViewControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvTargetDirectory;
        private System.Windows.Forms.TextBox tbSelectedFolder;
        private System.Windows.Forms.Button btSearchSimilar;
        private System.Windows.Forms.TreeView tvDestinationDirectory;
        private System.Windows.Forms.CheckedListBox clbSearchResult;
        private System.Windows.Forms.Button btMoveFolder;
        private System.Windows.Forms.Button btRefreshTargetNode;
        private System.Windows.Forms.Button btRefreshDestination;
        private System.Windows.Forms.Button btMoveFromTargetToDest;
        private System.Windows.Forms.Button btOpenFolder;
        private System.Windows.Forms.Button btOpenDestFolder;
        private System.Windows.Forms.ContextMenuStrip cmsTreeViewControl;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Button btOpenSearchFolder;
        private System.Windows.Forms.Button btTargetFolderDelete;
    }
}

