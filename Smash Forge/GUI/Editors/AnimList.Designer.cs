﻿namespace Smash_Forge
{
    partial class AnimListPanel
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.AnimationCM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportAllAsOMOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAnimationGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimationCM.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(224, 89);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.selectItem);
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // AnimationCM
            // 
            this.AnimationCM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllAsOMOToolStripMenuItem,
            this.createAnimationGroupToolStripMenuItem});
            this.AnimationCM.Name = "AnimationCM";
            this.AnimationCM.Size = new System.Drawing.Size(204, 70);
            // 
            // exportAllAsOMOToolStripMenuItem
            // 
            this.exportAllAsOMOToolStripMenuItem.Name = "exportAllAsOMOToolStripMenuItem";
            this.exportAllAsOMOToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exportAllAsOMOToolStripMenuItem.Text = "Export All as OMO";
            this.exportAllAsOMOToolStripMenuItem.Click += new System.EventHandler(this.exportAllAsOMOToolStripMenuItem_Click);
            // 
            // createAnimationGroupToolStripMenuItem
            // 
            this.createAnimationGroupToolStripMenuItem.Name = "createAnimationGroupToolStripMenuItem";
            this.createAnimationGroupToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.createAnimationGroupToolStripMenuItem.Text = "Create Animation Group";
            this.createAnimationGroupToolStripMenuItem.Click += new System.EventHandler(this.createAnimationGroupToolStripMenuItem_Click);
            // 
            // AnimListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 89);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Name = "AnimListPanel";
            this.ShowIcon = false;
            this.Text = "Animations";
            this.AnimationCM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip AnimationCM;
        private System.Windows.Forms.ToolStripMenuItem exportAllAsOMOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAnimationGroupToolStripMenuItem;
    }
}
