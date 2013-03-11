namespace CLEyeTester
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
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.fpsLabel = new System.Windows.Forms.Label();
      this.ledButton = new System.Windows.Forms.Button();
      this.stopButton = new System.Windows.Forms.Button();
      this.startButton = new System.Windows.Forms.Button();
      this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
      this.propertiesDataGridView = new System.Windows.Forms.DataGridView();
      this.groupBox = new System.Windows.Forms.GroupBox();
      this.fpsComboBox = new System.Windows.Forms.ComboBox();
      this.colorModeComboBox = new System.Windows.Forms.ComboBox();
      this.resolutionComboBox = new System.Windows.Forms.ComboBox();
      this.comboBox = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.outputCheckBox = new System.Windows.Forms.CheckBox();
      this.outputTextBox = new System.Windows.Forms.TextBox();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.browseButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.propertiesGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.propertiesDataGridView)).BeginInit();
      this.groupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // pictureBox
      // 
      this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox.Location = new System.Drawing.Point(3, 3);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(634, 508);
      this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox.TabIndex = 0;
      this.pictureBox.TabStop = false;
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer.IsSplitterFixed = true;
      this.splitContainer.Location = new System.Drawing.Point(0, 0);
      this.splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.fpsLabel);
      this.splitContainer.Panel1.Controls.Add(this.ledButton);
      this.splitContainer.Panel1.Controls.Add(this.stopButton);
      this.splitContainer.Panel1.Controls.Add(this.startButton);
      this.splitContainer.Panel1.Controls.Add(this.pictureBox);
      this.splitContainer.Panel1MinSize = 320;
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.label1);
      this.splitContainer.Panel2.Controls.Add(this.propertiesGroupBox);
      this.splitContainer.Panel2.Controls.Add(this.groupBox);
      this.splitContainer.Panel2.Controls.Add(this.comboBox);
      this.splitContainer.Size = new System.Drawing.Size(1047, 559);
      this.splitContainer.SplitterDistance = 640;
      this.splitContainer.TabIndex = 2;
      // 
      // fpsLabel
      // 
      this.fpsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.fpsLabel.AutoSize = true;
      this.fpsLabel.Location = new System.Drawing.Point(330, 526);
      this.fpsLabel.Name = "fpsLabel";
      this.fpsLabel.Size = new System.Drawing.Size(0, 13);
      this.fpsLabel.TabIndex = 5;
      // 
      // ledButton
      // 
      this.ledButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.ledButton.Location = new System.Drawing.Point(224, 517);
      this.ledButton.Name = "ledButton";
      this.ledButton.Size = new System.Drawing.Size(100, 30);
      this.ledButton.TabIndex = 4;
      this.ledButton.Text = "LED";
      this.ledButton.UseVisualStyleBackColor = true;
      this.ledButton.Click += new System.EventHandler(this.LEDButtonClick);
      // 
      // stopButton
      // 
      this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.stopButton.Location = new System.Drawing.Point(118, 517);
      this.stopButton.Name = "stopButton";
      this.stopButton.Size = new System.Drawing.Size(100, 30);
      this.stopButton.TabIndex = 2;
      this.stopButton.Text = "Stop";
      this.stopButton.UseVisualStyleBackColor = true;
      this.stopButton.Click += new System.EventHandler(this.StopButtonClick);
      // 
      // startButton
      // 
      this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.startButton.Location = new System.Drawing.Point(12, 517);
      this.startButton.Name = "startButton";
      this.startButton.Size = new System.Drawing.Size(100, 30);
      this.startButton.TabIndex = 1;
      this.startButton.Text = "Start";
      this.startButton.UseVisualStyleBackColor = true;
      this.startButton.Click += new System.EventHandler(this.StartButtonClick);
      // 
      // propertiesGroupBox
      // 
      this.propertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.propertiesGroupBox.Controls.Add(this.browseButton);
      this.propertiesGroupBox.Controls.Add(this.outputTextBox);
      this.propertiesGroupBox.Controls.Add(this.outputCheckBox);
      this.propertiesGroupBox.Controls.Add(this.propertiesDataGridView);
      this.propertiesGroupBox.Location = new System.Drawing.Point(3, 139);
      this.propertiesGroupBox.Name = "propertiesGroupBox";
      this.propertiesGroupBox.Size = new System.Drawing.Size(397, 417);
      this.propertiesGroupBox.TabIndex = 5;
      this.propertiesGroupBox.TabStop = false;
      this.propertiesGroupBox.Text = "Properties";
      // 
      // propertiesDataGridView
      // 
      this.propertiesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.propertiesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.propertiesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.propertiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.propertiesDataGridView.Location = new System.Drawing.Point(6, 19);
      this.propertiesDataGridView.MultiSelect = false;
      this.propertiesDataGridView.Name = "propertiesDataGridView";
      this.propertiesDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
      this.propertiesDataGridView.RowHeadersWidth = 4;
      this.propertiesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.propertiesDataGridView.Size = new System.Drawing.Size(382, 236);
      this.propertiesDataGridView.TabIndex = 1;
      // 
      // groupBox
      // 
      this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox.Controls.Add(this.fpsComboBox);
      this.groupBox.Controls.Add(this.colorModeComboBox);
      this.groupBox.Controls.Add(this.resolutionComboBox);
      this.groupBox.Location = new System.Drawing.Point(3, 30);
      this.groupBox.Name = "groupBox";
      this.groupBox.Size = new System.Drawing.Size(397, 103);
      this.groupBox.TabIndex = 4;
      this.groupBox.TabStop = false;
      this.groupBox.Text = "Settings";
      // 
      // fpsComboBox
      // 
      this.fpsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.fpsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.fpsComboBox.FormattingEnabled = true;
      this.fpsComboBox.Location = new System.Drawing.Point(6, 73);
      this.fpsComboBox.Name = "fpsComboBox";
      this.fpsComboBox.Size = new System.Drawing.Size(382, 21);
      this.fpsComboBox.TabIndex = 2;
      // 
      // colorModeComboBox
      // 
      this.colorModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.colorModeComboBox.FormattingEnabled = true;
      this.colorModeComboBox.Location = new System.Drawing.Point(6, 46);
      this.colorModeComboBox.Name = "colorModeComboBox";
      this.colorModeComboBox.Size = new System.Drawing.Size(382, 21);
      this.colorModeComboBox.TabIndex = 1;
      // 
      // resolutionComboBox
      // 
      this.resolutionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.resolutionComboBox.FormattingEnabled = true;
      this.resolutionComboBox.Location = new System.Drawing.Point(6, 19);
      this.resolutionComboBox.Name = "resolutionComboBox";
      this.resolutionComboBox.Size = new System.Drawing.Size(382, 21);
      this.resolutionComboBox.TabIndex = 0;
      // 
      // comboBox
      // 
      this.comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox.FormattingEnabled = true;
      this.comboBox.Location = new System.Drawing.Point(55, 6);
      this.comboBox.Name = "comboBox";
      this.comboBox.Size = new System.Drawing.Size(345, 21);
      this.comboBox.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Camera";
      // 
      // outputCheckBox
      // 
      this.outputCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.outputCheckBox.AutoSize = true;
      this.outputCheckBox.Location = new System.Drawing.Point(6, 386);
      this.outputCheckBox.Name = "outputCheckBox";
      this.outputCheckBox.Size = new System.Drawing.Size(58, 17);
      this.outputCheckBox.TabIndex = 2;
      this.outputCheckBox.Text = "Output";
      this.outputCheckBox.UseVisualStyleBackColor = true;
      // 
      // outputTextBox
      // 
      this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.outputTextBox.Location = new System.Drawing.Point(70, 384);
      this.outputTextBox.Name = "outputTextBox";
      this.outputTextBox.Size = new System.Drawing.Size(278, 20);
      this.outputTextBox.TabIndex = 3;
      this.outputTextBox.Text = "CLEyeTester{0:yyyyMMddTHHmmssfff}.avi";
      // 
      // browseButton
      // 
      this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.browseButton.Location = new System.Drawing.Point(354, 382);
      this.browseButton.Name = "browseButton";
      this.browseButton.Size = new System.Drawing.Size(34, 23);
      this.browseButton.TabIndex = 4;
      this.browseButton.Text = "...";
      this.browseButton.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1047, 559);
      this.Controls.Add(this.splitContainer);
      this.Name = "MainForm";
      this.Text = "CLEyeTest";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel1.PerformLayout();
      this.splitContainer.Panel2.ResumeLayout(false);
      this.splitContainer.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.propertiesGroupBox.ResumeLayout(false);
      this.propertiesGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.propertiesDataGridView)).EndInit();
      this.groupBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.Button stopButton;
    private System.Windows.Forms.Button startButton;
    private System.Windows.Forms.ComboBox comboBox;
    private System.Windows.Forms.Button ledButton;
    private System.Windows.Forms.GroupBox groupBox;
    private System.Windows.Forms.ComboBox fpsComboBox;
    private System.Windows.Forms.ComboBox colorModeComboBox;
    private System.Windows.Forms.ComboBox resolutionComboBox;
    private System.Windows.Forms.Label fpsLabel;
    private System.Windows.Forms.GroupBox propertiesGroupBox;
    private System.Windows.Forms.DataGridView propertiesDataGridView;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button browseButton;
    private System.Windows.Forms.TextBox outputTextBox;
    private System.Windows.Forms.CheckBox outputCheckBox;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
  }
}

