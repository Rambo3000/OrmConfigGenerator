namespace OrmConfigGenerator
{
    partial class FrmOrmConfigGenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrmConfigGenerator));
            btnBrowse = new Button();
            lblBranch = new Label();
            lblBranchValue = new Label();
            lblFilename = new Label();
            cboModules = new ComboBox();
            cboProjects = new ComboBox();
            lblProject = new Label();
            lblModule = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            grpCheckBoxSelection = new GroupBox();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            tabSCripts = new TabControl();
            tabPage1 = new TabPage();
            txtChangeSetId = new TextBox();
            txtAuthor = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtLiquibaseScript = new RichTextBox();
            tabPage2 = new TabPage();
            txtORMScheme = new RichTextBox();
            tabPage3 = new TabPage();
            txtOracleSql = new RichTextBox();
            btnGenerate = new Button();
            grpCheckBoxSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabSCripts.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(6, 19);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(108, 23);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Browse export...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += BtnBrowse_Click;
            // 
            // lblBranch
            // 
            lblBranch.AutoSize = true;
            lblBranch.Location = new Point(6, 45);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(44, 15);
            lblBranch.TabIndex = 6;
            lblBranch.Text = "Branch";
            // 
            // lblBranchValue
            // 
            lblBranchValue.AutoSize = true;
            lblBranchValue.Location = new Point(56, 45);
            lblBranchValue.Name = "lblBranchValue";
            lblBranchValue.Size = new Size(0, 15);
            lblBranchValue.TabIndex = 7;
            // 
            // lblFilename
            // 
            lblFilename.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFilename.Location = new Point(120, 23);
            lblFilename.Name = "lblFilename";
            lblFilename.Size = new Size(288, 22);
            lblFilename.TabIndex = 1;
            lblFilename.Text = "-";
            // 
            // cboModules
            // 
            cboModules.DropDownStyle = ComboBoxStyle.DropDownList;
            cboModules.FormattingEnabled = true;
            cboModules.Location = new Point(56, 92);
            cboModules.Name = "cboModules";
            cboModules.Size = new Size(218, 23);
            cboModules.TabIndex = 3;
            cboModules.SelectedIndexChanged += CboModules_SelectedIndexChanged;
            // 
            // cboProjects
            // 
            cboProjects.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProjects.FormattingEnabled = true;
            cboProjects.Location = new Point(56, 66);
            cboProjects.Name = "cboProjects";
            cboProjects.Size = new Size(218, 23);
            cboProjects.TabIndex = 2;
            cboProjects.SelectedIndexChanged += CboProjects_SelectedIndexChanged;
            // 
            // lblProject
            // 
            lblProject.AutoSize = true;
            lblProject.Location = new Point(6, 69);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(44, 15);
            lblProject.TabIndex = 4;
            lblProject.Text = "Project";
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Location = new Point(6, 95);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(48, 15);
            lblModule.TabIndex = 5;
            lblModule.Text = "Module";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(6, 118);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(421, 486);
            flowLayoutPanel1.TabIndex = 9;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.SizeChanged += FlowLayoutPanel_SizeChanged;
            // 
            // grpCheckBoxSelection
            // 
            grpCheckBoxSelection.Controls.Add(lblFilename);
            grpCheckBoxSelection.Controls.Add(lblBranchValue);
            grpCheckBoxSelection.Controls.Add(btnBrowse);
            grpCheckBoxSelection.Controls.Add(lblBranch);
            grpCheckBoxSelection.Controls.Add(flowLayoutPanel1);
            grpCheckBoxSelection.Controls.Add(lblProject);
            grpCheckBoxSelection.Controls.Add(cboModules);
            grpCheckBoxSelection.Controls.Add(cboProjects);
            grpCheckBoxSelection.Controls.Add(lblModule);
            grpCheckBoxSelection.Dock = DockStyle.Fill;
            grpCheckBoxSelection.Location = new Point(0, 0);
            grpCheckBoxSelection.Name = "grpCheckBoxSelection";
            grpCheckBoxSelection.Size = new Size(433, 610);
            grpCheckBoxSelection.TabIndex = 10;
            grpCheckBoxSelection.TabStop = false;
            grpCheckBoxSelection.Text = "Select entties and attributs from Blueriq export";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(grpCheckBoxSelection);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(873, 610);
            splitContainer1.SplitterDistance = 433;
            splitContainer1.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tabSCripts);
            groupBox1.Controls.Add(btnGenerate);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(436, 610);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generate scripts";
            // 
            // tabSCripts
            // 
            tabSCripts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabSCripts.Controls.Add(tabPage1);
            tabSCripts.Controls.Add(tabPage2);
            tabSCripts.Controls.Add(tabPage3);
            tabSCripts.Location = new Point(3, 50);
            tabSCripts.Name = "tabSCripts";
            tabSCripts.SelectedIndex = 0;
            tabSCripts.Size = new Size(430, 557);
            tabSCripts.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtChangeSetId);
            tabPage1.Controls.Add(txtAuthor);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtLiquibaseScript);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(422, 529);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Liquibase";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtChangeSetId
            // 
            txtChangeSetId.Location = new Point(244, 3);
            txtChangeSetId.Name = "txtChangeSetId";
            txtChangeSetId.Size = new Size(100, 23);
            txtChangeSetId.TabIndex = 8;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(56, 3);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(100, 23);
            txtAuthor.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 6);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 6;
            label2.Text = "ChangeSet Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 6);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 5;
            label1.Text = "Author";
            // 
            // txtLiquibaseScript
            // 
            txtLiquibaseScript.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLiquibaseScript.Location = new Point(3, 31);
            txtLiquibaseScript.Name = "txtLiquibaseScript";
            txtLiquibaseScript.Size = new Size(416, 495);
            txtLiquibaseScript.TabIndex = 0;
            txtLiquibaseScript.Text = "";
            txtLiquibaseScript.WordWrap = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtORMScheme);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(422, 529);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "ORM scheme";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtORMScheme
            // 
            txtORMScheme.Dock = DockStyle.Fill;
            txtORMScheme.Location = new Point(3, 3);
            txtORMScheme.Name = "txtORMScheme";
            txtORMScheme.Size = new Size(416, 523);
            txtORMScheme.TabIndex = 1;
            txtORMScheme.Text = "";
            txtORMScheme.WordWrap = false;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(txtOracleSql);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(422, 529);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Oracle SQL";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtOracleSql
            // 
            txtOracleSql.Dock = DockStyle.Fill;
            txtOracleSql.Location = new Point(0, 0);
            txtOracleSql.Name = "txtOracleSql";
            txtOracleSql.Size = new Size(422, 529);
            txtOracleSql.TabIndex = 2;
            txtOracleSql.Text = "";
            txtOracleSql.WordWrap = false;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(7, 16);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(150, 28);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += BtnGenerate_Click;
            // 
            // FrmOrmConfigGenerator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 610);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmOrmConfigGenerator";
            Text = "ORM Config Generator for Blueriq";
            grpCheckBoxSelection.ResumeLayout(false);
            grpCheckBoxSelection.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tabSCripts.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnBrowse;
        private Label lblFilename;
        private ComboBox cboModules;
        private ComboBox cboProjects;
        private Label lblProject;
        private Label lblModule;
        private Label lblBranch;
        private Label lblBranchValue;
        private FlowLayoutPanel flowLayoutPanel1;
        private SplitContainer splitContainer1;
        private GroupBox grpCheckBoxSelection;
        private RichTextBox txtLiquibaseScript;
        private Button btnGenerate;
        private GroupBox groupBox1;
        private TabControl tabSCripts;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox txtORMScheme;
        private TextBox txtChangeSetId;
        private TextBox txtAuthor;
        private Label label2;
        private Label label1;
        private TabPage tabPage3;
        private RichTextBox txtOracleSql;
    }
}
