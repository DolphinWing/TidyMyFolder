using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TidyMyFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives) {
                if (d.DriveType == DriveType.Fixed) {
                    TreeNode node = new TreeNode(d.Name);
                    add_node(node, d.Name);
                    tvTargetDirectory.Nodes.Add(node);

                    TreeNode node2 = new TreeNode(d.Name);
                    add_node(node2, d.Name);
                    tvDestinationDirectory.Nodes.Add(node2);
                }
            }

        }

        private void add_node(TreeNode node, string path)
        {
            if (!Directory.Exists(path)) {
                MessageBox.Show(this, path + " is not existed!");
                node.Remove();
                return;
            }

            string[] directories = Directory.GetDirectories(path);
            foreach (string dir in directories) {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (di != null) {
                    TreeNode n = new TreeNode(di.Name);
                    switch (di.Attributes) {
                        case FileAttributes.Directory:
                            break;
                        case FileAttributes.Hidden:
                        case FileAttributes.ReadOnly:
                        case FileAttributes.System:
                        case FileAttributes.Temporary:
                        case FileAttributes.Offline:
                            continue;

                    }
                    n.Tag = di.FullName;
                    node.Nodes.Add(n);
                }
            }
        }

        TreeNode lastSrcNode = null;
        TreeNode lastDestNode = null;

        private void tvTargetDirectory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView view = ((TreeView)sender);
            TreeNode node = view.SelectedNode;
            node.BackColor = Color.LightBlue;

            if (node.Tag != null && node.Nodes.Count <= 0) {
                string path = node.Tag.ToString();
                add_node(node, path);
            }

            switch (view.Name) {
                case "tvTargetDirectory":
                    tbSelectedFolder.Text = node.Text;
                    node.Expand();
                    lastSrcNode = node;
                    break;
                case "tvDestinationDirectory":
                    clbSearchResult.Items.Clear();
                    if (node.Tag != null) {
                        clbSearchResult.Items.Add(node.Tag);
                        clbSearchResult.SetSelected(0, true);
                    }
                    lastDestNode = node;
                    break;
            }

            //node.Expand();
        }

        private void btSearchSimilar_Click(object sender, EventArgs e)
        {
            btSearchSimilar.Enabled = false;

            clbSearchResult.Items.Clear();
            if (tvDestinationDirectory.SelectedNode != null &&
                tbSelectedFolder.Text != null && tbSelectedFolder.Text.Trim() != "") {
                string search_path = tvDestinationDirectory.SelectedNode.Tag.ToString();
                string[] patt = tbSelectedFolder.Text.Split(new char[] { '?', '~', ' ', 
                    '-', '_', '=', '+', '!', '(', ')', '{', '}', '[', ']', '\'', '\"',
                    ',', '.', '<', '>', '@', '#', '$', '%', '^', '&', '*', '\\', '|'});
                foreach (string pattern in patt) {
                    if (pattern.Trim() == "") {
                        continue;
                    }

                    string search_patt = "*" + pattern + "*";
                    string[] found_dirs = Directory.GetDirectories(search_path, search_patt,
                        SearchOption.AllDirectories);
                    foreach (string dir in found_dirs) {
                        clbSearchResult.Items.Add(dir);
                    }
                }

                if(clbSearchResult.Items.Count > 0) {
                    clbSearchResult.SetItemChecked(0, true);
                    clbSearchResult.SetSelected(0, true);
                }
            }

            btSearchSimilar.Enabled = true;
        }

        private void btMoveFolder_Click(object sender, EventArgs e)
        {
            btMoveFolder.Enabled = false;

            TreeNode node = tvTargetDirectory.SelectedNode;
            if (node != null && clbSearchResult.CheckedItems.Count > 0) {
                string dest_dir = clbSearchResult.CheckedItems[0].ToString();
                dest_dir += "\\" + node.Text;
                try {
                    if (!Directory.Exists(dest_dir)) {
                        Directory.Move(node.Tag.ToString(), dest_dir);
                    }
                    else {
                        MessageBox.Show(this, dest_dir + " is already there!");
                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(this, e1.Message, dest_dir);
                }

                tvTargetDirectory.SelectedNode = node.Parent;
                btRefreshTargetNode.PerformClick();

                if (lastDestNode != null) {
                    tvDestinationDirectory.SelectedNode = lastDestNode;//.Parent;
                    btRefreshDestination.PerformClick();
                }
            }

            btMoveFolder.Enabled = true;
        }

        private void btRefreshDestination_Click(object sender, EventArgs e)
        {
            Button view = ((Button)sender);
            TreeNode node = null;
            switch (view.Name) {
                case "btRefreshTargetNode":
                    node = tvTargetDirectory.SelectedNode;
                    break;
                case "btRefreshDestination":
                    node = tvDestinationDirectory.SelectedNode;
                    break;
            }

            if (node != null && node.Tag != null) {
                //re-build the tree node
                node.Nodes.Clear();
                add_node(node, node.Tag.ToString());
            }
        }

        private void btOpenFolder_Click(object sender, EventArgs e)
        {
            Button view = ((Button)sender);
            TreeNode node = null;
            switch (view.Name) {
                case "btOpenFolder":
                    node = tvTargetDirectory.SelectedNode;
                    break;
                case "btOpenDestFolder":
                    node = tvDestinationDirectory.SelectedNode;
                    break;
            }

            if (node != null && node.Tag != null) {
                Process p = Process.Start("explorer.exe", node.Tag.ToString());
            }
        }

        private void tvDestinationDirectory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView view = ((TreeView)sender);
            TreeNode node = view.SelectedNode;
            if (node != null && e.Button == MouseButtons.Right) {
                cmsTreeViewControl.Tag = view;
                cmsTreeViewControl.Show(view, e.X, e.Y);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string folder = cmsTreeViewControl.Tag.ToString();
            TreeView view = ((TreeView)cmsTreeViewControl.Tag);
            switch (view.Name) {
                case "tvTargetDirectory":
                    btOpenFolder.PerformClick();
                    break;
                case "tvDestinationDirectory":
                    btOpenDestFolder.PerformClick();
                    break;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeView view = ((TreeView)cmsTreeViewControl.Tag);
            switch (view.Name) {
                case "tvTargetDirectory":
                    btRefreshTargetNode.PerformClick();
                    break;
                case "tvDestinationDirectory":
                    btRefreshDestination.PerformClick();
                    break;
            }
        }

        private void tvTargetDirectory_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeView view = ((TreeView)sender);
            //TreeNode node = view.SelectedNode;
            //if (node != null)
            //{
            //    node.BackColor = Color.Transparent;
            //}
            try {
                switch (view.Name) {
                    case "tvTargetDirectory":
                        lastSrcNode.BackColor = Color.Transparent;
                        break;
                    case "tvDestinationDirectory":
                        lastDestNode.BackColor = Color.Transparent;
                        break;
                }
            }
            catch {
            }
        }

        private void btOpenSearchFolder_Click(object sender, EventArgs e)
        {
            if (clbSearchResult.SelectedItem != null) {
                Process p = Process.Start("explorer.exe", clbSearchResult.SelectedItem.ToString());
            }
        }

        private void btTargetFolderDelete_Click(object sender, EventArgs e)
        {
            btTargetFolderDelete.Enabled = false;
            //TreeView view = ((TreeView)sender);
            TreeNode node = tvTargetDirectory.SelectedNode;

            try {
                if (node.Tag != null) {
                    Directory.Delete(node.Tag.ToString(), true);
                    if (!Directory.Exists(node.Tag.ToString())) {
                        node.Remove();
                    }
                }
            }
            catch (Exception e1) {
                MessageBox.Show(this, e1.Message, node.Tag.ToString());
            }

            System.Threading.Thread.Sleep(500);
            btTargetFolderDelete.Enabled = true;
        }
    }
}
