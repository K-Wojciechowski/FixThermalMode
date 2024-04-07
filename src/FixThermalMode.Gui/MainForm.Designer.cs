namespace FixThermalMode.Gui;

partial class MainForm {
  /// <summary>
  ///  Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  ///  Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  ///  Required method for Designer support - do not modify
  ///  the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
    components = new System.ComponentModel.Container();
    var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
    tableLayoutPanel = new TableLayoutPanel();
    label = new Label();
    progressBar = new ProgressBar();
    notifyIcon = new NotifyIcon(components);
    notifyIconMenu = new ContextMenuStrip(components);
    performanceMenuItem = new ToolStripMenuItem();
    optimizedMenuItem = new ToolStripMenuItem();
    quietMenuItem = new ToolStripMenuItem();
    coolMenuItem = new ToolStripMenuItem();
    toolStripSeparator1 = new ToolStripSeparator();
    autoFixMenuItem = new ToolStripMenuItem();
    toolStripSeparator2 = new ToolStripSeparator();
    aboutMenuItem = new ToolStripMenuItem();
    quitMenuItem = new ToolStripMenuItem();
    tableLayoutPanel.SuspendLayout();
    notifyIconMenu.SuspendLayout();
    SuspendLayout();
    // 
    // tableLayoutPanel
    // 
    tableLayoutPanel.ColumnCount = 1;
    tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
    tableLayoutPanel.Controls.Add(label, 0, 0);
    tableLayoutPanel.Controls.Add(progressBar, 0, 1);
    tableLayoutPanel.Location = new Point(0, 0);
    tableLayoutPanel.Name = "tableLayoutPanel";
    tableLayoutPanel.RowCount = 2;
    tableLayoutPanel.RowStyles.Add(new RowStyle());
    tableLayoutPanel.RowStyles.Add(new RowStyle());
    tableLayoutPanel.Size = new Size(300, 72);
    tableLayoutPanel.TabIndex = 0;
    // 
    // label
    // 
    label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    label.AutoSize = true;
    label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
    label.ForeColor = Color.White;
    label.Location = new Point(0, 8);
    label.Margin = new Padding(0, 8, 0, 0);
    label.Name = "label";
    label.Size = new Size(300, 21);
    label.TabIndex = 0;
    label.Text = "Fixing thermal mode…";
    label.TextAlign = ContentAlignment.MiddleCenter;
    // 
    // progressBar
    // 
    progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    progressBar.Location = new Point(8, 37);
    progressBar.Margin = new Padding(8);
    progressBar.Maximum = 400;
    progressBar.Name = "progressBar";
    progressBar.Size = new Size(284, 27);
    progressBar.TabIndex = 1;
    // 
    // notifyIcon
    // 
    notifyIcon.ContextMenuStrip = notifyIconMenu;
    notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
    notifyIcon.Text = "Fix Thermal Mode";
    notifyIcon.Visible = true;
    notifyIcon.Click += notifyIcon_Click;
    // 
    // notifyIconMenu
    // 
    notifyIconMenu.Items.AddRange(new ToolStripItem[] { performanceMenuItem, optimizedMenuItem, quietMenuItem, coolMenuItem, toolStripSeparator1, autoFixMenuItem, toolStripSeparator2, aboutMenuItem, quitMenuItem });
    notifyIconMenu.Name = "contextMenuStrip1";
    notifyIconMenu.Size = new Size(181, 192);
    // 
    // performanceMenuItem
    // 
    performanceMenuItem.Image = Properties.Resources.performance16;
    performanceMenuItem.Name = "performanceMenuItem";
    performanceMenuItem.Size = new Size(180, 22);
    performanceMenuItem.Text = "Performance";
    performanceMenuItem.Click += performanceMenuItem_Click;
    // 
    // optimizedMenuItem
    // 
    optimizedMenuItem.Image = Properties.Resources.optimized16;
    optimizedMenuItem.Name = "optimizedMenuItem";
    optimizedMenuItem.Size = new Size(180, 22);
    optimizedMenuItem.Text = "Optimized";
    optimizedMenuItem.Click += optimizedMenuItem_Click;
    // 
    // quietMenuItem
    // 
    quietMenuItem.Image = Properties.Resources.quiet16;
    quietMenuItem.Name = "quietMenuItem";
    quietMenuItem.Size = new Size(180, 22);
    quietMenuItem.Text = "Quiet";
    quietMenuItem.Click += quietMenuItem_Click;
    // 
    // coolMenuItem
    // 
    coolMenuItem.Image = Properties.Resources.cool16;
    coolMenuItem.Name = "coolMenuItem";
    coolMenuItem.Size = new Size(180, 22);
    coolMenuItem.Text = "Cool";
    coolMenuItem.Click += coolMenuItem_Click;
    // 
    // toolStripSeparator1
    // 
    toolStripSeparator1.Name = "toolStripSeparator1";
    toolStripSeparator1.Size = new Size(177, 6);
    // 
    // autoFixMenuItem
    // 
    autoFixMenuItem.Image = Properties.Resources.app16;
    autoFixMenuItem.Name = "autoFixMenuItem";
    autoFixMenuItem.Size = new Size(180, 22);
    autoFixMenuItem.Text = "Auto Fix";
    autoFixMenuItem.Click += autoFixMenuItem_Click;
    // 
    // toolStripSeparator2
    // 
    toolStripSeparator2.Name = "toolStripSeparator2";
    toolStripSeparator2.Size = new Size(177, 6);
    // 
    // aboutMenuItem
    // 
    aboutMenuItem.Name = "aboutMenuItem";
    aboutMenuItem.Size = new Size(180, 22);
    aboutMenuItem.Text = "About…";
    aboutMenuItem.Click += aboutMenuItem_Click;
    // 
    // quitMenuItem
    // 
    quitMenuItem.Name = "quitMenuItem";
    quitMenuItem.Size = new Size(180, 22);
    quitMenuItem.Text = "Quit";
    quitMenuItem.Click += quitMenuItem_Click;
    // 
    // MainForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    AutoSize = true;
    AutoSizeMode = AutoSizeMode.GrowAndShrink;
    BackColor = Color.Black;
    ClientSize = new Size(512, 210);
    Controls.Add(tableLayoutPanel);
    FormBorderStyle = FormBorderStyle.FixedToolWindow;
    Icon = (Icon)resources.GetObject("$this.Icon");
    MaximizeBox = false;
    MinimizeBox = false;
    Name = "MainForm";
    Opacity = 0D;
    ShowInTaskbar = false;
    SizeGripStyle = SizeGripStyle.Hide;
    StartPosition = FormStartPosition.CenterScreen;
    Text = "Please wait…";
    FormClosing += MainForm_FormClosing;
    Load += MainForm_Load;
    tableLayoutPanel.ResumeLayout(false);
    tableLayoutPanel.PerformLayout();
    notifyIconMenu.ResumeLayout(false);
    ResumeLayout(false);
  }

  #endregion

  private TableLayoutPanel tableLayoutPanel;
  private Label label;
  private ProgressBar progressBar;
  private NotifyIcon notifyIcon;
  private ContextMenuStrip notifyIconMenu;
  private ToolStripMenuItem performanceMenuItem;
  private ToolStripMenuItem optimizedMenuItem;
  private ToolStripMenuItem quietMenuItem;
  private ToolStripMenuItem coolMenuItem;
  private ToolStripSeparator toolStripSeparator1;
  private ToolStripMenuItem autoFixMenuItem;
  private ToolStripSeparator toolStripSeparator2;
  private ToolStripMenuItem aboutMenuItem;
  private ToolStripMenuItem quitMenuItem;
}
