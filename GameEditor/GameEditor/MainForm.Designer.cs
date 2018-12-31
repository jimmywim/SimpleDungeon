namespace GameEditor
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenesListbox = new System.Windows.Forms.ListBox();
            this.sceneEditorPanel = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.forwardButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addItemButton = new System.Windows.Forms.Button();
            this.removeItemButton = new System.Windows.Forms.Button();
            this.editItemButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.sceneEditorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(670, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 22);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem2.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // scenesListbox
            // 
            this.scenesListbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.scenesListbox.FormattingEnabled = true;
            this.scenesListbox.Location = new System.Drawing.Point(0, 24);
            this.scenesListbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scenesListbox.Name = "scenesListbox";
            this.scenesListbox.Size = new System.Drawing.Size(140, 395);
            this.scenesListbox.TabIndex = 1;
            this.scenesListbox.SelectedValueChanged += new System.EventHandler(this.scenesListbox_SelectedValueChanged);
            // 
            // sceneEditorPanel
            // 
            this.sceneEditorPanel.Controls.Add(this.editItemButton);
            this.sceneEditorPanel.Controls.Add(this.removeItemButton);
            this.sceneEditorPanel.Controls.Add(this.addItemButton);
            this.sceneEditorPanel.Controls.Add(this.deleteButton);
            this.sceneEditorPanel.Controls.Add(this.backButton);
            this.sceneEditorPanel.Controls.Add(this.rightButton);
            this.sceneEditorPanel.Controls.Add(this.leftButton);
            this.sceneEditorPanel.Controls.Add(this.saveButton);
            this.sceneEditorPanel.Controls.Add(this.itemsListBox);
            this.sceneEditorPanel.Controls.Add(this.label3);
            this.sceneEditorPanel.Controls.Add(this.descriptionTextbox);
            this.sceneEditorPanel.Controls.Add(this.titleTextBox);
            this.sceneEditorPanel.Controls.Add(this.label2);
            this.sceneEditorPanel.Controls.Add(this.label1);
            this.sceneEditorPanel.Controls.Add(this.forwardButton);
            this.sceneEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneEditorPanel.Location = new System.Drawing.Point(140, 24);
            this.sceneEditorPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sceneEditorPanel.Name = "sceneEditorPanel";
            this.sceneEditorPanel.Size = new System.Drawing.Size(530, 395);
            this.sceneEditorPanel.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(52, 333);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(60, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // itemsListBox
            // 
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.Location = new System.Drawing.Point(52, 160);
            this.itemsListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(168, 121);
            this.itemsListBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Items:";
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(52, 80);
            this.descriptionTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.descriptionTextbox.Multiline = true;
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(415, 57);
            this.descriptionTextbox.TabIndex = 4;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(94, 38);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(373, 20);
            this.titleTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // forwardButton
            // 
            this.forwardButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.forwardButton.Location = new System.Drawing.Point(229, 0);
            this.forwardButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(82, 20);
            this.forwardButton.TabIndex = 0;
            this.forwardButton.Text = "Forward";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(6, 160);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(41, 23);
            this.leftButton.TabIndex = 8;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(474, 160);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(44, 23);
            this.rightButton.TabIndex = 9;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(229, 360);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(443, 333);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addItemButton
            // 
            this.addItemButton.Location = new System.Drawing.Point(55, 287);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(46, 23);
            this.addItemButton.TabIndex = 12;
            this.addItemButton.Text = "Add";
            this.addItemButton.UseVisualStyleBackColor = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // removeItemButton
            // 
            this.removeItemButton.Location = new System.Drawing.Point(155, 286);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(56, 23);
            this.removeItemButton.TabIndex = 13;
            this.removeItemButton.Text = "Remove";
            this.removeItemButton.UseVisualStyleBackColor = true;
            this.removeItemButton.Click += new System.EventHandler(this.removeItemButton_Click);
            // 
            // editItemButton
            // 
            this.editItemButton.Location = new System.Drawing.Point(109, 287);
            this.editItemButton.Name = "editItemButton";
            this.editItemButton.Size = new System.Drawing.Size(40, 23);
            this.editItemButton.TabIndex = 14;
            this.editItemButton.Text = "Edit";
            this.editItemButton.UseVisualStyleBackColor = true;
            this.editItemButton.Click += new System.EventHandler(this.editItemButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 419);
            this.Controls.Add(this.sceneEditorPanel);
            this.Controls.Add(this.scenesListbox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.sceneEditorPanel.ResumeLayout(false);
            this.sceneEditorPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox scenesListbox;
        private System.Windows.Forms.Panel sceneEditorPanel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button removeItemButton;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Button editItemButton;
    }
}

