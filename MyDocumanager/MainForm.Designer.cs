namespace MyDocumanager
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
      this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
      this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
      this.infoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.infoStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
      this.mainListView = new System.Windows.Forms.ListView();
      this.titleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.descriptionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.searchTextBox = new System.Windows.Forms.TextBox();
      this.addDocumentButton = new System.Windows.Forms.Button();
      this.addFolderButton = new System.Windows.Forms.Button();
      this.editButton = new System.Windows.Forms.Button();
      this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
      this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
      this.mainMenuStrip.SuspendLayout();
      this.mainStatusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // mainMenuStrip
      // 
      this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
      this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
      this.mainMenuStrip.Name = "mainMenuStrip";
      this.mainMenuStrip.Size = new System.Drawing.Size(680, 24);
      this.mainMenuStrip.TabIndex = 0;
      this.mainMenuStrip.Text = "menuStrip1";
      // 
      // fileMenuItem
      // 
      this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
      this.fileMenuItem.Name = "fileMenuItem";
      this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileMenuItem.Text = "File";
      // 
      // exitMenuItem
      // 
      this.exitMenuItem.Name = "exitMenuItem";
      this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
      this.exitMenuItem.Text = "Exit";
      // 
      // mainStatusStrip
      // 
      this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoStatusLabel,
            this.infoStatusStrip});
      this.mainStatusStrip.Location = new System.Drawing.Point(0, 548);
      this.mainStatusStrip.Name = "mainStatusStrip";
      this.mainStatusStrip.Size = new System.Drawing.Size(680, 22);
      this.mainStatusStrip.TabIndex = 1;
      this.mainStatusStrip.Text = "statusStrip1";
      // 
      // infoStatusLabel
      // 
      this.infoStatusLabel.Name = "infoStatusLabel";
      this.infoStatusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // infoStatusStrip
      // 
      this.infoStatusStrip.Name = "infoStatusStrip";
      this.infoStatusStrip.Size = new System.Drawing.Size(0, 17);
      // 
      // mainListView
      // 
      this.mainListView.AllowColumnReorder = true;
      this.mainListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.mainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColumn,
            this.descriptionColumn});
      this.mainListView.Location = new System.Drawing.Point(12, 106);
      this.mainListView.MultiSelect = false;
      this.mainListView.Name = "mainListView";
      this.mainListView.Size = new System.Drawing.Size(656, 439);
      this.mainListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.mainListView.TabIndex = 2;
      this.mainListView.UseCompatibleStateImageBehavior = false;
      this.mainListView.View = System.Windows.Forms.View.Details;
      this.mainListView.DoubleClick += new System.EventHandler(this.EditDocument);
      // 
      // titleColumn
      // 
      this.titleColumn.Text = "Title";
      this.titleColumn.Width = 114;
      // 
      // descriptionColumn
      // 
      this.descriptionColumn.Text = "Description";
      this.descriptionColumn.Width = 323;
      // 
      // searchTextBox
      // 
      this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.searchTextBox.Location = new System.Drawing.Point(12, 80);
      this.searchTextBox.Name = "searchTextBox";
      this.searchTextBox.Size = new System.Drawing.Size(656, 20);
      this.searchTextBox.TabIndex = 3;
      this.searchTextBox.Text = "Search...";
      this.searchTextBox.TextChanged += new System.EventHandler(this.TextChanged);
      this.searchTextBox.Enter += new System.EventHandler(this.OnFocus);
      this.searchTextBox.Leave += new System.EventHandler(this.LostFocus);
      // 
      // addDocumentButton
      // 
      this.addDocumentButton.Location = new System.Drawing.Point(12, 27);
      this.addDocumentButton.Name = "addDocumentButton";
      this.addDocumentButton.Size = new System.Drawing.Size(75, 47);
      this.addDocumentButton.TabIndex = 4;
      this.addDocumentButton.Text = "Add Document";
      this.addDocumentButton.UseVisualStyleBackColor = true;
      this.addDocumentButton.Click += new System.EventHandler(this.AddDocument);
      // 
      // addFolderButton
      // 
      this.addFolderButton.Location = new System.Drawing.Point(93, 27);
      this.addFolderButton.Name = "addFolderButton";
      this.addFolderButton.Size = new System.Drawing.Size(75, 47);
      this.addFolderButton.TabIndex = 5;
      this.addFolderButton.Text = "Add Directory";
      this.addFolderButton.UseVisualStyleBackColor = true;
      this.addFolderButton.Click += new System.EventHandler(this.AddFolder);
      // 
      // editButton
      // 
      this.editButton.Location = new System.Drawing.Point(174, 27);
      this.editButton.Name = "editButton";
      this.editButton.Size = new System.Drawing.Size(75, 47);
      this.editButton.TabIndex = 6;
      this.editButton.Text = "Edit Selected";
      this.editButton.UseVisualStyleBackColor = true;
      this.editButton.Click += new System.EventHandler(this.EditDocument);
      // 
      // folderBrowser
      // 
      this.folderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 570);
      this.Controls.Add(this.editButton);
      this.Controls.Add(this.addFolderButton);
      this.Controls.Add(this.addDocumentButton);
      this.Controls.Add(this.searchTextBox);
      this.Controls.Add(this.mainListView);
      this.Controls.Add(this.mainStatusStrip);
      this.Controls.Add(this.mainMenuStrip);
      this.MainMenuStrip = this.mainMenuStrip;
      this.Name = "MainForm";
      this.Text = "My Documanager";
      this.Load += new System.EventHandler(this.OnLoad);
      this.mainMenuStrip.ResumeLayout(false);
      this.mainMenuStrip.PerformLayout();
      this.mainStatusStrip.ResumeLayout(false);
      this.mainStatusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip mainMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
    private System.Windows.Forms.StatusStrip mainStatusStrip;
    private System.Windows.Forms.ToolStripStatusLabel infoStatusLabel;
    private System.Windows.Forms.ListView mainListView;
    private System.Windows.Forms.ColumnHeader titleColumn;
    private System.Windows.Forms.ColumnHeader descriptionColumn;
    private System.Windows.Forms.TextBox searchTextBox;
    private System.Windows.Forms.Button addDocumentButton;
    private System.Windows.Forms.Button addFolderButton;
    private System.Windows.Forms.Button editButton;
    private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    private System.Windows.Forms.OpenFileDialog fileBrowser;
    private System.Windows.Forms.ToolStripStatusLabel infoStatusStrip;
  }
}

