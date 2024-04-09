namespace FixThermalMode.Gui;

partial class AboutBox {
  /// <summary>
  /// Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  /// Clean up any resources being used.
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
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
    var resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
    tableLayoutPanel1 = new TableLayoutPanel();
    headingLabel = new Label();
    label3 = new Label();
    label2 = new Label();
    label4 = new Label();
    okButton = new Button();
    tableLayoutPanel1.SuspendLayout();
    SuspendLayout();
    // 
    // tableLayoutPanel1
    // 
    tableLayoutPanel1.ColumnCount = 1;
    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
    tableLayoutPanel1.Controls.Add(headingLabel, 0, 0);
    tableLayoutPanel1.Controls.Add(label3, 0, 3);
    tableLayoutPanel1.Controls.Add(label2, 0, 1);
    tableLayoutPanel1.Controls.Add(label4, 0, 2);
    tableLayoutPanel1.Controls.Add(okButton, 0, 4);
    tableLayoutPanel1.Location = new Point(0, 0);
    tableLayoutPanel1.Margin = new Padding(4);
    tableLayoutPanel1.Name = "tableLayoutPanel1";
    tableLayoutPanel1.RowCount = 5;
    tableLayoutPanel1.RowStyles.Add(new RowStyle());
    tableLayoutPanel1.RowStyles.Add(new RowStyle());
    tableLayoutPanel1.RowStyles.Add(new RowStyle());
    tableLayoutPanel1.RowStyles.Add(new RowStyle());
    tableLayoutPanel1.RowStyles.Add(new RowStyle());
    tableLayoutPanel1.Size = new Size(478, 324);
    tableLayoutPanel1.TabIndex = 0;
    // 
    // headingLabel
    // 
    headingLabel.Anchor = AnchorStyles.Top;
    headingLabel.AutoSize = true;
    headingLabel.Font = new Font("Segoe UI", 16F);
    headingLabel.Location = new Point(105, 8);
    headingLabel.Margin = new Padding(0, 8, 0, 0);
    headingLabel.Name = "headingLabel";
    headingLabel.Size = new Size(268, 30);
    headingLabel.TabIndex = 0;
    headingLabel.Text = "Fix Thermal Mode v0.0.0.0";
    // 
    // label3
    // 
    label3.AutoSize = true;
    label3.Location = new Point(8, 111);
    label3.Margin = new Padding(8, 0, 8, 0);
    label3.MaximumSize = new Size(460, 0);
    label3.Name = "label3";
    label3.Size = new Size(460, 180);
    label3.TabIndex = 2;
    label3.Text = resources.GetString("label3.Text");
    // 
    // label2
    // 
    label2.Anchor = AnchorStyles.Top;
    label2.AutoSize = true;
    label2.Font = new Font("Segoe UI", 10F);
    label2.Location = new Point(68, 38);
    label2.Name = "label2";
    label2.Size = new Size(341, 19);
    label2.TabIndex = 1;
    label2.Text = "Quickly fix and change thermal modes on Dell laptops.";
    // 
    // label4
    // 
    label4.AutoSize = true;
    label4.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
    label4.Location = new Point(8, 65);
    label4.Margin = new Padding(8, 8, 8, 16);
    label4.Name = "label4";
    label4.Size = new Size(461, 30);
    label4.TabIndex = 2;
    label4.Text = "Warning: this software is provided “AS-IS” and the authors DO NOT take responsibility for any hardware failure that may occur.";
    // 
    // okButton
    // 
    okButton.Anchor = AnchorStyles.Bottom;
    okButton.Location = new Point(201, 299);
    okButton.Margin = new Padding(8);
    okButton.Name = "okButton";
    okButton.Size = new Size(75, 23);
    okButton.TabIndex = 3;
    okButton.Text = "OK";
    okButton.UseVisualStyleBackColor = true;
    okButton.Click += okButton_Click;
    // 
    // AboutBox
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    AutoSize = true;
    AutoSizeMode = AutoSizeMode.GrowAndShrink;
    ClientSize = new Size(799, 483);
    Controls.Add(tableLayoutPanel1);
    Icon = (Icon)resources.GetObject("$this.Icon");
    MaximizeBox = false;
    MinimizeBox = false;
    Name = "AboutBox";
    Text = "About Fix Thermal Mode";
    tableLayoutPanel1.ResumeLayout(false);
    tableLayoutPanel1.PerformLayout();
    ResumeLayout(false);
  }

  #endregion

  private TableLayoutPanel tableLayoutPanel1;
  private Label headingLabel;
  private Label label2;
  private Label label3;
  private Label label4;
  private Button okButton;
}
